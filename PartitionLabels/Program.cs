using System;
using System.Collections.Generic;
using System.Linq;

namespace PartitionLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input: S = "ababcbacadefegdehijhklij"
            //Output:[9,7,8]
            string S = "ababcbacadefegdehijhklij";
            S = "abcd";
            S = "abcda";
            string resultS = S.Substring(1, 2);
            List<int> result = (List<int>)Solution.PartitionLabels(S);
        }
    }
    public static class Solution
    {
        public static IList<int> PartitionLabels(string S)
        {
            List<string> myResult = new List<string>();
            int index = 0;
            for (int i = 1; i < S.Length; i++)
            {
                if (Slice(S, index, i).Contains(S[i]))
                {
                    continue;
                }
                else
                {
                    bool booleanIsValid = true;
                    for (int j = 0; j < myResult.Count; j++)
                    {
                        if (myResult[j].Contains(S[i]))
                        {
                            myResult = myResult.Take(j).ToList();
                            index = string.Concat(myResult).Length;
                            booleanIsValid = false;
                        }
                    }
                    if (booleanIsValid)
                    {
                        myResult.Add(Slice(S, index, i));
                        index = i;
                    }
                }
            }
            myResult.Add(S.Substring(index));
            return myResult.Select(item => item.Length).ToList();
        }

        public static string Slice(string phrase, int index, int pos)
        {
            string result = null;
            for (int k = index; k < pos; k++)
            {
                result += phrase[k].ToString();
            }
            return result;
        }
    }

}
