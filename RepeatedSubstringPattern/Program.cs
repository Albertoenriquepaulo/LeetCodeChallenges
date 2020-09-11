using System;
using System.Text;

namespace RepeatedSubstringPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            string test = "abab";
            result = Solution.RepeatedSubstringPattern(test);
            test = "aba";
            result = Solution.RepeatedSubstringPattern(test);
            test = "abcabcabcabc";
            result = Solution.RepeatedSubstringPattern(test);
        }
    }

    public class Solution
    {
        public static bool RepeatedSubstringPattern(string s)
        {
            int stringSize = s.Length;
            for (int index = stringSize / 2; index >= 1; index--)
            {
                if (stringSize % index == 0)
                {
                    int tempStringSize = stringSize / index;
                    string subString = s.Substring(0, index);
                    StringBuilder strBuilder = new StringBuilder();
                    for (int j = 0; j < tempStringSize; j++) strBuilder.Append(subString);
                    if (strBuilder.ToString().Equals(s)) return true;
                }
            }
            return false;
        }
    }
}


//1) The length of the repeating substring must be a divisor of the length of the input string
//2) Search for all possible divisor of str.length, starting for length/2
//3) If i is a divisor of length, repeat the substring from 0 to i the number of times i is contained in s.length
//4) If the repeated substring is equals to the input str return true