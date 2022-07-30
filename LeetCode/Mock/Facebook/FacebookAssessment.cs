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


        #region | OnSite Assessment - 05/01/2022 | 

        /// <summary>
        /// 438. Find All Anagrams in a String
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> res = new List<int>();
            int sn = s.Length;
            int pn = p.Length;
            if (sn < pn)
                return res;

            int[] sCnt = new int[26];
            int[] pCnt = new int[26];
            foreach (char c in p)
                pCnt[c - 'a']++;

            // sliding window on the string s
            for (int i = 0; i < sn; i++)
            {
                sCnt[s[i] - 'a']++;
                //remove a letter from the left side of the window
                if (i >= pn)
                    sCnt[s[i - pn] - 'a']--;
                if (IsAnagram(pCnt, sCnt))
                    res.Add(i - pn + 1);
            }

            return res;
        }
        private bool IsAnagram(int[] sCnt, int[] pCnt)
        {
            for (int i = 0; i < sCnt.Length; i++)
            {
                if (sCnt[i] != pCnt[i])
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 1123. Lowest Common Ancestor of Deepest Leaves
        /// https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/
        /// </summary>
        List<TreeNode> Deepest = new List<TreeNode>();
        int MaxDepth = 0;
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            if (root == null) return root;

            GetDeepestNodes(root, 0);

            //Now among all of the deepest nodes find the lca(deepest[0], deepest[1], ... deepest[n-1])
            if (Deepest.Count == 1) return Deepest[0];
            if (Deepest.Count == 2) return Lca(root, Deepest[0], Deepest[1]);

            TreeNode lca = Lca(root, Deepest[0], Deepest[1]);
            for (int i = 2; i < Deepest.Count; i++)
            {
                lca = Lca(root, lca, Deepest[i]);
            }

            return lca;
        }


        private TreeNode Lca(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root == p) return p;
            if (root == q) return q;

            TreeNode left = Lca(root.left, p, q);
            TreeNode right = Lca(root.right, p, q);

            if (left != null && right != null) return root;
            if (left != null && right == null) return Lca(root.left, p, q);
            //if (left == null && right != null)
            return Lca(root.right, p, q);
        }

        private void GetDeepestNodes(TreeNode root, int depth)
        {
            if (depth > MaxDepth)
            {
                MaxDepth = depth; //Update the maximum depth
                Deepest.Clear(); //Erase old candidates
                                 //add this node as a candidate
                Deepest.Add(root);
            }
            else if (depth == MaxDepth)
            {
                Deepest.Add(root); //This node is one of the deepest children.
            }

            //Now try traversing the rest of the binary tree
            if (root.left != null) GetDeepestNodes(root.left, depth + 1);
            if (root.right != null) GetDeepestNodes(root.right, depth + 1);
        }



        /// <summary>
        /// 416. Partition Equal Subset Sum
        /// https://leetcode.com/problems/partition-equal-subset-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int n = nums.Length;
            int totalSum = 0;
            foreach (int num in nums)
                totalSum += num;

            if (totalSum % 2 != 0) return false;
            int subSetSum = totalSum / 2;
            bool[] dp = new bool[subSetSum + 1];
            dp[0] = true;
            foreach (int curr in nums)
            {
                for (int j = subSetSum; j >= curr; j--)
                    dp[j] |= dp[j - curr];
            }

            return dp[subSetSum];


        }
        #endregion


        #region | Online Assessment - 05/03/2022 | 

        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode newHead = new ListNode(-1);
            ListNode currNode = newHead;

            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    currNode.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    currNode.next = l1;
                    l1 = l1.next;
                }

                currNode = currNode.next;
            }

            if (l1 != null)
                currNode.next = l1;
            if (l2 != null)
                currNode.next = l2;

            return newHead.next;
        }


        /// <summary>
        /// 325. Maximum Size Subarray Sum Equals k
        /// https://leetcode.com/problems/maximum-size-subarray-sum-equals-k/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSubArrayLen(int[] nums, int k)
        {
            int maxLen = 0;
            int prefixSum = 0;
            Dictionary<int, int> indices = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];
                if (prefixSum == k)
                    maxLen = i + 1;

                if (indices.ContainsKey(prefixSum - k))
                    maxLen = Math.Max(maxLen, i - indices[prefixSum - k]);

                if (!indices.ContainsKey(prefixSum))
                    indices.Add(prefixSum, i);
            }

            return maxLen;
        }

        /// <summary>
        /// 209. Minimum Size Subarray Sum
        /// https://leetcode.com/problems/minimum-size-subarray-sum/
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int target, int[] nums)
        {
            int minLen = nums.Length + 1;
            int start = 0;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (sum >= target)
                {
                    minLen = Math.Min(minLen, i - start + 1);
                    sum -= nums[start++];
                }
            }

            return minLen == nums.Length + 1 ? 0 : minLen;
        }

        #endregion


        #region | Online Assessment - 05/04/2022 | 

        /// <summary>
        /// 1360. Number of Days Between Two Dates
        /// https://leetcode.com/problems/number-of-days-between-two-dates/
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public int DaysBetweenDates(string date1, string date2)
        {

            int days1 = CalNumOfDays(date1);
            int days2 = CalNumOfDays(date2);

            return Math.Abs(days1 - days2);

        }
        private bool IsLeapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0)
                return true;
            else if (year % 400 == 0)
                return true;
            else return false;
        }
        private int CalNumOfDays(string date)
        {
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(5, 2));
            int days = int.Parse(date.Substring(8));

            for (int yr = 1971; yr < year; yr++)
            {
                if (IsLeapYear(yr)) days += 1;
                days += 365;
            }
            for (int mth = 0; mth < month - 1; mth++)
            {
                if (mth == 1 && IsLeapYear(year)) days += 1;
                days += months[mth];
            }
            return days;
        }

        /// <summary>
        /// 1154. Day of the Year
        /// https://leetcode.com/problems/day-of-the-year/
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int DayOfYear(string date)
        {
            int[] months = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(5, 2));
            int day = int.Parse(date.Substring(8, 2));

            int days = 0;
            if (IsLeapYear2(year) && month >= 3)
                days += 1;

            for (int m = 1; m < month; m++)
                days += months[m];

            days += day;

            return days;
        }
        private bool IsLeapYear2(int yr)
        {
            if (yr % 4 == 0 && yr % 100 != 0)
                return true;
            else if (yr % 400 == 0)
                return true;
            else return false;
        }
        public class BinaryMatrix
        {
            public int Get(int row, int col) { return 0; }
            public IList<int> Dimensions() { return null; }
        }
        /// <summary>
        /// 1428. Leftmost Column with at Least a One
        /// 
        /// </summary>
        /// <param name="binaryMatrix"></param>
        /// <returns></returns>
        public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            int rows = binaryMatrix.Dimensions()[0];
            int cols = binaryMatrix.Dimensions()[1];

            // Set pointers to the top-right corner.
            int currentRow = 0;
            int currentCol = cols - 1;

            // Repeat the search until it goes off the grid.
            while (currentRow < rows && currentCol >= 0)
            {
                if (binaryMatrix.Get(currentRow, currentCol) == 0)
                {
                    currentRow++;
                }
                else
                {
                    currentCol--;
                }
            }

            // If we never left the last column, this is because it was all 0's.
            return (currentCol == cols - 1) ? -1 : currentCol + 1;
        }

        #endregion


        #region | Phone Interview - 07/30/2022 | 

        /// <summary>
        /// 349. Intersection of Two Arrays
        /// https://leetcode.com/problems/intersection-of-two-arrays/solution/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            //Sort
            Array.Sort(nums1);
            Array.Sort(nums2);
            List<int> intersections = new List<int>();

            int idx1 = 0, idx2 = 0;
            while (idx1 < nums1.Length && idx2 < nums2.Length)
            {
                if (nums1[idx1] == nums2[idx2])
                {
                    if (intersections.Contains(nums1[idx1]) == false)
                        intersections.Add(nums1[idx1]);
                    idx1++; idx2++;
                }
                else if (nums1[idx1] > nums2[idx2])
                {
                    idx2++;
                }
                else
                {
                    idx1++;
                }
            }

            return intersections.ToArray();
        }

        /// <summary>
        /// 340. Longest Substring with At Most K Distinct Characters
        /// https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int l = 0, r = 0;
            int maxLen = 0;
            while (r < s.Length)
            {
                if (dic.ContainsKey(s[r]) == false)
                    dic.Add(s[r], 0);
                dic[s[r]]++;

                while (dic.Count > k)
                {
                    //Remove
                    dic[s[l]]--;
                    if (dic[s[l]] == 0)
                        dic.Remove(s[l]);
                    l++;
                }

                maxLen = Math.Max(maxLen, r - l + 1);
                r++;
            }

            return maxLen;
        }


        /// <summary>
        /// 395. Longest Substring with At Least K Repeating Characters
        /// https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestSubstring(string s, int k)
        {
            int longestLen = 0;
            int maxUniqueChars = GetUniqueChars(s);

            //유니크한 문자 갯수가 각각 들어갔을 때를 가정하여 반복문으로 품
            for (int currUnique = 1; currUnique < maxUniqueChars; currUnique++)
            {
                longestLen = Math.Max(longestLen, LongestSubstringWithKUniqueChars(s, k, currUnique));
            }
            return longestLen;
        }
        private int GetUniqueChars(string s)
        {
            HashSet<char> map = new HashSet<char>();
            foreach (char c in s)
            {
                if (map.Contains(c) == false)
                    map.Add(c);
            }
            return map.Count;
        }
        private int LongestSubstringWithKUniqueChars(string s, int k, int u)
        {
            int longestLen = 0;
            int l = 0, r = 0;
            int[] dic = new int[26];
            while (r < s.Length)
            {
                dic[s[r] - 'a']++;

                while (GetUniqueCharCnt(dic) > u)
                {
                    dic[s[l] - 'a']--;
                    l++;
                }
                if (IsArleastKRepeat(dic, k))
                    longestLen = Math.Max(longestLen, r - l + 1);

                r++;
            }

            return longestLen;
        }

        private int GetUniqueCharCnt(int[] dic)
        {
            int ans = 0;
            foreach (int c in dic)
            {
                if (c > 0) ans++;
            }
            return ans;
        }
        private bool IsArleastKRepeat(int[] dic, int k)
        {
            foreach (int c in dic)
            {
                if (c != 0 && c < k)
                    return false;
            }
            return true;
        }

        #endregion
    }
}