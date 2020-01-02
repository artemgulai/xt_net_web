using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    public class HtmlReplacer
    {
        public static string ReplaceTags(string input)
        {
            Regex regex = new Regex("<.+?>");
            return regex.Replace(input,"_");
        }

        public static void Demo()
        {
            Console.WriteLine("Enter the text.");
            string text = Console.ReadLine();

            Console.WriteLine("Text without tags:");
            Console.WriteLine(ReplaceTags(text));
        }
    }
}
