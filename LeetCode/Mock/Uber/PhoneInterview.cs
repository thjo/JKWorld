using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Mock.Uber
{
    public class PhoneInterview
    {
        /// <summary>
        /// 1640. Check Array Formation Through Concatenation
        /// https://leetcode.com/problems/check-array-formation-through-concatenation/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="pieces"></param>
        /// <returns></returns>
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            //value, index
            Dictionary<int, int> dataset = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
                dataset.Add(arr[i], i);

            foreach (int[] piece in pieces)
            {
                if (piece.Length == 0)
                    continue;
                if (dataset.ContainsKey(piece[0]))
                {
                    int arrIdx = dataset[piece[0]];
                    arrIdx = arrIdx + 1;
                    for (int i = 1; i < piece.Length; i++)
                    {
                        if (arr.Length <= arrIdx || arr[arrIdx] != piece[i])
                            return false;
                        arrIdx++;
                    }
                    dataset.Remove(piece[0]);
                }
                else
                    return false;
            }

            return true;
        }


        /// <summary>
        /// 1400. Construct K Palindrome Strings
        /// https://leetcode.com/problems/construct-k-palindrome-strings/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanConstruct(string s, int k)
        {
            int[] chars = new int[26];
            foreach (char c in s)
                chars[c - 'a']++;

            //characters: 2 or more than 2 times and it's even.
            //characters: 1 or more than 2 times and it's odd.
            if (s.Length == k)
                return true;
            else if (s.Length < k)
                return false;

            //characters: 1 or more than 2 times and it's odd.
            int cnt = 0;
            foreach (int c in chars)
            {
                if (c != 0 && c % 2 != 0)
                    cnt++;
            }
            return cnt > k ? false : true;
        }
    }
}
