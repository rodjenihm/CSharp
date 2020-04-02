using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root => root;

        public BinaryTree()
        {
        }

        /// <summary>
        /// Inserts element at first available position in tree
        /// </summary>
        /// <param name="item"></param>
        public virtual void Insert(T item)
        {
            var newNode = new BinaryTreeNode<T>(item);

            if (IsEmpty())
            {
                root = newNode;
                return;
            }

            var nodesQueue = new Queue<BinaryTreeNode<T>>();

            var temp = root;

            nodesQueue.Enqueue(temp);

            while (nodesQueue.Count != 0)
            {
                temp = nodesQueue.Dequeue();

                if (temp.left == null)
                {
                    temp.left = newNode;
                    break;
                }
                else
                {
                    nodesQueue.Enqueue(temp.left);
                }

                if (temp.right == null)
                {
                    temp.right = newNode;
                    break;
                }
                else
                {
                    nodesQueue.Enqueue(temp.right);
                }
            }
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        private BinaryTreeNode<T> root = null;
    }
}
