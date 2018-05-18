using System;
using System.Collections.Generic;

namespace PatienceSort
{
    class PatienceSort<T> where T : IComparable
    {
        public static List<Stack<T>> Piles = new List<Stack<T>>();

        public static long Iterations { get; set; }

        public static void Sort(List<T> list)
        {
            Piles = new List<Stack<T>>();
            Iterations = 0;
            foreach (var item in list)
            {
                int j = BinarySearch(item);
                if (j == Piles.Count)
                {
                    Piles.Add(new Stack<T>());
                    Piles[Piles.Count - 1].Push(item);
                }
                else
                    Piles[j].Push(item);

                Iterations++;
            }

            PriorityQueue<T> priorityQueue = new PriorityQueue<T>(Piles);

            int count = 0;

            while (Piles.Count != 0)
            {
                list[count++] = priorityQueue.Min;
                Iterations++;
            }
        }

        private static int BinarySearch(T item)
        {
            int left = 0, right = Piles.Count - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (Piles[mid].Peek().CompareTo(item) >= 0)
                    right = mid - 1;
                else
                    left = mid + 1;
                Iterations++;
            }
            return left;
        }
    }
}
