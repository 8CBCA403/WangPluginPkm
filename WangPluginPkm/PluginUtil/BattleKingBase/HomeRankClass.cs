using System.IO.Compression;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System;
#nullable enable
namespace WangPluginPkm.PluginUtil.BattleKingBase
{
    class HomeRankClass(RankData d)
    {
        private static readonly HttpClient Client = CreateClient();
        private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

        public string? DisplayName { get; set; } = $"第{d.rank}名" + " " + $"{d.name}";
        public RankData? Description { get; set; } = d;

        private static HttpClient CreateClient()
        {
            var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("WangPluginPkm/1.0");
            return client;
        }

        public static async Task<RankData[]?> DownloadPageAsync(string url)
        {
            try
            {
                using HttpResponseMessage response = await Client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                if (!response.IsSuccessStatusCode)
                    return null;

                await using Stream responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<RankData[]>(responseStream, JsonOptions);
            }
            catch (Exception ex) when (ex is HttpRequestException or IOException or JsonException)
            {
                return null;
            }
        }
    }   
            
           
     class RankData
    {
        public int rank { get; set; }
        public double rating_value { get; set; }
        public string? icon { get; set; }
        public string? name { get; set; }
        public string? lng { get; set; }
       
    }
    

}
