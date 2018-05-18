using System;
using System.Collections;
using System.Collections.Generic;

namespace GraphicPic
{

    public class Node
    {
        public Figure Data { get; set; }
        public Node Next { get; set; }
    }

    public class SinglyLinkedList: IEnumerable
    {
        public int Count { get; private set; }

        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void Add(Figure item)
        {
            Node node = new Node() { Data = item };

            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        public bool Remove(Figure item)
        {
            Node previous = null;
            Node current = Head;

            while (current != null)
            {
                if (current.Data.Similar(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;
                        if (Head == null)
                            Tail = null;
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public Figure this[int index]
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();
                var item = Head;
                for (int i = 0; i < index; i++)
                    if (item.Next == null)
                        throw new IndexOutOfRangeException();
                    else
                        item = item.Next;
                return item.Data;
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
