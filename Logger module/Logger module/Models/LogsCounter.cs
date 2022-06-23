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
        public int CurrentLogs { get; set; }
        public int CountLogsToCreateReserveCopy { get;  init; }
    }
}
