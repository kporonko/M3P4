using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger_module
{
    internal class Starter
    {
        public static async void Start()
        {
            BackupConfig backupConfig = new BackupConfig();
            var loggerConfig = backupConfig.Deserialization();
            Logger logger = Logger.Instance;
            logger.LogsCounter = loggerConfig;

            LoggerService loggerService = new LoggerService();
            await loggerService.WriteLogsAsync();
            await loggerService.WriteLogsAsync();
        }
    }
}
