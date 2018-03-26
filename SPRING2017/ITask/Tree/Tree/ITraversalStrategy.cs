using System;
using System.Collections.Generic;
using BinaryTree;

namespace BinaryTree
{
    public interface ITraversalStrategy<T> where T : IComparable<T>
    {
        IEnumerator<T> Traversal(BinaryTreeNode<T> node);
    }
}
