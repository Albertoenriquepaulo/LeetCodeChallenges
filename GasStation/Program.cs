using System;

namespace GasStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();

            int[] gas = { 1, 2, 3, 4, 5 };
            int[] cost = { 3, 4, 5, 1, 2 };
            int result = sol.CanCompleteCircuit(gas, cost);

            gas = new int[] { 2, 3, 4 };
            cost = new int[] { 3, 4, 3 };
            result = sol.CanCompleteCircuit(gas, cost);

            gas = new int[] { 5, 1, 2, 3, 4 };
            cost = new int[] { 4, 4, 1, 5, 1 };
            result = sol.CanCompleteCircuit(gas, cost);
        }
    }

    public class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int remainingAccumulator = 0;
            int total = 0;
            int start = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                int remaining = gas[i] - cost[i];

                if (remainingAccumulator >= 0)
                {
                    remainingAccumulator += remaining;
                }
                else
                {
                    remainingAccumulator = remaining;
                    start = i;
                }
                total += remaining;
            }

            if (total >= 0)
            {
                return start;
            }
            else
            {
                return -1;
            }
        }
    }
}
