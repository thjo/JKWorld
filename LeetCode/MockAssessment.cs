using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MockAssessment
    {
        #region | Online Assessment | 

        public bool IsOneBitCharacter(int[] bits)
        {
            int i = 0;
            int lastChar = -1;
            while( i < bits.Length)
            {
                if(bits[i] == 0)
                    lastChar = 1;
                else
                    lastChar = 2;

                i += lastChar;
            }

            return lastChar == 1 ? true : false;
        }

        #endregion

        #region | Online Assessment - 11/28/2021 | 

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (dp.ContainsKey(target - nums[i]))
                    return new int[] { dp[target - nums[i]], i };
                else
                {
                    if(dp.ContainsKey(nums[i]) == false)
                        dp.Add(nums[i], i);
                }
            }

            return null;
        }


        /// <summary>
        /// https://leetcode.com/problems/prison-cells-after-n-days/
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] PrisonAfterNDays(int[] cells, int n)
        {
            if (cells == null || cells.Length <= 2)
                return cells;

            Dictionary<string, int> seen = new Dictionary<string, int>();
            int len = cells.Length;
            int currIdx = 1;
            while (currIdx <= n)
            {
                int[] cells2 = new int[len];

                for (int i = 1; i < len - 1; ++i)
                    cells2[i] = cells[i - 1] == cells[i + 1] ? 1 : 0;
                cells = cells2;

                string newCellsStr = ConvertToStr(cells);
                if (seen.ContainsKey(newCellsStr))
                {
                    int mod = n % (currIdx - 1);
                    if (mod == 0) mod = (currIdx - 1);
                    int cnt = 1;
                    foreach (var cell in seen)
                    {
                        if (cnt == mod)
                            return ConvertToIntArray(cell.Key);
                        cnt++;
                    }
                    return null;
                }
                else
                    seen.Add(newCellsStr, currIdx);
                currIdx++;
            }
            return cells;
        }
        private string ConvertToStr(int[] cells)
        {
            string ret = "";
            foreach (var n in cells)
                ret += n.ToString();

            return ret;
        }
        private int[] ConvertToIntArray(string cells)
        {
            int[] ret = new int[cells.Length];

            for (int i = 0; i < cells.Length; i++)
                ret[i] = int.Parse(cells[i].ToString());

            return ret;
        }

        #endregion

        #region | Online Assessment - 11/30/2021 | 

        public string FractionToDecimal(int numerator, int denominator)
        {
            string fraTotal = "";
            bool isNegative = false;

            if ( (numerator < 0 && denominator > 0) 
                || (numerator > 0 && denominator < 0))
            {
                isNegative = true;
            }

            long numer = numerator;
            long denom = denominator;
            if(numer < 0)
                numer = Math.Abs(numer);
            if(denom < 0)
                denom = Math.Abs(denom);
            long rest = (numer % denom);
            long num = (numer / denom);
            if (isNegative)
                fraTotal += "-";
            fraTotal += num.ToString();
            
            if (rest != 0)
            {
                Dictionary<long, int> dpRest = new Dictionary<long, int>();
                int idxPosition = 0;
                dpRest.Add(rest, idxPosition++);
                fraTotal += ".";
                string restStr = "";
                while (rest != 0)
                {
                    numer = rest * 10;
                    rest =  (numer % denom);
                    num =  (numer / denom);
                    restStr += num.ToString();

                    if (dpRest.ContainsKey(rest))
                    {
                        int posion = dpRest[rest];
                        restStr = restStr.Substring(0, posion) + "(" + restStr.Substring(0 + posion);
                        restStr += ")";
                        break;
                    }
                    else
                        dpRest.Add(rest, idxPosition++);
                }
                fraTotal += restStr;
            }

            return fraTotal;
        }


        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<int[]> intersections = new List<int[]>();
            if (firstList == null || secondList == null
                && firstList.Length < 1 || secondList.Length < 1)
                return intersections.ToArray();

            int firstIdx = 0, secIdx = 0;
            int start = -1, close = -1;
            while ( firstIdx < firstList.Length && secIdx < secondList.Length)
            {
                if (firstList[firstIdx][0] > secondList[secIdx][0])
                {
                    start = firstList[firstIdx][0];
                    if (start > secondList[secIdx][1])
                        secIdx++;
                    else
                    {
                        if (firstList[firstIdx][1] < secondList[secIdx][1])
                        {
                            close = firstList[firstIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = secondList[secIdx][1];
                            firstIdx++;
                        }
                        else
                        {
                            close = secondList[secIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = firstList[firstIdx][1];
                            secIdx++;
                        }
                    }
                }
                else
                {
                    start = secondList[secIdx][0];
                    if (start > firstList[firstIdx][1])
                        firstIdx++;
                    else
                    {
                        if (firstList[firstIdx][1] < secondList[secIdx][1])
                        {
                            close = firstList[firstIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = secondList[secIdx][1];
                            firstIdx++;
                        }
                        else
                        {
                            close = secondList[secIdx][1];
                            if (close >= start)
                            {
                                intersections.Add(new int[] { start, close });
                                start = -1; close = -1;
                            }
                            start = firstList[firstIdx][1];
                            secIdx++;
                        }
                    }
                }
            }


            return intersections.ToArray();
        }



        #endregion

        #region | | 

        /// <summary>
        /// 1094. Car Pooling
        /// https://leetcode.com/problems/car-pooling/
        /// </summary>
        /// <param name="trips"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public bool CarPooling(int[][] trips, int capacity)
        {
            int[] timestamp = new int[1001];
            foreach(var t in trips)
            {
                timestamp[t[1]] += t[0];
                timestamp[t[2]] -= t[0];
            }

            foreach(int p in timestamp)
            {
                capacity -= p;
                if (capacity < 0)
                    return false;
            }
            
            return true;
        }



        public string ReverseOnlyLetters(string s)
        {
            char[] reverseStr = new char[s.Length];

            int l = 0, r = s.Length - 1;
            while(l < s.Length)
            {
                if (char.IsLetter(s[l]))
                {
                    while(char.IsLetter(s[r]) == false || reverseStr[r] != '\0')
                        r--;
                    reverseStr[r--] = s[l];
                }
                else
                {
                    reverseStr[l] = s[l];
                }
                l++;
            }

            return new String(reverseStr);
        }

        /// <summary>
        /// https://massivealgorithms.blogspot.com/2019/11/leetcode-1223-dice-roll-simulation.html
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int DiagonalSum(int[][] mat)
        {
            int n = mat.Length;
            if (n == 1)
                return mat[0][0];

            int sumPri = 0, sumSec = 0; 

            for(int r = 0; r < n; r++)
            {
                sumPri += mat[r][r];
                sumSec += mat[r][n - 1 - r];
            }

            if( n % 2 == 0)
                return sumPri + sumSec;
            else
                return sumPri + sumSec - mat[n/2][n/2];
        }


        public int dieSimulator(int n, int[] rollMax)
        {
            long divisor = (long)Math.Pow(10, 9) + 7;
            long[][] dp = new long[n][];
            for (int i = 0; i < n; i++)
                dp[i] = new long[7];
            for (int i = 0; i < 6; i++)
            {
                dp[0][i] = 1;
            }
            dp[0][6] = 6;
            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int j = 0; j < 6; j++)
                {
                    dp[i][j] = dp[i - 1][6];
                    if (i - rollMax[j] < 0)
                    {
                        sum = (sum + dp[i][j]) % divisor;
                    }
                    else
                    {
                        if (i - rollMax[j] - 1 >= 0) dp[i][j] = (dp[i][j] - (dp[i - rollMax[j] - 1][6] - dp[i - rollMax[j] - 1][j])) % divisor + divisor;
                        else dp[i][j] = (dp[i][j] - 1) % divisor;
                        sum = (sum + dp[i][j]) % divisor;
                    }

                }
                dp[i][6] = sum;
            }
            return (int)(dp[n - 1][6]);
        }



        /// <summary>
        /// 11. Container With Most Water
        /// https://leetcode.com/problems/container-with-most-water/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int len = height.Length;
            int l = 0, r = len - 1;
            int area = 0;

            while(l < r)
            {
                area = Math.Max(area, Math.Min(height[l], height[r]) * (r - l));

                if (height[l] > height[r])
                    r--;
                else
                    l++;
            }

            return area;
        }



        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode ptr1 = headA;
            ListNode ptr2 = headB;
            if (ptr1 == null || ptr2 == null)
                return null;
            else if (ptr1 == ptr2)
                    return ptr1;

            while ( ptr1 != ptr2)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;

                if (ptr1 == ptr2)
                    return ptr1;

                if (ptr1 == null)
                    ptr1 = headA;
                if (ptr2 == null)
                    ptr2 = headB;
            }
            return ptr1;
        }


        /// <summary>
        /// 223. Rectangle Area
        /// https://leetcode.com/problems/rectangle-area/
        /// </summary>
        /// <param name="ax1"></param>
        /// <param name="ay1"></param>
        /// <param name="ax2"></param>
        /// <param name="ay2"></param>
        /// <param name="bx1"></param>
        /// <param name="by1"></param>
        /// <param name="bx2"></param>
        /// <param name="by2"></param>
        /// <returns></returns>
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            int area = 0;

            //Two rectangles
            area = (ax2 - ax1) * (ay2 - ay1) + (bx2 - bx1) * (by2 - by1);

            //overrap area
            if (ax1 > bx2 || ax2 < bx1 || ay1 > by2 || ay2 < by1)
                return area;
            else
            {
                
                return area - ((Math.Min(ay2, by2) - Math.Max(ay1, by1)) * (Math.Min(ax2, bx2) - Math.Max(ax1, bx1)));
            }
        }


        public int CoinChange(int[] coins, int amount)
        {
            //if (amount == 0)
            //    return 0;

            //Dictionary<int, int> dp = new Dictionary<int, int>();
            //int retVal = CoinChangeTopDown(coins, amount, dp, amount);
            //if (retVal > amount)
            //    return -1;
            //else
            //    return retVal;

            //Bottom-Up
            int[] map = new int[amount + 1];
            map[0] = 0;
            //for (int i = 1; i <= amount; i++)
            //    map[i] = amount + 1;

            for (int i = 1; i <= amount; i++)
            {
                int min = amount + 1;
                for (int c = 0; c < coins.Length; c++)
                {
                    if(coins[c] <= i)
                    {
                        min = Math.Min((1 + map[i - coins[c]]), min);
                    }
                }
                map[i] = min;
            }
            return map[amount] == (amount + 1) ? -1 : map[amount];
        }
        private int CoinChangeTopDown(int[] coins, int amount, Dictionary<int, int> dp, int originalAmt)
        {
            if (amount < 0)
                return originalAmt + 1;
            else if (amount == 0)
                return 0;

            if (dp.ContainsKey(amount))
                return dp[amount];
            else
            {
                int min = originalAmt + 1;
                foreach (int coin in coins)
                {
                    if (coin <= amount)
                        min = Math.Min(1 + CoinChangeTopDown(coins, amount - coin, dp, originalAmt), min);
                }
                dp.Add(amount, min);
                return min;
            }
        }


        /// <summary>
        /// 518. Coin Change 2
        /// https://leetcode.com/problems/coin-change-2/
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            if (coins == null || coins.Length <= 0)
                return 0;
            else if (amount == 0)
                return 1;
            int[][] map = new int[coins.Length + 1][];
            for (int c = 0; c <= coins.Length; c++)
                map[c] = new int[amount + 1];
            map[0][0] = 1;
            for (int c = 1; c <= coins.Length; c++)
            {
                map[c][0] = 1;
                for (int a = 1; a <= amount; a++)
                {
                    map[c][a] = map[c - 1][a] + ((a - coins[c - 1]) < 0 ? 0 : map[c][a - coins[c - 1]]);
                }
            }

            return map[coins.Length][amount];
        }

        #endregion

        /// <summary>
        /// 1169. Invalid Transactions
        /// https://leetcode.com/problems/invalid-transactions/
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public IList<string> InvalidTransactions(string[] transactions)
        {
            return null;
        }

        /// <summary>
        /// 1160. Find Words That Can Be Formed by Characters
        /// https://leetcode.com/problems/find-words-that-can-be-formed-by-characters/
        /// </summary>
        /// <param name="words"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public int CountCharacters(string[] words, string chars)
        {
            int totalLen = 0;
            Dictionary<char, int> charSets = new Dictionary<char, int>();
            foreach (char c in chars)
            {
                if (charSets.ContainsKey(c))
                    charSets[c]++;
                else
                    charSets.Add(c, 1);
            }

            foreach(string word in words)
            {
                if (CanbeFormed(word, charSets))
                    totalLen += word.Length;
            }

            return totalLen;
        }
        private bool CanbeFormed(string word, Dictionary<char, int> charSets)
        {
            Dictionary<char, int> buffWords = new Dictionary<char, int>();
            foreach(char c in word)
            {
                if (buffWords.ContainsKey(c))
                    buffWords[c]++;
                else
                    buffWords.Add(c, 1);
            }

            foreach(var w in buffWords)
            {
                if (charSets.ContainsKey(w.Key))
                {
                    if (charSets[w.Key] < w.Value)
                        return false;
                }
                else
                    return false;
            }

            return true;
        }


        private readonly int MOD = 1000000007;
        private Dictionary<String, int> mem = new Dictionary<string, int>();

        /// <summary>
        /// 1155. Number of Dice Rolls With Target Sum
        /// https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/
        /// </summary>
        /// <param name="d"></param>
        /// <param name="f"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int NumRollsToTarget(int d, int f, int target)
        {
            if (d == 0 && target == 0)
                return 1;

            if (d <= 0 || target <= 0)
                return 0;

            String key = d + "_" + target;
            if (mem.ContainsKey(key))
                return mem[key];

            int ans = 0;
            for (int i = 1; i <= f && i <= target; i++)
            {
                ans = (ans + NumRollsToTarget(d - 1, f, target - i)) % MOD;
            }
            mem.Add(key, ans);
            return ans;
        }

        /// <summary>
        /// 13. Roman to Integer
        /// https://leetcode.com/problems/roman-to-integer/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            int total = 0;
            if (string.IsNullOrWhiteSpace(s))
                return total;

            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);
            int i = 0;
            while(i < s.Length)
            {
                if( i < s.Length - 1)
                {
                    if( map[s[i]] >= map[s[i + 1]])
                    {
                        //normal number
                        total += map[s[i]];
                        i += 1;
                    }
                    else
                    {
                        //for four
                        total += (map[s[i+1]] - map[s[i]]);
                        i += 2;
                    }
                }
                else
                {
                    total += map[s[i]];
                    i += 1;
                }
            }

            return total;
        }

        /// <summary>
        /// Add Two Numbers
        /// https://leetcode.com/problems/add-two-numbers/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(-1);
            ListNode currNode = head;
            int exraNum = 0;
            int total = 0;
            while (l1 != null || l2 != null)
            {
                if (l1 != null && l2 != null)
                {
                    total = l1.val + l2.val + exraNum;
                    if (total >= 10)
                        exraNum = 1;
                }
                else
                {
                    total = l1 != null ? l1.val : l2.val;
                    if (exraNum == 1)
                    {
                        total += 1;
                        exraNum = 0;
                    }
                }

                //Add a node
                ListNode node = new ListNode(total % 10);
                currNode.next = node;
                currNode = node;

                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }

            if(exraNum == 1)
            {
                ListNode node = new ListNode(1);
                currNode.next = node;
            }

            return head.next;
        }


    }
    public class CTransaction
    {
        public string Name { get; set; }

        public int Time { get; set; }

        public int Amount { get; set; }

        public string City { get; set; }

        public string OriginTran { get; set; }
        public CTransaction(string name, string time, string amount, string city, string originTran)
        {
            Name = name;
            Time = int.Parse(time);
            Amount = int.Parse(amount);
            City = city;
            OriginTran = originTran;
        }
    }
}
