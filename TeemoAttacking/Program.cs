using System;

namespace TeemoAttacking
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] timeSeries = { 1, 4 };
            int duration = 2;
            int result = sol.FindPoisonedDuration(timeSeries, duration);

            timeSeries = new int[] { 1, 2 };
            duration = 2;
            result = sol.FindPoisonedDuration(timeSeries, duration);

            timeSeries = new int[] { 1, 2 };
            duration = 0;
            result = sol.FindPoisonedDuration(timeSeries, duration);

            timeSeries = new int[] { };
            duration = 2;
            result = sol.FindPoisonedDuration(timeSeries, duration);

            timeSeries = new int[] { };
            duration = 0;
            result = sol.FindPoisonedDuration(timeSeries, duration);

            timeSeries = new int[] { 1, 2 };
            duration = 3;
            result = sol.FindPoisonedDuration(timeSeries, duration);
        }

        public class Solution
        {
            public int FindPoisonedDuration(int[] timeSeries, int duration)
            {
                int timeSeriesLength = timeSeries.Length;
                if (timeSeriesLength == 0)
                {
                    return 0;
                }
                int total = 0;

                for (int i = 0; i < timeSeriesLength - 1; ++i)
                {
                    total += Math.Min(timeSeries[i + 1] - timeSeries[i], duration);
                }

                return total + duration;
            }

            public int FindPoisonedDuration1(int[] timeSeries, int duration)
            {
                int output = 0;
                int posionedTo = 0;
                for (int i = 0; i < timeSeries.Length; i++)
                {
                    if (timeSeries[i] < posionedTo)
                    {
                        //int remain = posionedTo - timeSeries[i];
                        //posionedTo += duration + remain;
                        //output += remain;
                        output = timeSeries[i] - timeSeries[i - 1] + duration;
                        continue;
                    }
                    else
                    {
                        posionedTo = timeSeries[i] + duration;
                        output += duration;
                    }
                }
                return output;
            }
        }
    }
}
