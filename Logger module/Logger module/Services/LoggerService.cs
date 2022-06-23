using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger_module
{
    internal class LoggerService
    {
        public LoggerService()
        {
            ReserveCopy = CreateNewBackup;
        }

        public event Action<int> ReserveCopy;

        public async Task WriteLogsAsync()
        {
            try
            {
                Logger logger = Logger.Instance;

                await Task.Run(async () =>
                {
                    for (int i = 0; i <= 50; i++)
                    {
                        CheckForBackup(logger, i);
                        using (StreamWriter sw = new StreamWriter(logger.FolderPath + "\\logs.txt", true))
                        {
                            await sw.WriteLineAsync($"Log {i} {DateTime.Now.ToString()}: Log number {i}");
                            Task.Delay(100).Wait();
                            sw.Dispose();
                            sw.Close();
                        }

                        logger.LogsCounter.CurrentLogs++;
                    }
                });
            }
            catch (Exception)
            {
            }
        }

        public void CheckForBackup(Logger logger, int i)
        {
            if (logger.LogsCounter.CurrentLogs % logger.LogsCounter.CountLogsToCreateReserveCopy == 0 && logger.LogsCounter.CurrentLogs != 0)
            {
                ReserveCopy.Invoke(i);
            }
        }

        public void CreateNewBackup(int version)
        {
            Logger logger = Logger.Instance;

            Task.Run(() =>
            {
                File.Copy(logger.FolderPath + "\\logs.txt", logger.FolderPath + "\\Backups" + $"\\Backup" + $"{logger.LogsCounter.CurrentLogs / logger.LogsCounter.CountLogsToCreateReserveCopy}.txt");
            });
        }
    }
}
