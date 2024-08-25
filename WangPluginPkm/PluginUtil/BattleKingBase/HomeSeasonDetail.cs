using iText.IO.Font;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;

#nullable enable
namespace WangPluginPkm.PluginUtil.BattleKingBase
{
     class HomeSeasonDetail
    {
        public string? DisplayName { get; set; }
        public SeasonDetail? Description { get; set; } = null;
        public string? Cid { get; set; }
        public int? Rule {  get; set; }
        public int? Rst{ get; set; }
        public long? Ts1 { get; set; }

        public HomeSeasonDetail(SeasonDetail d)
        {
            Description = d;
            DisplayName = $"{d.name}";
            Cid=$"{d.cId}";
            Rule = d.rule;
            Rst = d.rst;
            Ts1 = d.ts1;
        }
        public static async Task<List<SeasonDetail>?> DownloadPageAsync(string url)
            {
            var config = PluginConfig.LoadConfig();
            try
                {
                    var client = new RestClient();
                    var request = new RestRequest("https://api.battle.pokemon-home.com/tt/cbd/competition/rankmatch/list", Method.Post); // 直接使用字符串作为请求方法
                    request.AddHeader("Host", "api.battle.pokemon-home.com");
                    request.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
                    request.AddHeader("Langcode", "9");
                    request.AddHeader("Authorization", config.HomeAuthorization);
                    request.AddHeader("Sec-Fetch-Site", "same-site");
                    request.AddHeader("Sec-Fetch-Mode", "cors");
                    request.AddHeader("countrycode", "302");
                    request.AddHeader("Accept-Language", "zh-CN,zh-Hans;q=0.9");
                    request.AddHeader("Origin", "https://resource.pokemon-home.com");
                    request.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 17_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148");
                    request.AddHeader("Referer", "https://resource.pokemon-home.com/");
                    request.AddHeader("Connection", "keep-alive");
                    request.AddHeader("Sec-Fetch-Dest", "empty");
                    request.AddHeader("Cookie", config.HomeCookie);
                    request.AddHeader("Content-Type", "application/json");
                    var body = @"{""soft"":""Sc""}";
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    RestResponse response = await client.ExecuteAsync(request);
                    // 你可以在这里处理返回的数据，比如解析JSON或检查状态码
                    if (response.IsSuccessful)
                    {
                        if (response.Content == null)
                        {
                            return null;
                        }
                        string responseBody = response.Content;
                    var seasonDetailsList = new List<SeasonDetail>();

                    try
                    {
                        JsonNode jsonObject = JsonNode.Parse(responseBody);

                        // 遍历list对象并提取SeasonDetail
                        var listNode = jsonObject["list"];
                        foreach (var seasonGroup in listNode.AsObject())
                        {
                            foreach (var season in seasonGroup.Value.AsObject())
                            {
                                SeasonDetail seasonDetail = season.Value.Deserialize<SeasonDetail>();
                                if (seasonDetail != null && !seasonDetailsList.Any(s => s.cId == seasonDetail.cId))
                                {
                                    seasonDetailsList.Add(seasonDetail);
                                }
                            }
                        }
                        return seasonDetailsList;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("读取或反序列化JSON文件时发生错误: " + ex.Message);
                    }

                }

                    else
                    {
                        MessageBox.Show($"{response.StatusCode}\n{response.StatusDescription}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;


            }
     }
        class SeasonDetail
        {
            public string? cId { get; set; }
            public string? name { get; set; }
            public string? start { get; set; }
            public string? end { get; set; }
            public int? cnt { get; set; }
            public int? rankCnt { get; set; }
            public int? rule { get; set; }
            public int? season { get; set; }
            public int? rst { get; set; }
            public long? ts1 { get; set; }
            public long? ts2 { get; set; }
        }
       
    
}
