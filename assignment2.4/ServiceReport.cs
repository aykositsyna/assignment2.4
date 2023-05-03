using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2._4
{
    internal class ServiceReport
    {
        public string CustomerID = "111A 111";
        [NotPrintable]
        public int ExecutorID = 33987036;
        public int Cost = 76563;
        public string ServiceDescription = "Feeding a cat";
        public DateTime DealTime = DateTime.Now;
    }
}
