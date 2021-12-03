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
        private int SearchRangeB(int[] nums, int target, int startIdx, int endIdx, int flag)
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
            int n = nums.Length-1;
            retIdx = SearchB(nums, target, 0, n);

            return retIdx;
        }
        private int SearchB(int[] nums, int target, int startIdx, int endIdx)
        {
            if (startIdx > endIdx)
                return -1;

            int midIdx = (startIdx + endIdx) / 2;
            if (nums[midIdx] == target)
                return midIdx;

            /* If arr[l...mid] is sorted */
            if( nums[startIdx] <= nums[midIdx])
            {
                if( target >= nums[startIdx] && target <= nums[midIdx])
                    return SearchB(nums, target, startIdx, midIdx - 1);

                return SearchB(nums, target, midIdx + 1, nums.Length - 1);
            }
            else
            {
                /* If arr[l..mid] is not sorted, then arr[mid... r] must be sorted*/
                if( target >= nums[midIdx] && target <= nums[nums.Length-1])
                    return SearchB(nums, target, midIdx + 1, nums.Length - 1);

                return SearchB(nums, target, startIdx, midIdx - 1);
            }
        }

        /// <summary>
        /// 74. Search a 2D Matrix
        /// https://leetcode.com/problems/search-a-2d-matrix/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rowLen = matrix.Length;
            int colLen = matrix[0].Length;

            int rowPos = SearchMatrixRowB(matrix, target, 0, rowLen - 1, rowLen, colLen);
            if (rowPos < 0 || rowPos > rowLen)
                return false;
            else if (matrix[rowPos][0] == target)
                return true;

            return SearchMatrixColB(matrix, target, rowPos, 0, colLen - 1, colLen);
        }
        private int SearchMatrixRowB(int[][] matrix, int target, int startIdx, int endIdx, int rowLen, int colLen)
        {
            if (startIdx > endIdx)
                return -1;

            int midIdx = (startIdx + endIdx) / 2;
            if (matrix[midIdx][0] <= target && matrix[midIdx][colLen-1] >= target)
                return midIdx;

            if(matrix[midIdx][0] < target)
                return SearchMatrixRowB(matrix, target, midIdx+1, rowLen - 1, rowLen, colLen);
            else
                return SearchMatrixRowB(matrix, target, startIdx, midIdx - 1, rowLen, colLen);
        }
        private bool SearchMatrixColB(int[][] matrix, int target, int row, int startIdx, int endIdx, int len)
        {
            if (startIdx > endIdx)
                return false;

            int midIdx = (startIdx + endIdx) / 2;
            if (matrix[row][midIdx] == target)
                return true;

            if (matrix[row][midIdx] < target)
                return SearchMatrixColB(matrix, target, row, midIdx + 1, len - 1, len);
            else
                return SearchMatrixColB(matrix, target, row, startIdx, midIdx - 1, len);
        }


        /// <summary>
        /// 153. Find Minimum in Rotated Sorted Array
        /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];


            int left = 0, right = nums.Length - 1;

            //the array is sorted? 
            if (nums[left] < nums[right])
                return nums[left];


            while(right >= left)
            {
                int mid = left + (right - left) / 2;

                if (mid + 1 < nums.Length && nums[mid] > nums[mid + 1])
                    return nums[mid + 1];
                else if(mid - 1 >= 0 && nums[mid] < nums[mid-1])
                    return nums[mid];

                if (nums[mid] > nums[0])
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }


        #endregion



    }
}
