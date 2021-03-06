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

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            if (prices.Length <= 1)
                return maxProfit;

            int startPrice = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (startPrice > prices[i])
                    startPrice = prices[i];
                else if (startPrice < prices[i])
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - startPrice);
                }

            }

            return maxProfit;
        }

        /// <summary>
        /// 217. Contains Duplicate
        /// https://leetcode.com/problems/contains-duplicate/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            bool retVal = false;
            if (nums == null || nums.Length < 2)
                return retVal;

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    retVal = true;
                    break;
                }
                else
                    set.Add(nums[i]);
            }

            return retVal;
        }

        /// <summary>
        /// 238. Product of Array Except Self
        /// https://leetcode.com/problems/product-of-array-except-self/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int len = nums.Length;
            int[] res = new int[nums.Length];
            res[0] = 1;
            int answer = 1;
            for (int i = 1; i < len; i++)
            {
                answer *= nums[i - 1];
                res[i] = answer;
            }

            answer = 1;
            for (int i = len - 2; i >= 0; i--)
            {
                answer *= nums[i + 1];
                res[i] *= answer;
            }

            return res;
        }

        /// <summary>
        /// 53. Maximum Subarray
        /// https://leetcode.com/problems/maximum-subarray/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            int sum = nums[0];
            int max = sum;
            for (int i = 1; i < nums.Length; i++)
            {
                if (sum + nums[i] < nums[i])
                    sum = nums[i];
                else
                    sum += nums[i];

                max = Math.Max(max, sum);
            }
            return max;
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
            for (int i = 1; i < nums.Length; i++)
            {
                int max = Math.Max(nums[i], Math.Max(totalMax * nums[i], totalMin * nums[i]));
                int min = Math.Min(nums[i], Math.Min(totalMax * nums[i], totalMin * nums[i]));
                totalMax = max;
                totalMin = min;
                maxProduct = Math.Max(maxProduct, totalMax);
            }

            return maxProduct;
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

        /// <summary>
        /// 338. Counting Bits
        /// https://leetcode.com/problems/counting-bits/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] CountBits(int n)
        {
            int[] ans = new int[n + 1];
            ans[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                ans[i] = ans[i / 2] + i % 2;
            }
            return ans;
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


        /// <summary>
        /// 322. Coin Change
        /// https://leetcode.com/problems/coin-change/
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            if (amount <= 0)
                return 0;
            else if (coins == null || coins.Length == 0)
                return -1;

            //Dictionary<int, int> dp = new Dictionary<int, int>();
            //CoinChange(coins, amount, dp, amount);
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = max;
            dp[0] = 0;
            for(int i = 1; i <= amount; i++)
            {
                for(int j = 0; j < coins.Length; j++)
                {
                    if( coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return dp[amount] == amount + 1 ? -1 : dp[amount];
        }
        private int CoinChange(int[] coins, int amt, Dictionary<int, int> dp, int orgAmt)
        {
            if (amt < 0)
                return orgAmt + 1;
            else if (amt == 0)
                return 0;
            if (dp.ContainsKey(amt))
                return dp[amt];

            int min = orgAmt + 1;
            foreach (int c in coins)
            {
                min = Math.Min(min, 1 + CoinChange(coins, amt - c, dp, orgAmt));
            }
            dp.Add(amt, min);

            return min;
        }

        /// <summary>
        /// 300. Longest Increasing Subsequence
        /// https://leetcode.com/problems/longest-increasing-subsequence/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            int ans = 1;
            int n = nums.Length;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
                dp[i] = 1;

            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        dp[i] = dp[j] + 1;
                        ans = Math.Max(ans, dp[i]);
                    }
                }
            }
            return ans;

            //int[] longestDP = new int[nums.Length];
            //int[] prevNums = new int[nums.Length];
            //int longest = 1;
            //for (int i = 0; i < longestDP.Length; i++)
            //    longestDP[i] = 1;

            //for (int i = nums.Length - 2; i >= 0; i--)
            //{
            //    for (int j = nums.Length - 1; j > i; j--)
            //    {
            //        if (nums[j] > nums[i])
            //        {
            //            longestDP[i] = Math.Max(longestDP[i], 1 + longestDP[j]);
            //            longest = Math.Max(longestDP[i], longest);
            //        }
            //    }
            //}

            //return longest;
            /*
            for(int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && longestDP[i] < longestDP[j] + 1)
                    {
                        longestDP[i] = longestDP[j] + 1;
                        prevNums[i] = nums[j];

                        longest = Math.Max(longest, longestDP[i]);
                    }
                }
            }
            return longest;        
            */
        }


        /// <summary>
        /// 1143. Longest Common Subsequence
        /// https://leetcode.com/problems/longest-common-subsequence/
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence(string text1, string text2)
        {
            //abcde      ace
            //     Equal: +1      abcd     ac     remove the last character
            // Not Equal: +0      MAX( (abcd, a) , (abc, ac) )
            //                   +0 
            //Focus on the last character.
            if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2))
                return 0;
            Dictionary<string, int> dp = new Dictionary<string, int>();
            return LongestCommonSubsequenceR(text1, text2, text1.Length - 1, text2.Length - 1, dp);
        }
        private int LongestCommonSubsequenceR(string text1, string text2, int end1, int end2, Dictionary<string, int> dp)
        {
            if (end1 < 0 || end2 < 0)
                return 0;
            else if (dp.ContainsKey(string.Format("{0}_{1}", end1, end2)))
                return dp[string.Format("{0}_{1}", end1, end2)];

            int longestLen = 0;
            if (text1[end1] == text2[end2])
                longestLen = 1 + LongestCommonSubsequenceR(text1, text2, end1 - 1, end2 - 1, dp);
            else
            {
                longestLen = Math.Max(LongestCommonSubsequenceR(text1, text2, end1 - 1, end2, dp)
                                    , LongestCommonSubsequenceR(text1, text2, end1, end2 - 1, dp));
            }

            dp.Add(string.Format("{0}_{1}", end1, end2), longestLen);
            return longestLen;
        }

        /// <summary>
        /// 139. Word Break
        /// https://leetcode.com/problems/word-break/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            return false;
        }


        /// <summary>
        /// 39. Combination Sum
        /// https://leetcode.com/problems/combination-sum/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> results = new List<IList<int>>();
            CombinationCases(candidates, target, 0, new List<int>(), results);

            return results;
        }
        private void CombinationCases(int[] candidates, int target, int idx, IList<int> currCombination, IList<IList<int>> allCombinaions)
        {
            if (target == 0)
            {
                List<int> tmp = new List<int>();
                foreach (int i in currCombination)
                    tmp.Add(i);
                allCombinaions.Add(tmp);
                return;
            }
            else if (idx >= candidates.Length || target < 0)
                return;
            else
            {
                currCombination.Add(candidates[idx]);
                CombinationCases(candidates, target - candidates[idx], idx, currCombination, allCombinaions);
                currCombination.RemoveAt(currCombination.Count - 1);
                CombinationCases(candidates, target, idx + 1, currCombination, allCombinaions);
            }
            return;
        }


        /// <summary>
        /// 198. House Robber
        /// https://leetcode.com/problems/house-robber/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            int n = nums.Length;
            int[] dp = new int[n];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            //1 2 4 4
            return dp[n - 1];
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


        /// <summary>
        /// 207. Course Schedule
        /// https://leetcode.com/problems/course-schedule/
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
            foreach (var c in prerequisites)
            {
                if (preMap.ContainsKey(c[0]))
                    preMap[c[0]].Add(c[1]);
                else
                {
                    List<int> cc = new List<int>();
                    cc.Add(c[1]);
                    preMap.Add(c[0], cc);
                }
            }

            //detect a loop in this graph
            HashSet<int> visited = new HashSet<int>();
            //need to check every single course because courses might be not connected 
            bool ans = true;
            for (int c = 0; c < numCourses; c++)
            {
                ans = CanFinishDFS(c, preMap, visited);
                if (ans == false)
                    return false;
            }
            return ans;
        }
        private bool CanFinishDFS(int course, Dictionary<int, List<int>> preMap, HashSet<int> visited)
        {
            if (visited.Contains(course))
                return false;
            if (preMap.ContainsKey(course) == false || preMap[course].Count == 0)
                return true;

            visited.Add(course);
            foreach (int c in preMap[course])
            {
                if (CanFinishDFS(c, preMap, visited) == false)
                    return false;
            }
            visited.Remove(course);
            preMap[course].Clear();

            return true;
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


        /// <summary>
        /// 56. Merge Intervals
        /// https://leetcode.com/problems/merge-intervals/
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] Merge(int[][] intervals)
        {
            return null;
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

        /// <summary>
        /// 141. Linked List Cycle
        /// https://leetcode.com/problems/linked-list-cycle/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode slow = head.next;
            ListNode fast = head.next.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;

                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
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


        /// <summary>
        /// 54. Spiral Matrix
        /// https://leetcode.com/problems/spiral-matrix/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> visitedIdx = new List<int>();
            IList<int> visited = new List<int>();
            int direction = 0;      //0: left, 1: Down, 2:Right, 3: Up
            int m = matrix.Length;      //# of rows
            int n = matrix[0].Length;   //# of cols
            int row = 0, col = 0;
            int curridx = 0;
            while (visited.Count < m * n)
            {
                curridx = row * n + col;
                if (direction == 0)
                {
                    //Left
                    if (col >= n || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Down
                        direction = 1;
                        col--;
                        row++;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        col++;
                    }
                }
                else if (direction == 1)
                {
                    //Down
                    if (row >= m || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Right
                        direction = 2;
                        row--;
                        col--;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        row++;
                    }
                }
                else if (direction == 2)
                {
                    //Right
                    if (col < 0 || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Up
                        direction = 3;
                        col++;
                        row--;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        col--;
                    }
                }
                else
                {
                    //Up
                    if (row < 0 || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Left
                        direction = 0;
                        row++;
                        col++;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        row--;
                    }
                }
            }

            return visited;
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


        /// <summary>
        /// 424. Longest Repeating Character Replacement
        /// https://leetcode.com/problems/longest-repeating-character-replacement/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CharacterReplacement(string s, int k)
        {
            int n = s.Length;
            int[] letterCnts = new int[26];
            for (int i = 0; i < 26; i++)
                letterCnts[i] = 0;

            int l = 0, r = 0;
            int longestLen = 1;
            int maxCnt = 0;
            //length - maxCnt <= K >> Answer. Length
            while (r < n)
            {
                letterCnts[s[r] - 'A']++;
                maxCnt = Math.Max(maxCnt, letterCnts[s[r] - 'A']);

                while (l <= r && (r - l + 1) - maxCnt > k)
                {
                    letterCnts[s[l] - 'A']--;
                    l++;
                }

                longestLen = Math.Max(longestLen, r - l + 1);
                r++;
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


        /// <summary>
        /// 100. Same Tree
        /// https://leetcode.com/problems/same-tree/
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p == null || q == null)
                return false;

            if (p.val != q.val)
                return false;
            else
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
        }

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
