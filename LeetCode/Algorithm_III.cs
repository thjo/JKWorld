using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_III
    {
        /// <summary>
        /// 1060. Missing Element in Sorted Array
        /// https://leetcode.com/problems/missing-element-in-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MissingElement(int[] nums, int k)
        {
            int min = nums[0];
            if (nums.Length == 1)
                return min + k;

            int l = 0, r = nums.Length - 1;
            if (k > getMissingNums(r, nums))
                return nums[r] + k - getMissingNums(r, nums);

            while (l < r)
            {
                int m = l + (r - l) / 2;
                int missing = getMissingNums(m, nums);
                if (missing < k)
                {
                    //search right side
                    l = m + 1;
                }
                else
                {
                    //search left side
                    r = m;
                }
            }

            return nums[l - 1] + k - getMissingNums(l - 1, nums);

        }
        private int getMissingNums(int idx, int[] nums)
        {
            return nums[idx] - (nums[0] + idx);
        }
    }
}
