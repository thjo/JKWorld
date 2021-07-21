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
            if(root == null)
                return 0;

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        //Validate Binary Search Tree
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/625/
        public bool IsValidBST(TreeNode root)
        {
            return ValidBST(root, null, null);
        }
        public bool ValidBST(TreeNode node, int? low, int? high)
        {
            if (node == null)
                return true;

            if ((low != null && low.Value >= node.val)
                || (high != null && high.Value <= node.val))
                return false;

            return ValidBST(node.left, low, node.val) && ValidBST(node.right, node.val, high);
        }



        //Symmetric Tree
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/627/
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            return IsMirror(root.left, root.right);
        }
        public bool IsMirror(TreeNode nodeLeft, TreeNode nodeRight)
        {
            if (nodeLeft == null && nodeRight == null)
                return true;
            else if (nodeLeft == null || nodeRight == null)
                return false;

            if (nodeLeft.val == nodeRight.val)
                return IsMirror(nodeLeft.left, nodeRight.right) && IsMirror(nodeLeft.right, nodeRight.left);
            else
                return false;
        }



        // Binary Tree Level Order Traversal
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/628/
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            return null;
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
