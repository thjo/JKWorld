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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="calories"></param>
        /// <param name="k"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="subRoot"></param>
        /// <returns></returns>
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


        #region | Online Interview - 4/15/2022 | 

        public class TreeNodeEx
        {
            public TreeNode Node;
            //public int Depth;
            public int Total;
            public TreeNodeEx(TreeNode node, int prevVal)
            {
                Node = node;
                Total = prevVal * 2 + node.val;
            }
        }
        public int SumRootToLeaf(TreeNode root)
        {
            int sum = 0;
            if (root == null)
                return sum;

            Queue<TreeNodeEx> tree = new Queue<TreeNodeEx>();
            tree.Enqueue(new TreeNodeEx(root, 0));
            while (tree.Count > 0)
            {
                TreeNodeEx node = tree.Dequeue();
                if (node.Node.left == null && node.Node.right == null)
                    sum += node.Total;
                else
                {
                    if (node.Node.left != null)
                        tree.Enqueue(new TreeNodeEx(node.Node.left, node.Total));
                    if (node.Node.right != null)
                        tree.Enqueue(new TreeNodeEx(node.Node.right, node.Total));
                }
            }

            return sum;
        }


        public IList<string> GenerateSentences(IList<IList<string>> synonyms, string text)
        {
            Dictionary<string, IList<string>> dicBooks = new Dictionary<string, IList<string>>();

            for (int i = 0; i < synonyms.Count; i++)
            {
                AddWord(dicBooks, synonyms[i][0], synonyms[i][1]);
                AddWord(dicBooks, synonyms[i][1], synonyms[i][0]);
            }
            //happy > joy
            //joy > happy > cheerful
            //sad > sorrow
            //sorrow > sad
            // cheerful > joy

            Queue<string> q = new Queue<string>();
            IList<string> res = new List<string>();
            q.Enqueue(text);
            while (q.Count > 0)
            {
                string currText = q.Dequeue();
                if(res.Contains(currText) == false)
                    res.Add(currText);

                string[] words = currText.Split(" ".ToCharArray());
                for (int i = 0; i < words.Length; i++)
                {
                    if (dicBooks.ContainsKey(words[i]))
                    {
                        foreach (var s in dicBooks[words[i]])
                        {
                            words[i] = s;
                            string newText = String.Join(" ", words);
                            if (res.Contains(newText) == false)
                                q.Enqueue(newText);
                        }
                    }
                }
            }

            string[] results = new string[res.Count];
            res.CopyTo(results, 0);
            Array.Sort(results);
            res.Clear();
            foreach (string s in results)
                res.Add(s);

            return res;
        }

        private void AddWord(Dictionary<string, IList<string>> dicBooks, string w1, string w2)
        {
            if (dicBooks.ContainsKey(w1) == false)
                dicBooks.Add(w1, new List<string>());
            dicBooks[w1].Add(w2);
        }


        #endregion


        #region | Online Interview - 4/16/2022 | 

        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> banWords = new HashSet<string>();
            foreach (string b in banned)
            {
                if (banWords.Contains(b) == false)
                    banWords.Add(b);
            }
            Dictionary<string, int> pDic = new Dictionary<string, int>();
            int max = 0;
            string res = "";
            paragraph = paragraph.ToLower();
            string w = "";
            foreach (char c in paragraph)
            {
                if (c >= 'a' && c <= 'z')
                    w += c;
                else if (w != "")
                {
                    if (banWords.Contains(w) == false)
                    {
                        if (pDic.ContainsKey(w))
                            pDic[w]++;
                        else
                            pDic.Add(w, 1);

                        if (pDic[w] > max)
                        {
                            res = w;
                            max = pDic[w];
                        }
                    }
                    w = "";
                }
            }
            if (w != "")
            {
                if (banWords.Contains(w) == false)
                {
                    if (pDic.ContainsKey(w))
                        pDic[w]++;
                    else
                        pDic.Add(w, 1);

                    if (pDic[w] > max)
                    {
                        res = w;
                        max = pDic[w];
                    }
                }
            }


            return res;
        }

        /// <summary>
        /// 675. Cut Off Trees for Golf Event
        /// https://leetcode.com/problems/cut-off-trees-for-golf-event/
        /// </summary>
        /// <param name="forest"></param>
        /// <returns></returns>
        public int CutOffTree(IList<IList<int>> forest)
        {
            return -1;
        }

        #endregion


        #region | Onsite - 4/17/2022 | 

        /// <summary>
        /// 1539. Kth Missing Positive Number
        /// https://leetcode.com/problems/kth-missing-positive-number/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthPositive(int[] arr, int k)
        {
            int currVal = arr[0];
            k = k + (1 - currVal);
            if (k == 0)
                return currVal - 1;
            else if (k < 0)
                return currVal + k - 1;

            int n = arr.Length;
            int idx = 1;
            //2
            //5
            while (k > 0 && idx < n)
            {
                int interval = arr[idx] - currVal - 1;
                currVal = arr[idx];
                idx++;

                if (interval == 0)
                    continue;

                k = k - interval;
                if (k == 0)
                    return currVal - 1;
                else if (k < 0)
                    return currVal + k - 1;
            }

            return currVal + k;
        }

        /// <summary>
        /// 1035. Uncrossed Lines
        /// https://leetcode.com/problems/uncrossed-lines/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;

            int[,] dp = new int[n1 + 1, n2 + 1];

            for (int i = 0; i <= n1; i++)
            {
                for (int j = 0; j <= n2; j++)
                {

                    if (i == 0 || j == 0)
                        dp[i, j] = 0;
                    else if (nums1[i - 1] == nums2[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[n1, n2];
        }



        #endregion


        #region | Online - 4/18/22 | 

        /// <summary>
        /// 653. Two Sum IV - Input is a BST
        /// https://leetcode.com/problems/two-sum-iv-input-is-a-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool FindTarget(TreeNode root, int k)
        {
            //HashSet<int> sets = new HashSet<int>();
            //return FindTargetR(root, k, sets);
            List<int> sortedList = new List<int>();
            InOrderTrav(root, sortedList);
            int l = 0, r = sortedList.Count - 1;
            while (l < r)
            {
                if (sortedList[l] + sortedList[r] == k)
                    return true;
                else if (sortedList[l] + sortedList[r] > k)
                    r--;
                else
                    l++;
            }
            return false;
        }
        private void InOrderTrav(TreeNode root, List<int> sortedList)
        {
            if (root == null)
                return;

            InOrderTrav(root.left, sortedList);
            sortedList.Add(root.val);
            InOrderTrav(root.right, sortedList);
        }
        private bool FindTargetR(TreeNode root, int k, HashSet<int> sets)
        {
            if (root == null)
                return false;

            if (sets.Contains(k - root.val))
                return true;
            sets.Add(root.val);

            return FindTargetR(root.left, k, sets) ||
                FindTargetR(root.right, k, sets);
        }


        /// <summary>
        /// 1071. Greatest Common Divisor of Strings
        /// https://leetcode.com/problems/greatest-common-divisor-of-strings/
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string GcdOfStrings(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            int minLen = Math.Min(len1, len2);

            for (int i = minLen; i >= 1; i--)
            {
                if (len1 % i == 0 && len2 % i == 0 && str1.Substring(0, i).Equals(str2.Substring(0, i)))
                {
                    String tmp1 = str1.Substring(i) + str1.Substring(0, i);
                    String tmp2 = str2.Substring(i) + str2.Substring(0, i);
                    if (tmp1.Equals(str1) && tmp2.Equals(str2))
                    {
                        return str1.Substring(0, i);
                    }
                }
            }

            return "";
        }

        #endregion


        #region | Online Interview - 4/24/2022 | 

        /// <summary>
        /// 922. Sort Array By Parity II
        /// https://leetcode.com/problems/sort-array-by-parity-ii/submissions/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayByParityII(int[] nums)
        {
            int n = nums.Length;

            int even = 0;
            //int i = 0;
            //while(i < n && even < n)
            for (int i = 0; i < n && even < n; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    if (i % 2 != 0 || i > even)
                    {
                        Swap(nums, i, even);
                    }
                    even += 2;
                }
            }

            return nums;
        }
        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        /// <summary>
        /// 807. Max Increase to Keep City Skyline
        /// https://leetcode.com/problems/max-increase-to-keep-city-skyline/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            //North - Max of each col
            //7 8 4 9 

            //South
            //9 4 8 7

            //West - Max of row
            //8 7 9 3

            //East
            //3, 9, 7, 8
            int n = grid.Length;
            int m = grid[0].Length;
            int[] maxRow = new int[n];
            int[] maxCol = new int[m];

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    maxRow[r] = Math.Max(maxRow[r], grid[r][c]);
                    maxCol[c] = Math.Max(maxCol[c], grid[r][c]);
                }
            }

            int totalIncreased = 0;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    if (grid[r][c] < Math.Min(maxRow[r], maxCol[c]))
                        totalIncreased += (Math.Min(maxRow[r], maxCol[c]) - grid[r][c]);
                }
            }

            return totalIncreased;
        }


        /// <summary>
        /// 980. Unique Paths III
        /// https://leetcode.com/problems/unique-paths-iii/
        /// </summary>
        int totalPath = 0;
        public int UniquePathsIII(int[][] grid)
        {
            int numOfEmptySpots = 0;
            int n = grid.Length;
            int m = grid[0].Length;
            int startIdxRow = -1, startIdxCol = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        startIdxRow = i;
                        startIdxCol = j;
                        numOfEmptySpots++;
                    }
                    else if (grid[i][j] == 0)
                        numOfEmptySpots++;
                }
            }
            totalPath = 0;
            grid[startIdxRow][startIdxCol] = 0;
            UniquePathsIIIBackTrack(grid, startIdxRow, startIdxCol, numOfEmptySpots, n, m);

            return totalPath;
        }
        private void UniquePathsIIIBackTrack(int[][] grid, int rowIdx, int colIdx, int remainedNumOfSpots, int n, int m)
        {
            if (grid[rowIdx][colIdx] == 2 && remainedNumOfSpots == 0)
            {
                totalPath++;
                return;
            }
            if (grid[rowIdx][colIdx] != 0 || remainedNumOfSpots <= 0)
            {
                return;
            }
            int orgMark = grid[rowIdx][colIdx];
            remainedNumOfSpots--;
            grid[rowIdx][colIdx] = 3;   //visited

            //Top
            if (rowIdx > 0)
                UniquePathsIIIBackTrack(grid, rowIdx - 1, colIdx, remainedNumOfSpots, n, m);
            //Bottom
            if (rowIdx < n - 1)
                UniquePathsIIIBackTrack(grid, rowIdx + 1, colIdx, remainedNumOfSpots, n, m);
            //Left
            if (colIdx > 0)
                UniquePathsIIIBackTrack(grid, rowIdx, colIdx - 1, remainedNumOfSpots, n, m);
            //Right
            if (colIdx < m - 1)
                UniquePathsIIIBackTrack(grid, rowIdx, colIdx + 1, remainedNumOfSpots, n, m);

            grid[rowIdx][colIdx] = orgMark;
            //remainedNumOfSpots++;

        }

        #endregion


        #region | Online Interview - 05/01/2022 | 

        /// <summary>
        /// 957. Prison Cells After N Days
        /// https://leetcode.com/problems/prison-cells-after-n-days/
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] PrisonAfterNDays(int[] cells, int n)
        {
            int cellLen = cells.Length;
            List<string> results = new List<string>();
            //results.Add(ConvertToString(cells));
            int idx = 1;
            while (idx <= n)
            {
                cells = CheckCells(cells);
                string tmp = ConvertToString(cells);
                if (results.Contains(tmp))
                    break;
                else
                    results.Add(tmp);
                idx++;
            }
            int mod = n % (results.Count);
            if (mod == 0)
                return ConvertToArray(results[results.Count - 1]);
            else
                return ConvertToArray(results[mod - 1]);
        }
        private int[] CheckCells(int[] cells)
        {
            int[] newCells = new int[cells.Length];
            newCells[0] = 0;
            newCells[cells.Length - 1] = 0;
            for (int i = 1; i < cells.Length - 1; i++)
            {
                if (cells[i - 1] == cells[i + 1])
                    newCells[i] = 1;
                else
                    newCells[i] = 0;
            }
            return newCells;
        }
        private string ConvertToString(int[] cells)
        {
            string res = "";
            foreach (int c in cells)
                res += c.ToString();
            return res;
        }
        private int[] ConvertToArray(string cells)
        {
            int[] res = new int[cells.Length];
            for (int i = 0; i < cells.Length; i++)
                res[i] = int.Parse(cells[i].ToString());

            return res;
        }


        #endregion


        #region | Online Interview - 5/5/2022 | 



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
