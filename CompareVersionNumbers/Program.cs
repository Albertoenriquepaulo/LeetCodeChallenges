using System;
using System.Collections.Generic;

namespace CompareVersionNumbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string version1 = "0.1";
            string version2 = "1.1";
            int i = 1;
            int result = Solution.CompareVersion(version1, version2);
            Console.WriteLine($"Example {i++}:");
            Console.WriteLine($"Output: {result}:\n");

            version1 = "1.0.1";
            version2 = "1";
            result = Solution.CompareVersion(version1, version2);
            Console.WriteLine($"Example {i++}:");
            Console.WriteLine($"Output: {result}: \n");

            version1 = "7.5.2.4";
            version2 = "7.5.3";
            result = Solution.CompareVersion(version1, version2);
            Console.WriteLine($"Example {i++}:");
            Console.WriteLine($"Output: {result}: \n");

            version1 = "1.01";
            version2 = "1.001";
            result = Solution.CompareVersion(version1, version2);
            Console.WriteLine($"Example {i++}:");
            Console.WriteLine($"Output: {result}:\n");

            version1 = "1.0";
            version2 = "1.0.0";
            result = Solution.CompareVersion(version1, version2);
            Console.WriteLine($"Example {i++}:");
            Console.WriteLine($"Output: {result}:\n");

            version1 = "0.9.9.9.9.9.9.9.9.9.9.9.9";
            version2 = "1.0";
            result = Solution.CompareVersion(version1, version2);
            Console.WriteLine($"Example {i++}:");
            Console.WriteLine($"Output: {result}:\n");

            version1 = "19.8.3.17.5.01.0.0.4.0.0.0.0.0.0.0.0.0.0.0.0.0.00.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.1.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.000000.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.000000";
            version2 = "19.8.3.17.5.01.0.0.4.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0000.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.0.000000";
            result = Solution.CompareVersion(version1, version2);
            Console.WriteLine($"Example {i++}:");
            Console.WriteLine($"Output: {result}:\n");
        }
    }

    public class Solution
    {
        public static int CompareVersion(string version1, string version2)
        {
            char dot = '.';
            List<string> version1Splited = CorrectStringArray(version1.Split(dot));
            List<string> version2Splited = CorrectStringArray(version2.Split(dot));

            CompleteStringLists(version1Splited, version2Splited);

            return CompareLists(version1Splited, version2Splited);

        }

        public static List<string> CorrectStringArray(string[] strArray)
        {
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = int.Parse(strArray[i]).ToString();
            }
            return new List<string>(strArray);
        }

        public static void CompleteStringLists(List<string> strList1, List<string> strList2)
        {
            if (strList1.Count == strList2.Count)
            {
                return;
            }
            else if (strList1.Count > strList2.Count)
            {
                while (strList2.Count != strList1.Count)
                {
                    strList2.Add("0");
                }
            }
            else
            {
                while (strList1.Count != strList2.Count)
                {
                    strList1.Add("0");
                }
            }
        }

        public static int CompareLists(List<string> strList1, List<string> strList2)
        {
            for (int i = 0; i < strList1.Count; i++)
            {
                int numV1 = int.Parse(strList1[i]);
                int numV2 = int.Parse(strList2[i]);
                if (numV1 == numV2)
                {
                    continue;
                }
                else if (numV1 > numV2)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

    }
}