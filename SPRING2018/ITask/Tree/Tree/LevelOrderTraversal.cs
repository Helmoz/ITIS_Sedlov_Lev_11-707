using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class LevelOrderTraversal<T> : ITraversalStrategy<T> where T : IComparable<T>
    {
        public IEnumerator<T> Traversal(BinaryTreeNode<T> node)
        {
            var queue = new Queue<BinaryTreeNode<T>>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                yield return current.Value;

                if (current.Left != null)
                    queue.Enqueue(current.Left);
                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }

        }
    }
}
