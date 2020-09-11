using System;
using System.Globalization;
using System.Linq;

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "pwwkew";

            int result = Solution.LengthOfLongestSubstring(input);
        }
    }
    public class Solution
    {
        public static int LengthOfLongestSubstring(string s)
        {
            int[] lenghts = new int[3];

            for (int i = 0; i < s.Length; i++)
            {
                // check if the set already contains
                for (int j = i - 1; j >= lenghts[0]; --j)
                    lenghts[0] = (s[i] == s[j]) ? lenghts[0] = j + 1 : lenghts[0];

                lenghts[2] = i - lenghts[0] + 1;
                lenghts[1] = (lenghts[2] > lenghts[1]) ? lenghts[2] : lenghts[1];
            }
            return lenghts[1];
        }

    }

}
