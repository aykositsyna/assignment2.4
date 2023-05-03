using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2._4
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class NotPrintableAttribute : Attribute
    {
    
    }
}
