using System.IO.Compression;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
#nullable enable
namespace WangPluginPkm.PluginUtil.BattleKingBase
{
     class HomeRankClass
     {
        public string? DisplayName { get; set; }
        public RankData? Description { get; set; } = null;

        public HomeRankClass(RankData d) 
        { 
            Description = d;
            DisplayName = $"第{d.Rank}名" + " " + $"{d.Name}";
        }
        public static async Task<RankData[]?> DownloadPageAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
                    client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br");
                    client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-CN,zh;q=0.9");
                    client.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue { NoCache = true };
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var contentStream = await response.Content.ReadAsStreamAsync();
                        string responseBody;
                        using (var decompressionStream = new GZipStream(contentStream, CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(decompressionStream))
                            {
                                responseBody = reader.ReadToEnd();
                                var jsonOptions = new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true,
                                };
                                var dataArray = JsonSerializer.Deserialize<RankData[]>(responseBody, jsonOptions);
                                if (dataArray != null)
                                {
                                    return dataArray;
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch
            {
                return null;
            }
        }
    }
     class RankData
    {
        public int Rank { get; set; }
        public double rating_value { get; set; }
        public string? Icon { get; set; }
        public string? Name { get; set; }
        public string? Lng { get; set; }
       
    }

}
