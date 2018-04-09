using System;
using System.Collections.Generic;

namespace PatienceSort
{
    public class PriorityQueue<T> where T : IComparable
    {
        public List<Stack<T>> Piles { get; }

        public PriorityQueue(List<Stack<T>> piles)
        {
            Piles = piles;
            for (int i = piles.Count / 2; i >= 0; i--)
                SiftDown(i);
        }

        public T Min
        {
            get
            {
                T min = Piles[0].Pop();
                if (Piles[0].Count == 0)
                {
                    if (Piles.Count >= 1)
                        Swap(Piles, 0, Piles.Count - 1);
                    Piles.RemoveAt(Piles.Count - 1);
                }

                if (Piles.Count > 1)
                    SiftDown(0);
                return min;
            }
        }

        public void SiftDown(int i)
        {
            while (2 * i + 1 < Piles.Count)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                int j = left;

                if (right < Piles.Count &&
                    Piles[right].Peek().CompareTo(Piles[left].Peek()) <= 0)
                    j = right;

                if (Piles[i].Peek().CompareTo(Piles[j].Peek()) <= 0)
                    break;

                Swap(Piles, i, j);
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
}