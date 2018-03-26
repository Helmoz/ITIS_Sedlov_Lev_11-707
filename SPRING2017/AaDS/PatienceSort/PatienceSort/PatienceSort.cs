using System;
using System.Collections.Generic;

namespace PatienceSort
{
    class PriorityQueue<T> where T : IComparable
    {
        private List<Stack<T>> piles;

        public PriorityQueue(List<Stack<T>> piles)
        {
            this.piles = piles;
            for (int i = piles.Count / 2; i >= 0; i--)
                SiftDown(i);
        }

        public T Min
        {
            get
            {
                T min = piles[0].Pop();
                if (piles[0].Count == 0)
                {
                    if (piles.Count >= 1)
                        Swap(piles, 0, piles.Count - 1);
                    piles.RemoveAt(piles.Count - 1);
                }

                if (piles.Count > 1)
                    SiftDown(0);
                return min;
            }
        }

        public void SiftDown(int i)
        {
            while (2 * i + 1 < piles.Count)
            {
                int left = 2 * i + 1;

                int right = 2 * i + 2;

                int j = left;

                if (right < piles.Count && piles[right].Peek().CompareTo(piles[left].Peek()) <= 0)
                    j = right;

                if (piles[i].Peek().CompareTo(piles[j].Peek()) <= 0)
                    break;

                Swap(piles, i, j);

                i = j;
            }
        }

        private static void Swap<TItem>(List<TItem> list, int i, int j)
        {
            var tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }

    }

    class PatienceSort<T> where T : IComparable
    {
        public static List<Stack<T>> Piles = new List<Stack<T>>();

        public static int Iterations { get; set; }

        public static void Sort(List<T> list)
        {
            Piles = new List<Stack<T>>();
            Iterations = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int j = BinarySearch(list[i]);

                if (j == Piles.Count)
                {
                    Piles.Add(new Stack<T>());
                    Piles[Piles.Count - 1].Push(list[i]);
                }
                else
                    Piles[j].Push(list[i]);

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
            int left = 0, rigth = Piles.Count - 1;
            while (left <= rigth)
            {
                int mid = (left + rigth) / 2;
                if (Piles[mid].Peek().CompareTo(item) >= 0)
                    rigth = mid - 1;
                else
                    left = mid + 1;
                Iterations++;
            }
            return left;
        }
    }
}
