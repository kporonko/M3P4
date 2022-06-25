using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger_module.Models
{
    [Serializable]
    internal class LogsCounter : ILogsCounter
    {
        /// <summary>
        /// Gets or sets count of currently written logs.
        /// </summary>
        /// <value>
        /// Current count of logs.
        /// </value>
        public int CurrentLogs { get; set; }

        /// <summary>
        /// Gets the fixed number of logs that mean interval between backup creation.
        /// </summary>
        /// <value>
        /// Logs that mean interval between backup creation.
        /// </value>
        public int CountLogsToCreateReserveCopy { get;  init; }
    }
}
