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


        /// <summary>
        /// 34. Find First and Last Position of Element in Sorted Array
        /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] ans = new int[2];
            ans[0] = SearchRangeB(nums, target, 0, nums.Length - 1, true);
            if (ans[0] == -1)
                ans[1] = -1;
            else
                ans[1] = SearchRangeB(nums, target, ans[0], nums.Length - 1, false);
            return ans;
        }
        private int SearchRangeB(int[] nums, int target, int startIdx, int endIdx, bool isFirst)
        {
            int n = nums.Length;
            int l = startIdx, r = endIdx;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (nums[m] == target)
                {
                    if (isFirst)
                    {
                        // This means we found our lower bound.
                        if (m == l || nums[m - 1] != target)
                        {
                            return m;
                        }

                        // Search on the left side for the bound.
                        r = m - 1;
                    }
                    else
                    {
                        // This means we found our upper bound.
                        if (m == r || nums[m + 1] != target)
                        {
                            return m;
                        }

                        // Search on the right side for the bound.
                        l = m + 1;
                    }
                }
                else if (nums[m] > target)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return -1;
        }


        /// <summary>
        /// 441. Arranging Coins
        /// https://leetcode.com/problems/arranging-coins/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ArrangeCoins(int n)
        {
            if (n <= 1)
                return n;

            int l = 1, h = n - 1;
            while (l <= h)
            {
                long m = l + (h - l) / 2;
                long nCoins = m * (m + 1) / 2L;
                if (nCoins == n)
                {
                    return (int)m;
                }
                else if (nCoins < n)
                {
                    l = (int)m + 1;
                }
                else
                {
                    h = (int)m - 1;
                }
            }
            return h;
        }

        /// <summary>
        /// 1539. Kth Missing Positive Number
        /// https://leetcode.com/problems/kth-missing-positive-number/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthPositive(int[] arr, int k)
        {
            int startVal = arr[0];
            if (k == 0)
                return startVal;
            else if (startVal > k)
                return k;

            int n = arr.Length;
            int l = 0, r = n - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;
                int interval = arr[m] - m - 1;
                if (k == interval)
                {
                    while (m - 1 >= 0 && arr[m - 1] == arr[m] - 1)
                        m--;
                    return arr[m] - 1;
                }
                else if (k > interval)
                    l = m + 1;
                else
                    r = m - 1;
            }

            int diff = arr[r] - r - 1;
            return arr[r] + k - diff;

        }

        /// <summary>
        /// 167. Two Sum II - Input Array Is Sorted
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int idxLeft = 0, idxRight = numbers.Length - 1;

            while (idxLeft < idxRight)
            {
                if (numbers[idxLeft] + numbers[idxRight] == target)
                    return new int[] { idxLeft + 1, idxRight + 1 };
                else if (numbers[idxLeft] + numbers[idxRight] > target)
                    idxRight--;
                else
                    idxLeft++;
            }
            return new int[] { -1, -1 };
        }


        /// <summary>
        /// 1608. Special Array With X Elements Greater Than or Equal X
        /// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SpecialArray(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            //0, 0, 3, 4, 4
            int min = Math.Min(nums[0], n);
            int max = Math.Min(nums[n - 1], n);
            int x = min;
            int idx = 0;    //index point
            while (x <= max)
            {
                if (x == n - idx)
                    return x;

                while (idx < n && nums[idx] <= x)
                    idx++;

                x++;
            }

            return -1;
        }

        /// <summary>
        /// 1351. Count Negative Numbers in a Sorted Matrix
        /// https://leetcode.com/problems/count-negative-numbers-in-a-sorted-matrix/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountNegatives(int[][] grid)
        {
            int rowLen = grid.Length;
            int colLen = grid[0].Length;
            int numOfNeg = 0;

            int startCol = CountNegativesBSearchR(grid, 0, colLen);
            if (startCol != -1)
                numOfNeg += (colLen - startCol) * rowLen;
            else
                startCol = colLen;

            //int startRow = CountNegativesBSearchC(grid, 0, rowLen);
            //if (startRow != -1)
            //    numOfNeg += (rowLen - startRow) * startCol;

            for (int c = 0; c < startCol; c++)
            {
                int row = CountNegativesBSearchC(grid, c, rowLen);
                if (row != -1)
                    numOfNeg += (rowLen - row);
            }
            return numOfNeg;
        }
        private int CountNegativesBSearchR(int[][] grid, int row, int colLen)
        {
            int l = 0, h = colLen - 1;
            while (l <= h)
            {
                int m = l + (h - l) / 2;
                if (grid[row][m] == 0)
                {
                    if (m + 1 < colLen && grid[row][m + 1] < 0)
                        return m + 1;
                    else
                        l = m + 1;
                }
                else if (grid[row][m] > 0)
                    l = m + 1;
                else
                {
                    h = m - 1;
                }
            }
            return l < colLen ? l : -1;
        }
        private int CountNegativesBSearchC(int[][] grid, int col, int rowLen)
        {
            int l = 0, h = rowLen - 1;
            while (l <= h)
            {
                int m = l + (h - l) / 2;
                if (grid[m][col] == 0)
                {
                    if (m + 1 < rowLen && grid[m + 1][col] < 0)
                        return m + 1;
                    else
                        l = m + 1;
                }
                else if (grid[m][col] > 0)
                    l = m + 1;
                else
                {
                    h = m - 1;
                }
            }
            return l < rowLen ? l : -1;
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

            int left = 0;
            int right = rowLen * colLen - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                int row = mid / colLen;
                int col = mid % colLen;
                if (matrix[row][col] == target)
                    return true;
                else if (matrix[row][col] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return false;
        }

        /// <summary>
        /// 1337. The K Weakest Rows in a Matrix
        /// https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix/
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KWeakestRows(int[][] mat, int k)
        {
            //row, # of soldiers
            int[] ans = new int[k];
            int cursor = 0;
            int n = mat.Length;
            int m = mat[0].Length;
            for (int col = 0; col < m; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    if (mat[row][col] == 0)
                    {
                        if (col == 0)
                            ans[cursor++] = row;
                        else
                        {
                            if (mat[row][col - 1] == 1)
                                ans[cursor++] = row;
                        }
                        if (cursor == k)
                            return ans;
                    }
                }
            }
            //all elements are 1.
            for (int row = 0; row < n; row++)
            {
                if (mat[row][m - 1] == 1)
                    ans[cursor++] = row;

                if (cursor == k)
                    return ans;
            }
            return ans;
        }


        /// <summary>
        /// 1346. Check If N and Its Double Exist
        /// https://leetcode.com/problems/check-if-n-and-its-double-exist/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CheckIfExist(int[] arr)
        {
            HashSet<int> map = new HashSet<int>();
            foreach (var num in arr)
            {
                if (map.Contains(num * 2) || (num % 2 != 1 && map.Contains(num / 2)))
                    return true;
                else
                    map.Add(num);
            }
            return false;
        }


        /// <summary>
        /// 350. Intersection of Two Arrays II
        /// https://leetcode.com/problems/intersection-of-two-arrays-ii/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int n1 = 0, n2 = 0;
            List<int> res = new List<int>();
            while (n1 < nums1.Length && n2 < nums2.Length)
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
        }

        /// <summary>
        /// 633. Sum of Square Numbers
        /// https://leetcode.com/problems/sum-of-square-numbers/
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool JudgeSquareSum(int c)
        {
            for (long a = 0; a * a <= c; a++)
            {
                double b = Math.Sqrt(c - a * a);
                if (b == (int)b)
                    return true;
            }
            return false;
        }
    }
}
