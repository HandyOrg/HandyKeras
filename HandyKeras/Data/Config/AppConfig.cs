using System;

namespace HandyKeras.Data
{
    internal class AppConfig
    {
        public static string SavePath = $"{AppDomain.CurrentDomain.BaseDirectory}Config/AppConfig.json";

        public bool KerasInstalled { get; set; }
    }
}