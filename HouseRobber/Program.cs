using System;
using System.Linq;

namespace HouseRobber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 1 };
            var result = Solution.Rob(nums);

            nums = new int[] { 2, 7, 9, 3, 1 };
            result = Solution.Rob(nums);

            nums = new int[] { 5, 4, 0, 0, 0, 1, 5, 7, 6, 100, 1, 2, 3, 4, 5, 6, 8, 7, 9, 8, 300 };
            result = Solution.Rob(nums);

            nums = new int[] { 5, 4, 0, 0, 0, 1, 5, 7, 6, 100, 1, 2, 3, 4, 5, 6, 8, 7, 9, 8 };
            result = Solution.Rob(nums);

            nums = new int[] { };
            result = Solution.Rob(nums);
        }
    }

    public class Solution
    {
        public static int Rob(int[] nums)
        {
            int sizeOfnums = nums.Length;

            if (sizeOfnums == 0)
            {
                return 0;
            }
            else if (sizeOfnums == 1)
            {
                return nums[0];
            }

            int[] numsAux = new int[nums.Length];
            numsAux[0] = nums[0];
            numsAux[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < sizeOfnums; i++)
            {
                numsAux[i] = Math.Max(nums[i] + numsAux[i - 2], numsAux[i - 1]);
            }


            return numsAux[sizeOfnums - 1];

        }
    }
}
