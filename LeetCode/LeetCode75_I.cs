using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class LeetCode75_I
    {
        /// <summary>
        /// 1480. Running Sum of 1d Array
        /// https://leetcode.com/problems/running-sum-of-1d-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];

            return nums;
        }


        /// <summary>
        /// 724. Find Pivot Index
        /// https://leetcode.com/problems/find-pivot-index/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex(int[] nums)
        {
            int sum = 0, leftsum = 0;
            foreach (int x in nums)
                sum += x;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (leftsum == sum - leftsum - nums[i]) return i;
                leftsum += nums[i];
            }
            return -1;
        }

        /// <summary>
        /// 205. Isomorphic Strings
        /// https://leetcode.com/problems/isomorphic-strings/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> mapS = new Dictionary<char, char>();
            Dictionary<char, char> mapT = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (IsCheckedKey(s[i], t[i], mapS, mapT) == false)
                    return false;
            }
            return true;
        }
        private bool IsCheckedKey(char cs, char ct, Dictionary<char, char> mapS, Dictionary<char, char> mapT)
        {
            if (mapS.ContainsKey(cs) && mapS[cs] != ct)
                return false;

            if (mapT.ContainsKey(ct) && mapT[ct] != cs)
                return false;

            if (mapS.ContainsKey(cs) == false)
                mapS.Add(cs, ct);
            if (mapT.ContainsKey(ct) == false)
                mapT.Add(ct, cs);

            return true;
        }


        /// <summary>
        /// 392. Is Subsequence
        /// https://leetcode.com/problems/is-subsequence/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t))
                return true;
            else if (string.IsNullOrEmpty(s))
                return true;
            else if (string.IsNullOrEmpty(t))
                return false;

            int sIdx = 0, tIdx = 0;
            while (sIdx < s.Length && tIdx < t.Length)
            {
                if (s[sIdx] == t[tIdx])
                    sIdx++;

                tIdx++;
            }

            return sIdx == s.Length;
        }
    }
}
