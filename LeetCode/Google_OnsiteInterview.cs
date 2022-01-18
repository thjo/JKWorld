﻿using System;
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

        private Dictionary<string, int> msgDict;

        public Logger()
        {
            msgDict = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (this.msgDict.ContainsKey(message) == false)
            {
                this.msgDict.Add(message, timestamp);
                return true;
            }

            int oldTimestamp = this.msgDict[message];
            if (timestamp - oldTimestamp >= 10)
            {
                this.msgDict[message] = timestamp;
                return true;
            }
            else
                return false;

        }


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

    }
}
