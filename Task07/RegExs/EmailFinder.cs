using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExs
{
    public class EmailFinder
    {
        public static void FindEmails(string input)
        {
            Regex regex = new Regex(@"\b[\w.]+@[a-z.]+\b");
            MatchCollection matches = regex.Matches(input);
            if (matches.Count == 0)
            {
                Console.WriteLine("There is no emails in the text.");
            }
            else
            {
                Console.WriteLine("The following emails are found:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            Console.ReadLine();
        }
    }
}
