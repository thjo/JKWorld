﻿using System;
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


        #region | Microsoft - Technical Assessment - 02/13/2022 | 

        public bool solutionOrg(int[] A, int K)
        {
            int n = A.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] > A[i + 1])
                    return false;
            }
            if (A[0] < 1 && A[n - 1] > K)
                return false;
            else
                return true;
        }

        public bool solutionFix(int[] A, int K)
        {
            int n = A.Length;
            for (int i = 0; i < n - 1; i++) {
                if (A[i] > A[i + 1])
                    return false;
            }
            if (A[0] < 1 || A[n - 1] > K)
                return false;
            else
                return true;
        }


        public bool solution(string S, string T)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            string newS = ConvertToPattern(S);
            string newT = ConvertToPattern(T);

            if (newS.Length != newT.Length)
                return false;
            else
            {
                for(int i = 0; i < newS.Length; i++)
                {
                    if (newS[i] == '*' || newT[i] == '*'
                        || newS[i] == newT[i])
                        continue;
                    else
                        return false;
                }
            }
            return true;
        }
        private string ConvertToPattern(string str)
        {
            string newStr = "";
            string num = "";
            foreach (char c in str)
            {
                if (Char.IsDigit(c))
                    num += c;
                else
                {
                    if( num.Length > 0)
                    {
                        int n = int.Parse(num);
                        for (int i = 0; i < n; i++)
                            newStr += "*";

                        num = "";
                    }
                    newStr += c;
                }
            }
            if (num.Length > 0)
            {
                int n = int.Parse(num);
                for (int i = 0; i < n; i++)
                    newStr += "*";

                num = "";
            }
            return newStr;
        }


        #endregion


        #region | Phone Interview - 2/15/2022 | 

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
                return null;

            if (root.val == p.val || root.val == q.val)
                return root;

            TreeNode leftLowest = LowestCommonAncestor(root.left, p, q);
            TreeNode rightLowest = LowestCommonAncestor(root.right, p, q);

            if (leftLowest != null && rightLowest != null)
                return root;
            else if (leftLowest == null && rightLowest == null)
                return null;

            return leftLowest != null ? leftLowest : rightLowest;
        }


        /// <summary>
        /// 165. Compare Version Numbers
        /// https://leetcode.com/problems/compare-version-numbers/
        /// </summary>
        /// <param name="version1"></param>
        /// <param name="version2"></param>
        /// <returns></returns>
        public int CompareVersion(string version1, string version2)
        {
            int p1 = 0, p2 = 0;
            int n1 = version1.Length, n2 = version2.Length;

            int v1, v2;
            int[] pair = null;
            while (p1 < n1 || p2 < n2)
            {
                pair = GetNextChunk(version1, n1, p1);
                v1 = pair[0];
                p1 = pair[1];

                pair = GetNextChunk(version2, n2, p2);
                v2 = pair[0];
                p2 = pair[1];

                if (v1 != v2)
                    return v1 > v2 ? 1 : -1;
            }

            // the versions are equal
            return 0;
        }
        private int[] GetNextChunk(string version, int n, int p)
        {
            int[] pair = new int[2];
            if (p >= n)
            {
                pair[0] = 0;
                pair[1] = p;
                return pair;
            }

            // find the end of chunk        
            int i, pEnd = p;
            string val = "";
            while (pEnd < n && version[pEnd] != '.')
            {
                val = val + version[pEnd].ToString();
                pEnd++;
            }

            // retrieve the chunk
            i = int.Parse(val);

            // find the beginning of next chunk
            p = pEnd + 1;

            pair[0] = i;
            pair[1] = p;
            return pair;
        }
        #region | Bruce Force |
        //public int CompareVersion(string version1, string version2)
        //{
        //    List<int> ver1 = DisassembleVersion(version1);
        //    List<int> ver2 = DisassembleVersion(version2);

        //    int res = 0;
        //    int i = 0;
        //    while (i < ver1.Count && i < ver2.Count)
        //    {
        //        if (ver1[i] > ver2[i])
        //            return 1;
        //        else if (ver1[i] < ver2[i])
        //            return -1;
        //    }

        //    if (ver1.Count > ver2.Count)
        //    {
        //        while (i < ver1.Count)
        //        {
        //            if (ver1[i] > 0)
        //                return 1;
        //        }
        //    }
        //    else if (ver1.Count < ver2.Count)
        //    {
        //        while (i < ver2.Count)
        //        {
        //            if (ver2[i] > 0)
        //                return -1;
        //        }
        //    }


        //    return res;
        //}
        //private List<int> DisassembleVersion(string version)
        //{
        //    List<int> ver = new List<int>();
        //    if (version == null || version.Length < 1)
        //        return ver;

        //    int i = 0;
        //    int? tmpNum = null;
        //    while (i < version.Length)
        //    {
        //        if (version[i] == '.')
        //        {
        //            if (tmpNum != null)
        //                ver.Add(tmpNum.Value);
        //            tmpNum = null;
        //        }
        //        else
        //        {
        //            if (tmpNum == null)
        //                tmpNum = int.Parse(version[i].ToString());
        //            else
        //                tmpNum = tmpNum * 10 + int.Parse(version[i].ToString());
        //        }
        //        i++;
        //    }
        //    if (tmpNum != null)
        //        ver.Add(tmpNum.Value);
        //    return ver;
        //}
        #endregion

        /// <summary>
        /// 43. Multiply Strings
        /// https://leetcode.com/problems/multiply-strings/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";
            if (num1.Length > num2.Length)
            {
                String tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
            int num1_len = num1.Length, num2_len = num2.Length;
            int[] res = new int[num1_len + num2_len];
            for (int i = 0; i < res.Length; i++)
                res[i] = 0;

            for (int i = num1_len - 1; i >= 0; i--)
            {
                for (int j = num2_len - 1; j >= 0; j--)
                {
                    int p1 = i + j, p2 = p1 + 1;
                    int sum = (num1[i] - '0') * (num2[j] - '0') + res[p2];
                    res[p2] = sum % 10;
                    res[p1] += sum / 10;
                }
            }
            String output = ""; int idx = -1;
            for (int i = 0; i < num1_len + num2_len && res[i] == 0; i++)
                idx = i;
            for (int i = idx + 1; i < num1_len + num2_len; i++)
                output += res[i].ToString();
            return output;
        }

        // Multiply the current digit of secondNumber with firstNumber.
        List<int> MultiplyOneDigit(StringBuilder sbN1, char secondNumberDigit, int numZeros)
        {
            // Insert zeros at the beginning based on the current digit's place.
            List<int> currentResult = new List<int>();
            for (int i = 0; i < numZeros; ++i)
            {
                currentResult.Add(0);
            }

            int carry = 0;

            // Multiply firstNumber with the current digit of secondNumber.
            for (int i = 0; i < sbN1.Length; ++i)
            {
                char firstNumberDigit = sbN1[i];
                int multiplication = (secondNumberDigit - '0') * (firstNumberDigit - '0') + carry;
                // Set carry equal to the tens place digit of multiplication.
                carry = multiplication / 10;
                // Append last digit to the current result.
                currentResult.Add(multiplication % 10);
            }

            if (carry != 0)
            {
                currentResult.Add(carry);
            }
            return currentResult;
        }
        private List<int> AddStrings(List<int> num1, List<int> num2)
        {
            List<int> ans = new List<int>();
            int carry = 0;

            for (int i = 0; i < num1.Count || i < num2.Count; ++i)
            {
                // If num2 is shorter than num1 or vice versa, use 0 as the current digit.
                int digit1 = i < num1.Count ? num1[i] : 0;
                int digit2 = i < num2.Count ? num2[i] : 0;

                // Add current digits of both numbers.
                int sum = digit1 + digit2 + carry;
                // Set carry equal to the tens place digit of sum.
                carry = sum / 10;
                // Append the ones place digit of sum to answer.
                ans.Add(sum % 10);
            }

            if (carry != 0)
            {
                ans.Add(carry);
            }
            return ans;
        }

        #endregion
    }
}
