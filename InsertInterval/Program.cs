using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var n = intervals.Length;

            if (n == 0)
            {
                return new int[][] { newInterval };
            }

            List<int[]> result = new List<int[]>();

            bool isInto = false;
            for (int i = 0; i < n; i++)
            {
                if (intervals[i][0] > newInterval[0])
                {
                    result.Add(newInterval);
                    isInto = true;
                }
                result.Add(intervals[i]);
            }

            if (isInto == false)
            {
                result.Add(newInterval);
            }

            result = Merge(result);
            return result.ToArray();
        }

        private List<int[]> Merge(List<int[]> intervals)
        {
            int size = intervals.Count;
            if (size <= 1) return intervals;

            List<int[]> result = new List<int[]>();
            result.Add(intervals[0]);

            for (int i = 1; i < size; i++)
            {
                int[] lastInResultList = result.Last();
                int[] current = intervals[i];

                if (lastInResultList[1] >= current[0])
                {
                    lastInResultList[1] = Math.Max(lastInResultList[1], current[1]);
                }
                else
                {
                    result.Add(current);
                }
            }

            return result;
        }
    }
}
