using System.IO;
using System;
using System.Text.Json;

namespace WangPluginPkm
{
    public class PluginConfig
    {
        private const string ConfigFileName = "超王配置文件.json";
        private static string ConfigPath => Path.Combine(AppContext.BaseDirectory, ConfigFileName);

        public bool OpenSound { get; set; } = false;
        public string GoogleapiKey { get; set; } = "";
        public string GoogleApplicationName { get; set; } = "";

        public string HomeAuthorization { get; set; } = "";
        public string HomeCookie { get; set; } = "";

        public string PokemonPicUrl { get; set; } = "";

        // 添加其他配置项
        public static void SaveConfig(PluginConfig config)
        {
            ArgumentNullException.ThrowIfNull(config);
            string configJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigPath, configJson);
        }

        public static PluginConfig LoadConfig()
        {
            string legacyPath = Path.GetFullPath(ConfigFileName);
            string path = File.Exists(ConfigPath) ? ConfigPath : legacyPath;
            if (!File.Exists(path))
                return new PluginConfig();

            try
            {
                string configJson = File.ReadAllText(path);
                return JsonSerializer.Deserialize<PluginConfig>(configJson) ?? new PluginConfig();
            }
            catch (Exception ex) when (ex is JsonException or IOException or UnauthorizedAccessException)
            {
                return new PluginConfig();
            }
        }
    }
}
