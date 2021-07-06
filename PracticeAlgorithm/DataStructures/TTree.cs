using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm.DataStructures
{
    public class TNode
    {
        TNode left;
        TNode right;
        int data;

        public TNode(int data)
        {
            this.data = data;
        }

        public void Insert(int value)
        {
            if (value <= data)
            {
                if (left == null)
                    left = new TNode(data);
                else
                    left.Insert(data);
            }
            else
            {
                if (right == null)
                    right = new TNode(value);
                else
                    right.Insert(value);
            }
        }

        public bool Contains(int value)
        {
            if (value == data)
                return true;
            else if (value < data)
            {
                if (left == null)
                    return false;
                else
                    return left.Contains(value);
            }
            else
            {
                if (right == null)
                    return false;
                else
                    return right.Contains(value);
            }
        }

        public int Height(Node root)
        {
            if (root == null)
                return 0;

            int leftHeight = 0;
            int rightHeight = 0;
            if (root.left != null)
                leftHeight = Height(root.left);
            if (root.right != null)
                rightHeight = Height(root.right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }


        public void PrintInOrder()
        {
            if (left != null)
                left.PrintInOrder();

            Print(data);

            if (right != null)
                right.PrintInOrder();
        }
        public void PrintPreOrder()
        {
            Print(data);

            if (left != null)
                left.PrintPreOrder();

            if (right != null)
                right.PrintPreOrder();
        }
        public void PrintPostOrder()
        {
            if (left != null)
                left.PrintPostOrder();

            if (right != null)
                right.PrintPostOrder();

            Print(data);
        }


        private void Print(int value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

    }
}
