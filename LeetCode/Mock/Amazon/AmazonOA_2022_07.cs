﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AmazonOA_2022_07
    {
        //1.Find First Palindromic String in the Array
        /// <summary>
        /// 2108. Find First Palindromic String in the Array
        /// https://leetcode.com/problems/find-first-palindromic-string-in-the-array/
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string FirstPalindrome(string[] words)
        {
            foreach(string w in words)
            {
                if (IsPalindrome(w))
                    return w;
            }
            return string.Empty;
        }
        private bool IsPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l <= r)
            {
                if (s[l++] != s[r--])
                    return false;
            }
            return true;
        }


        //2.Adding Spaces to a String
        /// <summary>
        /// 2109. Adding Spaces to a String 
        /// https://leetcode.com/problems/adding-spaces-to-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public string AddSpaces(string s, int[] spaces)
        {
            StringBuilder ans = new StringBuilder();

            int startPos = 0;
            for (int p = 0; p < spaces.Length; p++)
            {
                int pos = spaces[p];
                ans.Append(s.Substring(startPos, pos - startPos));
                ans.Append(" ");
                startPos = pos;
            }
            if (startPos < s.Length)
                ans.Append(s.Substring(startPos, s.Length - startPos));

            return ans.ToString();
        }


        //3.Number of Smooth Descent Periods of a Stock
        /// <summary>
        /// 2110. Number of Smooth Descent Periods of a Stock - M
        /// https://leetcode.com/problems/number-of-smooth-descent-periods-of-a-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public long GetDescentPeriods(int[] prices)
        {
            return -1;
        }


        //4.Minimum Operations to Make the Array K-Increasing
        /// <summary>
        /// 2111. Minimum Operations to Make the Array K-Increasing  H
        /// https://leetcode.com/problems/minimum-operations-to-make-the-array-k-increasing/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KIncreasing(int[] arr, int k)
        {
            return -1;
        }


        //5.Divide a String Into Groups of Size k
        /// <summary>
        /// 2138. Divide a String Into Groups of Size k - E
        /// https://leetcode.com/problems/divide-a-string-into-groups-of-size-k/#:~:text=The%20first%20group%20consists%20of,used%20to%20complete%20the%20group.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public string[] DivideString(string s, int k, char fill)
        {
            return null;
        }



        //6.Minimum Moves to Reach Target Score
        /// <summary>
        /// 2139. Minimum Moves to Reach Target Score
        /// https://leetcode.com/problems/minimum-moves-to-reach-target-score/
        /// </summary>
        /// <param name="target"></param>
        /// <param name="maxDoubles"></param>
        /// <returns></returns>
        public int MinMoves(int target, int maxDoubles)
        {
            int minM = 0;
            if (target == 1)
                return minM;

            if (target % 2 == 0 && maxDoubles > 0)
                minM = MinMoves(target / 2, maxDoubles - 1) + 1;
            else if (maxDoubles <= 0)
                minM += target - 1;
            else
                minM = MinMoves(target - 1, maxDoubles) + 1;

            return minM;
        }


        //7.Solving Questions With Brainpower
        /// <summary>
        /// 2140. Solving Questions With Brainpower
        /// https://leetcode.com/problems/solving-questions-with-brainpower/
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        public long MostPoints(int[][] questions)
        {
            //position, max points
            //Dictionary<int, long> dp = new Dictionary<int, long>();
            //return MostPointsR(questions, 0, dp);
            int n = questions.Length;
            long[] dp = new long[n];
            dp[n - 1] = questions[n - 1][0];
            for (int i = n - 2; i >= 0; i--)
            {
                int p = questions[i][0];
                int bp = questions[i][1];
                if (i + 1 + bp < n)
                    dp[i] = Math.Max(p + dp[i + 1 + bp], dp[i + 1]);
                else
                    dp[i] = Math.Max(p, dp[i + 1]);
            }
            return dp[0];
        }
        private long MostPointsR(int[][] questions, int currPos, Dictionary<int, long> dp)
        {
            if (currPos >= questions.Length)
                return 0;
            if (dp.ContainsKey(currPos))
                return dp[currPos];

            int brainPower = questions[currPos][1];
            long maxPoint = questions[currPos][0];
            maxPoint += MostPointsR(questions, currPos + 1 + brainPower, dp);
            maxPoint = Math.Max(maxPoint, MostPointsR(questions, currPos + 1, dp));
            dp.Add(currPos, maxPoint);
            return maxPoint;
        }



        //8.Maximum Running Time of N Computers
        /// <summary>
        /// 2141. Maximum Running Time of N Computers - H
        /// https://leetcode.com/problems/maximum-running-time-of-n-computers/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="batteries"></param>
        /// <returns></returns>
        public long MaxRunTime(int n, int[] batteries)
        {
            return -1;
        }



        //9.Keep Multiplying Found Values by Two
        /// <summary>
        /// 2154. Keep Multiplying Found Values by Two - E
        /// https://leetcode.com/problems/keep-multiplying-found-values-by-two/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="original"></param>
        /// <returns></returns>
        public int FindFinalValue(int[] nums, int original)
        {
            return -1;
        }


        //10.All Divisions With the Highest Score of a Binary Array
        /// <summary>
        /// 2155. All Divisions With the Highest Score of a Binary Array - M
        /// https://leetcode.com/problems/all-divisions-with-the-highest-score-of-a-binary-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MaxScoreIndices(int[] nums)
        {
            return null;
        }


        //11.Find Substring With Given Hash Value
        /// <summary>
        /// 2156. Find Substring With Given Hash Value - H
        /// https://leetcode.com/problems/find-substring-with-given-hash-value/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="power"></param>
        /// <param name="modulo"></param>
        /// <param name="k"></param>
        /// <param name="hashValue"></param>
        /// <returns></returns>
        public string SubStrHash(string s, int power, int modulo, int k, int hashValue)
        {

            return null;
        }


        //12.Groups of Strings
        /// <summary>
        /// 2157. Groups of Strings - H
        /// https://leetcode.com/problems/groups-of-strings/
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int[] GroupStrings(string[] words)
        {
            return null;
        }


        //13.Count Operations to Obtain Zero
        /// <summary>
        /// 2169. Count Operations to Obtain Zero - E
        /// https://leetcode.com/problems/count-operations-to-obtain-zero/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public int CountOperations(int num1, int num2)
        {
            return -1;
        }


        //14.Minimum Operations to Make the Array Alternating 
        /// <summary>
        /// 2170. Minimum Operations to Make the Array Alternating - M
        /// https://leetcode.com/problems/minimum-operations-to-make-the-array-alternating/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums)
        {
            return -1;
        }


        //15.Removing Minimum Number of Magic Beans
        /// <summary>
        /// 2171. Removing Minimum Number of Magic Beans - M
        /// https://leetcode.com/problems/removing-minimum-number-of-magic-beans/
        /// </summary>
        /// <param name="beans"></param>
        /// <returns></returns>
        public long MinimumRemoval(int[] beans)
        {
            return -1;
        }


        //16.Maximum AND Sum of Array
        /// <summary>
        /// 2172. Maximum AND Sum of Array - H
        /// https://leetcode.com/problems/maximum-and-sum-of-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="numSlots"></param>
        /// <returns></returns>
        public int MaximumANDSum(int[] nums, int numSlots)
        {
            return -1;
        }
    }
}
