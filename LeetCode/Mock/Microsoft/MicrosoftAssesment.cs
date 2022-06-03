using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MicrosoftAssesment
    {
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
            for (int i = 0; i < n - 1; i++)
            {
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
                for (int i = 0; i < newS.Length; i++)
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
                    if (num.Length > 0)
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


        /// <summary>
        /// 41. First Missing Positive
        /// https://leetcode.com/problems/first-missing-positive/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            int minMissingVal = nums.Length + 1;
            Dictionary<int, bool> dp = new Dictionary<int, bool>();
            for (int i = 0; i < nums.Length; i++)
                dp.Add(i + 1, false);

            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] <= 0)
                    continue;
                else
                {
                    if (dp.ContainsKey(nums[i]))
                        dp[nums[i]] = true;
                }
            }

            foreach (var d in dp)
            {
                if (d.Value == false)
                {
                    return d.Key;
                }
            }
            return minMissingVal;
        }


        #region | Phone Interview - 03/06/2022 | 


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



        /// <summary>
        /// 28. Implement strStr()
        /// https://leetcode.com/problems/implement-strstr/
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(needle))
                return 0;
            else if (string.IsNullOrWhiteSpace(haystack))
                return -1;

            int n = haystack.Length;
            int m = needle.Length;
            for (int i = 0; i <= n - m; i++)
            {
                int j = 0;
                while (j < m && haystack[i + j] == needle[j])
                    j++;

                if (j == m)
                    return i;
            }
            return -1;
        }

        #endregion


        #region | Phone Interview - 3/16/2022 | 

        public int IslandPerimeter(int[][] grid)
        {
            int perimeter = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                        perimeter += 4 - numOfNeighbors(i, j, grid);
                }
            }
            return perimeter;
        }
        private int numOfNeighbors(int i, int j, int[][] grid)
        {
            int num = 0;
            if (i > 0 && grid[i - 1][j] == 1)
                num++;
            if (j > 0 && grid[i][j - 1] == 1)
                num++;
            if (i < grid.Length - 1 && grid[i + 1][j] == 1)
                num++;
            if (j < grid[0].Length - 1 && grid[i][j + 1] == 1)
                num++;

            return num;
        }

        public void ReorderList(ListNode head)
        {
            Stack<int> reverseList = new Stack<int>();
            Queue<int> orgList = new Queue<int>();
            ListNode currNode = head;
            while (currNode != null)
            {
                reverseList.Push(currNode.val);
                orgList.Enqueue(currNode.val);
                currNode = currNode.next;
            }

            currNode = head;
            while (currNode != null)
            {
                currNode.val = orgList.Dequeue();
                currNode = currNode.next;

                if (currNode != null)
                {
                    currNode.val = reverseList.Pop();
                    currNode = currNode.next;
                }
            }
        }

        #endregion

        #region | Microsoft - 3/20/2022 | 

        public int solution1(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (A == null || A.Length < 2)
                return 0;

            int maxTotalPairs = 0;
            bool isFirstIdxPair = true;
            int firstPairCnt = 0;
            int cnt = 1;

            for(int i = 1; i < A.Length; i++)
            {
                if ((A[i - 1] + A[i]) % 2 == 0)
                    cnt++;
                else
                {
                    if( isFirstIdxPair)
                    {
                        firstPairCnt = cnt;
                        isFirstIdxPair = false;
                    }

                    //update count and re-set variables
                    maxTotalPairs = maxTotalPairs + (cnt / 2);
                    cnt = 1;
                }
            }
            //update count
            maxTotalPairs = maxTotalPairs + (cnt / 2);
            int lastPairCnt = cnt;
            if ((A[0] + A[A.Length - 1]) % 2 == 0
                && firstPairCnt % 2 == 1 && lastPairCnt % 2 == 1)
                maxTotalPairs++;

            return maxTotalPairs;
        }

        #endregion

        #region | OnSite Interview - 3/21/2022 | 

        /// <summary>
        /// 1474. Delete N Nodes After M Nodes of a Linked List
        /// https://leetcode.com/problems/delete-n-nodes-after-m-nodes-of-a-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode DeleteNodes(ListNode head, int m, int n)
        {
            if (head == null || head.next == null)
                return head;

            ListNode prevNode = head;
            ListNode currNode = head;
            
            while(currNode != null)
            {
                int moveCursor = 1;
                int delCursor = 1;
                while (currNode != null && moveCursor <= m)
                {
                    prevNode = currNode;
                    currNode = currNode.next;
                    moveCursor++;
                }
                while(currNode != null && delCursor <= n)
                {
                    currNode = currNode.next;
                    delCursor++;
                }
                prevNode.next = currNode;
            }

            return head;
        }


        /// <summary>
        /// 654. Maximum Binary Tree
        /// https://leetcode.com/problems/maximum-binary-tree/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            int l = 0, r = nums.Length - 1;
            return ConstructMaximumBinaryTreeR(nums, l, r);
        }
        public TreeNode ConstructMaximumBinaryTreeR(int[] nums, int startIdx, int endIdx)
        {
            int? idx = GetMaxIdx(nums, startIdx, endIdx);
            if (idx == null)
                return null;

            TreeNode root = new TreeNode(nums[idx.Value]);
            root.left = ConstructMaximumBinaryTreeR(nums, startIdx, idx.Value - 1);
            root.right = ConstructMaximumBinaryTreeR(nums, idx.Value + 1, endIdx);

            return root;
        }
        private int? GetMaxIdx(int[] nums, int startIdx, int endIdx)
        {
            if (startIdx > endIdx || startIdx < 0 || endIdx >= nums.Length)
                return null;

            int maxIdx = startIdx;
            int max = nums[startIdx];
            for(int i = startIdx+1; i <= endIdx; i++)
            {
                if( max < nums[i])
                {
                    max = nums[i];
                    maxIdx = i;
                }
            }
            return maxIdx;
        }


        /// <summary>
        /// 296. Best Meeting Point
        /// https://leetcode.com/problems/best-meeting-point/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinTotalDistance(int[][] grid)
        {
            List<int> rows = CollectRows(grid);
            List<int> cols = CollectCols(grid);

            int row = rows[rows.Count / 2];
            int col = cols[cols.Count / 2];
            return MinDistance(rows, row) + MinDistance(cols, col);
        }
        private List<int> CollectRows(int[][] grid)
        {
            List<int> collections  = new List<int>();
            for(int i = 0; i < grid.Length; i++)
            {
                for(int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                        collections.Add(i);
                }
            }
            return collections;
        }
        private List<int> CollectCols(int[][] grid)
        {
            List<int> collections = new List<int>();
            for (int j = 0; j < grid[0].Length; j++)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    if (grid[i][j] == 1)
                        collections.Add(j);
                }
            }
            return collections;
        }
        private int MinDistance(List<int> points, int origin)
        {
            int distance = 0;
            foreach (int point in points)
                distance += Math.Abs(point - origin);

            return distance;
        }

        public int MinTotalDistanceSorted(int[][] grid)
        {
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            int[] sortedCols = cols.ToArray();
            Array.Sort(sortedCols);
            int row = rows[rows.Count / 2];
            int col = sortedCols[cols.Count / 2];

            return MinDistance(rows, row) + MinDistance(cols, col);
        }
        #endregion



        #region | Online Interview 1 | 

        /// <summary>
        /// 237. Delete Node in a Linked List
        /// https://leetcode.com/problems/delete-node-in-a-linked-list/
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            if (node == null)
                return;

            node.val = node.next.val;
            node.next = node.next.next;
        }


        /// <summary>
        /// 191. Number of 1 Bits
        /// https://leetcode.com/problems/number-of-1-bits/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int retVal = 0;
            while ((n | 0) > 0)
            {
                if ((n & 1) > 0)
                    retVal++;
                n = n >> 1;
            }

            return retVal;
        }

        #endregion

        #region | Online Interview 2 | 

        /// <summary>
        /// 796. Rotate String
        /// https://leetcode.com/problems/rotate-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == goal[0])
                {
                    if (RotateStringB(s, i, goal))
                        return true;
                }
            }

            return false;
        }
        private bool RotateStringB(string s, int startIdx, string goal)
        {
            int i = startIdx;
            int j = 0;
            do
            {
                if (s[i] != goal[j])
                    return false;

                i++;
                j++;
                if (i == s.Length)
                    i = 0;
            }
            while (i != startIdx);

            return true;
            //return s.Equals(goal);
        }

        /// <summary>
        /// 169. Majority Element
        /// https://leetcode.com/problems/majority-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int count = 0;
            int? candidate = null;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate.Value) ? 1 : -1;
            }

            return candidate.Value;
        }
        /// <summary>
        /// 229. Majority Element II
        /// https://leetcode.com/problems/majority-element-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MajorityElementII(int[] nums)
        {
            IList<int> ans = new List<int>();
            int nTimes = nums.Length / 3;
            int? candidate1 = null;
            int cnt1 = 0;
            int? candidate2 = null;
            int cnt2 = 0;
            foreach (int num in nums)
            {

                if (candidate1 != null && candidate1.Value == num)
                    cnt1++;
                else if (candidate2 != null && candidate2.Value == num)
                    cnt2++;
                else if (cnt1 == 0)
                {
                    candidate1 = num;
                    cnt1++;
                }
                else if (cnt2 == 0)
                {
                    candidate2 = num;
                    cnt2++;
                }
                else
                {
                    cnt1--;
                    cnt2--;
                }
            }

            cnt1 = 0;
            cnt2 = 0;
            foreach (int n in nums)
            {
                if (candidate1 != null && candidate1.Value == n)
                    cnt1++;
                else if (candidate2 != null && candidate2.Value == n)
                    cnt2++;
            }
            if (cnt1 > nTimes)
                ans.Add(candidate1.Value);
            if (cnt2 > nTimes)
                ans.Add(candidate2.Value);

            return ans;
        }

        #endregion

        #region | Online Interview 3 | 

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

        #endregion

        #region | Online Interview 4 | 

        /// <summary>
        /// 669. Trim a Binary Search Tree
        /// https://leetcode.com/problems/trim-a-binary-search-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return root;

            if (root.val > high)
                return TrimBST(root.left, low, high);
            if (root.val < low)
                return TrimBST(root.right, low, high);

            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);

            return root;
        }

        /// <summary>
        /// 445. Add Two Numbers II
        /// https://leetcode.com/problems/add-two-numbers-ii/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            List<int> nums1 = new List<int>();
            List<int> nums2 = new List<int>();

            while (l1 != null)
            {
                nums1.Add(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                nums2.Add(l2.val);
                l2 = l2.next;
            }

            ListNode newRoot = new ListNode(-1);
            int idx1 = nums1.Count - 1;
            int idx2 = nums2.Count - 1;
            int extraVal = 0;
            while (idx1 >= 0 || idx2 >= 0)
            {
                int n1 = 0, n2 = 0;
                if (idx1 >= 0 && idx2 >= 0)
                {
                    n1 = nums1[idx1--];
                    n2 = nums2[idx2--];
                }
                else if (idx1 >= 0)
                {
                    //idx1
                    n1 = nums1[idx1--];
                }
                else
                {
                    //idx2
                    n2 = nums2[idx2--];
                }
                int sum = n1 + n2;
                sum += extraVal;
                ListNode node = new ListNode(sum % 10);
                node.next = newRoot.next;
                newRoot.next = node;
                extraVal = sum / 10;
            }
            if (extraVal > 0)
            {
                ListNode node = new ListNode(extraVal);
                node.next = newRoot.next;
                newRoot.next = node;
            }

            return newRoot.next;

        }

        #endregion

        #region | Online Interview 5 | 

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
            int i1 = m - 1;
            int i2 = n - 1;
            int cursor = nums1.Length - 1;
            while (i1 >= 0 && i2 >= 0)
            {
                if (nums1[i1] > nums2[i2])
                    nums1[cursor--] = nums1[i1--];
                else if (nums1[i1] < nums2[i2])
                    nums1[cursor--] = nums2[i2--];
                else
                {
                    nums1[cursor--] = nums1[i1--];
                    nums1[cursor--] = nums2[i2--];
                }
            }
            for (; i1 >= 0; i1--)
                nums1[cursor--] = nums1[i1];
            for (; i2 >= 0; i2--)
                nums1[cursor--] = nums2[i2];
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
        #endregion

        #region | Online Interview 6 | 

        /// <summary>
        /// 509. Fibonacci Number
        /// https://leetcode.com/problems/fibonacci-number/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            if (n <= 1)
                return n;

            return Fib(n - 1) + Fib(n - 2);
        }

        /// <summary>
        /// 575. Distribute Candies
        /// https://leetcode.com/problems/distribute-candies/
        /// </summary>
        /// <param name="candyType"></param>
        /// <returns></returns>
        public int DistributeCandies(int[] candyType)
        {
            int n = candyType.Length / 2;   //n is always even

            HashSet<int> dic = new HashSet<int>();
            foreach (int ct in candyType)
            {
                if (dic.Contains(ct) == false)
                    dic.Add(ct);
            }

            return dic.Count > n ? n : dic.Count;
        }

        #endregion

        #region | Online Interview 7 | 

        /// <summary>
        /// 1185. Day of the Week
        /// https://leetcode.com/problems/day-of-the-week/
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public string DayOfTheWeek(int day, int month, int year)
        {
            string[] week = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            int[] days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                days[1] = 29;   //Leap Year
            int cnt = 0;

            for (int i = 1971; i < year; i++)
            {
                cnt += i % 4 == 0 ? 366 : 365;
            }
            for (int i = 0; i < month - 1; i++)
                cnt += days[i];
            cnt += day;


            return week[(cnt + 4) % 7];
        }

        /// <summary>
        /// 232. Implement Queue using Stacks
        /// https://leetcode.com/problems/implement-queue-using-stacks/
        /// </summary>
        public class MyQueue
        {

            private Stack<int> sData, sTemp;
            public MyQueue()
            {
                sData = new Stack<int>();
                sTemp = new Stack<int>();
            }

            public void Push(int x)
            {
                while (sData.Count > 0)
                    sTemp.Push(sData.Pop());

                sData.Push(x);

                while (sTemp.Count > 0)
                    sData.Push(sTemp.Pop());
            }

            public int Pop()
            {
                return sData.Pop();
            }

            public int Peek()
            {
                return sData.Peek();
            }

            public bool Empty()
            {
                return sData.Count == 0;
            }
        }

        #endregion

        #region | Online Interview - 03/09/2022 | 

        public int[][] FlipAndInvertImage(int[][] image)
        {
            int n = image.Length;
            int m = image[0].Length;
            int halfOfM = m / 2;
            if (m % 2 == 0)
                halfOfM--;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= halfOfM; j++)
                {
                    if (j == halfOfM && m % 2 == 1)
                    {
                        image[i][j] = (image[i][j] == 0 ? 1 : 0);
                    }
                    else
                    {
                        int tmp = image[i][j];
                        image[i][j] = (image[i][m - j - 1] == 0 ? 1 : 0);
                        image[i][m - j - 1] = (tmp == 0 ? 1 : 0);
                    }
                }
            }

            return image;
        }


        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leaves1 = new List<int>();
            ScanAllLeaf(root1, leaves1);
            List<int> leaves2 = new List<int>();
            ScanAllLeaf(root2, leaves2);

            if (leaves1.Count != leaves2.Count)
                return false;

            for (int i = 0; i < leaves1.Count; i++)
            {
                if (leaves1[i] != leaves2[i])
                    return false;
            }
            return true;
        }
        private void ScanAllLeaf(TreeNode root, List<int> leaves)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
            {
                leaves.Add(root.val);
                return;
            }
            else
            {
                ScanAllLeaf(root.left, leaves);
                ScanAllLeaf(root.right, leaves);
            }
        }

        #endregion


        #region | Phone Interview 1 |

        /// <summary>
        /// 151. Reverse Words in a String
        /// https://leetcode.com/problems/reverse-words-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            if (s == null || s.Length == 1)
                return s;

            StringBuilder res = new StringBuilder();
            Stack<char> sWord = new Stack<char>();
            int i = 0;
            while (i < s.Length)
            {
                if (s[i] == ' ')
                {
                    while (sWord.Count > 0)
                        res.Append(sWord.Pop());
                    res.Append(s[i]);
                }
                else
                {
                    sWord.Push(s[i]);
                }
                i++;
            }
            while (sWord.Count > 0)
                res.Append(sWord.Pop());

            return res.ToString();
        }

        /// <summary>
        /// 24. Swap Nodes in Pairs
        /// https://leetcode.com/problems/swap-nodes-in-pairs/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode newHead = new ListNode(-1, head.next);
            ListNode pre = null;
            ListNode cur = head;
            while (cur != null)
            {
                ListNode nex = cur.next;
                ListNode nnext = null;
                if (nex != null)
                    nnext = nex.next;

                //Swap
                if (nex != null)
                {
                    cur.next = nnext;
                    nex.next = cur;
                    if (pre != null)
                        pre.next = nex;
                }
                else
                {
                    if (pre != null)
                        pre.next = cur;
                }
                pre = cur;
                cur = nnext;
            }

            return newHead.next;

            //if (head == null || head.next == null)
            //    return head;

            //int tmp = head.next.val;
            //head.next.val = head.val;
            //head.val = tmp;

            //SwapPairs(head.next.next);
            //return head;
        }

        /// <summary>
        /// 79. Word Search
        /// https://leetcode.com/problems/word-search/
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist79(char[][] board, string word)
        {
            bool isExisted = false;
            if (board == null
               || board.Length < 1 || board[0].Length < 1)
                return isExisted;
            List<int[]> startPoints = new List<int[]>();
            int m = board.Length;
            int n = board[0].Length;

            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (board[row][col] == word[0])
                        startPoints.Add(new int[] { row, col });
                }
            }

            foreach (var startP in startPoints)
            {
                bool[][] visited = new bool[m][];
                for (int i = 0; i < m; i++)
                {
                    visited[i] = new bool[n];
                    for (int j = 0; j < n; j++)
                    {
                        visited[i][j] = false;
                    }
                }
                if (ExistDF(startP[0], startP[1], word, board, m, n, visited))
                    return true;
            }

            return isExisted;
        }
        private bool ExistDF(int startRow, int startCol, string word, char[][] board, int n, int m, bool[][] visited)
        {
            visited[startRow][startCol] = true;
            if (board[startRow][startCol] == word[0])
            {
                if (word.Length == 1)
                    return true;
                else
                {
                    if (startRow > 0 && !visited[startRow - 1][startCol])
                    {
                        if (ExistDF(startRow - 1, startCol, word.Substring(1), board, n, m, visited) == false)
                            visited[startRow - 1][startCol] = false;
                        else
                            return true;
                    }
                    if (startRow < n - 1 && !visited[startRow + 1][startCol])
                    {
                        if (ExistDF(startRow + 1, startCol, word.Substring(1), board, n, m, visited) == false)
                            visited[startRow + 1][startCol] = false;
                        else
                            return true;
                    }
                    if (startCol > 0 && !visited[startRow][startCol - 1])
                    {
                        if (ExistDF(startRow, startCol - 1, word.Substring(1), board, n, m, visited) == false)
                            visited[startRow][startCol - 1] = false;
                        else
                            return true;
                    }
                    if (startCol < m - 1 && !visited[startRow][startCol + 1])
                    {
                        if (ExistDF(startRow, startCol + 1, word.Substring(1), board, n, m, visited) == false)
                            visited[startRow][startCol + 1] = false;
                        else
                            return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// 212. Word Search II
        /// https://leetcode.com/problems/word-search-ii/
        /// </summary>
        char[][] _board = null;
        List<string> _result = new List<string>();
        public IList<string> FindWords(char[][] board, string[] words)
        {
            // Step 1). Construct the Trie
            TrieNode root = new TrieNode();
            foreach (string word in words)
            {
                TrieNode node = root;

                foreach (char letter in word.ToCharArray())
                {
                    if (node.children.ContainsKey(letter))
                    {
                        node = node.children[letter];
                    }
                    else
                    {
                        TrieNode newNode = new TrieNode();
                        node.children.Add(letter, newNode);
                        node = newNode;
                    }
                }
                node.word = word;  // store words in Trie
            }

            this._board = board;
            // Step 2). Backtracking starting for each cell in the board
            for (int row = 0; row < board.Length; ++row)
            {
                for (int col = 0; col < board[row].Length; ++col)
                {
                    if (root.children.ContainsKey(board[row][col]))
                    {
                        Backtracking(row, col, root);
                    }
                }
            }

            return this._result;
        }
        private void Backtracking(int row, int col, TrieNode parent)
        {
            char letter = this._board[row][col];
            TrieNode currNode = parent.children[letter];

            // check if there is any match
            if (currNode.word != null)
            {
                this._result.Add(currNode.word);
                currNode.word = null;
            }

            // mark the current letter before the EXPLORATION
            this._board[row][col] = '#';

            // explore neighbor cells in around-clock directions: up, right, down, left
            int[] rowOffset = { -1, 0, 1, 0 };
            int[] colOffset = { 0, 1, 0, -1 };
            for (int i = 0; i < 4; ++i)
            {
                int newRow = row + rowOffset[i];
                int newCol = col + colOffset[i];
                if (newRow < 0 || newRow >= this._board.Length || newCol < 0
                    || newCol >= this._board[0].Length)
                {
                    continue;
                }
                if (currNode.children.ContainsKey(this._board[newRow][newCol]))
                {
                    Backtracking(newRow, newCol, currNode);
                }
            }

            // End of EXPLORATION, restore the original letter in the board.
            this._board[row][col] = letter;

            // Optimization: incrementally remove the leaf nodes
            if (currNode.children.Count == 0)
            {
                parent.children.Remove(letter);
            }

        }
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public String word = null;
            public TrieNode() { }
        }

        #endregion

        #region | Phone Interview 2 | 

        /// <summary>
        /// 1518. Water Bottles
        /// https://leetcode.com/problems/water-bottles/#:~:text=Number%20of%20water%20bottles%20you%20can%20drink%3A%209%20%2B%203%20%2B,%2B%203%20%2B%201%20%3D%2019.
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public int NumWaterBottles(int numBottles, int numExchange)
        {
            int totalNum = numBottles;
            if (numBottles < numExchange)
                return totalNum;

            while (numBottles >= numExchange)
            {
                totalNum += (numBottles / numExchange);

                numBottles = (numBottles / numExchange) + (numBottles % numExchange);
            }

            return totalNum;
        }

        /// <summary>
        /// 1347. Minimum Number of Steps to Make Two Strings Anagram
        /// https://leetcode.com/problems/minimum-number-of-steps-to-make-two-strings-anagram/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int MinSteps(string s, string t)
        {
            int[] lowChars = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                lowChars[s[i] - 'a']++;
                lowChars[t[i] - 'a']--;
            }

            int steps = 0;
            foreach (int c in lowChars)
            {
                if (c > 0)
                    steps += c;
            }

            return steps;
        }

        #endregion

        #region | Phone Interview 3 | 

        /// <summary>
        /// 242. Valid Anagram
        /// https://leetcode.com/problems/valid-anagram/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] lowChars = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                lowChars[s[i] - 'a']++;
                lowChars[t[i] - 'a']--;
            }

            foreach (var c in lowChars)
            {
                if (c != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 171. Excel Sheet Column Number
        /// https://leetcode.com/problems/excel-sheet-column-number/
        /// </summary>
        /// <param name="columnTitle"></param>
        /// <returns></returns>
        public int TitleToNumber(string columnTitle)
        {
            int result = 0;
            int n = columnTitle.Length;
            for (int i = 0; i < n; i++)
            {
                result = result * 26;
                result += (columnTitle[i] - 'A' + 1);
            }
            return result;
        }

        /// <summary>
        /// 79. Word Search
        /// https://leetcode.com/problems/word-search/
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            bool isExisted = false;
            if (board == null
               || board.Length < 1 || board[0].Length < 1)
                return isExisted;
            List<int[]> startPoints = new List<int[]>();
            int m = board.Length;
            int n = board[0].Length;

            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (board[row][col] == word[0])
                        startPoints.Add(new int[] { row, col });
                }
            }

            foreach (var startP in startPoints)
            {
                bool[][] visited = new bool[m][];
                for (int i = 0; i < m; i++)
                {
                    visited[i] = new bool[n];
                    for (int j = 0; j < n; j++)
                    {
                        visited[i][j] = false;
                    }
                }
                if (ExistDFS(board, word, visited, startP[0], startP[1], m, n))
                    return true;
            }

            return isExisted;
        }
        private bool ExistDFS(char[][] board, string word, bool[][] visited, int startRow, int startCol, int m, int n)
        {
            visited[startRow][startCol] = true;
            if (board[startRow][startCol] == word[0])
            {
                if (word.Length == 1)
                    return true;
                bool isExisted = false;

                //Check Left
                if (startCol - 1 >= 0 && !visited[startRow][startCol - 1])
                {
                    isExisted = ExistDFS(board, word.Substring(1), visited, startRow, startCol - 1, m, n);
                    if (isExisted) return isExisted;
                    visited[startRow][startCol - 1] = false;
                }
                //Check Right
                if (startCol + 1 < n && !visited[startRow][startCol + 1])
                {
                    isExisted = ExistDFS(board, word.Substring(1), visited, startRow, startCol + 1, m, n);
                    if (isExisted) return isExisted;
                    visited[startRow][startCol + 1] = false;
                }
                //Check Top
                if (startRow - 1 >= 0 && !visited[startRow - 1][startCol])
                {
                    isExisted = ExistDFS(board, word.Substring(1), visited, startRow - 1, startCol, m, n);
                    if (isExisted) return isExisted;
                    visited[startRow - 1][startCol] = false;
                }

                //Check Bottom
                if (startRow + 1 < m && !visited[startRow + 1][startCol])
                {
                    isExisted = ExistDFS(board, word.Substring(1), visited, startRow + 1, startCol, m, n);
                    if (isExisted) return isExisted;
                    visited[startRow + 1][startCol] = false;
                }
            }

            return false;
        }


        #endregion

        #region | Phone Interview 4 | 


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

            //string[] ver1 = version1.Split(".".ToCharArray());
            //string[] ver2 = version2.Split(".".ToCharArray());

            //int p1 = 0, p2 = 0;
            //while (p1 < ver1.Length && p2 < ver2.Length)
            //{
            //    int v1 = int.Parse(ver1[p1++]);
            //    int v2 = int.Parse(ver2[p2++]);
            //    if (v1 > v2)
            //        return 1;
            //    else if (v1 < v2)
            //        return -1;
            //}

            //for (int i = p1; i < ver1.Length; i++)
            //{
            //    if (int.Parse(ver1[i]) > 0)
            //        return 1;
            //}
            //for (int i = p2; i < ver2.Length; i++)
            //{
            //    if (int.Parse(ver2[i]) > 0)
            //        return -1;
            //}
            //return 0;
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

        #region | Phone Interview 5 | 

        /// <summary>
        /// 1470. Shuffle the Array
        /// https://leetcode.com/problems/shuffle-the-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] Shuffle(int[] nums, int n)
        {
            int idx = 0, i = 0;
            int[] res = new int[2 * n];
            while (idx < n)
            {
                res[i++] = nums[idx];
                res[i++] = nums[idx + n];
                idx++;
            }

            return res;
        }

        /// <summary>
        /// 1156. Swap For Longest Repeated Character Substring
        /// https://leetcode.com/problems/swap-for-longest-repeated-character-substring/
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int MaxRepOpt1(string text)
        {
            int ans = 0;
            int[] count = new int[26];
            List<int[]> groups = new List<int[]>();

            foreach (char c in text)
                count[c - 'a']++;

            groups.Add(new int[] { text[0], 1 });

            for (int i = 1; i < text.Length; ++i)
                if (text[i] == text[i - 1])
                    groups[groups.Count - 1][1]++;
                else
                    groups.Add(new int[] { text[i], 1 });

            foreach (int[] group in groups)
                ans = Math.Max(ans, Math.Min(group[1] + 1, count[group[0] - 'a']));

            for (int i = 1; i + 1 < groups.Count; ++i)
                if (groups[i - 1][0] == groups[i + 1][0] && groups[i][1] == 1)
                    ans = Math.Max(ans, Math.Min(groups[i - 1][1] + groups[i + 1][1] + 1,
                                                 count[groups[i - 1][0] - 'a']));

            return ans;
        }

        #endregion

        #region | Phone Interview 6 | 

        /// <summary>
        /// 160. Intersection of Two Linked Lists
        /// https://leetcode.com/problems/intersection-of-two-linked-lists/solution/
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode pA = headA;
            ListNode pB = headB;
            bool isFirstA = true, isFirstB = true;
            while (pA != null || pB != null)
            {
                if (pA == pB)
                    return pA;

                pA = pA.next;
                if (pA == null && isFirstA)
                {
                    pA = headB;
                    isFirstA = false;
                }
                pB = pB.next;
                if (pB == null && isFirstB)
                {
                    pB = headA;
                    isFirstB = false;
                }
            }
            return null;
            ////Hash table
            //HashSet<ListNode> nodesInB = new HashSet<ListNode>();
            //while (headB != null)
            //{
            //    nodesInB.Add(headB);
            //    headB = headB.next;
            //}

            //while (headA != null)
            //{
            //    // if we find the node pointed to by headA,
            //    // in our set containing nodes of B, then return the node
            //    if (nodesInB.Contains(headA))
            //    {
            //        return headA;
            //    }
            //    headA = headA.next;
            //}

            //return null;
        }

        /// <summary>
        /// 223. Rectangle Area
        /// https://leetcode.com/problems/rectangle-area/
        /// </summary>
        /// <param name="ax1"></param>
        /// <param name="ay1"></param>
        /// <param name="ax2"></param>
        /// <param name="ay2"></param>
        /// <param name="bx1"></param>
        /// <param name="by1"></param>
        /// <param name="bx2"></param>
        /// <param name="by2"></param>
        /// <returns></returns>
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            int areaA = Math.Abs((ax2 - ax1) * (ay2 - ay1));
            int areaB = Math.Abs((bx2 - bx1) * (by2 - by1));
            int total = areaA + areaB;
            if (bx1 >= ax2 || ax1 >= bx2 || ay1 >= by2 || by1 >= ay2)
                return total;
            else
            {
                int x1 = Math.Min(ax2, bx2);
                int x2 = Math.Max(ax1, bx1);
                int y1 = Math.Min(ay2, by2);
                int y2 = Math.Max(ay1, by1);
                return total - Math.Abs((x1 - x2) * (y1 - y2));
            }
        }

        /// <summary>
        /// 322. Coin Change
        /// https://leetcode.com/problems/coin-change/
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            //amount, # of coins
            Dictionary<int, int> dp = new Dictionary<int, int>();
            int min = CoinChangeR(coins, amount, amount, dp);
            return min == amount + 1 ? -1 : min;
        }
        private int CoinChangeR(int[] coins, int currAmt, int orgAmt, Dictionary<int, int> dp)
        {
            if (currAmt < 0)
                return orgAmt + 1;
            else if (currAmt == 0)
                return 0;
            if (dp.ContainsKey(currAmt))
                return dp[currAmt];

            int minNumOfCoins = orgAmt + 1;
            foreach (var c in coins)
            {
                minNumOfCoins = Math.Min(minNumOfCoins, 1 + CoinChangeR(coins, currAmt - c, orgAmt, dp));
            }
            dp.Add(currAmt, minNumOfCoins);
            return minNumOfCoins;
        }
        #endregion

        #region | Phone Interview 7 | 

        /// <summary>
        /// 1700. Number of Students Unable to Eat Lunch
        /// https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/
        /// </summary>
        /// <param name="students"></param>
        /// <param name="sandwiches"></param>
        /// <returns></returns>
        public int CountStudents(int[] students, int[] sandwiches)
        {
            Queue<int> stu = new Queue<int>();
            Stack<int> san = new Stack<int>();
            int idxSan = 0;
            foreach (var s in students)
            {
                if (s == sandwiches[idxSan])
                {
                    idxSan++;
                }
                else
                    stu.Enqueue(s);
            }
            int remainedStu = stu.Count;
            int progress = 0;
            while (stu.Count > 0)
            {
                if (remainedStu == progress)
                    return stu.Count;
                else
                {
                    int s = stu.Dequeue();
                    if (s == sandwiches[idxSan])
                    {
                        idxSan++;
                        remainedStu--;
                        progress = 0;
                    }
                    else
                    {
                        stu.Enqueue(s);
                        progress++;
                    }
                }
            }
            return stu.Count;
            //bool isMatched = false;
            //int i = 0, j = 0;
            //int numOfMatched = 0;
            //while (i != students.Length || isMatched)
            //{
            //    if (i == students.Length)
            //    {
            //        i = 0;
            //        isMatched = false;
            //    }

            //    if (students[i] == -1)
            //    {
            //        ;
            //    }
            //    else if (students[i] != sandwiches[j])
            //    {
            //        ;
            //    }
            //    else
            //    {
            //        isMatched = true;
            //        students[i] = -1;
            //        numOfMatched++;
            //        j++;
            //    }
            //    i++;
            //}

            //return students.Length - numOfMatched;
        }

        /// <summary>
        /// 701. Insert into a Binary Search Tree
        /// https://leetcode.com/problems/insert-into-a-binary-search-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);

            if (root.val > val)
            {
                root.left = InsertIntoBST(root.left, val);
            }
            else
                root.right = InsertIntoBST(root.right, val);

            return root;
        }

        #endregion

        #region | Phone Interview 8 | 

        /// <summary>
        /// 142. Linked List Cycle II
        /// https://leetcode.com/problems/linked-list-cycle-ii/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return null;

            ListNode curr = head.next;
            ListNode fast = head.next.next;

            while (curr != fast && fast != null)
            {
                curr = curr.next;
                fast = fast.next != null ? fast.next.next : null;
            }
            if (fast == null)
                return null;

            ListNode ptr1 = head;
            while (ptr1 != fast)
            {
                ptr1 = ptr1.next;
                fast = fast.next;
            }

            return ptr1;
        }


        /// <summary>
        /// 328. Odd Even Linked List
        /// https://leetcode.com/problems/odd-even-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode oddHead = head;
            ListNode evenHead = head.next;
            ListNode oddCurr = oddHead, evenCurr = evenHead;
            ListNode currNode = (head.next != null) ? head.next.next : null;
            int idx = 3;
            while (currNode != null)
            {
                if (idx % 2 == 0)
                {
                    //even node
                    evenCurr.next = evenCurr;
                    evenCurr = evenCurr.next;
                }
                else
                {
                    //odd node
                    oddCurr.next = evenCurr;
                    oddCurr = oddCurr.next;
                }
                currNode = currNode.next;
                idx++;
            }

            oddCurr.next = evenHead;
            return oddHead;

            //if (head == null) return null;

            //ListNode odd = head, even = head.next, evenHead = even;
            //while (even != null && even.next != null)
            //{
            //    odd.next = even.next;
            //    odd = odd.next;
            //    even.next = odd.next;
            //    even = even.next;
            //}
            //odd.next = evenHead;

            //return head;
        }

        #endregion

        #region | Phone Interview 9 | 

        /// <summary>
        /// 979. Distribute Coins in Binary Tree
        /// https://leetcode.com/problems/distribute-coins-in-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        int ans = 0;
        public int DistributeCoins(TreeNode root)
        {
            return dfs(root);
        }
        private int dfs(TreeNode node)
        {
            if (node == null)
                return 0;

            int l = dfs(node.left);
            int r = dfs(node.right);
            ans += Math.Abs(l) + Math.Abs(r);
            return node.val + l + r - 1;
        }


        /// <summary>
        /// 935. Knight Dialer
        /// https://leetcode.com/problems/knight-dialer/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int KnightDialer(int n)
        {
            long[] dp = new long[10];
            long[] calDp = new long[10];
            for (int i = 0; i < 10; i++)
                dp[i] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp.CopyTo(calDp, 0);
                dp[1] = (calDp[6] + calDp[8]) % 1000000007;
                dp[2] = (calDp[7] + calDp[9]) % 1000000007;
                dp[3] = (calDp[4] + calDp[8]) % 1000000007;
                dp[4] = (calDp[3] + calDp[9] + calDp[0]) % 1000000007;
                dp[5] = 0;
                dp[6] = (calDp[1] + calDp[7] + calDp[0]) % 1000000007;
                dp[7] = (calDp[2] + calDp[6]) % 1000000007;
                dp[8] = (calDp[1] + calDp[3]) % 1000000007;
                dp[9] = (calDp[2] + calDp[4]) % 1000000007;
                dp[0] = (calDp[4] + calDp[6]) % 1000000007;
            }

            long ans = 0;
            for (int i = 0; i < 10; i++)
                ans += dp[i] % 1000000007;

            return (int)(ans % 1000000007);
        }


        #region | Bruce Force | 
        //public int KnightDialer(int n)
        //{
        //    int[,] pad = new int[,] {
        //          { 1,2,3 }
        //        , { 4,5,6 }
        //        , { 7,8,9 }
        //        , {-1,0,-1 } };

        //    int[][] dic = new int[8][];
        //    dic[0] = new int[2];
        //    dic[0][0] = -2; //row
        //    dic[0][1] = -1; //col
        //    dic[1] = new int[2];
        //    dic[1][0] = -1; //row
        //    dic[1][1] = -2; //col

        //    dic[2] = new int[2];
        //    dic[2][0] = -2; //row
        //    dic[2][1] =  1; //col
        //    dic[3] = new int[2];
        //    dic[3][0] = -1; //row
        //    dic[3][1] =  2; //col

        //    dic[4] = new int[2];
        //    dic[4][0] =  1; //row
        //    dic[4][1] = -2; //col
        //    dic[5] = new int[2];
        //    dic[5][0] =  2; //row
        //    dic[5][1] = -1; //col

        //    dic[6] = new int[2];
        //    dic[6][0] =  2; //row
        //    dic[6][1] =  1; //col
        //    dic[7] = new int[2];
        //    dic[7][0] =  1; //row
        //    dic[7][1] =  2; //col

        //    List<string> res = new List<string>();
        //    for(int r = 0; r < 4; r++)
        //    {
        //        for(int c = 0; c < 3; c++)
        //        {
        //            if (pad[r, c] >= 0)
        //            {
        //                int num = pad[r, c];
        //                pad[r, c] = -2;
        //                KnightDialerBTK(n - 1, r, c, num.ToString(), res, dic, pad);
        //                pad[r, c] = num;
        //            }
        //        }
        //    }

        //    return res.Count % 1000000007;
        //}
        //private void KnightDialerBTK(int move, int startRow, int startCol, string num, List<string> res, int[][] dic, int[,] pad)
        //{
        //    if( move == 0)
        //    {
        //        if (res.Contains(num) == false)
        //            res.Add(num);
        //        return;
        //    }

        //    for(int i = 0; i < dic.Length; i++)
        //    {
        //        //valid movement
        //        int row = startRow + dic[i][0];
        //        int col = startCol + dic[i][1];
        //        if (row >= 0 && row < 4
        //            && col >= 0 && col < 3 && pad[row,col] >= 0)
        //        {
        //            int currNum = pad[row, col];
        //            KnightDialerBTK(move - 1, row, col, num + currNum.ToString(), res, dic, pad);
        //            pad[row, col] = currNum;
        //        }
        //    }
        //}
        #endregion

        #endregion

        #region | Phone Interview 10 | 

        /// <summary>
        /// 1469. Find All The Lonely Nodes
        /// https://leetcode.com/problems/find-all-the-lonely-nodes/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> GetLonelyNodes(TreeNode root)
        {
            IList<int> res = new List<int>();
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                TreeNode node = nodes.Dequeue();
                int? val = OlnyChild(node);
                if (val != null)
                    res.Add(val.Value);
                if (node.left != null)
                    nodes.Enqueue(node.left);
                if (node.right != null)
                    nodes.Enqueue(node.right);
            }
            return res;
        }
        private int? OlnyChild(TreeNode root)
        {
            if (root.left == null && root.right != null)
                return root.right.val;
            else if (root.left != null && root.right == null)
                return root.left.val;
            else
                return null;
        }

        public IList<int> GetLonelyNodesII(TreeNode root)
        {
            IList<int> ans = new List<int>();
            GetLonelyNodesR(root, ans);

            return ans;
        }
        private void GetLonelyNodesR(TreeNode root, IList<int> ans)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
                return;
            else if (root.left == null && root.right != null)
            {
                ans.Add(root.right.val);
                GetLonelyNodesR(root.right, ans);
            }
            else if (root.left != null && root.right == null)
            {
                ans.Add(root.left.val);
                GetLonelyNodesR(root.left, ans);
            }
            else
            {
                GetLonelyNodesR(root.left, ans);
                GetLonelyNodesR(root.right, ans);
            }
        }

        //1381. Design a Stack With Increment Operation
        //https://leetcode.com/problems/design-a-stack-with-increment-operation/
        //public class CustomStack {
        //List<int> data = null;
        //int MAX_SIZE = 0;
        //public CustomStack(int maxSize)
        //{
        //    MAX_SIZE = maxSize;
        //    data = new List<int>();
        //}

        //public void Push(int x)
        //{
        //    if (data.Count < MAX_SIZE)
        //    {
        //        data.Add(x);
        //    }
        //}

        //public int Pop()
        //{
        //    if (data.Count <= 0)
        //        return -1;

        //    int tmp = data[data.Count - 1];
        //    data.RemoveAt(data.Count - 1);
        //    return tmp;
        //}

        //public void Increment(int k, int val)
        //{
        //    int min = data.Count;
        //    if (k < min)
        //        min = k;
        //    for (int i = 0; i < min; i++)
        //    {
        //        data[i] = data[i] + val;
        //    }
        //}
        //}
        #endregion


        #region | Phone Interview 11 | 


        /// <summary>
        /// 917. Reverse Only Letters
        /// https://leetcode.com/problems/reverse-only-letters/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseOnlyLetters(string s)
        {
            char?[] ans = new char?[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (!Char.IsLower(s[i]) && !Char.IsUpper(s[i]))
                    ans[i] = s[i];
                else
                    ans[i] = null;
            }
            int ansIdx = s.Length - 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLower(s[i]) || Char.IsUpper(s[i]))
                {
                    while (ans[ansIdx] != null)
                        ansIdx--;
                    ans[ansIdx--] = s[i];
                }
            }
            string result = "";
            foreach (var c in ans)
                result += c;
            return result;
        }

        #region | 622. Design Circular Queue | 
        //https://leetcode.com/problems/design-circular-queue/

        //public class Node
        //{
        //    public int value;
        //    public Node next;

        //    public Node(int value)
        //    {
        //        this.value = value;
        //        this.next = null;
        //    }
        //}
        //public class MyCircularQueue
        //{

        //    private Node head, tail;
        //    private int count;
        //    private int capacity;

        //    public MyCircularQueue(int k)
        //    {
        //        this.capacity = k;
        //    }

        //    public bool EnQueue(int value)
        //    {
        //        if (this.count == this.capacity)
        //            return false;

        //        Node newNode = new Node(value);
        //        if (this.count == 0)
        //        {
        //            this.head = newNode;
        //            this.tail = newNode;
        //        }
        //        else
        //        {
        //            tail.next = newNode;
        //            tail = newNode;
        //        }
        //        this.count++;
        //        return true;
        //    }

        //    public bool DeQueue()
        //    {
        //        if (this.count == 0)
        //            return false;

        //        this.head = this.head.next;
        //        if (this.head == null)
        //            this.tail = null;
        //        this.count--;
        //        return true;
        //    }

        //    public int Front()
        //    {
        //        if (this.count == 0)
        //            return -1;
        //        else
        //            return this.head.value;
        //    }

        //    public int Rear()
        //    {
        //        if (this.count == 0)
        //            return -1;
        //        else
        //            return this.tail.value;
        //    }

        //    public bool IsEmpty()
        //    {
        //        return this.count == 0;
        //    }

        //    public bool IsFull()
        //    {
        //        return this.count == this.capacity;
        //    }
        //}

        #endregion

        #endregion


        #region | Phone Interview 12 | 


        #endregion

        #region | Phone Interview 13 | 


        #endregion
    }
}
