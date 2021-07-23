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



        //Rotate List
        //
        public ListNode RotateRight(ListNode head, int k)
        {
            int numOfRotate = k;
            int lengthOfList = 0;

            if (head == null || head.next == null || k == 0)
                return head;

            ListNode tail = head;
            lengthOfList = 1;
            //Move to tail
            while (tail.next != null)
            {
                tail = tail.next;
                lengthOfList++;
            }
            if (k % lengthOfList == 0)
                return head;

            numOfRotate = lengthOfList - (k % lengthOfList);

            for (int i = 1; i <= numOfRotate; i++)
            {
                ListNode newHead = head.next;
                tail.next = head;
                tail = tail.next;
                tail.next = null;
                head = newHead;
            }

            return head;

            //if (head == null || head.next == null)
            //{
            //    return head;
            //}

            //int len = 1;
            //ListNode curr = head;

            //while (curr.next != null)
            //{
            //    curr = curr.next;
            //    len++;
            //}

            //curr.next = head;

            //ListNode newTail = head;

            //// Find the new tail, which is (n - k % n - 1)th node 
            //// from the head and the new head,
            //// which is (n - k % n)th node.
            //int rotate = len - k % len - 1;

            //while (rotate > 0)
            //{
            //    newTail = newTail.next;
            //    rotate--;
            //}

            //ListNode newHead = newTail.next;
            //newTail.next = null;

            //return newHead;
        }
    }
}
