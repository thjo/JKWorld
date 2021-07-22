using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Practices
    {
        //Climbing Stairs
        //https://leetcode.com/problems/climbing-stairs/
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;

            //int[] dp = new int[n + 1];
            //dp[1] = 1;
            //dp[2] = 2;
            //for (int i = 3; i <= n; i++)
            //    dp[i] = dp[i - 1] + dp[i - 2];

            //return dp[n];
            int first = 1;
            int second = 2;
            for (int i = 3; i <= n; i++)
            {
                int third = first + second;
                first = second;
                second = third;
            }

            return second;
        }


        //Coin Change
        //https://leetcode.com/problems/coin-change/
        public int CoinChange(int[] coins, int amount)
        {
            if (amount <= 0)
                return 0;
            else if (coins == null || coins.Length < 1)
                return -1;


            Dictionary<int, int> mapAmount = new Dictionary<int, int>();
            mapAmount.Add(0, 0);
            Array.Sort(coins);
            //int numOfCoins = ChangeMakingProblemBottomUp(coins, amount, mapAmount);
            int numOfCoins = ChangeMakingProblemTopDown(coins, coins.Length, amount + 1, amount, mapAmount);
            if (numOfCoins > amount)
                return -1;
            else
                return numOfCoins;

        }
        public int ChangeMakingProblemBottomUp(int[] coins, int amount, Dictionary<int, int> mapAmount)
        {
            for (int i = 1; i <= amount; i++)
            {
                int minVal = amount + 1;
                foreach (int c in coins)
                {
                    if (i < c)
                        break;
                    else
                    {
                        if (mapAmount.ContainsKey(i - c))
                            minVal = Math.Min(mapAmount[i - c] + 1, minVal);
                    }
                }
                mapAmount.Add(i, minVal);
            }

            return mapAmount[amount];
        }
        public int ChangeMakingProblemTopDown(int[] coins, int n, int initMinVal, int amount, Dictionary<int, int> mapAmount)
        {
            if (amount <= 0)
                return 0;
            else if (mapAmount.ContainsKey(amount))
                return mapAmount[amount];

            int minVal = initMinVal;
            for (int i = 0; i < coins.Length; i++)
            {
                if (amount - coins[i] >= 0)
                {
                    int tmp = ChangeMakingProblemTopDown(coins, n, initMinVal, amount - coins[i], mapAmount);
                    minVal = Math.Min(minVal, tmp + 1);
                }
            }
            mapAmount.Add(amount, minVal);
            return minVal;
        }



    }
}
