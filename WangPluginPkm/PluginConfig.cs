﻿using System.IO;
using System.Text.Json;

namespace WangPluginPkm
{
    public class PluginConfig
    {
        public bool OpenSound { get; set; } = false;
        public string GoogleapiKey { get; set; } = "";
        public string GoogleApplicationName { get; set; } = "";
        // 添加其他配置项
        public void SaveConfig(PluginConfig config)
        {
            string configJson = JsonSerializer.Serialize(config);
            File.WriteAllText("超王配置文件.json", configJson);
        }

        public static PluginConfig LoadConfig()
        {
            if (File.Exists("超王配置文件.json"))
            {
                string configJson = File.ReadAllText("超王配置文件.json");
                return JsonSerializer.Deserialize<PluginConfig>(configJson);
            }
            else
            {
                // 如果配置文件不存在，可以返回一个默认配置
                return new PluginConfig();
            }
        }
    }
}
