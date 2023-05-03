using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2._4
{
    public static class ConsoleReporting
    {
        public static void Parse(List<Object> objects) 
        {
            foreach (Object obj in objects)
            {
                Type typeInfo = obj.GetType();
                Console.WriteLine(typeInfo.Name);


                string separator = typeInfo.GetCustomAttributes(true).OfType<HorizontalAlignmentAttribute>().FirstOrDefault() != null
                    ? " | "
                    : "\n";
                
                foreach ( var field in typeInfo.GetFields())
                {
                    NotPrintableAttribute notPrintableAttribute =
                        field.GetCustomAttributes(true).OfType<NotPrintableAttribute>().FirstOrDefault();
                    if (notPrintableAttribute == null)
                    {
                        Console.Write($"{field.Name}: {field.GetValue(obj)}{separator}");
                    }
                }
            }
        }
    }
}
