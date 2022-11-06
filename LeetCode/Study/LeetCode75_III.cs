using LeetCode.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Study
{
    public class LeetCode75_III
    {

        /// <summary>
        /// 191. Number of 1 Bits
        /// https://leetcode.com/problems/number-of-1-bits/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int retVal = 0;

            while (n != 0)
            {
                if ((n & 1) == 1)
                    retVal++;
                n = n >> 1;
            }

            return retVal;
        }


        /// <summary>
        /// 136. Single Number
        /// https://leetcode.com/problems/single-number/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int retVal = nums[0];

            for (int i = 1; i < nums.Length; i++)
                retVal ^= nums[i];

            return retVal;
        }

        /// <summary>
        /// 90. Subsets II
        /// https://leetcode.com/problems/subsets-ii/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);
            SubsetsWithDupR(nums, 0, new List<int>(), result);
            return result;
        }
        private void SubsetsWithDupR(int[] nums, int start, IList<int> subset, IList<IList<int>> result)
        {
            IList<int> tmp = new List<int>();
            foreach (int n in subset)
                tmp.Add(n);
            result.Add(tmp);

            for (int i = start; i < nums.Length; i++)
            {
                if (i != start && nums[i] == nums[i - 1])
                    continue;

                subset.Add(nums[i]);
                SubsetsWithDupR(nums, i + 1, subset, result);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        /// <summary>
        /// 5. Longest Palindromic Substring
        /// https://leetcode.com/problems/longest-palindromic-substring/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
                return s;

            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    if (len % 2 == 0)
                        start = i - (len - 1) / 2;
                    else
                        start = i - len / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }
        private int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--; right++;
            }
            return right - left - 1;
        }

        /// <summary>
        /// 49. Group Anagrams
        /// https://leetcode.com/problems/group-anagrams/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if( strs.Length == 0)
                return new List<IList<string>>();

            Dictionary<string, List<string>> g = new Dictionary<string, List<string>>();
            int[] count = new int[26];
            foreach(string s in strs)
            {
                Array.Fill(count, 0);
                foreach (char c in s.ToCharArray())
                    count[c - 'a']++;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < count.Length; i++)
                {
                    sb.Append("#");
                    sb.Append(count[i].ToString());
                }
                if (g.ContainsKey(sb.ToString()) == false)
                    g.Add(sb.ToString(), new List<string>());
                g[sb.ToString()].Add(s);                
            }

            IList<IList<string>> ans = new List<IList<string>>();
            foreach(var item in g)
                ans.Add(item.Value);

            return ans;
        }

        /// <summary>
        /// 28. Find the Index of the First Occurrence in a String
        /// https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(needle))
                return 0;
            else if (string.IsNullOrWhiteSpace(haystack))
                return -1;

            int n = haystack.Length;
            int m = needle.Length;
            for (int i = 0; i <= n - m; i++)
            {
                int j = 0;
                while (j < m && haystack[i + j] == needle[j])
                    j++;

                if (j == m)
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// /658. Find K Closest Elements
        /// https://leetcode.com/problems/find-k-closest-elements/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int n = arr.Length;
            int l = 0, r = n - 1;
            IList<int> ans = new List<int>();
            if (n <= k)
            {
                int i = 0;
                while (i < n)
                    ans.Add(arr[i++]);
                return ans;
            }

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] == x)
                {
                    l = mid;
                    r = l + 1;
                    break;
                }
                else if (arr[mid] > x)
                {
                    r = mid - 1;
                }
                else

                    l = mid + 1;
            }

            l--;
            r = l + 1;

            while (r - l - 1 < k)
            {
                if (l == -1)
                {
                    r++;
                    continue;
                }

                if (r == n || Math.Abs(arr[l] - x) <= Math.Abs(arr[r] - x))
                    l--;
                else
                    r++;
            }
            for (int i = l + 1; i < r; i++)
                ans.Add(arr[i]);

            return ans;
        }
    }
}
