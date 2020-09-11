using System;
using System.Collections.Generic;
using System.Numerics;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode L1 = new ListNode() { val = 2, next = new ListNode { val = 4, next = new ListNode { val = 3 } } };
            ListNode L2 = new ListNode() { val = 5, next = new ListNode { val = 6, next = new ListNode { val = 4 } } };

            Solution sol = new Solution();
            ListNode result = sol.AddTwoNumbers(L1, L2);
        }
    }


    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            string strL1 = ExtractNumbers(l1);
            string strL2 = ExtractNumbers(l2);

            strL1 = ReverseString(strL1);
            strL2 = ReverseString(strL2);

            string result = ReverseString((BigInteger.Parse(strL1) + BigInteger.Parse(strL2)).ToString());

            return InsertNumbers(result);
        }

        public string ExtractNumbers(ListNode linkedList)
        {
            if (linkedList.next == null)
            {
                return linkedList.val.ToString();
            }

            return linkedList.val.ToString() + ExtractNumbers(linkedList.next);
        }
        public ListNode InsertNumbers(string strNumber)
        {
            BigInteger number;
            if (strNumber[0].ToString() == "0")
            {
                number = 0;
            }
            else
            {
                number = BigInteger.Parse(strNumber);
            }

            if (number < 10 && strNumber.Length == 1)
            {
                return new ListNode { val = (int)number };
            }

            int val = Int32.Parse(number.ToString()[0].ToString());
            strNumber = strNumber.Substring(1);

            return new ListNode { val = val, next = InsertNumbers(strNumber) };
        }
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
