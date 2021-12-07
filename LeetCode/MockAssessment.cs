using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MockAssessment
    {
        #region | Online Assessment | 

        public bool IsOneBitCharacter(int[] bits)
        {
            int i = 0;
            int lastChar = -1;
            while( i < bits.Length)
            {
                if(bits[i] == 0)
                    lastChar = 1;
                else
                    lastChar = 2;

                i += lastChar;
            }

            return lastChar == 1 ? true : false;
        }

        #endregion

        #region | Online Assessment - 11/28/2021 | 

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (dp.ContainsKey(target - nums[i]))
                    return new int[] { dp[target - nums[i]], i };
                else
                {
                    if(dp.ContainsKey(nums[i]) == false)
                        dp.Add(nums[i], i);
                }
            }

            return null;
        }


        /// <summary>
        /// https://leetcode.com/problems/prison-cells-after-n-days/
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] PrisonAfterNDays(int[] cells, int n)
        {
            if (cells == null || cells.Length <= 2)
                return cells;

            Dictionary<string, int> seen = new Dictionary<string, int>();
            int len = cells.Length;
            int currIdx = 1;
            while (currIdx <= n)
            {
                int[] cells2 = new int[len];

                for (int i = 1; i < len - 1; ++i)
                    cells2[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;
                cells = cells2;

                string newCellsStr = ConvertToStr(cells);
                if (seen.ContainsKey(newCellsStr))
                {
                    int mod = n % (currIdx - 1);
                    if (mod == 0) mod = (currIdx - 1);
                    int cnt = 1;
                    foreach (var cell in seen)
                    {
                        if (cnt == mod)
                            return ConvertToIntArray(cell.Key);
                        cnt++;
                    }
                    return null;
                }
                else
                    seen.Add(newCellsStr, currIdx);
                currIdx++;
            }
            return cells;
        }
        private string ConvertToStr(int[] cells)
        {
            string ret = "";
            foreach (var n in cells)
                ret += n.ToString();

            return ret;
        }
        private int[] ConvertToIntArray(string cells)
        {
            int[] ret = new int[cells.Length];

            for (int i = 0; i < cells.Length; i++)
                ret[i] = int.Parse(cells[i].ToString());

            return ret;
        }

        #endregion

        #region | Online Assessment - 11/30/2021 | 

        public string FractionToDecimal(int numerator, int denominator)
        {
            string fraTotal = "";
            bool isNegative = false;

            if ( (numerator < 0 && denominator > 0) 
                || (numerator > 0 && denominator < 0))
            {
                isNegative = true;
            }

            long numer = numerator;
            long denom = denominator;
            if(numer < 0)
                numer = Math.Abs(numer);
            if(denom < 0)
                denom = Math.Abs(denom);
            long rest = (numer % denom);
            long num = (numer / denom);
            if (isNegative)
                fraTotal += "-";
            fraTotal += num.ToString();
            
            if (rest != 0)
            {
                Dictionary<long, int> dpRest = new Dictionary<long, int>();
                int idxPosition = 0;
                dpRest.Add(rest, idxPosition++);
                fraTotal += ".";
                string restStr = "";
                while (rest != 0)
                {
                    numer = rest * 10;
                    rest =  (numer % denom);
                    num =  (numer / denom);
                    restStr += num.ToString();

                    if (dpRest.ContainsKey(rest))
                    {
                        int posion = dpRest[rest];
                        restStr = restStr.Substring(0, posion) + "(" + restStr.Substring(0 + posion);
                        restStr += ")";
                        break;
                    }
                    else
                        dpRest.Add(rest, idxPosition++);
                }
                fraTotal += restStr;
            }

            return fraTotal;
        }


        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<int[]> intersections = new List<int[]>();
            if (firstList == null || secondList == null
                && firstList.Length < 1 || secondList.Length < 1)
                return intersections.ToArray();

            int firstIdx = 0, secIdx = 0;
            int start = -1, close = -1;
            while ( firstIdx < firstList.Length && secIdx < secondList.Length)
            {
                if (firstList[firstIdx][0] > secondList[secIdx][0])
                {
                    start = firstList[firstIdx][0];
                    if (start > secondList[secIdx][1])
                        secIdx++;
                    else
                    {
                        if (firstList[firstIdx][1] < secondList[secIdx][1])
                        {
                            close = firstList[firstIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = secondList[secIdx][1];
                            firstIdx++;
                        }
                        else
                        {
                            close = secondList[secIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = firstList[firstIdx][1];
                            secIdx++;
                        }
                    }
                }
                else
                {
                    start = secondList[secIdx][0];
                    if (start > firstList[firstIdx][1])
                        firstIdx++;
                    else
                    {
                        if (firstList[firstIdx][1] < secondList[secIdx][1])
                        {
                            close = firstList[firstIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = secondList[secIdx][1];
                            firstIdx++;
                        }
                        else
                        {
                            close = secondList[secIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = firstList[firstIdx][1];
                            secIdx++;
                        }
                    }
                }
            }


            return intersections.ToArray();
        }



        #endregion

        /// <summary>
        /// 1094. Car Pooling
        /// https://leetcode.com/problems/car-pooling/
        /// </summary>
        /// <param name="trips"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public bool CarPooling(int[][] trips, int capacity)
        {
            int[] timestamp = new int[1001];
            foreach(var t in trips)
            {
                timestamp[t[1]] += t[0];
                timestamp[t[2]] -= t[0];
            }

            foreach(int p in timestamp)
            {
                capacity -= p;
                if (capacity < 0)
                    return false;
            }
            
            return true;
        }



        public string ReverseOnlyLetters(string s)
        {
            char[] reverseStr = new char[s.Length];

            int l = 0, r = s.Length - 1;
            while(l < s.Length)
            {
                if (char.IsLetter(s[l]))
                {
                    while(char.IsLetter(s[r]) == false || reverseStr[r] != '\0')
                        r--;
                    reverseStr[r--] = s[l];
                }
                else
                {
                    reverseStr[l] = s[l];
                }
                l++;
            }

            return new String(reverseStr);
        }


        public int DiagonalSum(int[][] mat)
        {
            int n = mat.Length;
            if (n == 1)
                return mat[0][0];

            int sumPri = 0, sumSec = 0; 

            for(int r = 0; r < n; r++)
            {
                sumPri += mat[r][r];
                sumSec += mat[r][n - 1 - r];
            }

            if( n % 2 == 0)
                return sumPri + sumSec;
            else
                return sumPri + sumSec - mat[n/2][n/2];
        }


        public int dieSimulator(int n, int[] rollMax)
        {
            long divisor = (long)Math.Pow(10, 9) + 7;
            long[][] dp = new long[n][];
            for (int i = 0; i < n; i++)
                dp[i] = new long[7];
            for (int i = 0; i < 6; i++)
            {
                dp[0][i] = 1;
            }
            dp[0][6] = 6;
            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int j = 0; j < 6; j++)
                {
                    dp[i][j] = dp[i - 1][6];
                    if (i - rollMax[j] < 0)
                    {
                        sum = (sum + dp[i][j]) % divisor;
                    }
                    else
                    {
                        if (i - rollMax[j] - 1 >= 0) dp[i][j] = (dp[i][j] - (dp[i - rollMax[j] - 1][6] - dp[i - rollMax[j] - 1][j])) % divisor + divisor;
                        else dp[i][j] = (dp[i][j] - 1) % divisor;
                        sum = (sum + dp[i][j]) % divisor;
                    }

                }
                dp[i][6] = sum;
            }
            return (int)(dp[n - 1][6]);
        }
    }
}
