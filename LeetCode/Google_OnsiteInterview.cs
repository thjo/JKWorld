using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Google_OnsiteInterview
    {
        public const int CONST_T = 0;
        public readonly int READONLY_T = 2;
        //public static const int CONST_ST = 10;    //const is already static
        public static readonly int READONLY_ST = 20;
        #region | 01/14/2022 | 

        /// <summary>
        /// 734. Sentence Similarity
        /// https://leetcode.com/problems/sentence-similarity/
        /// </summary>
        /// <param name="sentence1"></param>
        /// <param name="sentence2"></param>
        /// <param name="similarPairs"></param>
        /// <returns></returns>
        public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
        {
            if (sentence1.Length != sentence2.Length) return false;
            HashSet<string> pairs = new HashSet<string>();
            foreach (List<string> pair in similarPairs)
            {
                pairs.Add(pair[0] + pair[1]);
                pairs.Add(pair[1] + pair[0]);
            }
            for (int i = 0; i < sentence1.Length; i++)
            {
                if (!sentence1[i].Equals(sentence2[i]) && !pairs.Contains(sentence1[i] + sentence2[i])) return false;
            }
            return true;
        }


        /// <summary>
        /// 737. Sentence Similarity II
        /// https://leetcode.com/problems/sentence-similarity-ii/submissions/
        /// </summary>
        /// <param name="sentence1"></param>
        /// <param name="sentence2"></param>
        /// <param name="similarPairs"></param>
        /// <returns></returns>
        public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
        {
            if (sentence1.Length != sentence2.Length)
                return false;


            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            Dictionary<string, bool> dp = new Dictionary<string, bool>();
            foreach (var pairStr in similarPairs)
            {
                if (dic.ContainsKey(pairStr[0]))
                {
                    dic[pairStr[0]].Add(pairStr[1]);
                }
                else
                {
                    IList<string> buff = new List<string>();
                    buff.Add(pairStr[1]);
                    dic.Add(pairStr[0], buff);
                }
                if (dic.ContainsKey(pairStr[1]))
                {
                    dic[pairStr[1]].Add(pairStr[0]);
                }
                else
                {
                    IList<string> buff = new List<string>();
                    buff.Add(pairStr[0]);
                    dic.Add(pairStr[1], buff);
                }
            }

            for (int i = 0; i < sentence1.Length; i++)
            {
                if (sentence1[i] == sentence2[i]
                  || CompareStrTwo(sentence1[i], sentence2[i], dic, dp))
                    continue;
                else
                    return false;
            }

            return true;

        }
        private bool CompareStrTwo(string key, string value, Dictionary<string, IList<string>> dic, Dictionary<string, bool> dp)
        {
            if (dp.ContainsKey(string.Format("{0}^{1}", key, value)))
                return dp[string.Format("{0}^{1}", key, value)];
            List<string> checkedList = new List<string>();
            Queue<string> targetKey = new Queue<string>();
            targetKey.Enqueue(key);
            while (targetKey.Count > 0)
            {
                string tmpKey = targetKey.Dequeue();
                checkedList.Add(tmpKey);
                if (dic.ContainsKey(tmpKey))
                {
                    foreach (string word in dic[tmpKey])
                    {
                        if (word == value)
                        {
                            dp.Add(string.Format("{0}^{1}", key, value), true);
                            return true;
                        }
                        else if( checkedList.Contains(word) == false)
                            targetKey.Enqueue(word);
                    }
                }
            }

            dp.Add(string.Format("{0}^{1}", key, value), false);
            return false;
        }


        /// <summary>
        /// 351. Android Unlock Patterns
        /// https://leetcode.com/problems/android-unlock-patterns/
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumberOfPatterns(int m, int n)
        {
            // Keep a recod of invalid numbers on the path between 
            // two selected keys 
            int[][] skip = new int[10][];
            for (int i = 0; i < 10; i++)
                skip[i] = new int[10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    skip[i][j] = 0;
            }
            skip[1][3] = skip[3][1] = 2;
            skip[1][7] = skip[7][1] = 4;
            skip[3][9] = skip[9][3] = 6;
            skip[7][9] = skip[9][7] = 8;
            skip[1][9] = skip[9][1] = skip[2][8] = skip[8][2] = skip[3][7] = skip[7][3] = skip[4][6] = skip[6][4] = 5;
            bool[] visited = new bool[10];
            int res = 0;
            for (int i = m; i <= n; i++)
            {
                for(int startNum = 1; startNum < 10; startNum++)
                {
                    res += NumberOfPatternsDFS(visited, skip, startNum, i - 1);
                }
                ////Enhanced
                //// Use the symetry to reduce DFS call
                //res += NumberOfPatternsDFS(visited, skip, 1, i - 1) * 4;
                //res += NumberOfPatternsDFS(visited, skip, 2, i - 1) * 4;
                //res += NumberOfPatternsDFS(visited, skip, 5, i - 1);
            }
            return res;
        }
        private int NumberOfPatternsDFS(bool[] visited, int[][] skip, int cur, int remain)
        {
            // Base case: out of bound
            if (remain < 0) return 0;
            // Base case: no remaining numbers
            if (remain == 0) return 1;
            // Mark number as visited
            visited[cur] = true;
            int res = 0;


            for (int i = 1; i <= 9; i++)
            {
                // Next key must be unvisited
                // Current key and next key are adjacent or skip number is already visited
                if (!visited[i] && (skip[cur][i] == 0 || visited[skip[cur][i]]))
                {
                    res += NumberOfPatternsDFS(visited, skip, i, remain - 1);
                }
            }
            // Mark as unvisited for the rest of recursion calls after return from the first one  
            visited[cur] = false;
            return res;
        }

        /// <summary>
        /// 642. Design Search Autocomplete System
        /// https://leetcode.com/problems/design-search-autocomplete-system/
        /// </summary>
        /// <param name="sentences"></param>
        /// <param name="times"></param>
        //public AutocompleteSystem(string[] sentences, int[] times)
        //{

        //}
        //public IList<string> Input(char c)
        //{

        //}

        #endregion


        #region | 1/16/2022 | 

        public int CalculateTime(string keyboard, string word)
        {
            Dictionary<char, int> keyboardMap = new Dictionary<char, int>();
            for (int i = 0; i < keyboard.Length; i++)
                keyboardMap.Add(keyboard[i], i);

            int totalTimes = 0;
            int currIdx = 0;
            foreach (char c in word)
            {
                totalTimes += Math.Abs(currIdx - keyboardMap[c]);
                currIdx = keyboardMap[c];
            }

            return totalTimes;

        }


        public int MaxLevelSum(TreeNode root)
        {
            //Check the Level of the tree
            //Lv 1 to Max
            //  Sum

            //Lv, Sum
            Dictionary<int, int> map = new Dictionary<int, int>();
            if (root == null)
                return 0;

            SumperLv(root, 1, map);

            int maxVal = int.MinValue;
            int maxLv = 0;
            foreach (var v in map)
            {
                if (v.Value > maxVal)
                {
                    maxLv = v.Key;
                    maxVal = v.Value;
                }
            }

            return maxLv;

            
        }
        private void SumperLv(TreeNode root, int lv, Dictionary<int, int> map)
        {
            if (root == null)
                return;

            if (map.ContainsKey(lv))
                map[lv] += root.val;
            else
                map.Add(lv, root.val);

            SumperLv(root.left, lv + 1, map);
            SumperLv(root.right, lv + 1, map);
        }


        public int OddEvenJumps(int[] arr)
        {
            int len = arr.Length;
            bool[] oddStarting = new bool[len];
            bool[] evenStarting = new bool[len];

            //The last index is always good
            oddStarting[len - 1] = evenStarting[len - 1] = true;
            int cntOfGoodStartingIdx = 1;

            for (int i = len - 2; i >= 0; i--)
            {
                int ceilingVal = int.MaxValue;
                int ceilingIdx = -1;
                int floorVal = int.MinValue;
                int floorIdx = -1;
                for (int j = i + 1; j < len; j++)
                {
                    if (arr[j] >= arr[i] && arr[j] < ceilingVal)
                    {
                        ceilingVal = arr[j];
                        ceilingIdx = j;
                    }

                    if (arr[j] <= arr[i] && arr[j] > floorVal)
                    {
                        floorVal = arr[j];
                        floorIdx = j;
                    }
                }
                oddStarting[i] = (ceilingIdx != -1 && evenStarting[ceilingIdx]);
                evenStarting[i] = (floorIdx != -1 && oddStarting[floorIdx]);

                if (oddStarting[i])
                    cntOfGoodStartingIdx++;
            }

            return cntOfGoodStartingIdx;
        }




        #endregion



        #region | 1/17/2022 | 

        //private Dictionary<string, int> msgDict;

        //public Logger()
        //{
        //    msgDict = new Dictionary<string, int>();
        //}

        //public bool ShouldPrintMessage(int timestamp, string message)
        //{
        //    if (this.msgDict.ContainsKey(message) == false)
        //    {
        //        this.msgDict.Add(message, timestamp);
        //        return true;
        //    }

        //    int oldTimestamp = this.msgDict[message];
        //    if (timestamp - oldTimestamp >= 10)
        //    {
        //        this.msgDict[message] = timestamp;
        //        return true;
        //    }
        //    else
        //        return false;

        //}


        /// <summary>
        /// https://leetcode.com/problems/campus-bikes/
        /// </summary>
        /// <param name="workers"></param>
        /// <param name="bikes"></param>
        /// <returns></returns>
        public int[] AssignBikes(int[][] workers, int[][] bikes)
        {

            //1. pair with the shortest Manhattan distance between each other and assign the bike to that worker.
            //2. If there are multiple (workeri, bikej) pairs with the same shortest Manhattan distance,
            //2-1. we choose the pair with the smallest worker index
            //2-2. we choose the pair with the smallest bike index
            //3. Repeat this process until there are no available workers.

            //Return an array answer of length n, where answer[i] is the index (0-indexed) of the bike that the ith worker is assigned to.

            //Init
            int[][] distanceMap = new int[workers.Length][];
            for (int w = 0; w < workers.Length; w++)
            {
                distanceMap[w] = new int[bikes.Length];
                for (int b = 0; b < bikes.Length; b++)
                {
                    distanceMap[w][b] = int.MaxValue;
                }
            }

            //Calculate distance beween all workers and bikes
            for (int w = 0; w < workers.Length; w++)
            {
                for (int b = 0; b < bikes.Length; b++)
                {
                    distanceMap[w][b] = Math.Abs(workers[w][0] - bikes[b][0]) + Math.Abs(workers[w][1] - bikes[b][1]);
                } //End for
            } //End for

            //index: Worker, value: Bike
            int[] res = new int[workers.Length];
            bool[] assignedWorkers = new bool[workers.Length];
            bool[] assignedBikes = new bool[bikes.Length];

            for (int i = 0; i < workers.Length; i++)
            {
                int minDist = int.MaxValue;
                int minDistW = -1, minDistB = -1;
                for (int w = 0; w < workers.Length; w++)
                {
                    if (assignedWorkers[w])
                        continue;
                    for (int b = 0; b < bikes.Length; b++)
                    {
                        if (assignedBikes[b])
                            continue;

                        if (minDist > distanceMap[w][b])
                        {
                            minDist = distanceMap[w][b];
                            minDistW = w;
                            minDistB = b;
                        }

                    }
                }
                res[minDistW] = minDistB;
                assignedWorkers[minDistW] = true;
                assignedBikes[minDistB] = true;
            }

            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/all-paths-from-source-lead-to-destination/solution/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool LeadsToDestination(int n, int[][] edges, int source, int destination)
        {
            if (edges == null || edges.Length == 0)
            {
                return source == destination;
            }

            List<int>[] g = BuildDigraph(n, edges);
            int[] states = new int[n];
            for (int i = 0; i < n; i++)
                states[i] = 0;

            return LeadsToDestDFS(g, source, destination, states);
        }
        private bool LeadsToDestDFS(List<int>[] g, int s, int d, int[] states)
        {

            if (g[s] == null || g[s].Count == 0)
                return s == d;

            if (states[s] != 0)
                return states[s] == 2;

            states[s] = 1;
            foreach (int next in g[s])
            {
                if (LeadsToDestDFS(g, next, d, states) == false)
                     return false;
            }

            states[s] = 2;
            return true;
        }
        private List<int>[] BuildDigraph(int n, int[][] edges)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
            }

            return graph;
        }

        #endregion


        #region | 1/19/2022 | 

        /// <summary>
        /// 249. Group Shifted Strings
        /// https://leetcode.com/problems/group-shifted-strings/description/
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            IList<IList<string>> res = new List<IList<string>>();
            if (strings == null || strings.Length == 0) return res;

            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            foreach (string s in strings)
            {
                string key = Normalize(s);
                if (dic.ContainsKey(key))
                    dic[key].Add(s);
                else
                {
                    IList<string> buff = new List<string>();
                    buff.Add(s);
                    dic.Add(key, buff);
                }
            }

            foreach (var s in dic)
            {
                res.Add(s.Value);
            }

            return res;
        }
        private string Normalize(string s)
        {
            if (s.Length == 0 || s[0] == 'a') return s;

            char[] chars = s.ToCharArray();
            int diff = chars[0] - 'a';
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] - diff);
                if (chars[i] < 'a') chars[i] = (char)(chars[i]+26);
            }

            string norStr = "";
            foreach (char c in chars)
                norStr += c;
            return norStr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int numOfIslands = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            for (int r = 0; r < grid.Length; r++) {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        numOfIslands++;
                        VisitIsland(grid, r, c, rows, cols);
                    }
                }
            }

            return numOfIslands;
        }
        private void VisitIsland(char[][] grid, int currRow, int currCol, int rows, int cols)
        {
            if (currRow < 0 || currRow >= rows
                || currCol < 0 || currCol >= cols
                || grid[currRow][currCol] != '1')
                return;

            grid[currRow][currCol] = '2';   //visited
            VisitIsland(grid, currRow - 1, currCol, rows, cols);    //LEFT
            VisitIsland(grid, currRow + 1, currCol, rows, cols);    //RIGHT
            VisitIsland(grid, currRow, currCol - 1, rows, cols);    //TOP
            VisitIsland(grid, currRow, currCol + 1, rows, cols);    //BOTTON
        }


        /// <summary>
        /// 
        /// https://leetcode.com/problems/sentence-screen-fitting/submissions/
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public int WordsTyping(string[] sentence, int rows, int cols)
        {
            //fill the sentences with the words
            StringBuilder sb = new StringBuilder();
            foreach (string str in sentence)
            {
                string s = str + " ";
                sb.Append(s);
            }
            //hello world ;
            int start = 0;
            for (int i = 0; i < rows; i++)
            {
                start = start + cols;
                if (sb[start % sb.Length] == ' ')
                {
                    start++;     //move over the space by adding 1 to start;
                }
                else
                { //need to look for the previous space ;
                    while (start > 0 && sb[(start - 1) % sb.Length] != ' ')
                        start--;
                }
            }
            return start / sb.Length;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="positions"></param>
        /// <returns></returns>
        public IList<int> NumIslands2(int m, int n, int[][] positions)
        {
            IList<int> ans = new List<int>();
            UnionFind uf = new UnionFind(m * n);

            foreach (var pos in positions)
            {
                int r = pos[0], c = pos[1];
                IList<int> overlap = new List<int>();

                if (r - 1 >= 0 && uf.IsValid((r - 1) * n + c)) overlap.Add((r - 1) * n + c);
                if (r + 1 < m && uf.IsValid((r + 1) * n + c)) overlap.Add((r + 1) * n + c);
                if (c - 1 >= 0 && uf.IsValid(r * n + c - 1)) overlap.Add(r * n + c - 1);
                if (c + 1 < n && uf.IsValid(r * n + c + 1)) overlap.Add(r * n + c + 1);

                int index = r * n + c;
                uf.SetParent(index);
                foreach (int i in overlap) uf.Union(i, index);
                ans.Add(uf.GetCount());
            }

            return ans;
        }
        class UnionFind
        {
            int count; // # of connected components
            int[] parent;
            int[] rank;

            public UnionFind(int n)
            {
                count = n;
                parent = new int[n];
                rank = new int[n];
                for(int i = 0; i <n;i++)
                {
                    parent[i] = -1;
                    rank[i] = 0;
                }
            }

            public bool IsValid(int i)
            { // for problem 305
                return parent[i] >= 0;
            }

            public void SetParent(int i)
            {
                parent[i] = i;
                ++count;
            }

            public int Find(int i)
            { // path compression
                if (parent[i] != i) parent[i] = Find(parent[i]);
                return parent[i];
            }

            public void Union(int x, int y)
            { // union with rank
                int rootx = Find(x);
                int rooty = Find(y);
                if (rootx != rooty)
                {
                    if (rank[rootx] > rank[rooty])
                    {
                        parent[rooty] = rootx;
                    }
                    else if (rank[rootx] < rank[rooty])
                    {
                        parent[rootx] = rooty;
                    }
                    else
                    {
                        parent[rooty] = rootx; rank[rootx] += 1;
                    }
                    --count;
                }
            }

            public int GetCount()
            {
                return count;
            }


        }

        #endregion


        #region | 1/20/22 - Phone Interview | 

        /// <summary>
        /// 942. DI String Match
        /// https://leetcode.com/problems/di-string-match/solution/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] DiStringMatch(string s)
        {
            int n = s.Length;
            int low = 0, high = n;
            int[] res = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'I')
                    res[i] = low++;
                else
                    res[i] = high--;
            }

            res[n] = low;
            return res;
        }


        /// <summary>
        /// 1660. Correct a Binary Tree
        /// https://leetcode.com/problems/correct-a-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode CorrectBinaryTree(TreeNode root)
        {
            List<TreeNode> visited = new List<TreeNode>();
            TreeNode invalidNode = DetectInvalidNode(root, visited, null);
            if (invalidNode != null)
                DeleteNode(root, null, invalidNode);
            return root;
        }
        private TreeNode DetectInvalidNode(TreeNode root, List<TreeNode> visited, TreeNode parent)
        {
            if (root == null)
                return null;
            else if (visited.Contains(root))
            {
                return parent;
            }

            visited.Add(root);
            TreeNode res = null;
            if (root.right != null)
            {
                res = DetectInvalidNode(root.right, visited, root);
            }

            if (res == null && root.left != null)
            {
                res = DetectInvalidNode(root.left, visited, root);
            }

            return res;
        }
        private void DeleteNode(TreeNode currNode, TreeNode parent, TreeNode delNode)
        {
            if (currNode == null)
                return;

            if( currNode == delNode)
            {
                if(parent != null)
                {
                    if (parent.left == delNode)
                        parent.left = null;
                    else if (parent.right == delNode)
                        parent.right = null;
                }
            }

            DeleteNode(currNode.left, currNode, delNode);
            DeleteNode(currNode.right, currNode, delNode);
        }

        #endregion


        #region | Online Interview - 1/22/2022 | 

        public void ReverseString(char[] s)
        {
            if (s.Length == 1)
                return;

            int startIdx = 0, endIdx = s.Length - 1;
            while( startIdx < endIdx)
            {
                char buff = s[endIdx];
                s[endIdx] = s[startIdx];
                s[startIdx] = buff;
                startIdx++;
                endIdx--;
            }
        }

        /// <summary>
        /// 1504. Count Submatrices With All Ones
        /// https://leetcode.com/problems/count-submatrices-with-all-ones/
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int NumSubmat(int[][] mat)
        {
            int n = mat.Length;
            int m = mat[0].Length;
            int[][] ar = new int[n][];
            for (int i = 0; i < n; i++)
                ar[i] = new int[m];

            //row direction 
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    if (mat[r][c] == 1)
                    {
                        if (c == 0)
                            ar[r][c] = 1;
                        else
                            ar[r][c] = ar[r][c - 1] + 1;
                    }
                    else
                        ar[r][c] = 0;
                }
            }

            //col direction
            //based on at end of edge of a rectangle, count a possiblility        
            int ans = 0;
            for (int r = 0; r < n; r++) 
            {
                for (int c = 0; c < m; c++)
                {
                    int res = int.MaxValue;
                    for(int k = r; k < n; k++)
                    {
                        res = Math.Min(res, ar[k][c]);
                        ans += res;
                    }
                }
            }

            return ans;
        }
        public int NumSubmat2(int[][] mat)
        {
            int n = mat.Length;
            int m = mat[0].Length;
            int[][] ar = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ar[i] = new int[m];
            }
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = m - 1; j >= 0; j--)
                {
                    if (mat[i][j] == 1)
                    {
                        c++;
                    }
                    else
                        c = 0;
                    ar[i][j] = c;
                }
            }

            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int x = int.MaxValue;
                    for (int k = i; k < n; k++)
                    {
                        x = Math.Min(x, ar[k][j]);
                        ans += x;
                    }
                }
            }
            return ans;
        }

        #endregion


        #region | Phone Interview - 1/22/2022 | 

        /// <summary>
        /// 1672. Richest Customer Wealth  Easy
        /// https://leetcode.com/problems/richest-customer-wealth/
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public int MaximumWealth(int[][] accounts)
        {
            int maxAmt = int.MinValue;

            foreach (var cus in accounts)
            {
                int total = 0;
                for (int i = 0; i < cus.Length; i++)
                    total += cus[i];
                maxAmt = Math.Max(maxAmt, total);
            }

            return maxAmt;
        }

        /// <summary>
        /// 1506. Find Root of N-Ary Tree
        /// https://leetcode.com/problems/find-root-of-n-ary-tree/
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        //public Node FindRoot(List<Node> tree)
        //{
        //    Node root = null;
        //    int validSum = 0;
        //    //HashSet<int> seen = new HashSet<int>(); 
        //    //foreach(var n in tree)
        //    //{
        //    //    seen.Add(n.val);
        //    //    foreach (var c in n.children)
        //    //        seen.Add(c.val);
        //    //}

        //    //foreach(var n in tree)
        //    //{
        //    //    if( seen.Contains(n.val) == false)
        //    //    {
        //    //        root = n;
        //    //        break;
        //    //    }
        //    //}

        //    //return root;

        //    foreach (Node n in tree)
        //    {
        //        validSum += n.val;
        //        foreach (Node c in n.children)
        //        {
        //            validSum -= c.val;
        //        }
        //    }

        //    foreach (Node n in tree)
        //    {
        //        if (n.val == validSum)
        //        {
        //            root = n;
        //            break;
        //        }
        //    }

        //    return root;
        //}
        //class Node
        //{
        //    public int val;
        //    public IList<Node> children;

        //    public Node()
        //    {
        //        val = 0;
        //        children = new List<Node>();
        //    }

        //    public Node(int _val)
        //    {
        //        val = _val;
        //        children = new List<Node>();
        //    }

        //    public Node(int _val, List<Node> _children)
        //    {
        //        val = _val;
        //        children = _children;
        //    }
        //}

        #endregion

        #region | Onsite Interview - 01/22/2022 | 

        ///1592. Rearrange Spaces Between Words
        ///https://leetcode.com/problems/rearrange-spaces-between-words/
        public string ReorderSpaces(string text)
        {
            int totalSpaces = 0;
            int numOfWords = 0;
            string tempWord = "";
            //Check total # of spaces and words
            foreach (char c in text)
            {
                if (c == ' ')
                {
                    totalSpaces++;

                    if (tempWord != "")
                    {
                        numOfWords++;
                        tempWord = "";
                    }
                }
                else
                    tempWord += c;
            }
            if (tempWord != "")
            {
                numOfWords++;
                tempWord = "";
            }

            string newText = "";
            if (numOfWords == 1)
            {
                foreach (char c in text)
                {
                    if (c != ' ')
                        newText += c;
                }
                for (int i = 0; i < totalSpaces; i++)
                    newText += " ";
                return newText;
            }

            int modSpace = totalSpaces % (numOfWords - 1);
            int evenlySpace = totalSpaces / (numOfWords - 1);
            int spaceIdx = 0;
            string spaceStr = "";
            for (int i = 0; i < evenlySpace; i++)
                spaceStr += " ";

            foreach (char c in text)
            {
                if (c == ' ')
                {
                    if (tempWord != "")
                    {
                        newText += tempWord;
                        if (spaceIdx < numOfWords - 1)
                            newText += spaceStr;

                        tempWord = "";
                        spaceIdx++;
                    }
                }
                else
                    tempWord += c;
            }
            if (tempWord != "")
            {
                newText += tempWord;
                if (spaceIdx < numOfWords - 1)
                    newText += spaceStr;
            }
            for (int i = 0; i < modSpace; i++)
                newText += " ";

            return newText;
        }


        /// <summary>
        /// 801. Minimum Swaps To Make Sequences Increasing
        /// https://leetcode.com/problems/minimum-swaps-to-make-sequences-increasing/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MinSwap(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int[] noSwap = new int[n];  // number of swaps needed up to i, if no swap at i
            int[] swap = new int[n];    // number of swaps needed up to i, if swap at i
            noSwap[0] = 0;
            swap[0] = 1;
            for (int i= 1; i < n; i++) {
                noSwap[i] = n; swap[i] = n;

                // elements are in order without a swap
                if(nums1[i-1] < nums1[i] && nums2[i-1] < nums2[i])
                {
                    noSwap[i] = noSwap[i - 1];
                    swap[i] = swap[i - 1];
                }
                // elements are in order with a swap
                if(nums1[i-1] < nums2[i] && nums2[i-1] < nums1[i])
                {
                    noSwap[i] = Math.Min(noSwap[i], swap[i - 1]);
                    swap[i] = Math.Min(swap[i], noSwap[i - 1] + 1);
                }
            }

            return Math.Min(swap[n - 1], noSwap[n - 1]);
        }

        /// <summary>
        /// 1088. Confusing Number II
        /// https://leetcode.com/problems/confusing-number-ii/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ConfusingNumberII(int n)
        {
            Dictionary<int, int> confusingNums = new Dictionary<int, int>();
            confusingNums.Add(0, 0);
            confusingNums.Add(1, 1);
            confusingNums.Add(6, 9);
            confusingNums.Add(8, 8);
            confusingNums.Add(9, 6);

            //int totalConfusingNums = 0;
            //for (int i = 1; i <= n; i++)
            //{
            //    if (IsConfusingNum(i, confusingNums))
            //        totalConfusingNums++;
            //}
            //return totalConfusingNums;

            //Key. using all confusing numbers to make possible numbers within the range of numbers
            //Rduce Time complexity

            return ConfusingNumberIIBackTrack(n, 0, confusingNums);
        }

        private int ConfusingNumberIIBackTrack(int n, int currNum, Dictionary<int, int> confusingNums)
        {
            if (currNum > n)
                return 0;

            int res = 0;
            foreach (var v in confusingNums)
            {
                int nextNum = currNum * 10 + v.Key;
                if (nextNum > 0 && nextNum <= n)
                {
                    if (IsConfusingNum(nextNum, confusingNums))
                        res += 1;
                    res += ConfusingNumberIIBackTrack(n, nextNum, confusingNums);
                }
            }
            return res;
        }

        private bool IsConfusingNum(int n, Dictionary<int, int> confusingNums)
        {
            int orgN = n;
            int newN = 0;
            while (n > 0)
            {
                int d = n % 10;
                n = n / 10;
                if (confusingNums.ContainsKey(d) == false)
                    return false;
                else
                    newN = newN * 10 + confusingNums[d];
            }

            return orgN != newN;
        }


        #endregion
    }
}
