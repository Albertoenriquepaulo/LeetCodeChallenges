using System;
using System.Collections.Generic;

namespace CombinationSumIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 3, n = 9;
            IList<IList<int>> result = Solution.CombinationSum3(k, n);
        }


        class Solution
        {
            public static IList<IList<int>> CombinationSum3(int k, int n)
            {
                LinkedList<int> combinationList = new LinkedList<int>();
                IList<IList<int>> results = new List<IList<int>>();

                Recursive(n, k, combinationList, 0, results);
                return results;
            }


            public static void Recursive(int remain, int k, LinkedList<int> combinationList, int nxtStart, IList<IList<int>> results)
            {
                if (remain == 0 && combinationList.Count == k)
                {
                    results.Add(new List<int>(combinationList));
                    return;
                }
                else if (remain < 0 || combinationList.Count == k)
                {
                    return;
                }

                for (int i = nxtStart; i < 9; i++)
                {
                    combinationList.AddLast(i + 1);
                    Recursive(remain - i - 1, k, combinationList, i + 1, results);
                    combinationList.RemoveLast();
                }
            }

        }
    }
}
