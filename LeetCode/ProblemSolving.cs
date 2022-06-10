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

        /// <summary>
        /// Combination Sum
        /// https://leetcode.com/problems/combination-sum/
        /// Video: https://www.youtube.com/watch?v=GBKI9VSKdGg
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> results = new List<IList<int>>();
            CombinationCases(candidates, target, 0, new List<int>(), results);

            return results;
        }
        private void CombinationCases(int[] candidates, int target, int idx, IList<int> currCombination, IList<IList<int>> allCombinaions)
        {
            if (target == 0)
            {
                List<int> tmp = new List<int>();
                foreach (int i in currCombination)
                    tmp.Add(i);
                allCombinaions.Add(tmp);
                return;
            }
            else if (idx >= candidates.Length || target < 0)
                return;
            else
            {
                currCombination.Add(candidates[idx]);
                CombinationCases(candidates, target - candidates[idx], idx, currCombination, allCombinaions);
                currCombination.RemoveAt(currCombination.Count - 1);
                CombinationCases(candidates, target, idx + 1, currCombination, allCombinaions);
            }
            return;
        }

        /// <summary>
        /// 238. Product of Array Except Self
        /// https://leetcode.com/problems/product-of-array-except-self/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int len = nums.Length;
            int[] res = new int[nums.Length];
            res[0] = 1;
            int answer = 1;
            for (int i = 1; i < len; i++)
            {
                answer *= nums[i - 1];
                res[i] = answer;
            }

            answer = 1;
            for (int i = len - 2; i >= 0; i--)
            {
                answer *= nums[i + 1];
                res[i] *= answer;
            }

            return res;
        }


        public int ShipWithinDays(int[] weights, int days)
        {
            int n = weights.Length;
            int minWeight = int.MinValue;
            int maxWeight = 0;
            foreach (int w in weights)
            {
                minWeight = Math.Max(minWeight, w);
                maxWeight += w;
            }
            if (n == days)
                return minWeight;

            //[1,2,3,4,5,6,7,8,9,10]  - 15
            while (minWeight < maxWeight)
            {
                int mid = minWeight + (maxWeight - minWeight) / 2;
                if (CheckPossibility(weights, days, mid))
                    maxWeight = mid;
                else
                    minWeight = mid + 1;
            }
            return maxWeight;
        }

        private bool CheckPossibility(int[] weights, int days, int capacity)
        {
            int currWeight = weights[0];
            for (int i = 1; i < weights.Length; i++)
            {
                if(currWeight + weights[i] > capacity)
                {
                    if (days == 0)
                        return false;
                    days--;
                    currWeight = weights[i];
                }
                else  {
                    currWeight += weights[i];
                }
            }
            if (currWeight > 0)
                days--;

            return days >= 0 ? true : false;
        }

        /// <summary>
        /// 1151. Minimum Swaps to Group All 1's Together
        /// https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together/
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int MinSwaps(int[] data)
        {

        }

    }
}
