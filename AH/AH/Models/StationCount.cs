using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AH.Models
{
    public class StationCount
    {
        public string MyStation { get; set; }
        public int MyCount { get; set; }
        public int StationID { get; set; }
        public int TrainID { get; set; }
        public int LastBackPeriod { get; set; }
        public DateTime Now { get; set; }




    }
}