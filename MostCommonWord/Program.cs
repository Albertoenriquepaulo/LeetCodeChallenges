using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MostCommonWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var paragraph = "Bob hit a ball, the hit!!! BALL??? flew far after it was hit.";
            var banned = new string[] { "hit", "cual" };
            var sol = new Solution();
            var result = sol.MostCommonWord(paragraph, banned);

            paragraph = "a.";
            banned = new string[] { };
            result = sol.MostCommonWord(paragraph, banned);

            paragraph = "a, a, a, a, b,b,b,c, c";
            banned = new string[] { "a" };
            result = sol.MostCommonWord(paragraph, banned);
        }
    }
    public class Solution
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var symbolsToDelete = @"[!?',;.]";
            paragraph = Regex.Replace(paragraph, symbolsToDelete, " ");
            paragraph = Regex.Replace(paragraph, " {2,}", " ");
            var dictionary = new Dictionary<string, int>();
            var arrayParagraph = paragraph.ToLower().TrimEnd().Split(" ");
            foreach (var word in arrayParagraph)
            {
                if (banned.Contains(word))
                {
                    continue;
                }
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                    continue;
                }
                dictionary[word]++;
            }

            var keyOfMaxValue = dictionary.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return keyOfMaxValue;
        }
    }
}
