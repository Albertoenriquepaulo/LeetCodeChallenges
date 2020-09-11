using System;

namespace MedianofTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1 };
            int[] nums2 = { 6 };
            int test = nums1.Length;
            double result = Solution.FindMedianSortedArrays(nums1, nums2);
        }
    }

    public class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0)
            {
                return new int { };
            }
            int[] mergedArray = MergeArrays(nums1, nums2);
            int mergedArrayLength = mergedArray.Length;

            int pos = mergedArrayLength / 2;
            if (mergedArrayLength % 2 != 0)
            {
                return mergedArray[pos];
            }

            return (mergedArray[pos] + mergedArray[pos - 1]) / 2.0;
        }

        public static int[] MergeArrays(int[] array1, int[] array2)
        {
            int array1Length = array1.Length;
            int array2Length = array2.Length;
            int[] result = new int[array1Length + array2Length];
            int i = 0, j = 0, k = 0;

            while (i < array1Length && j < array2Length)
            {
                if (array1[i] < array2[j])
                    result[k++] = array1[i++];
                else
                    result[k++] = array2[j++];
            }

            while (i < array1Length)
                result[k++] = array1[i++];

            while (j < array2Length)
                result[k++] = array2[j++];

            return result;
        }
    }
}
