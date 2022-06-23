using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger_module;
using Logger_module.Models;
using Newtonsoft.Json;

namespace Logger_module
{
    internal class BackupConfig
    {
        public void Serialization()
        {
            var json = JsonConvert.SerializeObject(new LogsCounter());
            File.WriteAllText("config.json", json);
        }

        public LogsCounter Deserialization()
        {
            string startupPath = "D:\\Учеба\\A-LEVEL\\.NET C#\\M3P4HW\\Logger module\\Logger module\\config.json";
            var configFile = File.ReadAllText(startupPath, Encoding.UTF8);
            var config = JsonConvert.DeserializeObject<LogsCounter>(configFile);
            return config;
        }
    }
}
