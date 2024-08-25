using System.IO.Compression;
using System.IO;
using System.Net.Http;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text;
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
            DisplayName = $"第{d.rank}名" + " " + $"{d.name}";
        }
        public static async Task<RankData[]?> DownloadPageAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // 设置请求头
                    client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
                    client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                    client.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9");
                    client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Mobile Safari/537.36");
                    // 发送GET请求
                    HttpResponseMessage response = await client.GetAsync(url);

                    // 读取并处理响应
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                        using (GZipStream decompressionStream = new GZipStream(responseStream, CompressionMode.Decompress))
                        using (StreamReader reader = new StreamReader(decompressionStream))
                        {
                            responseBody = reader.ReadToEnd();
                            var jsonOptions = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true,
                            };
                            var dataArray = System.Text.Json.JsonSerializer.Deserialize<RankData[]>(responseBody, jsonOptions);
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
                    else
                    {
                       return null;
                    }
                }
               
            }
            catch (Exception ex)
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
