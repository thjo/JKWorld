using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class DataStructureI
    {
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
    }
}
