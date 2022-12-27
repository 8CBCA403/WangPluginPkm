using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.IO;
namespace WangPluginPkm
{
    public static partial class Utils
    {
        private static readonly Assembly thisAssembly = typeof(Utils).GetTypeInfo().Assembly;
        private static readonly Dictionary<string, string> resourceNameMap = BuildLookup(thisAssembly.GetManifestResourceNames());

        private static Dictionary<string, string> BuildLookup(IReadOnlyCollection<string> manifestNames)
        {
            var result = new Dictionary<string, string>(manifestNames.Count);
            foreach (var resName in manifestNames)
            {
                var fileName = GetFileName(resName);
                if (!result.ContainsKey(fileName))
                    result.Add(fileName, resName);
            }
            return result;
        }

        private static string GetFileName(string resName)
        {
            var period = resName.LastIndexOf('.', resName.Length - 5);
            var start = period + 1;
            System.Diagnostics.Debug.Assert(start != 0);

            // text file fetch excludesa.Add(".txt" (mixed case...); other extensions are used (all lowercase).
            return resName.EndsWith(".txt", StringComparison.Ordinal) ? resName[start..^4].ToLowerInvariant() : resName[start..];
        }

        public static byte[] GetBinaryResource(string name)
        {
            if (!resourceNameMap.TryGetValue(name, out var resName))
                return Array.Empty<byte>();

            using var resource = thisAssembly.GetManifestResourceStream(resName);
            if (resource is null)
                return Array.Empty<byte>();

            var buffer = new byte[resource.Length];
            _ = resource.Read(buffer, 0, (int)resource.Length);
            return buffer;
        }
#nullable enable
        public static string? GetStringResource(string name)
        {
            if (!resourceNameMap.TryGetValue(name.ToLowerInvariant(), out var resourceName))
            {
                MessageBox.Show($"resourceName: {resourceName}");
                MessageBox.Show($"name: {name}");
                return null;
            }

            using var resource = thisAssembly.GetManifestResourceStream(resourceName);
            if (resource is null)
            {
                return null;
            }
            using var reader = new StreamReader(resource);
            return reader.ReadToEnd();
        }
    }
}
