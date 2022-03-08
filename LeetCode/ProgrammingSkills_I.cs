﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ProgrammingSkills_I
    {
        /// <summary>
        /// 1523. Count Odd Numbers in an Interval Range
        /// https://leetcode.com/problems/count-odd-numbers-in-an-interval-range/
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int CountOdds(int low, int high)
        {
            int res = (high - low) / 2;

            if (high % 2 == 1 || low % 2 == 1)
            {
                res++;
            }

            return res;
        }

        /// <summary>
        /// 1491. Average Salary Excluding the Minimum and Maximum Salary
        /// https://leetcode.com/problems/average-salary-excluding-the-minimum-and-maximum-salary/
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public double Average(int[] salary)
        {
            if (salary.Length <= 2)
                return 0;

            int min = salary[0];
            int max = salary[0];
            double sum = 0;
            foreach (int s in salary)
            {
                sum += s;
                min = Math.Min(min, s);
                max = Math.Max(max, s);
            }

            return (sum - min - max) / (salary.Length - 2);
        }


        /// <summary>
        /// 191. Number of 1 Bits
        /// https://leetcode.com/problems/number-of-1-bits/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int retVal = 0;
            while ((n | 0) > 0)
            {
                if ((n & 1) > 0)
                    retVal++;
                n = n >> 1;
            }

            return retVal;
        }


        /// <summary>
        /// 1281. Subtract the Product and Sum of Digits of an Integer
        /// https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SubtractProductAndSum(int n)
        {
            int pDigits = 1;
            int sDigits = 0;

            while (n > 0)
            {
                int d = n % 10;
                pDigits *= d;
                sDigits += d;
                n = n / 10;
            }

            return pDigits - sDigits;
        }

        /// <summary>
        /// 976. Largest Perimeter Triangle
        /// https://leetcode.com/problems/largest-perimeter-triangle/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);
            for (int i = nums.Length - 3; i >= 0; --i)
                if (nums[i] + nums[i + 1] > nums[i + 2])
                    return nums[i] + nums[i + 1] + nums[i + 2];
            return 0;
        }

        /// <summary>
        /// 1779. Find Nearest Point That Has the Same X or Y Coordinate
        /// https://leetcode.com/problems/find-nearest-point-that-has-the-same-x-or-y-coordinate/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public int NearestValidPoint(int x, int y, int[][] points)
        {
            int minDist = int.MaxValue;
            int idxMinDist = -1;
            for (int i = 0; i < points.Length; i++)
            {
                int[] p = points[i];
                if (p[0] == x || p[1] == y)
                {
                    int distX = Math.Abs(x - p[0]);
                    int distY = Math.Abs(y - p[1]);
                    int dist = distX;
                    if (dist == 0)
                        dist = distY;
                    else
                    {
                        if (distY != 0)
                            dist *= distY;
                    }

                    if (minDist > dist)
                    {
                        minDist = dist;
                        idxMinDist = i;
                    }
                }
            }

            return idxMinDist;
        }

        /// <summary>
        /// 1790. Check if One String Swap Can Make Strings Equal
        /// https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool AreAlmostEqual(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            char? c1 = null;
            char? c2 = null;
            int cnt = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                    continue;
                else
                {
                    cnt++;
                    if (cnt > 2)
                        return false;

                    if (c1 == null)
                    {
                        c1 = s1[i];
                        c2 = s2[i];
                    }
                    else
                    {
                        if (c1 != c2 && c1 == s2[i] && c2 == s1[i])
                            c1 = c2;
                    }
                }
            }

            if (cnt == 0 || (cnt == 2 && c1.Value == c2.Value))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 202. Happy Number
        /// https://leetcode.com/problems/happy-number/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {
            if (n == 1)
                return true;

            int slowRunner = n;
            int fastRunner = getNext(n);
            while (fastRunner != 1 && fastRunner != slowRunner)
            {
                slowRunner = getNext(slowRunner);
                fastRunner = getNext(getNext(fastRunner));
            }

            if (fastRunner == 1)
                return true;
            else
                return false;
        }
        private int getNext(int n)
        {
            int totalSum = 0;
            while (n > 0)
            {
                int d = n % 10;
                n = n / 10;
                totalSum += d * d;
            }

            return totalSum;
        }


        /// <summary>
        /// 1502. Can Make Arithmetic Progression From Sequence
        /// https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            //Brute Force
            //Array.Sort(arr);
            //int d = arr[1] - arr[0];
            //for (int i = 2; i < arr.Length; i++)
            //{
            //    if (arr[i] - arr[i - 1] != d)
            //        return false;
            //}
            //return true;

            //Optimization
            int min = int.MaxValue;
            int max = int.MinValue;
            HashSet<int> set = new HashSet<int>();

            foreach (int num in arr)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
                set.Add(num);
            }
            int n = arr.Length;
            int d = (max - min);
            if (d % (n - 1) != 0)
                return false;
            d /= (n - 1);
            int i = 0;
            while (i < n)
            {
                if (set.Contains(min) == false)
                    return false;

                min += d;
                i++;
            }

            return true;
        }


        /// <summary>
        /// 1822. Sign of the Product of an Array
        /// https://leetcode.com/problems/sign-of-the-product-of-an-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ArraySign(int[] nums)
        {
            int numOfNegative = 0;
            foreach (int n in nums)
            {
                if (n == 0)
                    return 0;
                else if (n < 0)
                {
                    numOfNegative++;
                }
            }
            return numOfNegative % 2 == 0 ? 1 : -1;
        }


        /// <summary>
        /// 496. Next Greater Element I
        /// https://leetcode.com/problems/next-greater-element-i/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            Stack<int> wait = new Stack<int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                while (wait.Count > 0 && nums2[i] > wait.Peek())
                    map.Add(wait.Pop(), nums2[i]);
                wait.Push(nums2[i]);
            }

            while (wait.Count > 0)
                map.Add(wait.Pop(), -1);

            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                res[i] = map[nums1[i]];
            }

            return res;
        }


        /// <summary>
        /// 1232. Check If It Is a Straight Line
        /// https://leetcode.com/problems/check-if-it-is-a-straight-line/
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public bool CheckStraightLine(int[][] coordinates)
        {

            //dX/dY = xX/xY

            int dX = coordinates[1][0] - coordinates[0][0];
            int dY = coordinates[1][1] - coordinates[0][1];
            for (int i = 2; i < coordinates.Length; i++)
            {
                int x = coordinates[i][0] - coordinates[i - 1][0];
                int y = coordinates[i][1] - coordinates[i - 1][1];
                if (dX * y == dY * x)
                    continue;
                else
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 1572. Matrix Diagonal Sum
        /// https://leetcode.com/problems/matrix-diagonal-sum/
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int DiagonalSum(int[][] mat)
        {
            int sum = 0;

            int len = mat.Length;
            int l = 0, r = len - 1;
            for (int i = 0; i < len; i++)
            {
                if (l + i == r - i)
                    sum += mat[i][l + i];
                else
                    sum = sum + mat[i][l + i] + mat[i][r - i];
            }

            return sum;
        }

        /// <summary>
        /// 1588. Sum of All Odd Length Subarrays
        /// https://leetcode.com/problems/sum-of-all-odd-length-subarrays/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumOddLengthSubarrays(int[] arr)
        {
            int sum = 0;
            for(int i = 1; i < arr.Length; i +=2)
            {

            }

            return sum;
        }
    }
}
