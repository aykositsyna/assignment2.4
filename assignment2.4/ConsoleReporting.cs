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
            int maxLength = 0;
            foreach (Object obj in objects)
            {
                Type typeInfo = obj.GetType();
                maxLength = Math.Max(typeInfo.Name.Length, maxLength);
                string headerName = typeInfo.Name;
                //Console.WriteLine(HeaderCreator(maxLength, headerName, "="));
                Console.Write("=======");
                Console.Write(typeInfo.Name);
                Console.WriteLine("=======");


                string separator = typeInfo
                    .GetCustomAttributes(true)
                    .OfType<HorizontalAlignmentAttribute>()
                    .FirstOrDefault() != null
                        ? " | "
                        : "\n";
                
                foreach ( var field in typeInfo.GetFields())
                {
                    NotPrintableAttribute notPrintableAttribute = field
                        .GetCustomAttributes(true)
                        .OfType<NotPrintableAttribute>()
                        .FirstOrDefault();
                    if (notPrintableAttribute == null)
                    {
                        Console.Write($"{field.Name}: {field.GetValue(obj)}{separator}");
                    }
                }
                headerName = "";
                Console.WriteLine();
                Console.WriteLine(HeaderCreator(maxLength, headerName));
            }
        }

        private static string HeaderCreator(int length, string header, string sChar = "-")
        {
            header = header == "" ? "" : " " + header + " ";
            int separatorLength = (length - header.Length) / 2;
            string separator = String.Join("", Enumerable.Repeat(sChar, separatorLength).ToArray());
            return separator + header + separator + "\n";
        }
    }
}
