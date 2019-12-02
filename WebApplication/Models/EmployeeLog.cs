using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class EmployeeLog
    {
        public int AccessLogID { get; set; }
        public int AccessLocationID { get; set; }
        public string StationID { get; set; }
        public DateTime AccessDate { get; set; }
        public int IDCardNumber { get; set; }
        public string DeclineReason { get; set; }
    }
}
