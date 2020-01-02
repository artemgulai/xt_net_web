using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    public class NumberValidator
    {
        public static bool IsUsusalNotation(string input)
        {
            Regex regex = new Regex(@"^-?\d+(\.\d+)?$");
            return regex.IsMatch(input);
        }

        public static bool IsScientificNotation(string input)
        {
            Regex regex = new Regex(@"^-?[1-9](\.[1-9]|\.\d+[1-9])?e-?[1-9](\d+)?$");
            return regex.IsMatch(input);
        }

        public static void Demo()
        {
            Console.WriteLine("Enter the number.");
            string number = Console.ReadLine();
            if (IsUsusalNotation(number))
            {
                Console.WriteLine("This is a number in the usual notation.");
            }
            else if (IsScientificNotation(number))
            {
                Console.WriteLine("This is a number in the normalized scientific notation.");
            }
            else
            {
                Console.WriteLine("This is not a number in either the usual or the normalized scientific notation.");
            }
        }
    }
}
