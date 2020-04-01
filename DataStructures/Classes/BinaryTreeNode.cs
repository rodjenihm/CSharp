using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Classes
{
    public class BinaryTreeNode<T>
    {
        public T Value { get => value; set => this.value = value; }
        public BinaryTreeNode<T> Left { get => left; set => left = value; }
        public BinaryTreeNode<T> Right { get => right; set => right = value; }

        public BinaryTreeNode() : this(default, null, null)
        {
        }

        public BinaryTreeNode(T value) : this(value, null, null)
        {
        }

        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        internal T value;
        internal BinaryTreeNode<T> left;
        internal BinaryTreeNode<T> right;
    }
}
