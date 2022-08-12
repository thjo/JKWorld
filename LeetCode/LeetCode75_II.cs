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


        /// <summary>
        /// 148. Sort List
        /// https://leetcode.com/problems/sort-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode mid = GetMid(head);
            ListNode left = SortList(head);
            ListNode right = SortList(mid);
            return Merge(left, right);
        }
        private ListNode GetMid(ListNode head)
        {
            ListNode midPrev = null;
            while (head != null && head.next != null)
            {
                midPrev = midPrev == null ? head : midPrev.next;
                head = head.next.next;
            }
            ListNode mid = midPrev.next;
            midPrev.next = null;
            return mid;
        }
        private ListNode Merge(ListNode left, ListNode right)
        {
            ListNode newHead = new ListNode();
            ListNode tail = newHead;
            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    tail.next = left;
                    left = left.next;
                    tail = tail.next;
                }
                else
                {
                    tail.next = right;
                    right = right.next;
                    tail = tail.next;
                }
            }
            tail.next = left != null ? left : right;
            return newHead.next;
        }



        /// <summary>
        /// 621. Task Scheduler
        /// https://leetcode.com/problems/task-scheduler/
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval(char[] tasks, int n)
        {
            int len = tasks.Length;
            if (n == 0)
                return len;

            int[] freq = new int[26];
            foreach (char t in tasks)
                freq[t - 'A']++;

            Array.Sort(freq);

            int fMax = freq[25];
            int idleTime = (fMax - 1) * n;
            for (int i = 24; i >= 0 && idleTime > 0; i--)
            {
                idleTime -= Math.Min(fMax - 1, freq[i]);
            }
            idleTime = Math.Max(0, idleTime);
            return idleTime + tasks.Length;
        }



        int cntOfPath = 0;
        public int PathSum(TreeNode root, int targetSum)
        {
            PathSumR(root, 0, targetSum);
            return cntOfPath;
        }

        private void PathSumR(TreeNode root, int currNum, int targetSum)
        {
            if (root == null)
                return;

            int sum = currNum + root.val;
            if (sum == targetSum)
            {
                cntOfPath++;
            }

            //with current root node
            PathSumR(root.left, sum, targetSum);
            PathSumR(root.right, sum, targetSum);

            //start at current root node
            PathSumR(root.left, root.val, targetSum);
            PathSumR(root.right, root.val, targetSum);
        }


        /// <summary>
        /// 173. Binary Search Tree Iterator
        /// https://leetcode.com/problems/binary-search-tree-iterator/
        /// </summary>
        public class BSTIterator
        {

            private TreeNode currPoint = null;
            Queue<TreeNode> q = new Queue<TreeNode>();
            public BSTIterator(TreeNode root)
            {
                currPoint = root;
                SetQueue(currPoint);
            }
            private void SetQueue(TreeNode root)
            {
                if (root == null)
                    return;
                SetQueue(root.left);
                q.Enqueue(root);
                SetQueue(root.right);
            }
            public int Next()
            {
                currPoint = q.Dequeue();
                return currPoint.val;
            }

            public bool HasNext()
            {
                return q.Count > 0;
            }

        }


        /// <summary>
        /// 417. Pacific Atlantic Water Flow
        /// https://leetcode.com/problems/pacific-atlantic-water-flow/
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int rows = heights.Length;
            int cols = heights[0].Length;
            //default: null, 0: No way, 1: Pacific, 2: Atlantic, 3: Both
            int?[][] dp = new int?[rows][];
            for (int i = 0; i < rows; i++)
                dp[i] = new int?[cols];

            //Direction: to left, to bottom
            for (int r = 0; r < rows; r++)
            {
                for (int c = cols - 1; c >= 0; c--)
                {
                    dp[r][c] = GetPacificAtlanticDef(r, c, rows, cols);
                    //Compare it to top
                    if (r > 0 && dp[r - 1][c] <= dp[r][c])
                        dp[r][c] |= dp[r - 1][c];
                    //Compare it to right
                    if (c < cols - 1 && dp[r][c + 1] <= dp[r][c])
                        dp[r][c] |= dp[r][c + 1];
                }
            }
            //Direction: to right, to top
            for (int r = 0; r < rows; r++)
            {
                for (int c = cols - 1; c >= 0; c--)
                {
                    dp[r][c] |= GetPacificAtlanticDef(r, c, rows, cols);
                    //Compare it to bottom
                    if (r < rows - 1 && dp[r + 1][c] <= dp[r][c])
                        dp[r][c] |= dp[r + 1][c];
                    //Compare it to left
                    if (c > 0 && dp[r][c - 1] <= dp[r][c])
                        dp[r][c] |= dp[r][c - 1];
                }
            }

            IList<IList<int>> ans = new List<IList<int>>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = cols - 1; c >= 0; c--)
                {
                    if (dp[r][c] == 3)
                    {
                        IList<int> buff = new List<int>();
                        buff.Add(r); buff.Add(c);
                        ans.Add(buff);
                    }
                }
            }
            return ans;
        }
        private int GetPacificAtlanticDef(int r, int c, int rows, int cols)
        {
            int val = 0;    //No way
            if (r == 0)
                val |= 1;    //Pacific;
            if (r == rows - 1)
                val |= 2;    //Atlantic
            if (c == 0)
                val |= 1;   //Pacific;
            if (c == cols - 1)
                val |= 2;    //Atlantic        
            return val;
        }



        /// <summary>
        /// 416. Partition Equal Subset Sum
        /// https://leetcode.com/problems/partition-equal-subset-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            if (nums.Length == 0)
                return false;
            int totalSum = 0;
            // find sum of all array elements
            foreach (int num in nums)
            {
                totalSum += num;
            }
            // if totalSum is odd, it cannot be partitioned into equal sum subset
            if (totalSum % 2 != 0) return false;
            int subSetSum = totalSum / 2;
            bool?[][] dp = new bool?[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
                dp[i] = new bool?[subSetSum + 1];
            return CanPartitionR(nums, 0, subSetSum, dp);
        }
        private bool CanPartitionR(int[] nums, int idx, int subSetSum, bool?[][] dp)
        {
            if (subSetSum == 0) return true;
            else if (subSetSum < 0) return false;
            if (idx < 0 || idx == nums.Length) return false;

            if (dp[idx][subSetSum] != null) return dp[idx][subSetSum].Value;
            bool ret = CanPartitionR(nums, idx + 1, subSetSum, dp) || CanPartitionR(nums, idx + 1, subSetSum - nums[idx], dp);
            dp[idx][subSetSum] = ret;
            return ret;
        }

        /// <summary>
        /// 152. Maximum Product Subarray
        /// https://leetcode.com/problems/maximum-product-subarray/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxProduct(int[] nums)
        {
            int maxProduct = nums[0];
            int totalMax = nums[0];
            int totalMin = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                int max = Math.Max(nums[i], Math.Max(totalMin * nums[i], totalMax * nums[i]));
                int min = Math.Min(nums[i], Math.Min(totalMin * nums[i], totalMax * nums[i]));
                totalMax = max;
                totalMin = min;
                maxProduct = Math.Max(totalMax, maxProduct);
            }

            return maxProduct;
        }


        /// <summary>
        /// 16. 3Sum Closest
        /// https://leetcode.com/problems/3sum-closest/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            int ans = int.MaxValue;
            int n = nums.Length;
            Array.Sort(nums);
            for(int i = 0; i < n; i++)
            {
                int low = i + 1;
                int high = n - 1;
                while(low < high)
                {
                    int sum = nums[i] + nums[low] + nums[high];
                    if (Math.Abs(target - sum) < Math.Abs(ans))
                        ans = target - sum;

                    if (target - sum == 0)
                        return target;
                    else if (target > sum)
                        low++;
                    else
                        high--;
                }
            }

            return target - ans;
        }
    }
}
