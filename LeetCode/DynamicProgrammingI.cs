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
        public int RobI(int[] nums)
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

        /// <summary>
        /// 213. House Robber II
        /// https://leetcode.com/problems/house-robber-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RobII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            else if (nums.Length == 1)
                return nums[0];

            int max1 = RobRec(nums, 0, nums.Length - 2);
            int max2 = RobRec(nums, 1, nums.Length - 1);

            return Math.Max(max1, max2);

        }
        private int RobRec(int[] nums, int start, int end)
        {
            if (start == end)
                return nums[start];

            int[] dp = new int[nums.Length];
            dp[start] = nums[start];
            dp[start + 1] = Math.Max(nums[start], nums[start + 1]);

            for (int i = start + 2; i <= end; i++)
            {
                dp[i] = Math.Max(dp[i - 1], (dp[i - 2] + nums[i]));
            }

            return dp[end];
        }


        /// <summary>
        /// 740. Delete and Earn
        /// https://leetcode.com/problems/delete-and-earn/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DeleteAndEarn(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int n in nums)
            {
                if (map.ContainsKey(n))
                    map[n]++;
                else
                    map.Add(n, 1);
            }
            Array.Sort(nums);
            int[] dp = new int[map.Count];
            int prev = nums[0];
            int dpIdx = 0;
            dp[dpIdx] = nums[0] * map[nums[0]];
            for (int i = 1; i < nums.Length; i++)
            {
                if (prev == nums[i])
                    continue;

                int total = nums[i] * map[nums[i]];
                if (prev + 1 != nums[i])
                    total += dp[dpIdx];
                else
                {
                    if (dpIdx - 1 >= 0)
                        total += dp[dpIdx - 1];

                    total = Math.Max(total, dp[dpIdx]);
                }
                dpIdx++;
                dp[dpIdx] = total;
                prev = nums[i];
            }
            return dp[map.Count - 1];
        }


        /// <summary>
        /// 55. Jump Game
        /// https://leetcode.com/problems/jump-game/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1)
                return true;

            int goal = nums.Length - 1;

            for (int currIdx = nums.Length - 2; currIdx >= 0; currIdx--)
            {
                if (nums[currIdx] + currIdx >= goal)
                    goal = Math.Min(currIdx, goal);
            }
            return goal == 0;
        }
        public bool CanJumpI(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return true;

            bool[] dp = new bool[n];
            for (int i = 0; i < n; i++)
                dp[i] = false;
            dp[n - 1] = true;
            int idx = n - 2;
            while (idx >= 0)
            {
                int maxJump = nums[idx];
                int addIdx = 1;
                while (addIdx <= maxJump)
                {
                    if (idx + addIdx < n)
                        dp[idx] = dp[idx + addIdx];
                    if (dp[idx])
                        break;
                    addIdx++;
                }
                idx--;
            }
            return dp[0];
        }


        /// <summary>
        /// 45. Jump Game II
        /// https://leetcode.com/problems/jump-game-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            int
        }
    }
}
