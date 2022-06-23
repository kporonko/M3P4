using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger_module
{
    internal class Starter
    {
        public static void Start()
        {
            BackupConfig backupConfig = new BackupConfig();
            var loggerConfig = backupConfig.Deserialization();
            Logger logger = Logger.Instance;
            logger.LogsCounter = loggerConfig;
            LoggerService loggerService = new LoggerService();

            // According to task (i mean exercise) we must subscribe to the logger event in starter class. So here it is.
            loggerService.ReserveCopy += () => Console.WriteLine("Creating copy");

            // Calling the main asynchronous methods (they will run together because after the await of the first method call we can back to this place by released thread).
            Task.Run(() => loggerService.WriteLogsAsync("Task1"));
            Thread.Sleep(100);
            Task.Run(() => loggerService.WriteLogsAsync("Task2"));
        }
    }
}
