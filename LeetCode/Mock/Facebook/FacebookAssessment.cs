using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class FacebookAssessment
    {
        #region | Onlin Assessment - 4/22/2022 | 

        public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            int i1 = 0, i2 = 0, i3 = 0;
            int n1 = arr1.Length, n2 = arr2.Length, n3 = arr3.Length;
            IList<int> res = new List<int>();
            while (i1 < n1 && i2 < n2 && i3 < n3)
            {
                if (arr1[i1] == arr2[i2] && arr2[i2] == arr3[i3])
                {
                    res.Add(arr1[i1]);
                    i1++; i2++; i3++;
                }
                else
                {
                    int max = Math.Max(arr1[i1], arr2[i2]);
                    max = Math.Max(max, arr3[i3]);
                    if (arr1[i1] < max)
                        i1++;
                    if (arr2[i2] < max)
                        i2++;
                    if (arr3[i3] < max)
                        i3++;
                }
            }

            return res;
        }


        /// <summary>
        /// 496. Next Greater Element I
        /// https://leetcode.com/problems/next-greater-element-i/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            ////Bruce Force
            //int n1 = nums1.Length;
            //int n2 = nums2.Length;
            //Dictionary<int, int> map = new Dictionary<int, int>();
            //for (int i = 0; i < n2; i++)
            //{
            //    map.Add(nums2[i], i);
            //}
            //int[] res = new int[n1];
            //for (int idx = 0; idx < n1; idx++)
            //{
            //    int val = nums1[idx];
            //    res[idx] = -1;
            //    for (int i = map[val] + 1; i < n2; i++)
            //    {
            //        if (nums2[i] > val)
            //        {
            //            res[idx] = nums2[i];
            //            break;
            //        }
            //    }
            //}
            //return res;

            Dictionary<int, int> map = new Dictionary<int, int>();
            Stack<int> wait = new Stack<int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                while (wait.Count > 0 && nums2[i] > wait.Peek())
                    map.Add(wait.Pop(), nums2[i]);
                wait.Push(nums2[i]);
            }

            while (wait.Count > 0)
                map.Add(wait.Pop(), -1);

            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                res[i] = map[nums1[i]];
            }

            return res;
        }

        #endregion


        #region | Onlin Assessment - 4/23/2022 | 

        /// <summary>
        /// 938. Range Sum of BST
        /// https://leetcode.com/problems/range-sum-of-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            //IList<int> arr = new List<int>();
            int total = 0;
            InorderTraversals(root, low, high, ref total);
            return total;
        }
        private void InorderTraversals(TreeNode root, int low, int high, ref int total)
        {
            //, IList<int> arr) {
            if (root == null)
                return;

            if (root.val < low)
                InorderTraversals(root.right, low, high, ref total);
            else if (root.val > high)
                InorderTraversals(root.left, low, high, ref total);
            else
            {
                total += root.val;
                InorderTraversals(root.left, low, high, ref total);
                InorderTraversals(root.right, low, high, ref total);
            }
        }

        #endregion


        #region | Onlin Assessment - 4/24/2022 | 

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 1)
                return 0;

            int maxProfit = 0;
            int minVal = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (minVal > prices[i])
                {
                    minVal = prices[i];
                }
                else
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - minVal);
                }
            }
            return maxProfit;
        }

        /// <summary>
        /// 238. Product of Array Except Self
        /// https://leetcode.com/problems/product-of-array-except-self/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {

            int n = nums.Length;
            int[] answers = new int[n];

            int sum = 1;
            for (int i = 0; i < n; i++)
            {
                answers[i] = sum;
                sum *= nums[i];
            }
            sum = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                answers[i] = answers[i] * sum;
                sum *= nums[i];
            }

            return answers;
        }
        #endregion


        #region | Onlin Assessment - 4/25/2022 | 

        public string ReverseVowels(string s)
        {
            int len = s.Length;
            int l = 0, r = len - 1;
            string lStr = "", rStr = "";
            while (l < len && r >= 0 && l <= r)
            {
                while (l < r && l < len && IsVowels(s[l]) == false)
                {
                    lStr += s[l++];
                }

                while (l < r && r >= 0 && IsVowels(s[r]) == false)
                {
                    rStr = s[r] + rStr;
                    r--;
                }

                if (l >= r)
                {
                    lStr += s[l];
                    break;
                }
                else if (l < len && r >= 0)
                {
                    lStr += s[r];
                    rStr = s[l] + rStr;
                    l++;
                    r--;
                }
            }

            return lStr + rStr;
        }
        private bool IsVowels(char c)
        {
            if (c == 'a' || c == 'A' || c == 'e' || c == 'E'
             || c == 'i' || c == 'I' || c == 'o' || c == 'O'
             || c == 'u' || c == 'U')
                return true;
            else
                return false;
        }


        /// <summary>
        /// 515. Find Largest Value in Each Tree Row
        /// https://leetcode.com/problems/find-largest-value-in-each-tree-row/
        /// </summary>
        public class TreeNodeInfo
        {
            public int Depth;
            public TreeNode Node;
            public TreeNodeInfo(int depth, TreeNode node)
            {
                Depth = depth;
                Node = node;
            }
        }
        public IList<int> LargestValues(TreeNode root)
        {
            IList<int> res = new List<int>();
            if (root == null)
                return res;

            Queue<TreeNodeInfo> q = new Queue<TreeNodeInfo>();
            q.Enqueue(new TreeNodeInfo(0, root));
            while (q.Count > 0)
            {
                TreeNodeInfo nd = q.Dequeue();
                if (nd.Depth + 1 > res.Count)
                    res.Add(int.MinValue);
                res[nd.Depth] = Math.Max(res[nd.Depth], nd.Node.val);

                if (nd.Node.left != null)
                    q.Enqueue(new TreeNodeInfo(nd.Depth + 1, nd.Node.left));
                if (nd.Node.right != null)
                    q.Enqueue(new TreeNodeInfo(nd.Depth + 1, nd.Node.right));
            }

            return res;
        }

        #endregion


        #region | Onlin Assessment - 4/26/2022 | 

        /// <summary>
        /// 71. Simplify Path
        /// https://leetcode.com/problems/simplify-path/
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SimplifyPath(string path)
        {
            Stack<string> sDir = new Stack<string>();
            string[] dirs = path.Split("/".ToCharArray());

            foreach (string dir in dirs)
            {
                if (dir == "." || string.IsNullOrEmpty(dir))
                    continue;
                else if (dir == "..")
                {
                    if (sDir.Count > 0)
                        sDir.Pop();
                }
                else
                    sDir.Push(dir);
            }

            String res = "";
            while (sDir.Count > 0)
                res = "/" + sDir.Pop() + res;

            return res.Length > 0 ? res : "/";
        }


        /// <summary>
        /// 270. Closest Binary Search Tree Value
        /// https://leetcode.com/problems/closest-binary-search-tree-value/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ClosestValue(TreeNode root, double target)
        {
            int res = root.val;
            double minDiff = int.MaxValue;
            Queue<TreeNode> qNodes = new Queue<TreeNode>();
            while (root != null)
            {
                double diff = root.val - target;
                if (minDiff > Math.Abs(diff))
                {
                    res = root.val;
                    minDiff = Math.Abs(diff);
                }

                if (root.left != null && diff > 0)
                    root = root.left;
                else if (root.right != null && diff < 0)
                    root = root.right;
                else
                    root = null;
            }
            return res;
        }

        #endregion


        #region | Onlin Assessment - 4/28/2022 | 

        /// <summary>
        /// 1528. Shuffle String
        /// https://leetcode.com/problems/shuffle-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public string RestoreString(string s, int[] indices)
        {
            char[] buff = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                buff[indices[i]] = s[i];
            }
            StringBuilder res = new StringBuilder();
            foreach (char c in buff)
                res.Append(c);

            return res.ToString();
        }

        /// <summary>
        /// 1266. Minimum Time Visiting All Points
        /// https://leetcode.com/problems/minimum-time-visiting-all-points/
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            int n = points.Length;
            int minTimes = 0;
            int[] start = points[0];
            for (int i = 1; i < n; i++)
            {
                int[] dest = points[i];
                minTimes += Math.Max(Math.Abs(start[0] - dest[0]), Math.Abs(start[1] - dest[1]));
                start = dest;
            }
            return minTimes;
        }
        #endregion


        #region | Onlin Assessment - 4/29/2022 | 

        /// <summary>
        /// 977. Squares of a Sorted Array
        /// https://leetcode.com/problems/squares-of-a-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortedSquares(int[] nums)
        {
            Stack<int> sNegative = new Stack<int>();
            int n = nums.Length;
            int[] res = new int[n];
            int newIdx = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    res[newIdx++] = 0;
                }
                else if (nums[i] < 0)
                {
                    //negative number
                    sNegative.Push(nums[i]);
                }
                else
                {
                    //positive number
                    while (sNegative.Count > 0
                          && sNegative.Peek() * -1 <= nums[i])
                    {
                        int tmp = sNegative.Pop();
                        res[newIdx++] = tmp * tmp;
                    }
                    res[newIdx++] = nums[i] * nums[i];
                }
            }
            while (sNegative.Count > 0)
            {
                int tmp = sNegative.Pop();
                res[newIdx++] = tmp * tmp;
            }

            return res;

            int len = nums.Length;
            int negativPoint = -1;

            int[] newSorted = new int[len];
            int idxNew = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    //Positive value
                    while (negativPoint > -1 && negativPoint < len
                        && nums[negativPoint] * nums[negativPoint] < nums[i] * nums[i])
                    {
                        newSorted[idxNew++] = nums[negativPoint] * nums[negativPoint];
                        negativPoint--;
                    }
                    newSorted[idxNew] = nums[i] * nums[i];
                    idxNew++;
                }
                else
                {
                    //Negative value
                    negativPoint = i;
                }
            }

            while (negativPoint > -1 && negativPoint < len)
            {
                newSorted[idxNew] = nums[negativPoint] * nums[negativPoint];
                idxNew++;
                negativPoint--;
            }

            return newSorted;
        }


        /// <summary>
        /// 791. Custom Sort String
        /// https://leetcode.com/problems/custom-sort-string/
        /// </summary>
        /// <param name="order"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public string CustomSortString(string order, string s)
        {
            Dictionary<char, string> strMap = new Dictionary<char, string>();
            foreach (char c in s)
            {
                if (strMap.ContainsKey(c))
                    strMap[c] += c;
                else
                    strMap.Add(c, c.ToString());
            }
            StringBuilder sbRes = new StringBuilder();
            foreach (char c in order)
            {
                if (strMap.ContainsKey(c))
                {
                    sbRes.Append(strMap[c]);
                    strMap.Remove(c);
                }
            }
            foreach (var v in strMap)
            {
                sbRes.Append(v.Value);
            }
            return sbRes.ToString();
        }
        #endregion


    }
}
