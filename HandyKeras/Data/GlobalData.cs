using System.IO;
using Newtonsoft.Json;

namespace HandyKeras.Data
{
    internal class GlobalData
    {
        public static AppConfig AppConfig { get; set; }

        public static UserConfig UserConfig { get; set; }

        public static void Init()
        {
            if (File.Exists(AppConfig.SavePath))
            {
                try
                {
                    var json = File.ReadAllText(AppConfig.SavePath);
                    AppConfig = JsonConvert.DeserializeObject<AppConfig>(json);
                }
                catch
                {
                    AppConfig = new AppConfig();
                }
            }
            else
            {
                AppConfig = new AppConfig();
            }
        }

        public static void Save()
        {
            var json = JsonConvert.SerializeObject(AppConfig);
            File.WriteAllText(AppConfig.SavePath, json);
        }
    }
}