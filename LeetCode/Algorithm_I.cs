using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_I
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
            int targetIdx = -1;
            int len = nums.Length;

            int left = 0, right = len - 1;
            int mid = len / 2;

            while(left <= right)
            {
                if(nums[mid] == target)
                {
                    targetIdx = mid;
                    break;
                }
                else if (nums[mid] > target)
                {
                    //Search left area of the array
                    right = mid - 1;
                }
                else
                {
                    //Search right area of the array
                    left = mid + 1;
                }
                mid = (left + right) / 2;
            }

            return targetIdx;
        }


        /// <summary>
        /// 278. First Bad Version
        /// https://leetcode.com/problems/first-bad-version/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int l = 1, h = n;

            while (l <= h)
            {
                int m = l + (h - l) / 2;
                if (IsBadVersion(m) == false)
                {
                    l = m + 1;
                }
                else
                {
                    h = m - 1;
                }
            }

            return l;
        }
        private bool IsBadVersion(int version)
        {
            if (version == 1)
                return true;
            else
                return false;
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

            //int idxInserted = 0;

            //if (nums == null || nums.Length < 1)
            //    return idxInserted;

            //idxInserted = nums.Length;
            //for (int i = 0; i < idxInserted; i++)
            //{
            //    if (nums[i] >= target)
            //    {
            //        idxInserted = i;
            //        break;
            //    }
            //}

            //return idxInserted;
        }
    }
}
