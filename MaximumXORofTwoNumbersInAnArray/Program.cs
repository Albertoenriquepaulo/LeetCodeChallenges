using System;
using System.Linq;

namespace MaximumXORofTwoNumbersInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 30, 31, 102, 108, 105, 35, 43, 199, 195, 300, 512 };
            int result = Solution.FindMaximumXOR(nums);
            int result1 = Solution.FindMaximumXOR1(nums);


            nums = new int[] { 3, 10, 5, 25, 2, 8 };
            result = Solution.FindMaximumXOR(nums);
            result1 = Solution.FindMaximumXOR1(nums);

            nums = new int[] { 8, 10, 2 };
            result = Solution.FindMaximumXOR(nums);
            result1 = Solution.FindMaximumXOR1(nums);

            nums = new int[] { 3, 1 };
            result = Solution.FindMaximumXOR(nums);
            result1 = Solution.FindMaximumXOR1(nums);
        }
    }

    public class Solution
    {
        public static int FindMaximumXOR(int[] nums)
        {
            int maxXor = 0;
            int size = nums.Length;

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    maxXor = Math.Max(maxXor, nums[i] ^ nums[j]);
                }
            }
            return maxXor;

        }
        public static int FindMaximumXOR2(int[] nums)
        {
            int maxXor = 0, auxMaxXor = 0;
            int size = nums.Length;

            int[] result = { -1, 1 };

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    maxXor = Math.Max(maxXor, nums[i] ^ nums[j]);
                    if (maxXor > auxMaxXor)
                    {
                        auxMaxXor = maxXor;
                        result[0] = nums[i];
                        result[1] = nums[j];
                    }

                }
            }
            return maxXor;

        }

        public static int FindMaximumXOR1(int[] nums)
        {
            int maxXor = 0;
            int max = nums.Max();
            int size = nums.Length;

            for (int i = 0; i < size; i++)
            {
                maxXor = Math.Max(maxXor, nums[i] ^ max);
                //maxXor = maxXor < max ? max : maxXor;
            }
            return maxXor;

        }
    }
}
