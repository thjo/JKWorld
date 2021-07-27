using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class InterviewPreparationKit
    {
        #region | Recursion | 

        //Recursion: Fibonacci Numbers
        //https://www.hackerrank.com/challenges/ctci-fibonacci-numbers/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking
        public static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        //Recursion: Davis' Staircase
        //https://www.hackerrank.com/challenges/ctci-recursive-staircase/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking&h_r=next-challenge&h_v=zen
        public static int stepPerms(int n)
        {
            ////Bottom-Up
            //if (n <= 2) 
            //    return n;
            //else if (n == 3) 
            //    return 4;
            //else
            //{
            //    Dictionary<int, int> dp = new Dictionary<int, int>();
            //    dp.Add(1, 1);
            //    dp.Add(2, 2);
            //    dp.Add(3, 4);

            //    for (int i = 4; i <= n; i++)
            //    {
            //        dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            //    }

            //    return dp[dp.Count];
            //}


            //Top Down Approach
            Dictionary<int, int> dp = new Dictionary<int, int>();
            return StepsClimbing(n, dp);
        }
        private static int StepsClimbing(int n, Dictionary<int, int> dp)
        {
            if (n < 0)
                return 0;
            else if (n <= 1)
                return 1;
            else
            {
                if (dp.ContainsKey(n))
                    return dp[n];
                else
                {
                    int step3 = StepsClimbing(n - 3, dp);
                    int step2 = StepsClimbing(n - 2, dp);
                    int step1 = StepsClimbing(n - 1, dp);
                    dp.Add(n, step3 + step2 + step1);
                    return step1 + step2 + step3;
                }
            }
        }


        //Crossword Puzzle
        //https://www.hackerrank.com/challenges/crossword-puzzle/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=recursion-backtracking&h_r=next-challenge&h_v=zen
        public static List<string> crosswordPuzzle(List<string> crossword, string words)
        {
            return null;
        }


        #endregion
    }
}
