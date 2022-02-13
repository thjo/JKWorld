using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MicrosoftAssesment
    {
        /// <summary>
        /// 88. Merge Sorted Array
        /// https://leetcode.com/problems/merge-sorted-array/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums1.Length == 0 || n == 0)
                return;

            int[] res = new int[nums1.Length];
            int i = 0;
            int idx1 = 0, idx2 = 0;
            while (idx1 < m && idx2 < n)
            {
                if (nums1[idx1] > nums2[idx2])
                {
                    res[i++] = nums2[idx2];
                    idx2++;
                }
                else
                {
                    res[i++] = nums1[idx1];
                    idx1++;
                }
            }
            for (int j = idx1; j < m; j++)
                res[i++] = nums1[j];
            for (int j = idx2; j < n; j++)
                res[i++] = nums2[j];

            for (int j = 0; j < res.Length; j++)
                nums1[j] = res[j];
        }

        /// <summary>
        /// 285. Inorder Successor in BST
        /// https://leetcode.com/problems/inorder-successor-in-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            TreeNode successor = null;

            while (root != null)
            {

                if (p.val >= root.val)
                {
                    root = root.right;
                }
                else
                {
                    successor = root;
                    root = root.left;
                }
            }

            return successor;
        }

        private TreeNode previous;
        private TreeNode inorderSuccessorNode;
        public TreeNode InorderSuccessorII(TreeNode root, TreeNode p)
        {
            // Case 1: We simply need to find the leftmost node in the subtree rooted at p.right.
            if (p.right != null)
            {

                TreeNode leftmost = p.right;

                while (leftmost.left != null)
                {
                    leftmost = leftmost.left;
                }

                this.inorderSuccessorNode = leftmost;
            }
            else
            {

                // Case 2: We need to perform the standard inorder traversal and keep track of the previous node.
                this.InorderCase2(root, p);
            }

            return this.inorderSuccessorNode;
        }

        private void InorderCase2(TreeNode node, TreeNode p)
        {

            if (node == null)
            {
                return;
            }

            // Recurse on the left side
            this.InorderCase2(node.left, p);

            // Check if previous is the inorder predecessor of node
            if (this.previous == p && this.inorderSuccessorNode == null)
            {
                this.inorderSuccessorNode = node;
                return;
            }

            // Keeping previous up-to-date for further recursions
            this.previous = node;

            // Recurse on the right side
            this.InorderCase2(node.right, p);
        }


        /// <summary>
        /// 75. Sort Colors
        /// https://leetcode.com/problems/sort-colors/
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return;

            int[] colors = new int[3];
            foreach (int color in nums)
                colors[color]++;

            int c = 0;
            int i = 0;
            while (c < 3 && i < nums.Length)
            {
                if (colors[c] <= 0)
                    c++;
                else
                {
                    nums[i++] = c;
                    colors[c]--;
                }
            }
        }


        /// <summary>
        /// 402. Remove K Digits
        /// https://leetcode.com/problems/remove-k-digits/
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveKdigits(string num, int k)
        {
            if (num == null || num.Length < 1)
                return "0";

            Stack<char> sNums = new Stack<char>();
            sNums.Push(num[0]);
            for (int i = 1; i < num.Length; i++)
            {
                while (sNums.Count > 0 && k > 0
                     && sNums.Peek() > num[i])
                {
                    sNums.Pop();
                    k--;
                }
                sNums.Push(num[i]);
            }
            for (int i = 0; i < k; i++)
                sNums.Pop();

            string res = "";
            while (sNums.Count > 0)
            {
                res = sNums.Pop().ToString() + res;
            }
            int j = 0;
            while (j < res.Length && res[j] == '0')
                j++;
            if (res.Length == j)
                return "0";
            else
                return res.Substring(j);

        }
    }
}
