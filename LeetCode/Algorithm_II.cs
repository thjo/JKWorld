using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_II
    {
        #region | Binary Search | 

        /// <summary>
        /// 34. Find First and Last Position of Element in Sorted Array
        /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };

            if (nums == null || nums.Length < 1)
                return result;

            int len = nums.Length-1;
            result[0] = SearchRangeB(nums, target, 0, len, 0);
            result[1] = SearchRangeB(nums, target, 0, len, 1);

            return result;
        }
        public int SearchRangeB(int[] nums, int target, int startIdx, int endIdx, int flag)
        {
            //flag: 0, Starting position, 1: ending position
            if (startIdx > endIdx)
                return -1;

            int midIdx = (startIdx + endIdx) / 2;
            if( nums[midIdx] == target)
            {
                if( flag == 0)
                {
                    //Seeking starting position
                    while((midIdx-1) >= 0 && nums[midIdx-1] == target)
                        midIdx--;

                    return midIdx;
                }
                else
                {
                    //Seeking ending position
                    while ((midIdx + 1) < nums.Length && nums[midIdx + 1] == target)
                        midIdx++;

                    return midIdx;
                }
            }
            else if (nums[midIdx] > target)
            {
                return SearchRangeB(nums, target, startIdx, midIdx - 1, flag);
            }
            else
            {
                return SearchRangeB(nums, target, midIdx+1, nums.Length-1, flag);
            }
        }


        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int retIdx = -1;



            return retIdx;
        }

        #endregion



    }
}
