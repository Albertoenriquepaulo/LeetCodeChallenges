using System;
using System.Collections.Generic;
using System.Linq;

namespace CarPooling
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
        public bool CarPooling(int[][] trips, int capacity)
        {
            List<(int, int)> listTuples = new List<(int, int)>();
            int currPassengers = 0;
            var tripsOrdered = trips.OrderBy(t => t[1]);
            foreach (var trip in tripsOrdered)
            {
                if (listTuples.Count > 0)
                    for (int i = 0; i < listTuples.Count; i++)
                        if (listTuples[i].Item1 <= trip[1])
                        {
                            currPassengers -= listTuples[i].Item2;
                            listTuples.RemoveAt(i--);
                        }

                listTuples.Add((trip[2], trip[0]));
                currPassengers += trip[0];
                if (currPassengers > capacity)
                    return false;
            }

            return true;

        }
    }
}
