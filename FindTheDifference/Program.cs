using System;

namespace FindTheDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abcd";
            string t = "abcde";
            Solution sol = new Solution();
            var char1 = sol.FindTheDifference(s, t);
        }
    }
    public class Solution
    {
        public char FindTheDifference(string s, string t)
        {
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < t.Length; j++)
                {
                    if (s[i] == t[j])
                    {
                        t = t.Remove(j, 1);
                        break;
                    }
                }
            }
            return t[0];
        }
    }
}
