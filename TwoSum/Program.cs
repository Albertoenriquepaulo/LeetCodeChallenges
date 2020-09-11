using System;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, -2, -3, -4, -5 };//{ 11, 2, 15, 7 };//{ 2, 7, 11, 15 };
            int target = -8;

            int[] result = Solution.TwoSum(nums, target);
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int rest = target - nums[i];
                int j = i + 1;
                while (j < nums.Length)
                {
                    if (Math.Abs(rest) >= 0 && rest - nums[j] == 0)
                    {
                        return new int[] { i, j };
                    }
                    j++;
                }

            }
            return new int[] { };
        }
    }
}
