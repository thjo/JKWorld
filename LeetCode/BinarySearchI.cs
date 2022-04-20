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


        /// <summary>
        /// 35. Search Insert Position
        /// https://leetcode.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int mid = (left + right) / 2;

            while (left <= right)
            {
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

                mid = (left + right) / 2;
            }

            return left;
        }

        /// <summary>
        /// 852. Peak Index in a Mountain Arra
        /// https://leetcode.com/problems/peak-index-in-a-mountain-array/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int PeakIndexInMountainArray(int[] arr)
        {
            int l = 0, h = arr.Length - 1;
            while (l < h)
            {
                int m = l + (h - l) / 2;
                if (arr[m] < arr[m + 1])
                    l = m + 1;
                else
                    h = m;
            }
            return l;
        }


    }
}
