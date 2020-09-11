using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DesignHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> HashDatatype = new List<int> { 1, 3, 4, 5, 3 };
            //int number = HashDatatype.IndexOf(30);
            //Console.WriteLine("Hello World!");

            string num1 = "9333852702227987";
            string num2 = "85731737104263";

            string result1 = (BigInteger.Parse(num1) * BigInteger.Parse(num2)).ToString();

            MyHashSetArray hashSet = new MyHashSetArray();
            hashSet.Add(1);
            hashSet.Add(2);
            bool result = hashSet.Contains(1);    // returns true
            result = hashSet.Contains(3);    // returns false (not found)
            hashSet.Add(2);
            result = hashSet.Contains(2);    // returns true
            hashSet.Remove(2);
            result = hashSet.Contains(2);    // returns false (already removed)
        }
    }
    public class MyHashSet
    {

        /** Initialize your data structure here. */
        //public struct strHash
        //{
        //    int Key;
        //    int Value;
        //}

        public List<int> HashDatatype { get; set; }
        public MyHashSet()
        {
            HashDatatype = new List<int>();
        }

        public void Add(int key)
        {
            if (HashDatatype.IndexOf(key) == -1)
            {
                HashDatatype.Add(key);
            }
        }

        public void Remove(int key)
        {
            if (HashDatatype.Count == 0)
            {
                return;
            }
            HashDatatype.Remove(key);
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            if (HashDatatype.Count == 0)
            {
                return false;
            }

            return HashDatatype.Contains(key);
        }
    }

    public class MyHashSetArray
    {

        /** Initialize your data structure here. */
        //public struct strHash
        //{
        //    int Key;
        //    int Value;
        //}

        public int[] HashDatatype;
        public MyHashSetArray()
        {
            HashDatatype = new int[0];
        }

        public void Add(int key)
        {
            if (Contains(key) == false)
            {
                Array.Resize(ref HashDatatype, HashDatatype.Length + 1);
                HashDatatype[HashDatatype.Length - 1] = key;
            }
        }

        public void Remove(int key)
        {
            if (HashDatatype.Length == 0)
            {
                return;
            }
            HashDatatype = Array.FindAll(HashDatatype, k => k != key).ToArray();
        }

        /** Returns true if this set contains the specified element */
        public bool Contains(int key)
        {
            bool result = false;
            if (HashDatatype.Length == 0)
            {
                return false;
            }
            foreach (int item in HashDatatype)
            {
                if (item == key)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }

    /**
     * Your MyHashSet object will be instantiated and called as such:
     * MyHashSet obj = new MyHashSet();
     * obj.Add(key);
     * obj.Remove(key);
     * bool param_3 = obj.Contains(key);
     */

}
