using System;
using System.Collections.Generic;
using System.Linq;

namespace BestTimeToBuyAndSellStock
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] prices = { };
            int result = sol.MaxProfit(prices);

            prices = new int[] { 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 1, 0 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 0, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 1, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 3, 2, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 7, 1, 5, 3, 6, 4 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 7, 6, 4, 3, 2, 3, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 3, 2, 6, 5, 0, 3 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 4, 5, 2, 6, 10, 4, 1, 8, 9, 13 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 2, 4, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 2, 4, 1, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 2, 1, 2, 0, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 2, 1, 2, 1, 0, 0, 1 };
            result = sol.MaxProfit(prices);

            prices = new int[] { 4, 7, 1, 2 };
            result = sol.MaxProfit(prices);

        }
    }

    //This does not work well for some cases...
    public class Solution1
    {
        public int MaxProfit(int[] prices)
        {
            int pricesSize = prices.Length;
            if (pricesSize < 2)
            {
                return 0;
            }
            else if (pricesSize < 3)
            {
                if (prices[0] < prices[1])
                {
                    return prices[1] - prices[0];
                }
                return 0;
            }
            int? min = 0;
            int minIndex = 0;
            while (prices.Length > 1)
            {
                min = prices.Min();
                minIndex = Array.IndexOf(prices, min);
                if (minIndex == pricesSize - 1)
                {
                    Array.Resize(ref prices, prices.Length - 1);
                    pricesSize = prices.Length;
                }
                else
                {
                    break;
                }
            }
            if (pricesSize == 1)
            {
                return 0;
            }
            else if (pricesSize < 3)
            {
                if (prices[0] < prices[1])
                {
                    return prices[1] - prices[0];
                }
                return 0;
            }
            else
            {
                List<int> minors = new List<int>();
                int result = 0;
                int counter = 0;
                while (counter < pricesSize - 1)
                {
                    if (min != null)
                    {
                        minors.Add(min.Value);
                        if (minIndex < pricesSize - 1)
                        {
                            int max = prices.Skip(minIndex + 1).ToArray().Max();
                            if (min < max)
                            {
                                int newResult = max - min.Value;
                                result = Math.Max(result, newResult);
                            }
                        }
                    }
                    min = GetMin(prices, minors);
                    minIndex = Array.IndexOf(prices, min);
                    counter++;
                }

                return result;
            }
        }

        public int? GetMin(int[] prices, List<int> exception)
        {
            try
            {
                return prices.Except(exception).Min();
            }
            catch (Exception)
            {
                return null;
            }

        }

    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int result = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    int max = prices[j] - prices[i];
                    if (max > result)
                        result = max;
                }
            }
            return result;
        }
    }
}
