using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class BinarySearchI
    {
        /// <summary>
        /// 704. Binary Search
        /// https://leetcode.com/problems/binary-search/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            //[5], 5 ==> 0
            while (l <= r)
            {
                int mid = l + (r-l)/2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            return -1;
        }
    }
}
