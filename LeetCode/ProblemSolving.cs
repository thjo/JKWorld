using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ProblemSolving
    {
        /// <summary>
        /// Spiral Matrix
        /// https://leetcode.com/problems/spiral-matrix/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> visitedIdx = new List<int>();
            IList<int> visited = new List<int>();
            int direction = 0;      //0: left, 1: Down, 2:Right, 3: Up
            int m = matrix.Length;      //# of rows
            int n = matrix[0].Length;   //# of cols
            int row = 0, col = 0;
            int curridx = 0;
            while (visited.Count < m * n)
            {
                curridx = row * n + col;
                if ( direction == 0)
                {
                    //Left
                    if(col >= n || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Down
                        direction = 1;
                        col--;
                        row++;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        col++;
                    }
                }
                else if (direction == 1)
                {
                    //Down
                    if(row >= m || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Right
                        direction = 2;
                        row--;
                        col--;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        row++;
                    }
                }
                else if (direction == 2)
                {
                    //Right
                    if (col < 0 || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Up
                        direction = 3;
                        col++;
                        row--;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        col--;
                    }
                }
                else
                {
                    //Up
                    if (row < 0 || visitedIdx.Contains(curridx))
                    {
                        //Change the direction to Left
                        direction = 0;
                        row++;
                        col++;
                    }
                    else
                    {
                        visitedIdx.Add(curridx);
                        visited.Add(matrix[row][col]);
                        row--;
                    }
                }
            }

            return visited;
        }

        /// <summary>
        /// Divide Two Integers
        /// https://leetcode.com/problems/divide-two-integers/
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (dividend == 0)
                return 0;
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;

            bool isFlag = (dividend ^ divisor) < 0;
            long d1 = Math.Abs((long)dividend);
            long d2 = Math.Abs((long)divisor);
            int result = 0;
            for (int i = 31; i >= 0; i--)
            {
                if ((d1 >> i) >= d2)
                {
                    result += 1 << i;
                    d1 -= d2 << i;
                }
            }
            return isFlag ? -1 * result : result;
            //long result = 0L;
            //if (dividend == 0)
            //    return 0;

            //bool sign = (dividend < 0) == (divisor < 0) ? true : false;
            //long dividendL = dividend * 1L;
            //if (dividend < 0)
            //    dividendL = dividendL * -1;
            //long divisorL = divisor * 1L;
            //if (divisor < 0)
            //    divisorL = divisorL * -1;

            //while (dividendL - divisorL >= 0)
            //{
            //    int count = 1;
            //    while (dividendL - (divisorL << count) >= 0)
            //        count++;

            //    dividendL -= divisorL << (count-1);
            //    result += 1L << (count - 1);
            //}

            //if (sign && result > Int32.MaxValue)
            //    return Int32.MaxValue;
            //else
            //    return sign ? (int)result : (int)(result * -1);
        }

    }
}
