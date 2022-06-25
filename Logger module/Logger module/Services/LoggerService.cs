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
        /// <summary>
        /// Event of alerting the user about start of the backup copy creation process.
        /// </summary>
        public event Action ReserveCopy;

        /// <summary>
        /// Asynchronious method creates the log and passes log into WritingInFile method.
        /// </summary>
        /// <param name="task">The task number is passed so that we could see which method exactly creates the corresponding log.</param>
        /// <returns>Task.</returns>
        public async Task WriteLogsAsync(string task)
        {
            try
            {
                for (int i = 0; i <= 50; i++)
                {
                    // Awaitable call of the method that writes logs into file. (this place will release the thread so that it can call this method second time in higher hierarchy method.)
                    await Task.Run(() => WritingInFile($"Log number {i}: {DateTime.Now.ToString()}: {task}", i));

                    // In order to make methods writing almost by turns.
                    Task.Delay(100).Wait();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Method that writes log in file and creates the backup copy if we need to (according to config number).
        /// </summary>
        /// <param name="log">Text of log we must write.</param>
        /// <param name="i">Current loop (log number).</param>
        public void WritingInFile(string log, int i)
        {
            Logger logger = Logger.Instance;

            try
            {
                using (StreamWriter sw = new StreamWriter(logger.FolderPath + "\\logs.txt", true))
                {
                    sw.WriteLineAsync(log);
                }
            }
            catch (Exception)
            {
            }

            // Check whether we are supposed to create backup.
            if (CheckForBackup(logger, i))
            {
                // Invoking the message to user that we create the backup copy.
                ReserveCopy.Invoke();
            }

            // Current logs is incremented so that we could go ahead.
            logger.LogsCounter.CurrentLogs++;
        }

        /// <summary>
        /// Method check whether we are supposed to create backup.
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        /// <param name="i">Current loop or log.</param>
        /// <returns>True if we created a backup copy or false if we didnt.</returns>
        private bool CheckForBackup(Logger logger, int i)
        {
            // No need to check the first loop bcs 0 % n can be 0 and it`ll work in the way we dont want to. Main idea that we check the multiplicity of current logs.
            // If it multiple of our 'N' we had in config - then we must create the copy.
            if (logger.LogsCounter.CurrentLogs % logger.LogsCounter.CountLogsToCreateReserveCopy == 0 && logger.LogsCounter.CurrentLogs != 0)
            {
                try
                {
                    // Create the copy of current 'logs.txt' - our main log file.
                    File.Copy(logger.FolderPath + "\\logs.txt", logger.FolderPath + "\\Backups" + $"\\Backup" + $"{logger.LogsCounter.CurrentLogs / logger.LogsCounter.CountLogsToCreateReserveCopy}.txt");
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
