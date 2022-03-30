using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Leetcode75Questions
    {
        #region | Arrays | 

        /// <summary>
        /// 1. Two Sum
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();
            int[] res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                if (dp.ContainsKey(target - nums[i]))
                {
                    res[0] = dp[target - nums[i]];
                    res[1] = i;
                    break;
                }
                else
                    dp[nums[i]] = i;
            }

            return res;
        }

        #endregion


        #region | Binary | 

        /// <summary>
        /// 371. Sum of Two Integers
        /// https://leetcode.com/problems/sum-of-two-integers/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetSum(int a, int b)
        {
            return 0;
        }


        #endregion


        #region | Dynamic Programming | 

        /// <summary>
        /// 70. Climbing Stairs
        /// https://leetcode.com/problems/climbing-stairs/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n <= 2)
                return n;

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];

            return dp[n];
        }


        #endregion


        #region | Graph | 

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
        /// <summary>
        /// 133. Clone Graph
        /// https://leetcode.com/problems/clone-graph/
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node CloneGraph(Node node)
        {
            Node newNode = null;
            if (node == null)
                return newNode;

            //This helps to avoid cycles.        
            Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
            Queue<Node> qq = new Queue<Node>();
            qq.Enqueue(node);
            visited.Add(node, new Node(node.val, new List<Node>()));
            while (qq.Count > 0)
            {
                // Pop a node say "n" from the from the front of the queue.
                Node n = qq.Dequeue();
                // Iterate through all the neighbors of the node "n"
                foreach (Node neighbor in n.neighbors)
                {
                    if (!visited.ContainsKey(neighbor))
                    {
                        // Clone the neighbor and put in the visited, if not present already
                        visited.Add(neighbor, new Node(neighbor.val, new List<Node>()));
                        // Add the newly encountered node to the queue.
                        qq.Enqueue(neighbor);
                    }
                    // Add the clone of the neighbor to the neighbors of the clone node "n".
                    visited[n].neighbors.Add(visited[neighbor]);
                }
            }

            return visited[node];
        }

        #endregion


        #region | Interval | 

        /// <summary>
        /// 57. Insert Interval
        /// https://leetcode.com/problems/insert-interval/
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> res = new List<int[]>();
            int newStart = newInterval[0];
            int newEnd = newInterval[1];
            int idx = 0, n = intervals.Length;

            //Add all intervals starting before newInterval
            while (idx < n && intervals[idx][0] < newStart)
                res.Add(intervals[idx++]);

            //Add newInterval
            //if there is no overlap, just add a newInterval
            if (res.Count == 0 || res[res.Count - 1][1] < newStart)
                res.Add(newInterval);
            else
            {
                //Merge with the last interval
                res[res.Count - 1][1] = Math.Max(res[res.Count - 1][1], newEnd);
            }

            //Add next intervals, merge with newInterval if needed
            while (idx < n)
            {
                int[] interval = intervals[idx++];
                //if there is no overlap, just add it
                if (res[res.Count - 1][1] < interval[0])
                    res.Add(interval);
                else
                {
                    res[res.Count - 1][1] = Math.Max(res[res.Count - 1][1], interval[1]);
                }
            }

            int[][] output = new int[res.Count][];
            for (int i = 0; i < res.Count; i++)
            {
                output[i] = res[i];
            }
            return output;
        }

        #endregion


        #region | Linked List | 

        /// <summary>
        /// 206. Reverse Linked List
        /// https://leetcode.com/problems/reverse-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            //iteratively 
            //return ReverseListIteratively(head);

            //Recursively
            return ReverseListRecursively(head);
        }
        private ListNode ReverseListRecursively(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode p = ReverseListRecursively(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }
        private ListNode ReverseListIteratively(ListNode head)
        {
            //iteratively 
            if (head == null || head.next == null)
                return head;
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        #endregion


        #region | Matrix | 

        /// <summary>
        /// 73. Set Matrix Zeroes
        /// https://leetcode.com/problems/set-matrix-zeroes/
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes(int[][] matrix)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;

            //Space Complexity O(1)
            bool isCol = false;
            for (int i = 0; i < row; i++)
            {
                if (matrix[i][0] == 0)
                    isCol = true;

                for(int j =1; j < col; j++)
                {
                    if(matrix[i][j]==0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            // Iterate over the array once again and using the first row and first column, update the elements.
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // See if the first row needs to be set to zero as well
            if (matrix[0][0] == 0)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            // See if the first column needs to be set to zero as well
            if (isCol)
            {
                for (int i = 0; i < row; i++)
                {
                    matrix[i][0] = 0;
                }
            }

            ////Space Complexity O(M+N)
            //HashSet<int> rows = new HashSet<int>();
            //HashSet<int> cols = new HashSet<int>();

            //// Essentially, we mark the rows and columns that are to be made zero
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < col; j++)
            //    {
            //        if (matrix[i][j] == 0)
            //        {
            //            rows.Add(i);
            //            cols.Add(j);
            //        }
            //    }
            //}

            //// Iterate over the array once again and using the rows and cols sets, update the elements.
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < col; j++)
            //    {
            //        if (rows.Contains(i) || cols.Contains(j))
            //        {
            //            matrix[i][j] = 0;
            //        }
            //    }
            //}
        }

        #endregion


        #region | String | 

        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            //char, index
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int startIdx = 0;
            int longestLen = 1;
            dic.Add(s[0], 0);
            for (int i = 1; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    //Since it's continuous substring
                    int dupIdx = dic[s[i]];
                    while (startIdx <= dupIdx)
                    {
                        dic.Remove(s[startIdx]);
                        startIdx++;
                    }
                }

                dic.Add(s[i], i);
                longestLen = Math.Max(longestLen, dic.Count);
            }
            return longestLen;
        }


        #endregion


        #region | Tree |


        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }
        private void MaxDepthopDown(TreeNode root, int depth, ref int finalAnswer)
        {
            if (root == null)
                return;
            else
            {
                if (root.left == null && root.right == null)
                    finalAnswer = Math.Max(depth, finalAnswer);
            }

            MaxDepthopDown(root.left, depth + 1, ref finalAnswer);
            MaxDepthopDown(root.right, depth + 1, ref finalAnswer);
        }

        #endregion


        #region | Heap | 

        /// <summary>
        /// 23. Merge k Sorted Lists
        /// https://leetcode.com/problems/merge-k-sorted-lists/
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            return null;
        }

        #endregion

    }
}
