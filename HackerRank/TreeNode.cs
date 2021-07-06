using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int data)
        {
            this.val = data;
        }

        public void Insert(int value)
        {
            if (value <= val)
            {
                if (left == null)
                    left = new TreeNode(val);
                else
                    left.Insert(val);
            }
            else
            {
                if (right == null)
                    right = new TreeNode(value);
                else
                    right.Insert(value);
            }
        }

        public bool Contains(int value)
        {
            if (value == val)
                return true;
            else if (value < val)
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


        public void PrintInOrder()
        {
            if (left != null)
                left.PrintInOrder();

            Print(val);

            if (right != null)
                right.PrintInOrder();
        }
        public void PrintPreOrder()
        {
            Print(val);

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

            Print(val);
        }


        private void Print(int value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

    }
}
