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
    }
}
