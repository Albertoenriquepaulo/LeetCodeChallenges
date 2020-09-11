using System;
using System.Collections.Generic;

namespace ContainsDuplicateIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 1 };
            int k = 3, t = 0;

            nums = new int[] { 1, 0, 1, 1 };
            k = 1; t = 2;

            nums = new int[] { 1, 5, 9, 1, 5, 9 };
            k = 2; t = 3;

            nums = new int[] { 2, 1 };
            k = 1; t = 1;

            bool result = Solution.ContainsNearbyAlmostDuplicate(nums, k, t);
        }

        public static class Solution
        {
            public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
            {
                if (nums == null || k < 0 || t < 0)
                {
                    return false;
                }
                Dictionary<int, int> buckets = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int bucket = FloorDiv(nums[i], (long)t + 1);
                    if (buckets.ContainsKey(bucket))
                    {
                        return true;
                    }
                    else
                    {
                        buckets.Add(bucket, nums[i]);
                        if (buckets.ContainsKey(bucket - 1) && nums[i] - (long)buckets.GetValueOrDefault(bucket - 1) <= t)
                        {
                            return true;
                        }

                        if (buckets.ContainsKey(bucket + 1) && buckets.GetValueOrDefault(bucket + 1) - (long)nums[i] <= t)
                        {
                            return true;
                        }

                        if (buckets.Count > k)
                        {
                            buckets.Remove(FloorDiv(nums[i - k], (long)t + 1));
                        }
                    }
                }
                return false;
            }

            public static int FloorDiv(long a, long b)
            {
                return (int)((a / b) - Convert.ToInt32(((a < 0) ^ (b < 0)) && (a % b != 0)));
            }
        }
    }
}
