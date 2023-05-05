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
                int maxLength = 0;
                string printedText = "";
                Type typeInfo = obj.GetType();
                string headerName = typeInfo.Name;
        
                string separator = typeInfo
                    .GetCustomAttributes(true)
                    .OfType<HorizontalAlignmentAttribute>()
                    .FirstOrDefault() != null
                        ? " | "
                        : "\n";
                
                foreach ( var field in typeInfo.GetFields())
                {
                    string newTextLine = "";
                    NotPrintableAttribute notPrintableAttribute = field
                        .GetCustomAttributes(true)
                        .OfType<NotPrintableAttribute>()
                        .FirstOrDefault();
                    if (notPrintableAttribute == null)
                    {
                        newTextLine = $"{field.Name}: {field.GetValue(obj)}{separator}";
                        printedText += newTextLine;
                        maxLength = separator == " | "
                            ? maxLength + newTextLine.Length
                            : Math.Max(maxLength, newTextLine.Length);
                    }
                }
                
                printedText =
                    HeaderCreator(maxLength, headerName, "=") +
                    printedText + (separator == " | " ? "\n" : "") +
                    HeaderCreator(maxLength) + "\n";
                Console.WriteLine(printedText);
            }
        }

        private static string HeaderCreator(int length, string header = "", string sChar = "-")
        {
            header = header == "" ? "" : " " + header + " ";
            int separatorLength = (length - header.Length) / 2;
            separatorLength = separatorLength > 0 ? separatorLength : 1;
            string separator = String.Join("", Enumerable.Repeat(sChar, separatorLength).ToArray());
            return separator + header + separator + "\n";
        }
    }
}
