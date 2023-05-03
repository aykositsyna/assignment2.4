using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2._4
{
    public class Assignment2_4
    {
        public static void Main(string[] args)
        {
            List<object> list = new List<object>();
            list.Add(new ServiceReport());
            list.Add(new TransactionReport());
            ConsoleReporting.Parse(list);
        }
    }
}
