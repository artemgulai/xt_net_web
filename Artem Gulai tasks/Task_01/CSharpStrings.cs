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
            int emptyWordsCorrection = 0;
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim(punctuation.ToArray());
                words[i] = words[i].Trim(separators.ToArray());
                wordsLength += words[i].Length;
                if (words[i].Length == 0) emptyWordsCorrection--;
            }

            Console.WriteLine("Average word length is {0, 0:N2}", (double)wordsLength / (words.Length + emptyWordsCorrection));
        }

        public static void CharDoubler_1_12()
        {
            Console.WriteLine("Enter the first line");
            string line1 = Console.ReadLine();
            Console.WriteLine("Enter the second line");
            string line2 = Console.ReadLine();

            StringBuilder doubledLineLettersDigitsNonCase = new StringBuilder();
            StringBuilder doubledLineLettersDigitsCase = new StringBuilder();
            StringBuilder doubledLineLettersDigitsPunctuationNonCase = new StringBuilder();
            StringBuilder doubledLineLettersDigitsPunctuationCase = new StringBuilder();
            StringBuilder doubledLineAllCase = new StringBuilder();

            Console.WriteLine();

            
            // this line is used to perform non-case-sensitive doubling
            string line3 = line2.ToLower();

            foreach (char c in line1)
            {
                doubledLineLettersDigitsNonCase.Append(c);
                doubledLineLettersDigitsCase.Append(c);
                doubledLineLettersDigitsPunctuationNonCase.Append(c);
                doubledLineLettersDigitsPunctuationCase.Append(c);
                doubledLineAllCase.Append(c);

                // this doubles only letters and digits (non-case-sensitive)
                if (Char.IsLetterOrDigit(c) && line3.Contains(Char.ToLower(c)))
                {
                    doubledLineLettersDigitsNonCase.Append(c);
                }

                // this doubles only letters and digits (case-sensitive)
                if (Char.IsLetterOrDigit(c) && line2.Contains(c))
                {
                    doubledLineLettersDigitsCase.Append(c);
                }

                // this doubles letters, digits and punctuation (non-case-sensitive)
                if ((Char.IsPunctuation(c) && line2.Contains(c)) || (Char.IsLetterOrDigit(c) && line3.Contains(Char.ToLower(c))))
                {
                    doubledLineLettersDigitsPunctuationNonCase.Append(c);
                }

                // this doubles letters, digits and punctuation (case-sensitive)
                if ((Char.IsPunctuation(c) || Char.IsLetterOrDigit(c)) && line2.Contains(c))
                {
                    doubledLineLettersDigitsPunctuationCase.Append(c);
                }

                // this doubles all chars (case-sensitive)
                if (line2.Contains(c))
                {
                    doubledLineAllCase.Append(c);
                }
            }

            Console.WriteLine("Doubled chars are letters and digits (non-case-sensitive):");
            Console.WriteLine(doubledLineLettersDigitsNonCase);
            Console.WriteLine();

            Console.WriteLine("Doubled chars are letters and digits (case-sensitive):");
            Console.WriteLine(doubledLineLettersDigitsCase);
            Console.WriteLine();

            Console.WriteLine("Doubled chars are letters, digits and punctuation (non-case-sensitive):");
            Console.WriteLine(doubledLineLettersDigitsPunctuationNonCase);
            Console.WriteLine();

            Console.WriteLine("Doubled chars are letters, digits and punctuation (case-sensitive):");
            Console.WriteLine(doubledLineLettersDigitsPunctuationCase);
            Console.WriteLine();

            Console.WriteLine("Doubled chars are all chars (case-sensitive):");
            Console.WriteLine(doubledLineAllCase);
            Console.WriteLine();
        }
    }
}
