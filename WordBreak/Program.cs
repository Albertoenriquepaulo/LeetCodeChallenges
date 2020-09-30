using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            string s = "applepenapple";
            List<string> wordDict = new List<string>() { "apple", "pen" };
            bool result = sol.WordBreak(s, wordDict);

            s = "catsandog";
            wordDict = new List<string>() { "cats", "dog", "sand", "and", "cat" };
            result = sol.WordBreak(s, wordDict);
            //s = s.Replace("apple", string.Empty);
        }
    }

    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            int length = s.Length;
            bool[] booleanArray = new bool[length + 1];
            booleanArray[0] = true;

            for (int i = 1; i <= length; i++)
            {
                if (booleanArray[i - 1] == false)
                {
                    continue;
                }
                foreach (string word in wordDict)
                {
                    int end = i - 1 + word.Length;
                    int start = i - 1;
                    if (end <= length && s.Substring(start, end - start).Equals(word))
                    {
                        booleanArray[end] = true;
                    }
                }
            }
            return booleanArray[length];
        }
    }
}
