using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2._4
{
    [HorizontalAlignment]
    internal class TransactionReport
    {
        public string SenderID = "AAA 2313";
        [NotPrintable]
        public string RecipientID = "BGH 123HT";
        public int sum = 3230;
        public DateTime TransactionTime = DateTime.Now;

    }
}
