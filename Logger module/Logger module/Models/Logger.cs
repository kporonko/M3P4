using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger_module
{
    /// <summary>
    /// Singletone pattern is realized.
    /// </summary>
    public sealed class Logger
    {
        private static Logger instance = null;

        private Logger()
        {
        }

        public ILogsCounter LogsCounter { get; set; }

        public string FolderPath { get; set; } = "D:\\Study\\alevel";
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }
    }
}
