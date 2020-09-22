using System;
using System.Collections.Generic;

namespace MajorityElementII
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            IList<int> result = new List<int>();

            int[] nums = { 1, 1, 2, 1, 3, 5, 1 };
            result = sol.MajorityElement(nums);

            nums = new int[] { 3, 2, 3 };
            result = sol.MajorityElement(nums);

            nums = new int[] { 1, 1, 1, 3, 3, 2, 2, 2 };
            result = sol.MajorityElement(nums);
        }
    }
    public class Solution
    {
        public IList<int> MajorityElement(int[] nums)
        {
            int counter1 = 0, counter2 = 0;

            int? possibleValue1 = null, possibleValue2 = null;

            foreach (int element in nums)
            {
                if (possibleValue1 != null && possibleValue1 == element)
                {
                    counter1++;
                }
                else if (possibleValue2 != null && possibleValue2 == element)
                {
                    counter2++;
                }
                else if (counter1 == 0)
                {
                    possibleValue1 = element;
                    counter1++;
                }
                else if (counter2 == 0)
                {
                    possibleValue2 = element;
                    counter2++;
                }
                else
                {
                    counter1--;
                    counter2--;
                }
            }

            List<int> result = new List<int>();

            counter1 = 0;
            counter2 = 0;

            foreach (int element in nums)
            {
                if (possibleValue1 != null && element == (int)possibleValue1) counter1++;
                if (possibleValue2 != null && element == (int)possibleValue2) counter2++;
            }

            int numsSize = nums.Length;
            if (counter1 > numsSize / 3) result.Add((int)possibleValue1);
            if (counter2 > numsSize / 3) result.Add((int)possibleValue2);

            return result;
        }
    }

}
