﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class AuguestChallenge2021
    {
        /// <summary>
        ///  Array of Doubled Pairs
        ///  https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3877/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool CanReorderDoubled(int[] arr)
        {
            List<int> negativeNums = new List<int>();
            List<int> positiveNums = new List<int>();
            List<int> zeroNums = new List<int>();
            Array.Sort(arr);
            foreach (int n in arr)
            {
                if (n == 0)
                    zeroNums.Add(0);
                else if (n < 0)
                    negativeNums.Add(n);
                else
                    positiveNums.Add(n);
            }

            if (zeroNums.Count % 2 != 0
                || positiveNums.Count % 2 != 0
                || negativeNums.Count % 2 != 0)
                return false;

            int i = 0;
            while (positiveNums.Count > 0)
            {
                if (positiveNums.Remove(2 * positiveNums[i]) == false)
                    break;
                else
                    positiveNums.RemoveAt(i);
            }

            if (positiveNums.Count == 0)
            {
                while (negativeNums.Count > 0)
                {
                    i = negativeNums.Count-1;
                    if (negativeNums.Contains(negativeNums[i] * 2))
                    {
                        int tmp = negativeNums[i] * 2;
                        negativeNums.RemoveAt(i);
                        negativeNums.Remove(tmp);
                    }
                    else
                        break;
                }

                if (negativeNums.Count == 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        /// <summary>
        /// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/614/week-2-august-8th-august-14th/3887/
        /// Group Anagrams
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();

            if (strs == null)
                return result;
            else if(strs.Length == 1)
            {
                IList<string> buff = new List<string>();
                buff.Add(strs[0]);
                result.Add(buff);
                return result;
            }

            IList<Dictionary<char, int>> words = new List<Dictionary<char, int>>();
            foreach (string s in strs)
            {
                Dictionary<char, int> word = new Dictionary<char, int>();
                foreach (char c in s)
                {
                    if (word.ContainsKey(c))
                        word[c]++;
                    else
                        word.Add(c, 1);
                }
                words.Add(word);
            }

            int[] checkedList = new int[strs.Length];
            for(int idx = 0; idx < words.Count; idx++)
            {
                if (checkedList[idx] == 1)
                    continue;

                Dictionary<char, int> word = words[idx];
                IList<string> buff = new List<string>();
                buff.Add(strs[idx]);
                checkedList[idx] = 1;

                if (idx + 1 == words.Count) {
                    result.Add(buff);
                    continue;
                }

                for (int curr = idx+1; curr < words.Count; curr++)
                {
                    if (checkedList[curr] == 1)
                        continue;
                    if ( GroupAnagramsCompareWords(word, words[curr]))
                    {
                        buff.Add(strs[curr]);
                        checkedList[curr] = 1;
                    }
                }
                result.Add(buff);
            }

            return result;
        }
        private bool GroupAnagramsCompareWords(Dictionary<char, int> word1, Dictionary<char, int> word2)
        {
            bool retVal = true;
            if (word1.Count != word2.Count)
                return false;
            else if (word1.Count == 0 && word2.Count == 0)
                return true;

            foreach(var c in word1)
            {
                if (word2.ContainsKey(c.Key) && word2[c.Key] == c.Value)
                    continue;
                else
                {
                    retVal = false;
                    break;
                }
            }

            return retVal;
        }


        /// <summary>
        /// Minimum Window Substring
        /// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3891/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(t))
                return "";

            // Dictionary which keeps a count of all the unique characters in t.
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach(char c in t)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            }

            // Number of unique characters in t, which need to be present in the desired window.
            int requiredMinLen = dict.Count;

            // Left and Right pointer
            int l = 0, r = 0;
            while (l < s.Length)
            {
                if (dict.ContainsKey(s[l]))
                    break;
                l++;
            }

            int finalL = 0, finalR = int.MaxValue;
            Dictionary<char, int> windowsCnt = new Dictionary<char, int>();
            //Seach a satisfy window first then consider about miniumizing.
            while (r < s.Length)
            {
                if (dict.ContainsKey(s[r]))
                    break;
                r++;
            }
            l = r;
            while (r < s.Length)
            {
                if (windowsCnt.ContainsKey(s[r]))
                    windowsCnt[s[r]]++; 
                else
                    windowsCnt.Add(s[r], 1);

                while (l <= r && windowsCnt.Count >= requiredMinLen && MinWindowSatisfy(dict, windowsCnt))
                {
                    if( (finalR - finalL) > (r - l))
                    {
                        finalL = l;
                        finalR = r;
                    }

                    //Minimize the window o fine a smallest satisfy window
                    windowsCnt[s[l]]--;
                    if (windowsCnt[s[l]] <= 0)
                        windowsCnt.Remove(s[l]);
                    l++;
                }

                r++;
            }

            if (finalR - finalL == int.MaxValue)
                return "";
            else
                return s.Substring(finalL, (finalR - finalL)+1);
        }
        private bool MinWindowSatisfy(Dictionary<char, int> dict, Dictionary<char, int> windowsCnt)
        {
            bool isValid = true;
            foreach(var d in dict)
            {
                if (windowsCnt.ContainsKey(d.Key) && windowsCnt[d.Key] >= d.Value)
                    continue;
                else
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

        /// <summary>
        /// Count Good Nodes in Binary Tree
        /// https://leetcode.com/explore/featured/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3899/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GoodNodes(TreeNode root)
        {
            int cntOfGoodNodes = 0;
            int max = int.MinValue;
            GoodNodesScan(root, max, ref cntOfGoodNodes);

            return cntOfGoodNodes;
        }
        private void GoodNodesScan(TreeNode root, int max, ref int cntOfGoodNodes)
        {
            if (root == null)
                return;

            if (root.val >= max)
            {
                cntOfGoodNodes++;
                max = root.val;
            }

            //Left
            if (root.left != null)
                GoodNodesScan(root.left, max, ref cntOfGoodNodes);

            //Right
            if (root.right != null)
                GoodNodesScan(root.right, max, ref cntOfGoodNodes);
        }

        /// <summary>
        /// Maximum Product of Splitted Binary Tree
        /// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3903/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxProduct(TreeNode root)
        {
            int modulo = 1000000007;
            long max = 0;
            //First. Get a total sum
            long total = MaxProductGetSum(root);

            //Second. check all of posibilities
            MaxProductCutSum(root, total, ref max);

            return (int)(max%modulo);
        }
        private long MaxProductGetSum(TreeNode root)
        {
            if (root == null)
                return 0;

            long leftSum = MaxProductGetSum(root.left);
            long rightSum = MaxProductGetSum(root.right);

            return (root.val + leftSum + rightSum);
        }
        private long MaxProductCutSum(TreeNode root, long total, ref long max)
        {
            if (root == null)
                return 0;

            long leftSum = MaxProductCutSum(root.left, total, ref max);
            long rightSum = MaxProductCutSum(root.right, total, ref max);

            max = Math.Max(max, leftSum*(total-leftSum));
            max = Math.Max(max, rightSum * (total - rightSum));
            return (root.val + leftSum + rightSum);
        }


        /// <summary>
        /// Valid Sudoku
        /// https://leetcode.com/explore/challenge/card/august-leetcoding-challenge-2021/615/week-3-august-15th-august-21st/3904/
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            return false;
        }
    }
}
