using System;
using System.Collections.Generic;
using System.Linq;

namespace WordPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string strPattern = "abba";
            string str = "dog cat cat dog";

            bool booleanResult = Solution.WordPattern(strPattern, str);

            str = "dog cat cat fish";
            booleanResult = Solution.WordPattern(strPattern, str);

            strPattern = "aaaa";
            str = "dog cat cat dog";
            booleanResult = Solution.WordPattern(strPattern, str);

            strPattern = "abba";
            str = "dog dog dog dog";
            booleanResult = Solution.WordPattern(strPattern, str);


            strPattern = "aaaab";
            str = "d d d d a";
            booleanResult = Solution.WordPattern(strPattern, str);

            strPattern = "abab";
            str = "";
            booleanResult = Solution.WordPattern(strPattern, str);

            strPattern = "";
            str = "";
            booleanResult = Solution.WordPattern(strPattern, str);



            strPattern = " ";
            str = "";
            booleanResult = Solution.WordPattern(strPattern, str);

            strPattern = "";
            str = " ";
            booleanResult = Solution.WordPattern(strPattern, str);

            strPattern = " ";
            str = " ";
            booleanResult = Solution.WordPattern(strPattern, str);

        }
    }

    public class Solution
    {
        public static bool WordPattern(string pattern, string str)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(str))
            {
                return false;
            }
            List<string> stringList = ConvertToStringList(str);

            if (stringList.Count != pattern.Length)
            {
                return false;
            }

            bool success = false;

            while (string.IsNullOrEmpty(pattern) == false)
            {
                List<int> list1 = GetPositionsListFromString(pattern, pattern[0].ToString());
                List<int> list2 = GetPositionsListFromList(stringList, stringList[0]);

                if (Enumerable.SequenceEqual(list1, list2))
                {
                    pattern = pattern.Replace(pattern[0].ToString(), string.Empty);
                    string strToDelete = stringList[0];
                    stringList = stringList.Where(x => x != strToDelete).ToList();//stringList.Select(x => x != strToDelete).ToList();
                    success = true;
                }
                else
                {
                    return false;
                }
            }
            return success;
        }

        public static List<string> ConvertToStringList(string str)
        {
            char[] delimiters = new char[] { ' ' };
            return new List<string>(str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));
        }

        public static List<int> GetPositionsListFromString(string str, string strToFind)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == strToFind)
                {
                    result.Add(i);
                }
            }
            return result;
        }
        public static List<int> GetPositionsListFromList(List<string> strList, string strToFind)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < strList.Count; i++)
            {
                if (strList[i] == strToFind)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
