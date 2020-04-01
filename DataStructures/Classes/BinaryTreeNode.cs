using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Classes
{
    public class BinaryTreeNode<T>
    {
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
