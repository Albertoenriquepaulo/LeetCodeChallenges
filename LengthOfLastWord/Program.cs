using System;

namespace LengthOfLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int result = Solution.LengthOfLastWord(s);
            int result1 = Solution.LengthOfLastWord1(s);

            s = "     China";
            result = Solution.LengthOfLastWord(s);
            result1 = Solution.LengthOfLastWord1(s);

            s = "Alberto";
            result = Solution.LengthOfLastWord(s);
            result1 = Solution.LengthOfLastWord1(s);


            s = "Alberto ";
            result = Solution.LengthOfLastWord(s);
            result1 = Solution.LengthOfLastWord1(s);
        }

    }

    public class Solution
    {
        public static int LengthOfLastWord(string s)
        {
            s = s.Trim();



            int sSize = s.Length;
            if (sSize == 0)
            {
                return 0;
            }

            int result = 0;

            for (int i = sSize - 1; i >= 0; i--)
            {
                if (s[i].ToString() == " ")
                {
                    break;
                }
                result++;
            }

            return result;
        }

        //This is faster than the above one
        public static int LengthOfLastWord1(string s)
        {
            s = s.Trim();
            if (s.Trim().Length == 0)
            {
                return 0;
            }
            var sSplited = s.Split(" ");
            return sSplited[sSplited.Length - 1].Length;
        }
    }
}
