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

        /// <summary>
        /// 367. Valid Perfect Square
        /// https://leetcode.com/problems/valid-perfect-square/
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPerfectSquare(int num)
        {
            int l = 1, r = num;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (num % m == 0 && num / m == m)
                    return true;
                else if (num / m >= m)
                {
                    l = m + 1;
                }
                else
                    r = m - 1;
            }

            return false;
        }


        /// <summary>
        /// 1385. Find the Distance Value Between Two Arrays
        /// https://leetcode.com/problems/find-the-distance-value-between-two-arrays/
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            Array.Sort(arr1);
            Array.Sort(arr2);
            int ans = 0;
            int idx1 = 0, idx2 = 0;
            while (idx1 < arr1.Length && idx2 < arr2.Length)
            {
                if (arr1[idx1] >= arr2[idx2])
                {
                    if (arr1[idx1] - arr2[idx2] > d)
                        idx2++;
                    else
                        idx1++;
                }
                else
                {
                    if (arr2[idx2] - arr1[idx1] > d)
                    {
                        idx1++;
                        ans++;
                    }
                    else
                        idx1++;
                }
            }

            ans += arr1.Length - idx1;
            return ans;
        }


        /// <summary>
        /// 69. Sqrt(x)
        /// https://leetcode.com/problems/sqrtx/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            int l = 0, r = x;
            while (l <= r)
            {
                double mid = l + (r - l) / 2;
                if ((mid * mid) == x)
                    return (int)mid;

                if (x > (mid * mid))
                    l = (int)mid + 1;
                else
                    r = (int)mid - 1;
            }
            return r;
        }


        /// <summary>
        /// 744. Find Smallest Letter Greater Than Target
        /// https://leetcode.com/problems/find-smallest-letter-greater-than-target/submissions/
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter(char[] letters, char target)
        {
            int l = 0, h = letters.Length;
            while (l < h)
            {
                int m = l + (h - l) / 2;
                if (letters[m] <= target)
                    l = m + 1;
                else
                    h = m;
            }
            return letters[l % letters.Length];
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
            while (l < h)
            {
                int m = l + (h - l) / 2;
                if (IsBadVersion(m) == false)
                {
                    l = m + 1;
                }
                else
                {
                    h = m;
                }
            }

            return l;
        }
        private bool IsBadVersion(int ver)
        {
            return true;
        }
    }
}
