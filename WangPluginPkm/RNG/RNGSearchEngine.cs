using PKHeX.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WangPluginPkm.RNG.Methods;

namespace WangPluginPkm.RNG
{
    internal class SearchResult
    {
        public bool Found { get; set; }
        public PKM FoundPKM { get; set; }
        public string SeedHex { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public double SeedsPerSecond { get; set; }
    }

    internal static class RNGSearchEngine
    {
        public static Task<SearchResult> RunSearchAsync(
        RNGService rngService,
        CheckRules rules,
        IPKMView editor,
        ISaveFileProvider sav,
        uint initSeed32,
        ulong initSeed64,
        List<uint> seedList,
        bool zeroSeedCheck,
        bool teamLockEnabled,
        bool checkFrame,
        Func<string, Task> updateSeedDisplayAsync,
        CancellationToken token,
        int updateIntervalMs = 100,
        int workers = 0,
        bool traverseMode = false,
        string traverseOutputPath = null)
        {
            if (rngService is null) throw new ArgumentNullException(nameof(rngService));
            if (rules is null) throw new ArgumentNullException(nameof(rules));
            if (editor is null) throw new ArgumentNullException(nameof(editor));

            if (workers <= 0)
                workers = Environment.ProcessorCount;

            // If single worker requested, keep earlier simple loop to avoid overhead
            if (workers == 1)
            {
                return Task.Run(async () =>
                {
                    var isLumiose = rules.Method == MethodType.Lumiose;
                    uint seed = initSeed32;
                    ulong seed64 = initSeed64;
                    int i = 0, j = 0;

                    var cloneSeed = seed;
                    var pk = editor.Data; // reference
                    var p = editor.Data.Clone(); // snapshot

                    string CurrentHex() => isLumiose ? seed64.ToString("X16") : seed.ToString("X8");

                    void Advance()
                    {
                        if (!isLumiose)
                            seed = traverseMode ? seed + 1u : (zeroSeedCheck ? seed + 1u : rngService.NextSeed(seed));
                        else
                            seed64 = traverseMode ? seed64 + 1ul : (zeroSeedCheck ? seed64 + 1ul : rngService.NextSeed(seed64));
                    }

                    var sw = Stopwatch.StartNew();
                    long count = 0;
                    long lastReportMs = 0;

                    StreamWriter writer = null;
                    object fileLock = new();
                    if (traverseMode && !string.IsNullOrEmpty(traverseOutputPath))
                    {
                        try
                        {
                            writer = new StreamWriter(new FileStream(traverseOutputPath, FileMode.Create, FileAccess.Write, FileShare.Read));
                        }
                        catch
                        {
                            writer = null;
                        }
                    }

                    try
                    {
                        while (true)
                        {
                            token.ThrowIfCancellationRequested();

                            // preset seed list
                            if (seedList != null && seedList.Count != 0 && i < seedList.Count)
                            {
                                if (isLumiose)
                                    seed64 = seedList[i];
                                else
                                    seed = seedList[i];
                                i++;
                            }

                            // team lock
                            if (teamLockEnabled && !LockCheck.ChooseLock(pk.Species, p, ref seed))
                            {
                                cloneSeed = rngService.NextSeed(cloneSeed);
                                seed = cloneSeed;
                                await Task.Yield();
                                continue;
                            }

                            var ok = isLumiose ? rngService.GenPkm(ref pk, seed64, p.Form) : rngService.GenPkm(ref pk, seed, p.Form);

                            count++;

                            if (ok)
                            {
                                if (checkFrame)
                                {
                                    var la = new LegalityAnalysis(pk);
                                    if (!la.Info.FrameMatches)
                                    {
                                        if (seedList == null || seedList.Count == 0)
                                        {
                                            if (!isLumiose)
                                                seed = traverseMode ? seed + 1u : (zeroSeedCheck ? seed + 1u : Util.Rand32());
                                            else
                                                seed64 = traverseMode ? seed64 + 1ul : (zeroSeedCheck ? seed64 + 1ul : (ulong)Random.Shared.NextInt64(long.MinValue, long.MaxValue));
                                        }

                                        if (seedList != null && seedList.Count != 0 && j < seedList.Count)
                                        {
                                            if (isLumiose)
                                                seed64 = seedList[j];
                                            else
                                                seed = seedList[j];
                                            j++;
                                        }

                                        if (j >= (seedList?.Count ?? 0) && seedList != null && seedList.Count != 0)
                                        {
                                            return new SearchResult { Found = false, Reason = "NoMatch", SeedsPerSecond = count / Math.Max(1.0, sw.Elapsed.TotalSeconds) };
                                        }

                                        await Task.Yield();
                                        continue;
                                    }
                                }

                                // If traverse mode and this is a valid match, write to file
                                if (traverseMode && writer != null)
                                {
                                    try
                                    {
                                        lock (fileLock)
                                        {
                                            var seedHex = isLumiose ? seed64.ToString("X16") : seed.ToString("X8");
                                            writer.WriteLine(seedHex);
                                        }
                                    }
                                    catch { }
                                }

                                // Found valid PKM
                                return new SearchResult { Found = true, FoundPKM = pk, SeedHex = CurrentHex(), SeedsPerSecond = count / Math.Max(1.0, sw.Elapsed.TotalSeconds) };
                            }

                            Advance();

                            // Update UI at most every updateIntervalMs milliseconds (updateIntervalMs <=0 means never update until finish)
                            if (updateIntervalMs > 0 && updateSeedDisplayAsync != null)
                            {
                                var elapsed = sw.ElapsedMilliseconds;
                                if (elapsed - lastReportMs >= updateIntervalMs)
                                {
                                    lastReportMs = elapsed;
                                    var rate = count / Math.Max(1.0, sw.Elapsed.TotalSeconds);
                                    try
                                    {
                                        var seedHex = isLumiose ? seed64.ToString("X16") : seed.ToString("X8");
                                        await updateSeedDisplayAsync($"{seedHex}|{elapsed}|{rate:F0}").ConfigureAwait(false);
                                    }
                                    catch { }
                                }
                            }

                            await Task.Yield();
                        }
                    }
                    finally
                    {
                        if (writer != null)
                        {
                            try { writer.Flush(); writer.Dispose(); } catch { }
                        }
                    }
                }, token);
            }

            // Parallel workers implementation
            return Task.Run(async () =>
            {
                var isLumiose = rules.Method == MethodType.Lumiose;

                var sw = Stopwatch.StartNew();
                long totalCount = 0;
                long lastReportMs = 0;

                var tcs = new TaskCompletionSource<SearchResult>();
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(token);
                var localToken = cts.Token;

                ConcurrentQueue<uint> queue = null;
                if (seedList != null && seedList.Count > 0)
                {
                    queue = new ConcurrentQueue<uint>(seedList);
                }

                StreamWriter writer = null;
                object fileLock = new();
                if (traverseMode && !string.IsNullOrEmpty(traverseOutputPath))
                {
                    try
                    {
                        writer = new StreamWriter(new FileStream(traverseOutputPath, FileMode.Create, FileAccess.Write, FileShare.Read));
                    }
                    catch
                    {
                        writer = null;
                    }
                }

                var tasks = new List<Task>();
                for (int w = 0; w < workers; w++)
                {
                    int workerId = w;
                    tasks.Add(Task.Run(async () =>
         {
                try
                {
                 // Per-thread clones to avoid allocations each iteration
                    var pk = editor.Data.Clone();
                    var p = editor.Data.Clone();

                 // compute local start
                    ulong local64 = initSeed64 + (ulong)workerId;
                    uint local = initSeed32 + (uint)workerId;


                 // If using seedList, we'll dequeue; else iterate sequentially
                    while (!localToken.IsCancellationRequested && !tcs.Task.IsCompleted)
                    {
                        if (queue != null)
                        {
                            if (!queue.TryDequeue(out var qseed))
                            {
                             // empty
                                break;
                            }
                            if (!isLumiose)
                                local = qseed;
                            else
                                local64 = qseed;
                        }

                     // team lock check uses local seed (32-bit) - for lumiose team lock likely not relevant
                        if (!isLumiose && teamLockEnabled && !LockCheck.ChooseLock(pk.Species, p, ref local))
                        {
                            local = rngService.NextSeed(local);
                            Interlocked.Increment(ref totalCount);
                            continue;
                        }

                        var ok = isLumiose ? rngService.GenPkm(ref pk, local64, p.Form) : rngService.GenPkm(ref pk, local, p.Form);
                        Interlocked.Increment(ref totalCount);

                        if (ok)
                        {
                            if (checkFrame)
                            {
                                var la = new LegalityAnalysis(pk);
                                if (!la.Info.FrameMatches)
                                {
                                 // bad frame: continue
                                    if (queue == null)
                                    {
                                        if (!isLumiose)
                                            local = traverseMode ? local + (uint)workers : (zeroSeedCheck ? local + (uint)workers : rngService.NextSeed(local));
                                        else
                                            local64 = traverseMode ? local64 + (ulong)workers : (zeroSeedCheck ? local64 + (ulong)workers : rngService.NextSeed(local64));
                                    }
                                    else
                                    {
                                     // continue to next queued seed
                                    }
                                    continue;
                                }
                            }

                         // If traverse mode and this is a valid match, write to file
                            if (traverseMode && writer != null)
                            {
                                try
                                {
                                    lock (fileLock)
                                    {
                                        var seedHex = isLumiose ? local64.ToString("X16") : local.ToString("X8");
                                        writer.WriteLine(seedHex);
                                    }
                                }
                                catch { }
                            }

                         // We found result; attempt set tcs and cancel others
                            var result = new SearchResult { Found = true, FoundPKM = pk, SeedHex = (isLumiose ? local64.ToString("X16") : local.ToString("X8")), SeedsPerSecond = totalCount / Math.Max(1.0, sw.Elapsed.TotalSeconds) };
                            if (tcs.TrySetResult(result))
                            {
                                cts.Cancel();
                                break;
                            }
                        }

                     // advance local seed for next iteration
                        if (queue == null)
                        {
                            if (!isLumiose)
                            {
                                if (traverseMode)
                                {
                                    if (local + (uint)workers < local) // overflow
                                        break;
                                    local = local + (uint)workers;
                                    if (local == uint.MaxValue && local + (uint)workers < local) break; // extra safety
                                }
                                else
                                    local = zeroSeedCheck ? local + (uint)workers : rngService.NextSeed(local);
                            }
                            else
                            {
                                if (traverseMode)
                                {
                                    if (local64 + (ulong)workers < local64) // overflow
                                        break;
                                    local64 = local64 + (ulong)workers;
                                }
                                else
                                    local64 = zeroSeedCheck ? local64 + (ulong)workers : rngService.NextSeed(local64);
                            }
                        }

                     // UI rate-limited update from any worker
                        if (updateIntervalMs > 0 && updateSeedDisplayAsync != null)
                        {
                            var elapsed = sw.ElapsedMilliseconds;
                            if (elapsed - lastReportMs >= updateIntervalMs)
                            {
                                lastReportMs = elapsed;
                                var rate = totalCount / Math.Max(1.0, sw.Elapsed.TotalSeconds);
                                try { var seedHex = isLumiose ? local64.ToString("X16") : local.ToString("X8"); await updateSeedDisplayAsync($"{seedHex}|{elapsed}|{rate:F0}").ConfigureAwait(false); } catch { }
                            }
                        }

                     // be cooperative
                        await Task.Yield();
                    }
                }
                catch (OperationCanceledException) { }
                catch { }
            }, localToken));
                }

                // wait for either completion or cancellation
                var completed = await Task.WhenAny(Task.WhenAll(tasks), tcs.Task).ConfigureAwait(false);

                if (tcs.Task.IsCompleted)
                {
                    // close writer
                    if (writer != null)
                    {
                        try { lock (fileLock) { writer.Flush(); writer.Dispose(); } } catch { }
                    }
                    return await tcs.Task.ConfigureAwait(false);
                }

                // close writer
                if (writer != null)
                {
                    try { lock (fileLock) { writer.Flush(); writer.Dispose(); } } catch { }
                }

                // no result found
                return new SearchResult { Found = false, Reason = "Exhausted", SeedsPerSecond = totalCount / Math.Max(1.0, sw.Elapsed.TotalSeconds) };

            }, token);
        }
    }
}
