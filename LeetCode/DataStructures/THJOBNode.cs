using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class THJOBNode
    {
        THJOBNode left, right;
        int data;

        public THJOBNode(int data)
        {
            this.data = data;
        }

        public void Insert(int value)
        {
            if(value >= data)
            {
                if (this.right != null)
                    this.right.Insert(value);
                else
                    this.right = new THJOBNode(value);
            }
            else
            {
                if (this.left != null)
                    this.left.Insert(value);
                else
                    this.left = new THJOBNode(value);
            }
        }

        public bool Contains(int value)
        {
            if (this.data == value)
                return true;
            else if (this.data > value)
            {
                if (this.left == null)
                    return false;
                return this.left.Contains(value);
            }
            else
            {
                if (this.right == null)
                    return false;
                return this.right.Contains(value);
            }
        }

        public void PrintInOrder()
        {
            if (this.left != null)
                this.left.PrintInOrder();

            System.Diagnostics.Debug.WriteLine(this.data);

            if (this.right != null)
                this.right.PrintInOrder();
        }

        public void PrintPreOrder()
        {
            System.Diagnostics.Debug.WriteLine(this.data);

            if (this.left != null)
                this.left.PrintInOrder();

            if (this.right != null)
                this.right.PrintInOrder();
        }

        public void PrintPostOrder()
        {
            if (this.left != null)
                this.left.PrintInOrder();

            if (this.right != null)
                this.right.PrintInOrder();

            System.Diagnostics.Debug.WriteLine(this.data);
        }
    }
}
