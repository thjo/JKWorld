using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TopInterviewQuestions_Trees
    {
        //Maximum Depth of Binary Tree
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/555/
        public int MaxDepth(TreeNode root)
        {
            return 0;
        }
    }

    /// <summary>
    /// Definition for a binary tree node.
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public void Insert(int value)
        {
            if( value <= this.val)
            {
                //to add it on left side
                if (this.left != null)
                    this.left.Insert(value);
                else
                    this.left = new TreeNode(value);
            }
            else
            {
                //to add it on right side
                if (this.right != null)
                    this.right.Insert(value);
                else
                    this.right = new TreeNode(value);
            }
        }


        public bool Contains(int value) 
        {
            if (value == this.val)
                return true;
            else if (value < this.val)
                return this.left == null ? false : this.left.Contains(value);
            else 
                return this.right == null ? false : this.right.Contains(value);
        }


        public void PrintInOrder()
        {
            if(this.left != null)
                this.left.PrintInOrder();

            Print(this.val);

            if(this.right != null)
                this.right.PrintInOrder();
        }

        public void PrintPreOrder()
        {
            Print(this.val);

            if (this.left != null)
                this.left.PrintPreOrder();

            if (this.right != null)
                this.right.PrintPreOrder();
        }


        public void PrintPostOrder()
        {
            if (this.left != null)
                this.left.PrintPostOrder();

            if (this.right != null)
                this.right.PrintPostOrder();

            Print(this.val);
        }

        private void Print(int value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            System.Console.WriteLine(value);
        }
    }
}
