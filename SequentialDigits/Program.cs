using System;
using System.Collections.Generic;

namespace SequentialDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int low = 100;
            int high = 300;
            IList<int> result = new List<int>();
            result = sol.SequentialDigits(low, high);

            low = 1000;
            high = 13000;
            result = sol.SequentialDigits(low, high);

            low = 1;
            high = 1;
            result = sol.SequentialDigits(low, high);

            low = 10;
            high = (int)Math.Pow(10, 9);
            result = sol.SequentialDigits(low, high);

            low = 10;
            high = 12;
            result = sol.SequentialDigits(low, high);

            low = 58;
            high = 155;
            result = sol.SequentialDigits(low, high);

            low = 234;
            high = 2314;
            result = sol.SequentialDigits(low, high);

        }
    }

    public class Solution
    {
        public IList<int> SequentialDigits(int low, int high)
        {
            int minNumber = 10;
            int maxNumber = (int)Math.Pow(10, 9);

            if (low < minNumber || low > maxNumber || high < low || high > maxNumber)
            {
                return null;
            }

            int[] lowArray = GetIntArray(low);
            int numberOfDigitOfLow = lowArray.Length;
            int firstNumber = lowArray[0];

            int[] highArray = GetIntArray(high);
            int numberOfDigitOfHigh = highArray.Length;
            List<int> resultList = new List<int>();
            int startDigit = lowArray[0];
            for (int i = numberOfDigitOfLow; i <= numberOfDigitOfHigh; i++, startDigit = 1)
            {
                GetSequentialDigits(low, high, i, startDigit, resultList);
            }

            return resultList;
        }

        public void GetSequentialDigits(int low, int high, int numberOfDigits, int startDigit, List<int> resultList)
        {
            List<int> possibleNumberList = new List<int>();
            if (startDigit + (numberOfDigits - 1) < 10)
            {
                possibleNumberList.Add(startDigit);
                for (int i = 1; i < numberOfDigits; i++)
                {
                    possibleNumberList.Add(startDigit + i);
                }
                string result = string.Join("", possibleNumberList);
                int possibleNumber = Int32.Parse(result);
                if (possibleNumber > high)
                {
                    return;
                }
                else if (possibleNumber >= low)
                {
                    resultList.Add(possibleNumber);
                    GetSequentialDigits(low, high, numberOfDigits, startDigit + 1, resultList);
                }
                else
                {
                    GetSequentialDigits(low, high, numberOfDigits, startDigit + 1, resultList);
                }
            }
        }

        public int[] GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            listOfInts.Reverse();
            return listOfInts.ToArray();
        }
    }
}
