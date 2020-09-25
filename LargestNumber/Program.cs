using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = { 10, 2 };
            string result = sol.LargestNumber(nums);

            nums = new int[] { 3, 30, 34, 5, 9 };
            result = sol.LargestNumber(nums);

            nums = new int[] { 1, 1, 2, 1 };
            result = sol.LargestNumber(nums);



        }
    }
    public class Solution
    {
        public string LargestNumber(int[] nums)
        {
            Array.Sort(nums, (i, j) => String.Compare(j.ToString() + i.ToString(), i.ToString() + j.ToString(), StringComparison.Ordinal));
            var res = nums.Aggregate(string.Empty, (s, i) => s + i);

            if (res.Any() && res[0].Equals('0'))
            {
                return "0";
            }

            return res;
        }
    }
}