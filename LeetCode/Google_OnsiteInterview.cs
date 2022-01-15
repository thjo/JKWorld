using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Google_OnsiteInterview
    {
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
        public AutocompleteSystem(string[] sentences, int[] times)
        {

        }
        public IList<string> Input(char c)
        {

        }
        #endregion
    }
}
