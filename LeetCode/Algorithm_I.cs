using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_I
    {
        #region | Binary Search | 

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

        #endregion

        #region | Two Points |

        /// <summary>
        /// 977. Squares of a Sorted Array
        /// https://leetcode.com/problems/squares-of-a-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortedSquares(int[] nums)
        {
            int len = nums.Length;
            int negativPoint = -1;

            int[] newSorted = new int[len];
            int idxNew = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    //Positive value
                    while (negativPoint > -1 && negativPoint < len
                        && nums[negativPoint] * nums[negativPoint] < nums[i] * nums[i])
                    {
                        newSorted[idxNew++] = nums[negativPoint] * nums[negativPoint];
                        negativPoint--;
                    }
                    newSorted[idxNew] = nums[i] * nums[i]; 
                    idxNew++;
                }
                else
                {
                    //Negative value
                    negativPoint = i;
                }
            }

            while (negativPoint > -1 && negativPoint < len)
            {
                newSorted[idxNew] = nums[negativPoint] * nums[negativPoint];
                idxNew++;
                negativPoint--;
            }

            return newSorted;
        }

        #endregion
    }
}
