using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class CSharpStrings
    {
        public static void AverageStringLength_1_11()
        {
            Console.WriteLine("Enter a text line");
            string textLine = Console.ReadLine();

            // set containing all symbols of entered line
            HashSet<char> alphabet = textLine.ToHashSet();
            
            HashSet<char> separators = new HashSet<char>();
            HashSet<char> punctuation = new HashSet<char>();
            
            foreach (char c in alphabet)
            {
                if (Char.IsSeparator(c))
                {
                    separators.Add(c);
                }
                else if (Char.IsPunctuation(c))
                {
                    punctuation.Add(c);
                }
            }

            string[] words = textLine.Split(separators.ToArray());

            int wordsLength = 0;
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim(punctuation.ToArray());
                wordsLength += words[i].Length;
            }

            Console.WriteLine("Average word length is {0, 0:N2}", (double)wordsLength / words.Length);
        }

        public static void CharDoubler_1_12()
        {
            Console.WriteLine("Enter the first line");
            string line1 = Console.ReadLine();
            Console.WriteLine("Enter the second line");
            string line2 = Console.ReadLine();

            StringBuilder doubledLine = new StringBuilder();
            foreach(char c in line1)
            {
                doubledLine.Append(c);
                // this line of code is for a case when punctuation chars should not be doubled
                if ((line2.Contains(Char.ToUpper(c)) || line2.Contains(Char.ToLower(c))) && !Char.IsPunctuation(c) && !Char.IsSeparator(c))
                // this line of code is for a case when punctuation chars should be doubled
                //if ((line2.Contains(Char.ToUpper(c)) || line2.Contains(Char.ToLower(c))) && !Char.IsSeparator(c))
                {
                    doubledLine.Append(c);
                }
            }

            Console.WriteLine(doubledLine);
        }
    }
}
