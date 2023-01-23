using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Study
{
    public class Daily
    {
        /// <summary>
        /// 433. Minimum Genetic Mutation
        /// https://leetcode.com/problems/minimum-genetic-mutation/
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public int MinMutation(string start, string end, string[] bank)
        {
            Dictionary<string, List<string>> g = new Dictionary<string, List<string>>();
            g.Add(start, new List<string>());
            foreach (string gene in bank)
            {
                if (g.ContainsKey(gene) == false)
                    g.Add(gene, new List<string>());
            }
            foreach (var gen in g)
            {
                BuildGraph(gen.Key, g, bank);
            }

            HashSet<string> visited = new HashSet<string>();
            Queue<string[]> qGraph = new Queue<string[]>();
            qGraph.Enqueue(new string[] { start, "0" });
            while (qGraph.Count > 0)
            {
                string[] gene = qGraph.Dequeue();
                visited.Add(gene[0]);
                int lv = int.Parse(gene[1]);
                if (gene[0] == end)
                    return lv;

                foreach (var v in g[gene[0]])
                {
                    if (visited.Contains(v) == false)
                        qGraph.Enqueue(new string[] { v, (lv + 1).ToString() });
                }
            }

            return -1;
        }
        private void BuildGraph(string gene, Dictionary<string, List<string>> g, string[] bank)
        {
            foreach (string bGen in bank)
            {
                int diff = 0;
                for (int i = 0; i < bGen.Length; i++)
                {
                    if (gene[i] != bGen[i])
                        diff++;
                    if (diff > 1)
                        break;
                }
                if (diff == 1)
                    g[gene].Add(bGen);
            }
        }



        /// <summary>
        /// 2131. Longest Palindrome by Concatenating Two Letter Words
        /// https://leetcode.com/problems/longest-palindrome-by-concatenating-two-letter-words/
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestPalindrome(string[] words)
        {
            Dictionary<string, int> pairStr = new Dictionary<string, int>();
            int longestLen = 0;
            for (int i = 0; i < words.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(words[i][1]);
                sb.Append(words[i][0]);
                if (pairStr.ContainsKey(sb.ToString()))
                {
                    longestLen += 4;
                    pairStr[sb.ToString()]--;
                    if (pairStr[sb.ToString()] == 0)
                        pairStr.Remove(sb.ToString());
                }
                else
                {
                    if (pairStr.ContainsKey(words[i]) == false)
                        pairStr.Add(words[i], 0);
                    pairStr[words[i]]++;
                }
            }
            foreach (var p in pairStr)
            {
                if (p.Key[0] == p.Key[1])
                {
                    longestLen += 2;
                    break;
                }
            }

            return longestLen;
        }


        /// <summary>
        /// 212. Word Search II
        /// https://leetcode.com/problems/word-search-ii/submissions/
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



        /// <summary>
        /// 1047. Remove All Adjacent Duplicates In String
        /// https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string s)
        {
            Stack<char> sBuff = new Stack<char>();
            foreach(char c in s)
            {
                if (sBuff.Count > 0 && sBuff.Peek() == c)
                    sBuff.Pop();
                else
                    sBuff.Push(c);
            }

            StringBuilder sb = new StringBuilder();
            while(sBuff.Count > 0)
                sb.Insert(0, sBuff.Pop());

            return sb.ToString();
        }


        /// <summary>
        /// 1099. Two Sum Less Than K
        /// https://leetcode.com/problems/two-sum-less-than-k/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int TwoSumLessThanK(int[] nums, int k)
        {
            Array.Sort(nums);
            int maxSum = -1;
            int left = 0, right = nums.Length - 1;
            while( left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum < k && sum > maxSum)
                    maxSum = sum;
                else if (sum >= k)
                    right--;
                else
                    left++;
            }

            return maxSum;
        }
        private int TwoSumLessThanKS(int[] nums, int target, int startIdx)
        {
            int l = startIdx + 1;
            int r = nums.Length - 1;

            //t=5
            //1 3 5 7
            //l=1, r=3
            //m=2
            //l=1, r=1
            //l=2, r=1

            //t=7
            //1 3 3 5 5 7
            //l=1,r=5
            //m=3
            //l=4,r=5
            //m=4
            //l=5,r=5
            //m=5
            //l=5,r=4

            //t=3
            //1 3 3 5 5 7
            //l=1,r=5
            //m=3
            //l=1,r=2
            //m=1
            //l=1,r=0
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (target <= nums[m])
                    r = m - 1;
                else
                    l = m + 1;
            }

            return r <= startIdx ? -1 : nums[r];
        }
        public int TwoSumLessThanK_Adv(int[] nums, int k)
        {
            int ans = -1;
            int[] cnt = new int[1001];
            foreach (int num in nums)
                cnt[num]++;

            int l = 1;
            int r = 1000;
            while ( l <= r)
            {
                if (l + r >= k || cnt[r] == 0)
                    r--;
                else
                {
                    if (cnt[l] > (l < r ? 0 : 1))
                        ans = Math.Max(ans, l + r);
                    l++;
                }
            }

            return ans;
        }


        /// <summary>
        /// 907. Sum of Subarray Minimums
        /// https://leetcode.com/problems/sum-of-subarray-minimums/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumSubarrayMins(int[] arr)
        {
            int modulo = 1000000000 + 7;
            int n = arr.Length;
            int[] dp = new int[n];
            //index
            Stack<int> sTrack = new Stack<int>();
            //3,1,2,4
            for (int i = 0; i < n;i++)
            {
                while(sTrack.Count > 0 && arr[sTrack.Peek()] >= arr[i])
                    sTrack.Pop();

                if (sTrack.Count > 0) {
                    int prevSmallerIdx = sTrack.Peek();
                    dp[i] = dp[prevSmallerIdx] + (i- prevSmallerIdx) * arr[i];
                }
                else
                    dp[i] = (i + 1) * arr[i];

                sTrack.Push(i);
            }
            int minSum = 0;
            foreach(int d in dp)
            {
                minSum += d;
                minSum %= modulo;
            }
            return minSum;
        }


        /// <summary>
        /// 1657. Determine if Two Strings Are Close
        /// https://leetcode.com/problems/determine-if-two-strings-are-close/
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool CloseStrings(string word1, string word2)
        {
            //Condition 1: Every character that exists in word1 must exist in word2 as well, irrespective of the frequency.
            //             Let's understand this condition with an example. The following figure illustrates the valid transformations of a string uua on applying operations 1 and 2.
            //Condition 2: The frequency of all the characters is always the same. In the above example for string uua, regardless of the operation, following condition always holds :
            //             There exists 1 character that occurs once(frequency = 1) and 1 character that occurs twice(frequency = 2)
            if (word1.Length != word2.Length)
                return false;

            int[] word1Map = new int[26];
            int[] word2Map = new int[26];
            foreach (char c in word1)
            {
                word1Map[c - 'a']++;
            }
            foreach (char c in word2)
            {
                word2Map[c - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if ((word1Map[i] == 0 && word2Map[i] > 0) ||
                    (word2Map[i] == 0 && word1Map[i] > 0))
                {
                    return false;
                }
            }
            Array.Sort(word1Map);
            Array.Sort(word2Map);
            for (int i = 0; i < 26; i++)
            {
                if(word1Map[i] != word2Map[i])
                    return false;
            }
            return true;

        }

        /// <summary>
        /// 944. Delete Columns to Make Sorted
        /// https://leetcode.com/problems/delete-columns-to-make-sorted/description/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MinDeletionSize(string[] strs)
        {
            int n = strs.Length;
            int colLen = strs[0].Length;
            int ans = 0;
            for (int col = 0; col < colLen; col++)
            {
                int line = 0;
                char c = strs[line][col];
                while (line < n)
                {
                    if (c > strs[line][col])
                        break;
                    else
                        c = strs[line++][col];
                }
                if (line != n)
                    ans++;
            }


            return ans;
        }


        /// <summary>
        /// 2244. Minimum Rounds to Complete All Tasks
        /// https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks/
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public int MinimumRounds(int[] tasks)
        {
            //difficulty, # of tasks
            Dictionary<int,int> map = new Dictionary<int, int>();
            Dictionary<int, int?> dp = new Dictionary<int, int?>();
            dp.Add(1, null);
            dp.Add(2, 1);
            dp.Add(3, 1);
            foreach (int lv in tasks)
            {
                if (map.ContainsKey(lv) == false)
                    map.Add(lv, 0);
                map[lv]++;
            }

            int ans = 0;
            foreach(var d in map)
            {
                int? res = MinimumRounds(d.Value, dp);
                if (res == null)
                    return -1;
                else
                    ans += res.Value;
            }

            return ans;
        }
        private int? MinimumRounds(int tasks, Dictionary<int, int?> dp)
        {
            if (dp.ContainsKey(tasks))
                return dp[tasks];

            int? min1 = MinimumRounds(tasks - 2, dp);
            int? min2 = MinimumRounds(tasks - 3, dp);
            int? res = null;
            if (min1 != null && min2 != null)
            {
                res = Math.Min(min1.Value, min2.Value) + 1;
            }
            else if (min1 != null)
            {
                res = min1.Value + 1;
            }
            else if (min2 != null)
            {
                res = min2.Value + 1;
            }
            else
            {
                res = null;
            }
            dp.Add(tasks, res);
            return res;
        }


        /// <summary>
        /// 452. Minimum Number of Arrows to Burst Balloons
        /// https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/description/
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int FindMinArrowShots(int[][] points)
        {
            var sortedPoints = points.OrderBy(p => p[0]);  //.ThenBy(p => p[1]);
            int? currEnd = null;
            int arrow = 1;
            foreach(var point in sortedPoints)
            {
                if (currEnd == null)
                    currEnd = point[1];
                else
                {
                    if(point[0] > currEnd.Value)
                    {
                        arrow++;
                        currEnd = point[1];
                    }
                    else
                    {
                        currEnd = Math.Min(currEnd.Value, point[1]);
                    }
                }
            }

            return arrow;
        }



        /// <summary>
        /// 1519. Number of Nodes in the Sub-Tree With the Same Label
        /// https://leetcode.com/problems/number-of-nodes-in-the-sub-tree-with-the-same-label/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="labels"></param>
        /// <returns></returns>
        public int[] CountSubTrees(int n, int[][] edges, string labels)
        {
            int[] subNodes = new int[n];
            int[] ancestors = new int[n];
            for (int i = 0; i < n; i++)
                ancestors[i] = -1;

            foreach (var edge in edges)
            {
                subNodes[edge[0]]++;
                ancestors[edge[1]] = edge[0];
            }

            int[] ans = new int[n];

            Dictionary<char,int>[] cnts = new Dictionary<char, int>[n];
            Queue<int> qNodes = new Queue<int>();
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (subNodes[i] == 0) { 
                    //edge
                    qNodes.Enqueue(i);
                }
            }

            while (qNodes.Count > 0)
            {
                int nd = qNodes.Dequeue();
                if (seen.Contains(nd))
                    continue;

                seen.Add(nd);
                char currChar = labels[nd];
                //ancestor exists
                if (cnts[nd] == null)
                    cnts[nd] = new Dictionary<char, int>();
                if (cnts[nd].ContainsKey(currChar) == false)
                    cnts[nd].Add(currChar, 0);
                cnts[nd][currChar]++;

                //check ancestor
                if ( ancestors[nd] != -1)
                {
                    int anc = ancestors[nd];
                    //append child node's history
                    foreach(var cnt in cnts[nd])
                    {
                        if (cnts[anc] == null)
                            cnts[anc] = new Dictionary<char, int>();
                        if (cnts[anc].ContainsKey(cnt.Key) == false)
                            cnts[anc].Add(cnt.Key, 0);
                        cnts[anc][cnt.Key]+= cnt.Value;
                    }

                    qNodes.Enqueue(anc);
                }
            }

            for(int i = 0; i < n; i++)
            {
                ans[i] = cnts[i][labels[i]];
            }

            return ans;
        }


        /// <summary>
        /// 926. Flip String to Monotone Increasing
        /// https://leetcode.com/problems/flip-string-to-monotone-increasing/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinFlipsMonoIncr(string s)
        {
            //Base
            //  step 01.  from left to right, flip 1 to 0 and count
            //  step 02.  from right to left, flip 0 to 1 and count

            //Solution #1 Dynamic Windows


            //Solution #2 Dynamic Programming
            int n = s.Length;

            //int[] dp = new int[n];
            //dp[0] = 0;
            //int numOfOne = 0;
            //for(int i = 0; i < n; i++)
            //{
            //    if (s[i] == '1')
            //    {
            //        //맨 끝이 1인 경우 flip 없음
            //        numOfOne++;
            //        if (i > 0)
            //            dp[i] = dp[i - 1];
            //    }
            //    else if (i > 0)
            //    {
            //        //0을 그대로 두고, 앞의 나온 모든 1을 0으로 바꾸는 횟수 "numOfOne"  0을 두고
            //        //0을 1로 flip, 바로 앞전에 답에 1만 더하면 됨
            //        if (i > 0)
            //            dp[i] = Math.Min(numOfOne, dp[i - 1] + 1);
            //    }
            //}
            //return dp[n - 1];

            int ans = 0, num = 0;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    //맨 끝이 1인 경우 flip 없음
                    num++;
                }
                else
                {
                    //0을 그대로 두고, 앞의 나온 모든 1을 0으로 바꾸는 횟수 "numOfOne"  0을 두고
                    //0을 1로 flip, 바로 앞전에 답에 1만 더하면 됨
                    ans = Math.Min(num, ans + 1);
                }
            }
            return ans;
        }



        /// <summary>
        /// 491. Non-decreasing Subsequences
        /// https://leetcode.com/problems/non-decreasing-subsequences/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            HashSet<IList<int>> dp = new HashSet<IList<int>>();
            IList<int> result = new List<int>();
            FindSubsequencesBT(nums, 0, result, dp);

            IList<IList<int>> ans = new List<IList<int>>();
            foreach (IList<int> item in dp)
                ans.Add(item);

            return ans;
        }
        public void FindSubsequencesBT(int[] nums, int startIdx, IList<int> result, HashSet<IList<int>> dp)
        {
            int n = nums.Length;
            if (startIdx == n)
            {
                if (result.Count >= 2)
                {
                    IList<int> tmp = new List<int>();
                    foreach (int i in result)
                        tmp.Add(i);

                    if(dp.Contains(tmp)==false)
                        dp.Add(tmp);
                }
                return;
            }

            if (result.Count == 0 || result[result.Count-1] <= nums[startIdx])
            {
                result.Add(nums[startIdx]);
                FindSubsequencesBT(nums, startIdx+1, result, dp);
                result.RemoveAt(result.Count - 1);
            }
            FindSubsequencesBT(nums, startIdx + 1, result, dp);
        }


        /// <summary>
        /// 997. Find the Town Judge
        /// https://leetcode.com/problems/find-the-town-judge/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="trust"></param>
        /// <returns></returns>
        public int FindJudge(int n, int[][] trust)
        {
            if (trust.Length < n - 1)
                return -1;

            int[] trustScores = new int[n + 1];

            foreach (int[] relation in trust)
            {
                trustScores[relation[0]]--;
                trustScores[relation[1]]++;
            }

            for (int i = 1; i <= n; i++)
            {
                if (trustScores[i] == n - 1)
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// 844. Backspace String Compare
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool BackspaceCompare1(string s, string t)
        {
            int sIdx = s.Length - 1, tIdx = t.Length - 1;
            int sBS = 0, tBS = 0;
            while (sIdx >= 0 || tIdx >= 0)
            {
                sBS = 0;
                tBS = 0;
                while (sIdx >= 0)
                {
                    if (s[sIdx] == '#') { sIdx--; sBS++; }
                    else if (sBS > 0) { sIdx--; sBS--; }
                    else { break; }
                }

                while (tIdx >= 0)
                {
                    if (t[tIdx] == '#') { tIdx--; tBS++; }
                    else if (tBS > 0) { tIdx--; tBS--; }
                    else { break; }
                }

                if ((sIdx >= 0) != (tIdx >= 0))
                    return false;
                if (sIdx >= 0 && tIdx >= 0 && s[sIdx] != t[tIdx])
                    return false;

                sIdx--; tIdx--;
            }

            return true;
        }
        public bool BackspaceCompare(string s, string t)
        {
            Stack<char> sS = BackspaceCompareC(s);
            Stack<char> sT = BackspaceCompareC(t);

            if (sS.Count == sT.Count)
            {
                while (sS.Count > 0)
                {
                    if (sS.Pop() == sT.Pop())
                        continue;
                    else
                        return false;
                }
                return true;
            }
            else
                return false;
        }
        private Stack<char> BackspaceCompareC(string str)
        {
            Stack<char> sStr = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '#')
                {
                    if (sStr.Count > 0)
                        sStr.Pop();
                }
                else
                    sStr.Push(str[i]);
            }

            return sStr;
        }


        /// <summary>
        /// 15. 3Sum
        /// https://leetcode.com/problems/3sum/?envType=study-plan&id=algorithm-ii
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> groups = new List<IList<int>>();
            int n = nums.Length;
            Array.Sort(nums);

            for (int i = 0; i < n - 1; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i])
                    continue;

                int l = i + 1, r = n - 1;
                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        List<int> tmp = new List<int>();
                        tmp.Add(nums[i]); tmp.Add(nums[l]); tmp.Add(nums[r]);
                        groups.Add(tmp);
                    }
                    if (sum <= 0)
                    {
                        l++;
                        while (l < n && nums[l - 1] == nums[l])
                            l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }

            return groups;
        }

        /// <summary>
        /// 82. Remove Duplicates from Sorted List II
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/?envType=study-plan&id=algorithm-ii
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode newHead = new ListNode(-1, head);
            ListNode currNew = newHead;

            while (head != null)
            {
                if (head.next != null && head.val == head.next.val)
                {
                    while (head.next != null && head.val == head.next.val)
                        head = head.next;
                    currNew.next = head.next;
                }
                else
                    currNew = currNew.next;

                head = head.next;
            }

            return newHead.next;
        }


    }
}
