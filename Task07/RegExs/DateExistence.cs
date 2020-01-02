using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    public static class DateExistence
    {
        public static bool IfDateExists(string input, out int numberOfDates)
        {
            Regex regex = new Regex(@"\b([0-2][0-9]|3[01])-(1[012]|0[1-9])-\d{4}\b");
            Match match = regex.Match(input);

            numberOfDates = 0;
            while(match.Success)
            {
                if (DateTime.TryParse(match.Value,out DateTime date))
                {
                    numberOfDates++;
                }
                match = match.NextMatch();
            }

            if (numberOfDates > 0) return true;
            return false;
        }

        public static void Demo()
        {
            Console.WriteLine("Enter text string.");
            string text = Console.ReadLine();
            if (IfDateExists(text, out int numberOfDates))
            {
                Console.WriteLine($@"The text{Environment.NewLine}""{text}""{Environment.NewLine}contains {numberOfDates} dates.");
            }
            else
            {
                Console.WriteLine($@"The text{Environment.NewLine}""{text}""{Environment.NewLine}does not contain dates.");
            }
        }
    }
}
