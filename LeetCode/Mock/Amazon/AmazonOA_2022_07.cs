using System;
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
            //7,6,5,4, 3,2,3,4,5,3,2,1
            //dp[0] = 1
            //dp[1] = (p[i-1]-1==p[i]) ? dp[i] + 1 : 1 >> 2
            //dp[2] = 3
            //dp[3] = 
            long ans = 1, prevCnt = 1;  //index = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                prevCnt = prices[i - 1] - 1 == prices[i] ? prevCnt + 1 : 1;
                ans += prevCnt;
            }

            return ans;
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
            int ans = 0;
            for(int i = 0; i < k; i++)
            {
                ans += MinKIncreasingOp(arr, k, i);
            }
            return ans;
        }
        private int MinKIncreasingOp(int[] arr, int k, int startIdx)
        {
            int ans = 0;
            for(int i = startIdx+k; i < arr.Length; i+=k)
            {
                if (arr[i - k] > arr[i])
                    ans++;
            }

            return ans;
        }


        //5.Divide a String Into Groups of Size k
        /// <summary>
        /// 2138. Divide a String Into Groups of Size k - E
        /// https://leetcode.com/problems/divide-a-string-into-groups-of-size-k/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <param name="fill"></param>
        /// <returns></returns>
        public string[] DivideString(string s, int k, char fill)
        {
            int len = s.Length / k;
            if (s.Length % k != 0)
                len++;
            string[] ans = new string[len];
            int idxS = 0, idxA = 0;
            while (idxS < s.Length)
            {
                if (idxS + k >= s.Length)
                    ans[idxA] = s.Substring(idxS);
                else
                    ans[idxA++] = s.Substring(idxS, k);
                idxS += k;
            }
            for (int i = k - ans[idxA].Length; i > 0; i--)
                ans[idxA] += fill;

            return ans;
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
            int final = original;
            //Case 1. Use an extra space
            HashSet<int> map = new HashSet<int>();
            foreach (int n in nums)
                map.Add(n);

            while (map.Contains(final))
                final *= 2;

            return final;
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
            int totalCntZero = 0;
            int totalCntOne = 0;
            foreach (int n in nums)
            {
                if (n == 0)
                    totalCntZero++;
                else
                    totalCntOne++;
            }

            int maxSocre = 0;
            int[] score = new int[nums.Length + 1];
            score[0] = totalCntOne;
            maxSocre = score[0];
            int currTotalZero = 0, currTotalOne = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    currTotalZero++;
                else
                    currTotalOne++;

                //count of curr zero, left of one (total one - curr one)
                score[i + 1] = currTotalZero + (totalCntOne - currTotalOne);
                maxSocre = Math.Max(maxSocre, score[i + 1]);
            }

            IList<int> listOfIdx = new List<int>();
            for (int i = 0; i < score.Length; i++)
            {
                if (score[i] == maxSocre)
                    listOfIdx.Add(i);
            }
            return listOfIdx;
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
            if (num1 < num2) (num1, num2) = (num2, num1);

            int numberOfOperations = 0;
            while (num1 != 0 && num2 != 0)
            {
                numberOfOperations += num1 / num2;
                (num1, num2) = (num2, num1 % num2);
            }

            return numberOfOperations;
            /*
                int op = 0;
                if (num1 == 0 || num2 == 0)
                    return op;
                if (num1 >= num2)
                    op = CountOperations(num1 - num2, num2) + 1;
                else
                    op = CountOperations(num1, num2 - num1) + 1;

                return op;        
            */
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
            if (nums.Length < 2)
                return 0;

            //value, frequency
            //Need to use Priority Queue
            Dictionary<int, int> maxFrqEvenVals = new Dictionary<int, int>();
            Dictionary<int, int> maxFrqOddVals = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    //Even
                    if (maxFrqEvenVals.ContainsKey(nums[i]) == false)
                        maxFrqEvenVals.Add(nums[i], 0);
                    maxFrqEvenVals[nums[i]]++;
                }
                else
                {
                    //Odd
                    if (maxFrqOddVals.ContainsKey(nums[i]) == false)
                        maxFrqOddVals.Add(nums[i], 0);
                    maxFrqOddVals[nums[i]]++;
                }
            }

            //Calculate min operations
            var eeList = maxFrqEvenVals.OrderByDescending(k => k.Value).ToList();
            var ooList = maxFrqOddVals.OrderByDescending(k => k.Value).ToList();

            int maxEE = eeList[0].Value, maxOO = ooList[0].Value;
            if (eeList[0].Key == ooList[0].Key)
            {
                int secEE = 0, secOO = 0;
                if (eeList.Count > 1)
                    secEE = eeList[1].Value;
                if (ooList.Count > 1)
                    secOO = ooList[1].Value;
                if (maxEE + secOO > maxOO + secEE)
                    maxOO = secOO;
                else
                    maxEE = secEE;
            }


            return nums.Length - (maxOO + maxEE);
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
            int len = beans.Length;
            Array.Sort(beans);
            long sum = 0;
            for (int i = 0; i < len; i++)
                sum += beans[i];
            long ans = long.MaxValue;
            for (int i = 0; i < len; i++)
                ans = Math.Min(ans, sum - (beans[i] * 1L * (len - i)));

            return ans;
            //https://jooncco.com/leetcode-2171/
            //key idea: beansToRemove = totalBeans - beans[i]*(n-i)
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
