using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class DataStructureI
    {

        /// <summary>
        /// 217. Contains Duplicate
        /// https://leetcode.com/problems/contains-duplicate/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            bool retVal = false;
            if (nums == null || nums.Length < 2)
                return retVal;

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    retVal = true;
                    break;
                }
                else
                    set.Add(nums[i]);
            }

            return retVal;
        }

        /// <summary>
        /// 53. Maximum Subarray
        /// https://leetcode.com/problems/maximum-subarray/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            int sum = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (sum + nums[i] > nums[i])
                    sum = sum + nums[i];
                else
                    sum = nums[i];

                if (max < sum)
                    max = sum;
            }

            return max;
        }

        /// <summary>
        /// 1. Two Sum
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();
            int[] res = new int[2];
            for(int i = 0; i < nums.Length; i++)
            {
                if (dp.ContainsKey(target - nums[i]))
                {
                    res[0] = dp[target - nums[i]];
                    res[1] = i;
                    break;
                }
                else
                    dp[nums[i]] = i;
            }

            return res;
        }


        /// <summary>
        /// 88. Merge Sorted Array
        /// https://leetcode.com/problems/merge-sorted-array/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] newArr = new int[m + n];

            int n1 = 0, n2 = 0;
            int i = 0;
            while (m > 0 && n > 0)
            {
                if (nums1[n1] > nums2[n2])
                {
                    newArr[i] = nums2[n2++];
                    n--;
                }
                else
                {
                    newArr[i] = nums1[n1++];
                    m--;
                }
                i++;
            }

            while (m > 0)
            {
                newArr[i++] = nums1[n1++];
                m--;
            }
            while (n > 0)
            {
                newArr[i++] = nums2[n2++];
                n--;
            }

            for (int j = 0; j < newArr.Length; j++)
                nums1[j] = newArr[j];
        }

        /// <summary>
        /// 350. Intersection of Two Arrays II
        /// https://leetcode.com/problems/intersection-of-two-arrays-ii/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int n1 = 0, n2 = 0;
            List<int> res = new List<int>();
            while(n1 < nums1.Length && n2 < nums2.Length)
            {
                if (nums1[n1] == nums2[n2])
                {
                    res.Add(nums1[n1]);
                    n1++; n2++;
                }
                else if (nums1[n1] > nums2[n2])
                    n2++;
                else
                    n1++;
            }

            return res.ToArray();

            //Dictionary<int, int> map = new Dictionary<int, int>();
            //List<int> returnList = new List<int>();

            //foreach (int num1 in nums1)
            //{
            //    if (map.ContainsKey(num1))
            //        map[num1]++;
            //    else
            //        map.Add(num1, 1);
            //}

            //foreach (int num2 in nums2)
            //{
            //    if (map.ContainsKey(num2) && map[num2] != 0)
            //    {
            //        returnList.Add(num2);
            //        map[num2]--;
            //    }
            //}

            //return returnList.ToArray();
        }

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            if (prices.Length <= 1)
                return maxProfit;

            int startPrice = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (startPrice > prices[i])
                    startPrice = prices[i];
                else if (startPrice < prices[i])
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - startPrice);
                }

            }

            return maxProfit;
        }


        /// <summary>
        /// 566. Reshape the Matrix
        /// https://leetcode.com/problems/reshape-the-matrix/
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int[][] res = new int[r][];
            for (int i = 0; i < r; i++)
                res[i] = new int[c];

            if (mat.Length == 0 || r * c != mat.Length * mat[0].Length)
                return mat;

            int count = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    res[count / c][count % c] = mat[i][j];
                    count++;
                }
            }
            return res;
        }


        /// <summary>
        /// 118. Pascal's Triangle
        /// https://leetcode.com/problems/pascals-triangle/
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> res = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                IList<int> row = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        row.Add(1);
                    else
                        row.Add(res[i - 1][j - 1] + res[i - 1][j]);
                }
                res.Add(row);
            }

            return res;
        }




        /// <summary>
        /// 387. First Unique Character in a String
        /// https://leetcode.com/problems/first-unique-character-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            int retIdx = -1;

            Dictionary<char, int> buff = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (buff.ContainsKey(c))
                    buff[c]++;
                else
                    buff.Add(c, 1);
            }


            for (int i = 0; i < s.Length; i++)
            {
                if (buff[s[i]] == 1)
                {
                    retIdx = i;
                    break;
                }
            }

            return retIdx;
        }


        /// <summary>
        /// 383. Ransom Note
        /// https://leetcode.com/problems/ransom-note/
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            foreach (char c in ransomNote)
            {
                if (dic.ContainsKey(c))
                    dic[c]--;
                else
                    return false;
                if (dic[c] < 0)
                    return false;
            }

            return true;
        }


        /// <summary>
        /// 242. Valid Anagram
        /// https://leetcode.com/problems/valid-anagram/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            bool isAnag = false;

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            foreach (char c in t)
            {
                if (dic.ContainsKey(c))
                {
                    if (dic[c] <= 1)
                        dic.Remove(c);

                    else
                        dic[c]--;
                }
                else
                    return false;
            }

            if (dic.Count == 0)
                isAnag = true;

            return isAnag;
        }

    }
}
