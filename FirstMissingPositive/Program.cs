using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstMissingPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = { 1, 2, 0 };
            int result = sol.FirstMissingPositive(nums);

            nums = new int[] { 3, 4, -1, 1 };
            result = sol.FirstMissingPositive(nums);

            nums = new int[] { 7, 8, 9, 11, 12 };
            result = sol.FirstMissingPositive(nums);

            nums = new int[] { };
            result = sol.FirstMissingPositive(nums);

        }
    }
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            Array.Sort(nums);
            List<int> numsList = new List<int>(nums);
            numsList.RemoveAll(i => i < 0);
            int limit = numsList.LastOrDefault();
            for (int i = 1; i < limit; i++)
            {
                if (numsList.Contains(i) == false)
                {
                    return i;
                }
            }

            return numsList.LastOrDefault() + 1;
        }
    }
}
