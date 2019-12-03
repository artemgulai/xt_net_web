using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.WordFrequency
{
    class WordFrequency
    {
        /// <summary>
        /// Counts how many times a word occures in text and prints the result.
        /// </summary>
        /// <param name="text">A text in English.</param>
        /// <param name="word">A word.</param>
        public static void WordCount(string text, string word)
        {
            List<string> words = new List<string>(text.Split(new char[] { ' ', ',', '.' }));
            int numOfOccurences = 0;
            foreach (string wordInText in words)
            {
                if (wordInText.Equals(word, StringComparison.OrdinalIgnoreCase))
                    numOfOccurences++;
            }
            Console.WriteLine($"The word {word} occures {numOfOccurences} times.");
        }

        /// <summary>
        /// Counts how many times each word occures in text and prints the result.
        /// </summary>
        /// <param name="text">A text in English.</param>
        public static void WordsCount(string text)
        {
            List<string> words = new List<string>(text.Split(new char[] { ' ', ',', '.' }));
            SortedDictionary<string, int> wordsOccurences = new SortedDictionary<string, int>();

            foreach (string word in words)
            {
                string wordToLower = word.ToLower();
                
                if (string.IsNullOrWhiteSpace(wordToLower))
                    continue;

                string.Intern(wordToLower);
                if (wordsOccurences.ContainsKey(wordToLower))
                {
                    wordsOccurences[wordToLower]++;
                }
                else
                {
                    wordsOccurences.Add(wordToLower, 1);
                }
            }

            foreach (KeyValuePair<string, int> wordOccurence in wordsOccurences)
            {
                Console.WriteLine($"The word \"{wordOccurence.Key}\" occures \"{wordOccurence.Value}\" times.");
            }
        }

        public static void WordFrequencyDemo()
        {
            Console.Clear();
            Console.WriteLine("Task 3.2. Word Frequency.");

            string text =
                "I put a spell on you because you are mine You better stop the things that you do " +
                "I am not lying, no, I am not lying I just can not stand it babe The way you are always running around " +
                "I just can not stand it, the way you always put me down " +
                "I put a spell on you because you are mine I put a spell on you because you are mine " +
                "You better stop the things that you do I am not lying, no, I am not lying " +
                "I just can not stand it babe The way you are always running around " +
                "I just can not stand it, the way you always put me down " +
                "I put a spell on you because you are mine I put a spell on you. I put a spell on you " +
                "I put a spell on you. I put a spell on you.";
            
            string word = "tHe";
            WordCount(text, word);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            WordsCount(text);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
