using System;
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




        //public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        //{
        //    Queue<string> queue = new Queue<string>();
        //}

        #endregion


        #region | Online Interview - 3/27/2022 | 

        /// <summary>
        /// 541. Reverse String II
        /// https://leetcode.com/problems/reverse-string-ii/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string ReverseStr(string s, int k)
        {
            char[] strs = s.ToCharArray();
            for (int i = 0; i < strs.Length; i += 2*k)
            {
                int start = i, end = Math.Min(i + k-1, strs.Length-1);
                while (start < end)
                {
                    char tmp = strs[start];
                    strs[start] = strs[end];
                    strs[end] = tmp;
                    start++;
                    end--;
                }
            }
            string newStr = "";
            foreach (char c in strs)
                newStr += c;
            return newStr;
        }

        #endregion


        #region | Online Interview - 4/3/2022 | 

        /// <summary>
        /// 994. Rotting Oranges
        /// https://leetcode.com/problems/rotting-oranges/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            int[][] directions = new int[4][];
            directions[0] = new int[2] { 1, 0 };
            directions[1] = new int[2] { 0, 1 };
            directions[2] = new int[2] { -1, 0 };
            directions[3] = new int[2] { 0, -1 };
            int rowLen = grid.Length;
            int colLen = grid[0].Length;

            Queue<int[]> rottenOrangs = new Queue<int[]>();
            int freshOranges = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        List<int> loc = new List<int>();
                        loc.Add(r); loc.Add(c);
                        rottenOrangs.Enqueue(new int[] { r, c, 0 });
                    }
                    else if (grid[r][c] == 1)
                        freshOranges++;
                }
            }

            int numfMins = 0;
            while (rottenOrangs.Count > 0)
            {
                var map = rottenOrangs.Dequeue();
                numfMins = Math.Max(map[2], numfMins);
                for (int i = 0; i < directions.Length; i++)
                {
                    int x = map[0] + directions[i][0];
                    int y = map[1] + directions[i][1];
                    if (x >= 0 && x < rowLen && y >= 0 && y < colLen && grid[x][y] == 1)
                    {
                        grid[x][y] = 2;
                        freshOranges--;
                        rottenOrangs.Enqueue(new int[] { x, y, (map[2] + 1) });
                    }
                }
            }

            return freshOranges > 0 ? -1 : numfMins;
        }

        /// <summary>
        /// 59. Spiral Matrix II
        /// https://leetcode.com/problems/spiral-matrix-ii/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                    matrix[i][j] = -1;
            }

            int[][] dir = new int[4][];
            dir[0] = new int[] { 0, 1 };
            dir[1] = new int[] { 1, 0 };
            dir[2] = new int[] { 0, -1 };
            dir[3] = new int[] { -1, 0 };

            int d = 0;
            int num = 1;
            int row = 0, col = 0;
            while (num <= n * n)
            {
                matrix[row][col] = num;
                int newRow = row + dir[d][0];
                int newCol = col + dir[d][1];
                if (newRow >= 0 && newRow < n
                  && newCol >= 0 && newCol < n
                  && matrix[newRow][newCol] == -1)
                {
                    row = newRow;
                    col = newCol;
                    num++;
                }
                else
                {
                    if (num >= n * n)
                        break;

                    if (d == 3)
                        d = 0;
                    else
                        d++;
                }
            }

            return matrix;

        }


        #endregion


        #region | Online Interview - 4/11/2022 | 

        /// <summary>
        /// 1331. Rank Transform of an Array
        /// https://leetcode.com/problems/rank-transform-of-an-array/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ArrayRankTransform(int[] arr)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(arr[i]))
                    map[arr[i]].Add(i);
                else
                {
                    List<int> buff = new List<int>();
                    buff.Add(i);
                    map.Add(arr[i], buff);
                }
            }
            Array.Sort(arr);
            int[] res = new int[n];
            int rank = 1;
            for (int i = 0; i < n; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    foreach (int idx in map[arr[i]])
                        res[idx] = rank;
                    map.Remove(arr[i]);
                    rank++;
                }
            }

            return res;
        }


        /// <summary>
        /// 1214. Two Sum BSTs
        /// https://leetcode.com/problems/two-sum-bsts/
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target)
        {
            HashSet<int> map = new HashSet<int>();
            SetDicMap(root1, map);

            return TwoSumBSTsRR(root2, target, map);
        }
        private void SetDicMap(TreeNode root, HashSet<int> map)
        {
            if (root == null)
                return;

            SetDicMap(root.left, map);
            if (map.Contains(root.val) == false)
                map.Add(root.val);
            SetDicMap(root.right, map);
        }
        private bool TwoSumBSTsRR(TreeNode root, int target, HashSet<int> map)
        {
            if (root == null)
                return false;

            if (map.Contains(target - root.val))
                return true;

            return TwoSumBSTsRR(root.left, target, map) || TwoSumBSTsRR(root.right, target, map);
        }


        #endregion


        #region | Online Interview - 4/13/2022 | 

        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int n1 = arr1.Length;
            int n2 = arr2.Length;

            int[] res = new int[n1];
            Dictionary<int, int> arr1Dic = new Dictionary<int, int>();
            foreach (int val in arr1)
            {
                if (arr1Dic.ContainsKey(val))
                    arr1Dic[val]++;
                else
                    arr1Dic.Add(val, 1);
            }

            int idxArr2 = 0, idxNew = 0;
            while (idxArr2 < n2)
            {
                int v2 = arr2[idxArr2];
                while (arr1Dic[v2] > 0)
                {
                    res[idxNew++] = v2;
                    arr1Dic[v2]--;
                }
                arr1Dic.Remove(v2);
                idxArr2++;
            }
            if (arr1Dic.Count > 0)
            {
                int[] tmp = new int[n1 - idxNew];
                int i = 0;
                foreach (var v in arr1Dic)
                {
                    for (int k = 0; k < v.Value; k++)
                        tmp[i++] = v.Key;
                }
                Array.Sort(tmp);
                for (int j = 0; j < tmp.Length; j++)
                    res[idxNew++] = tmp[j];
            }
            return res;
        }


        private readonly int MOD = 1000000007;
        private Dictionary<String, int> mem = new Dictionary<string, int>();
        public int NumRollsToTarget(int d, int f, int target)
        {
            if (d == 0 && target == 0)
                return 1;

            if (d <= 0 || target <= 0)
                return 0;

            String key = d + "_" + target;
            if (mem.ContainsKey(key))
                return mem[key];

            int ans = 0;
            for (int i = 1; i <= f && i <= target; i++)
            {
                ans = (ans + NumRollsToTarget(d - 1, f, target - i)) % MOD;
            }
            mem.Add(key, ans);
            return ans;
        }


        #endregion


        #region | Online Interview - 4/14/2022 | 


        public int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {
            int totalPoints = 0;
            int n = calories.Length;
            if (n < k)
                return 0;

            int startIdx = 0, endIdx = 0;
            int sum = 0;
            while (endIdx < k)
            {
                sum += calories[endIdx++];
            }
            //Check 
            if (sum > upper)
                totalPoints++;
            else if (sum < lower)
                totalPoints--;

            while (endIdx < n)
            {
                sum += calories[endIdx++];
                sum -= calories[startIdx++];

                //Check 
                if (sum > upper)
                    totalPoints++;
                else if (sum < lower)
                    totalPoints--;
            }

            return totalPoints;
        }


        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null)
                return false;
            else if (root.val == subRoot.val && IsSameTree(root, subRoot))
                return true;
            else
                return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }
        private bool IsSameTree(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true;
            else if (t1 == null || t2 == null)
                return false;

            return t1.val == t2.val && IsSameTree(t1.left, t2.left) && IsSameTree(t1.right, t2.right);
        }

        #endregion




        public int CountDecreasingRatings(int[] ratings)
        {
            if (ratings == null || ratings.Length < 2)
                return 0;
            else if (ratings.Length < 2)
                return 0;

            int cnt = 0;
            int n = ratings.Length;
            for (int startIdx = 0; startIdx < n; startIdx++)
            {
                bool isBreak = false;
                for (int period = 1; period <= n; period++)
                {
                    if (isBreak)
                        break;

                    bool isIncreasing = false;
                    int currIdx = startIdx;
                    while (isIncreasing == false && period > currIdx-startIdx+1 && currIdx < n-1)
                    {
                        if ((ratings[currIdx] - 1) == (ratings[currIdx + 1]))
                            currIdx++;
                        else
                        {
                            isIncreasing = true;
                            isBreak = true;
                        }
                    }
                    if (isBreak ==false && isIncreasing == false)
                        cnt++;
                }
  
            }
    

            //for (int period = 1; period <= n ; period++)
            //{
            //    for (int startIdx = 0; startIdx <= n - period; startIdx++)
            //    {
            //        int currIdx = startIdx;
            //        bool isIncreasing = false;
            //        while (period != 1 && isIncreasing == false && currIdx < startIdx + period-1)
            //        {
            //            if ( (ratings[currIdx]-1) == (ratings[currIdx + 1]))
            //                currIdx++;
            //            else
            //                isIncreasing = true;
            //        }
            //        if (isIncreasing == false)
            //            cnt++;
            //    }
            //}

            return cnt;
        }

    }
}
