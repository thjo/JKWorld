using LeetCode.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class LeetCode75_II
    {


        /// <summary>
        /// 226. Invert Binary Tree
        /// https://leetcode.com/problems/invert-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return root;


            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }


        /// <summary>
        /// 543. Diameter of Binary Tree
        /// https://leetcode.com/problems/diameter-of-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int ans = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;

            DFS(root);
            return ans;
        }
        public int DFS(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = DFS(root.left);
            int right = DFS(root.right);
            ans = Math.Max(ans, left + right);
            return Math.Max(left, right) + 1;
        }


        /// <summary>
        /// 108. Convert Sorted Array to Binary Search Tree
        /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return AddNodes(0, nums.Length - 1, nums);
        }
        private TreeNode AddNodes(int left, int right, int[] nums)
        {
            if (left > right)
                return null;

            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = AddNodes(left, mid - 1, nums);
            root.right = AddNodes(mid + 1, right, nums);

            return root;
        }

    }
}
