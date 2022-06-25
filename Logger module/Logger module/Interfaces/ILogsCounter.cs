using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger_module
{
    public interface ILogsCounter
    {
        public int CurrentLogs { get; set; }

        public int CountLogsToCreateReserveCopy { get; init; }
    }
}
