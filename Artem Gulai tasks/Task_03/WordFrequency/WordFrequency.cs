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
            if (text == null || text.Length == 0)
                throw new ArgumentException("Text cannot be null or empty");
            if (word == null || word.Length == 0)
                throw new ArgumentException("Word cannot be null or empty");

            List<string> words = new List<string>(text.Split(new char[] { ' ', ',', '.', '\n' }));
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
        public static SortedDictionary<string,int> WordsCount(string text)
        {
            if (text == null || text.Length == 0)
                throw new ArgumentException("Text cannot be null or empty");

            List<string> words = new List<string>(text.Split(new char[] { ' ', ',', '.', '\n' }));
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

            Console.WriteLine("Number of occurences of words in the text.");
            foreach (KeyValuePair<string, int> wordOccurence in wordsOccurences)
            {
                Console.WriteLine($"The word \"{wordOccurence.Key}\" occures {wordOccurence.Value} times.");
            }

            return wordsOccurences;
        }

        public static void WordsCountPercentage(SortedDictionary<string,int> wordsOccurences)
        {
            int numberOfWords = 0;
            foreach (var item in wordsOccurences)
            {
                numberOfWords += item.Value;
            }

            foreach (var item in wordsOccurences)
            {
                Console.WriteLine($"The word \"{item.Key}\" is every {(double)numberOfWords/item.Value:N1} " +
                    $"word.");
            }
            Console.WriteLine($"Words in total: {numberOfWords}");
            Console.WriteLine($"Unique words in total: {wordsOccurences.Count}");
        }
    }

    public class WordFrequencyDemo
    {
        public static void Demo()
        {
            Console.Clear();
            Console.WriteLine("Task 3.2. Word Frequency.");

            string text =
                "I put a spell on you because you are mine\n" +
                "You better stop the things that you do\n" +
                "I am not lying, no, I am not lying\n" +
                "I just can not stand it babe The way you are always running around\n" +
                "I just can not stand it, the way you always put me down\n" +
                "I put a spell on you because you are mine\n" +
                "I put a spell on you because you are mine\n" +
                "You better stop the things that you do\n" +
                "I am not lying, no, I am not lying\n" +
                "I just can not stand it babe The way you are always running around\n" +
                "I just can not stand it, the way you always put me down\n" +
                "I put a spell on you because you are mine\n" +
                "I put a spell on you. I put a spell on you\n" +
                "I put a spell on you. I put a spell on you.";

            Console.WriteLine("The text is the folowing: (I Put a Spell on You by Joe Cocker)" + Environment.NewLine);
            Console.WriteLine(text + Environment.NewLine);

            Console.WriteLine("Press enter to count number occurences of \"the\".");
            Console.ReadLine();
            string word = "tHe";
            WordFrequency.WordCount(text,word);
            Console.WriteLine("Press enter to count number of occurences of all words.");
            Console.ReadLine();
            var dict = WordFrequency.WordsCount(text);
            
            Console.WriteLine("Press enter to count the frequency of all words in the text.");
            Console.ReadLine();
            WordFrequency.WordsCountPercentage(dict);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
