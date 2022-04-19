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




    }
}
