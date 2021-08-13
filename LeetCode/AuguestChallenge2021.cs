using System;
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
            int cntEmpty = 0;
            foreach (string s in strs)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    cntEmpty++;
                    continue;
                }
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

            if (cntEmpty > 0)
            {
                IList<string> empty = new List<string>();
                while (cntEmpty > 0)
                {
                    empty.Add("");
                    cntEmpty--;
                }
                result.Add(empty);
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

    }
}
