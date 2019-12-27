using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            string text = Console.ReadLine();
            if (NumberValidator.IsUsusalNotation(text))
            {
                Console.WriteLine("This is a number in usual notation.");
            }
            else if (NumberValidator.IsScientificNotation(text))
            {
                Console.WriteLine("This is a number in scientific notation.");
            }
            else
            {
                Console.WriteLine("This is not a number.");
            }
            Console.ReadLine();
        }
    }
}
