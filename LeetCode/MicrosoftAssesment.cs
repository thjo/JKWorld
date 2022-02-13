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

        }
    }
}
