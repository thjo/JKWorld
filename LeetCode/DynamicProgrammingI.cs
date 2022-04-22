using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class DynamicProgrammingI
    {
        /// <summary>
        /// 509. Fibonacci Number
        /// https://leetcode.com/problems/fibonacci-number/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            if (n <= 1)
                return n;
            return Fib(n - 1) + Fib(n - 2);

            Dictionary<int, int> memFib = new Dictionary<int, int>();
            return FibSub(n, memFib);
        }
        private int FibSub(int n, Dictionary<int, int> memFib)
        {
            if (memFib.ContainsKey(n))
                return memFib[n];
            else if (n <= 1)
                return n;

            int n2 = FibSub(n - 2, memFib);
            if (memFib.ContainsKey(n - 2) == false)
                memFib.Add(n - 2, n2);
            int n1 = FibSub(n - 1, memFib);
            if (memFib.ContainsKey(n - 1) == false)
                memFib.Add(n - 1, n1);
            return n2 + n1;
        }

        /// <summary>
        /// 1137. N-th Tribonacci Number
        /// https://leetcode.com/problems/n-th-tribonacci-number/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci(int n)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();
            return TribonacciM(n, dp);
        }
        private int TribonacciM(int n, Dictionary<int, int> dp)
        {
            if (n == 0)
                return n;
            else if (n == 1 || n == 2)
                return 1;
            if (dp.ContainsKey(n))
                return dp[n];

            int total = TribonacciM(n - 3, dp) + TribonacciM(n - 2, dp) + TribonacciM(n - 1, dp);
            dp.Add(n, total);
            return total;
        }


        /// <summary>
        /// 70. Climbing Stairs
        /// https://leetcode.com/problems/climbing-stairs/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n <= 2)
                return n;

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
                dp[i] = dp[i - 1] + dp[i - 2];

            return dp[n];
        }


        /// <summary>
        /// 746. Min Cost Climbing Stairs
        /// https://leetcode.com/problems/min-cost-climbing-stairs/
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 2)
                return Math.Min(cost[0], cost[1]);

            int n = cost.Length;
            int[] dp = new int[n];
            dp[0] = cost[0];
            dp[1] = cost[1];

            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + cost[i];
            }

            return Math.Min(dp[n - 1], dp[n - 2]);
        }


        /// <summary>
        /// 198. House Robber
        /// https://leetcode.com/problems/house-robber/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            int n = nums.Length;
            int[] dp = new int[n];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            //1 2 4 4
            return dp[n - 1];
        }
    }
}
