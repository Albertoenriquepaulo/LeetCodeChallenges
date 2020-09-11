using System;
using System.Collections.Generic;

namespace AllElementsInTwoBinarySearchTrees
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class Solution
    {
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            List<int> result = new List<int>();
            TraverseTree(result, root1);
            TraverseTree(result, root2);
            result.Sort();
            return result;
        }

        private void TraverseTree(List<int> result, TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            result.Add(root.val);
            TraverseTree(result, root.left);
            TraverseTree(result, root.right);
        }
    }
}
