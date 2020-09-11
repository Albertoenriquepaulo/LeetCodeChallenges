using System;
using System.Linq;

namespace DetectCapital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool test = Solution.DetectCapitalUse("USA");
        }
    }
    public class Solution
    {
        public static bool DetectCapitalUse(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            int capitalLetterNumber = NumbersOfCapitalLetter(word);
            int wordSize = word.Length;
            if (capitalLetterNumber > 1 && capitalLetterNumber < wordSize)
            {
                return false;
            }
            else if (capitalLetterNumber == 1 && Char.IsUpper(word[0]) == false)
            {
                return false;
            }

            return true;
        }

        public static int NumbersOfCapitalLetter(string word)
        {
            return word.Count(x => Char.IsUpper(x));
        }
    }
}
