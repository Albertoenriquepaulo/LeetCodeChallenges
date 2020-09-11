using System;

namespace SumOfRootToLeafBinaryNumbers
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
        int result = 0;
        public int SumRootToLeaf(TreeNode root)
        {
            Preorder(root, 0);
            return result;
        }

        public void Preorder(TreeNode tree, int number)
        {
            if (tree != null)
            {
                number = (number << 1) | tree.val;
                if (tree.left == null && tree.right == null)
                {
                    result += number;
                }
                Preorder(tree.left, number);
                Preorder(tree.right, number);
            }
        }
    }
}
