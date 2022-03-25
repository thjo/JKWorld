﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class AmazonAssessment
    {
        #region | Onsite Interview - 3/24/2022 | 

        /// <summary>
        /// 13. Roman to Integer
        /// https://leetcode.com/problems/roman-to-integer/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            map.Add("I", 1);
            map.Add("IV", 4);
            map.Add("V", 5);
            map.Add("IX", 9);
            map.Add("X", 10);
            map.Add("XL", 40);
            map.Add("L", 50);
            map.Add("XC", 90);
            map.Add("C", 100);
            map.Add("CD", 400);
            map.Add("D", 500);
            map.Add("CM", 900);
            map.Add("M", 1000);

            int idx = 0;
            int sum = 0;
            while (idx < s.Length)
            {
                if (idx + 1 < s.Length
                  && map.ContainsKey(s.Substring(idx, 2)))
                {
                    sum += map[s.Substring(idx, 2)];
                    idx += 2;
                }
                else
                {
                    sum += map[s[idx].ToString()];
                    idx++;
                }
            }

            return sum;
        }


        /// <summary>
        /// 236. Lowest Common Ancestor of a Binary Tree
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return root;

            if (root.val == p.val || root.val == q.val)
                return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
                return root;
            else if (left == null & right == null)
                return null;
            else
                return left != null ? left : right;            
        }






        #endregion
    }
}
