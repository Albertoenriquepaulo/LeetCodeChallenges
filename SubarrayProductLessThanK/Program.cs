using System;

namespace SubarrayProductLessThanK
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = { 10, 5, 2, 6 };
            int k = 100;
            int result = sol.NumSubarrayProductLessThanK(nums, k);

            nums = new int[] { 1, 1, 1, 1 };
            k = 100;
            result = sol.NumSubarrayProductLessThanK(nums, k);

            nums = new int[] { 1, 1, 1, 1 };
            k = 100;
            result = sol.NumSubarrayProductLessThanK(nums, k);
        }
    }

    class Solution
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k == 0)
            {
                return 0;
            }
            double logk = Math.Log(k);
            double[] prefix = new double[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                prefix[i + 1] = prefix[i] + Math.Log(nums[i]);
            }

            int result = 0;
            for (int i = 0; i < prefix.Length; i++)
            {
                int low = i + 1, high = prefix.Length;
                while (low < high)
                {
                    int medium = low + (high - low) / 2;
                    if (prefix[medium] < prefix[i] + logk - 1e-9) low = medium + 1;
                    else high = medium;
                }
                result += low - i - 1;
            }
            return result;
        }

        public int NumSubarrayProductLessThanK2(int[] nums, int k)
        {

            if (nums == null || nums.Length == 0)
                return 0;

            int left = 0;
            var prod = 1;

            var count = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                prod *= nums[right];
                while (prod >= k && left <= right)
                {
                    prod /= nums[left];
                    left++;
                }

                count += right - left + 1;
            }

            return count;

        }
        public int NumSubarrayProductLessThanK1(int[] nums, int k) //Time limit exceed if the array is too big
        {
            int result = 0;
            int factor = 1;
            for (int i = -1; i <= nums.Length; i++)
            {
                Recursive(nums, i, k, ref result, factor);
            }

            return result;
        }

        private void Recursive(int[] nums, int index, int k, ref int result, int factor)
        {
            index++;

            if (index < nums.Length)
            {
                factor *= nums[index];
                if (factor < k)
                {
                    result++;
                    Recursive(nums, index, k, ref result, factor);
                }
                return;
            }
            else
            {
                return;
            }
        }

        public bool Incluir(int num, int k)
        {
            return num < k;
        }
    }
}
