using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    class TimeCounter
    {
        public static int Count(string input)
        {
            Regex regex = new Regex(@"\b([01]?\d|2[0-3]):[0-5]\d\b");
            var matches = regex.Matches(input);
            return matches.Count;
        }

        public static void Demo()
        {
            Console.WriteLine("Enter text.");
            string text = Console.ReadLine();
            Console.WriteLine("The text");
            Console.WriteLine(text);
            Console.WriteLine($"contains {Count(text)} times.");
        }
    }
}
