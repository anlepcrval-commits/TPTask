using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public static class Extension
    {
        public static void ReverseString(this string input)
        {
            Console.WriteLine("==========================================");

            
            if (input == "" || input.Length == 1)
            {
                Console.WriteLine(input);
            }
            else
            {
                string result = "";

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    result += input[i];
                }

                Console.WriteLine("Результат: " + result);
            }
            Console.WriteLine("==========================================");
        }
        public static void IsPalindrome(this string input)
        {

            
            input = input.ToLower();
            string result = "";
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }
            }
            bool palindrome = true;
            for (int i = 0; i < result.Length / 2; i++)
            {
                if (result[i] != result[result.Length - 1 - i])
                {
                    palindrome = false;
                    break;
                }
            }
            if (palindrome)
                Console.WriteLine("Это палиндром!");
            else
                Console.WriteLine("Это не палиндром!");
        }
        public static void WordCount(this string input)
        {
            string text = input;

        
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            char[] separators = new char[] { ' ', ',', '.', '!', '?', ':', ';', '-', '\t', '\n', '"', '(', ')' };
            string[] words = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }
            List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(wordCounts);
            sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));
            foreach (var pair in sortedList)
            {
                Console.WriteLine($"{pair.Key,-15} → {pair.Value}");
            }
            Console.WriteLine("=========================================");
        }
    }
}
