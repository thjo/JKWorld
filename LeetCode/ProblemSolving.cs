using LeetCode.DataStructures;
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
            int numOfOne = 0;
            int numOfZero = 0; 

            foreach(int n in data)
            {
                if (n == 0)
                    numOfZero++;
                else
                    numOfOne++;
            }
            if (numOfOne <= 1 || numOfZero <= 1)
                return 0;

            int l = 0, r = 0;
            int currSeenOne = 0;
            int maxSeenOne = 0;
            while(r < data.Length)
            {
                if (data[r] == 1)
                    currSeenOne++;

                if (r - l + 1 > numOfOne)
                {
                    if (data[l] == 1)
                        currSeenOne--;
                    l++;
                }
                maxSeenOne = Math.Max(maxSeenOne, currSeenOne);
                r++;
            }
            return numOfOne - maxSeenOne;
        }




        public int OpenLock(string[] deadends, string target)
        {
            HashSet<string> deadDic = new HashSet<string>();
            foreach (string end in deadends)
            {
                if (deadDic.Contains(end) == false)
                    deadDic.Add(end);
            }

            HashSet<string> seen = new HashSet<string>();
            Queue<KeyInfo> keys = new Queue<KeyInfo>();
            KeyInfo defKey = new KeyInfo(0, "0000");
            keys.Enqueue(defKey);
            seen.Add(defKey.Key);
            while (keys.Count > 0)
            {
                KeyInfo key = keys.Dequeue();
                if (key.Key == target)
                    return key.Depth;
                else if (IsDeadEnd(deadDic, key.Key) == false)
                {
                    for (int pos = 0; pos < 4; pos++)
                    {
                        String buffKey = NewKey(pos, key.Key, true);
                        if (seen.Contains(buffKey) == false)
                        {
                            keys.Enqueue(new KeyInfo(key.Depth + 1, buffKey));
                            seen.Add(buffKey);
                        }
                        buffKey = NewKey(pos, key.Key, false);
                        if (seen.Contains(buffKey) == false)
                        {
                            keys.Enqueue(new KeyInfo(key.Depth + 1, buffKey));
                            seen.Add(buffKey);
                        }
                    }
                }
            }

            return - 1;
        }
        private string NewKey(int pos, string currKey, bool increased)
        {
            int posKey = int.Parse(currKey.Substring(pos, 1));
            if (increased)
                posKey = (posKey + 1) % 10;
            else
                posKey = (posKey - 1) < 0 ? 9 : posKey;
            return pos == 0 ? posKey.ToString() + currKey.Substring(pos + 1) : currKey.Substring(0, pos+1)+ posKey.ToString() + currKey.Substring(pos + 1);
        }
        private bool IsDeadEnd(HashSet<string> deadDic, string key)
        {
            return deadDic.Contains(key);
        }
        public class KeyInfo
        {
            public int Depth;
            public string Key;
            public KeyInfo(int depth, string key)
            {
                Depth = depth;
                Key = key;
            }
        }


        /// <summary>
        /// 1642. Furthest Building You Can Reach
        /// https://leetcode.com/problems/furthest-building-you-can-reach/
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="bricks"></param>
        /// <param name="ladders"></param>
        /// <returns></returns>
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            THJOMinMaxHeap minDic = new THJOMinMaxHeap(heights.Length, true);
            for (int i = 0; i < heights.Length - 1; i++)
            {
                int diff = heights[i + 1] - heights[i];
                if (diff > 0)
                    minDic.Add(diff);

                if (minDic.Size() > ladders)
                {
                    if (minDic.Peek() > bricks)
                        return i;
                    else
                        bricks -= minDic.Poll();
                }
            }
            return heights.Length - 1;
        }
        public int FurthestBuildingI(int[] heights, int bricks, int ladders)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();
            return FurthestBuildingR(heights, 0, bricks, ladders, dp);

            Random ranNum = new Random();
            
        }
        private int FurthestBuildingR(int[] heights, int startIdx, int bricks, int ladders, Dictionary<string, int> dp)
        {
            int furthVal = startIdx;
            if (startIdx >= heights.Length - 1)
                return furthVal;
            string key = string.Format("{0}_{1}", bricks, ladders);
            if (dp.ContainsKey(key))
                return dp[key];
            int diff = heights[startIdx + 1] - heights[startIdx];
            if (diff > 0)
            {
                if (bricks >= diff)
                    furthVal = Math.Max(furthVal, FurthestBuildingR(heights, startIdx + 1, bricks - diff, ladders, dp));
                if (ladders > 0)
                    furthVal = Math.Max(furthVal, FurthestBuildingR(heights, startIdx + 1, bricks, ladders - 1, dp));
            }
            else
            {
                furthVal = FurthestBuildingR(heights, startIdx + 1, bricks, ladders, dp);
            }
            if (dp.ContainsKey(key) == false)
                dp.Add(key, furthVal);

            return furthVal;

        }


        /// <summary>
        /// 215. Kth Largest Element in an Array
        /// https://leetcode.com/problems/kth-largest-element-in-an-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            int n = nums.Length;
            return QuickSelect(nums, 0, n - 1, n - k);
        }
        private int QuickSelect(int[] nums, int left, int right, int kSmallest)
        {
            if (left == right)
                return nums[left];

            Random ranNum = new Random();
            int pivot = left + (ranNum.Next() % (right - left));
            pivot = Partition(nums, left, right, pivot);
            if (kSmallest == pivot)
                return nums[kSmallest];
            else if (kSmallest < pivot)
                return QuickSelect(nums, left, pivot - 1, kSmallest);
            else
                return QuickSelect(nums, pivot + 1, right, kSmallest);
        }
        private int Partition(int[] nums, int left, int right, int pivot)
        {
            int pivotVal = nums[pivot];
            Swap(pivot, right, nums);
            int ansIdx = left;

            for (int i = left; i <= right; i++)
            {
                if (nums[i] < pivotVal)
                {
                    Swap(ansIdx, i, nums);
                    ansIdx++;
                }
            }
            Swap(ansIdx, right, nums);
            return ansIdx;
        }
        private void Swap(int a, int b, int[] nums)
        {
            int tmp = nums[a];
            nums[a] = nums[b];
            nums[b] = tmp;
        }


        /// <summary>
        /// 1705. Maximum Number of Eaten Apples
        /// https://leetcode.com/problems/maximum-number-of-eaten-apples/
        /// </summary>
        /// <param name="apples"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public int EatenApples(int[] apples, int[] days)
        {
            int d = 1;
            int numOfEatenApps = 0;
            //apples, days
            PriorityQueue<int, int> minQ = new PriorityQueue<int, int>();
            for (int i = 0; i < apples.Length; i++)
            {
                minQ.Enqueue(apples[i], (d + days[i]-1));
                while (minQ.TryDequeue(out int apple, out int day))
                {
                    if (day >= d && apple > 0)
                    {
                        apple--;
                        if (day > d && apple > 0)
                            minQ.Enqueue(apple, day);
                        numOfEatenApps++;
                        break;
                    }
                }

                d++;
            }
            //rest of them.
            while (minQ.Count > 0)
            {
                while (minQ.TryDequeue(out int apple, out int day))
                {
                    if (day >= d && apple > 0)
                    {
                        apple--;
                        if (day > d && apple > 0)
                            minQ.Enqueue(apple, day);
                        numOfEatenApps++;
                        break;
                    }
                }

                d++;
            }

            return numOfEatenApps;
        }



        public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
        {
            IList<int> ans = new List<int>();
            CSort(slots1, 1);
            CSort(slots2, 1);
            int n1 = slots1.Length, n2 = slots2.Length; ;
            int idx1 = 0, idx2 = 0;
            while (idx1 < n1 && idx2 < n2)
            {
                int left = Math.Max(slots1[idx1][0], slots2[idx2][0]);
                int right = Math.Min(slots1[idx1][1], slots2[idx2][1]);

                if (right - left >= duration)
                {
                    ans.Add(left);
                    ans.Add(left + duration);
                    return ans;
                }

                if (slots1[idx1][1] > slots2[idx2][1])
                    idx2++;
                else
                    idx1++;
            }
            return ans;
        }
        private static void CSort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }



        /// <summary>
        /// /1465. Maximum Area of a Piece of Cake After Horizontal and Vertical Cuts
        /// https://leetcode.com/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts/
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        /// <param name="horizontalCuts"></param>
        /// <param name="verticalCuts"></param>
        /// <returns></returns>
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            int mod = 1000000007;
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            long maxH = horizontalCuts[0] - 0;
            long maxW = verticalCuts[0] - 0;
            for (int i = 1; i < horizontalCuts.Length; i++)
            {
                if (h < horizontalCuts[i])
                    break;
                int height = Math.Min(h, horizontalCuts[i]);
                maxH = Math.Max(height - horizontalCuts[i - 1], maxH);
            }
            if (h > horizontalCuts[horizontalCuts.Length - 1])
                maxH = Math.Max(h - horizontalCuts[horizontalCuts.Length - 1], maxH);
            for (int i = 1; i < verticalCuts.Length; i++)
            {
                if (w < verticalCuts[i])
                    break;
                int width = Math.Min(w, verticalCuts[i]);
                maxW = Math.Max(verticalCuts[i] - verticalCuts[i - 1], maxW);
            }
            if (w > verticalCuts[verticalCuts.Length - 1])
                maxW = Math.Max(w - verticalCuts[verticalCuts.Length - 1], maxW);
            return (int)((maxH * maxW) % mod);
        }


        /// <summary>
        /// 299. Bulls and Cows
        /// https://leetcode.com/problems/bulls-and-cows/
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string GetHint(string secret, string guess)
        {
            int[] keys = new int[10];
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                char s = secret[i];
                char g = guess[i];
                if (s == g)
                {
                    bulls++;
                }
                else
                {
                    if (keys[s - '0'] < 0)
                        cows++;
                    if (keys[g - '0'] > 0)
                        cows++;

                    keys[s - '0']++;
                    keys[g - '0']--;
                }
            }

            return string.Format("{0}A{1}B", bulls, cows);
        }



        public string DecodeString(string s)
        {
            #region | Using Stack | 

            int i = 0;
            Stack<char> decoder = new Stack<char>();
            while (i < s.Length)
            {
                if (s[i] == ']')
                {
                    List<char> decodeStr = new List<char>();
                    while (decoder.Peek() != '[')
                        decodeStr.Add(decoder.Pop());

                    //pop '['
                    decoder.Pop();

                    //Get a number
                    int b = 1;
                    int k = 0;
                    while (decoder.Count > 0
                          && Char.IsDigit(decoder.Peek()))
                    {
                        k = k + (decoder.Pop() - '0') * b;
                        b *= 10;
                    }
                    //decoded string
                    while (k > 0)
                    {
                        for (int j = decodeStr.Count - 1; j >= 0; j--)
                            decoder.Push(decodeStr[j]);
                        k--;
                    }
                }
                else
                    decoder.Push(s[i]);
                i++;
            } //End while

            string plainText = "";
            while (decoder.Count > 0)
            {
                plainText = decoder.Pop() + plainText;
            }

            return plainText;

            #endregion
        }

        /// <summary>
        /// 97. Interleaving String
        /// https://leetcode.com/problems/interleaving-string/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;

            bool[] dp = new bool[s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[j] = true;
                    }
                    else if (i == 0)
                    {
                        dp[j] = dp[j - 1] && s2[j - 1] == s3[i + j - 1];
                    }
                    else if (j == 0)
                    {
                        dp[j] = dp[j] && s1[i - 1] == s3[i + j - 1];
                    }
                    else
                    {
                        dp[j] = (dp[j] && s1[i - 1] == s3[i + j - 1]) || (dp[j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                }
            }
            return dp[s2.Length];
        }
        public bool IsInterleave1(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;
            int[][] dp = new int[s1.Length][];
            for (int i = 0; i < s1.Length; i++)
            {
                dp[i] = new int[s2.Length];
                for (int j = 0; j < s2.Length; j++)
                    dp[i][j] = 0;
            }
            return IsInterleaveR(s1, s2, s3, 0, 0, 0, dp);
        }
        private bool IsInterleaveR(string s1, string s2, string s3, int iS1, int iS2, int iS3, int[][] dp)
        {
            if (iS1 == s1.Length && iS2 == s2.Length && iS3 == s3.Length)
                return true;
            else if (iS1 == s1.Length)
                return s2.Substring(iS2).Equals(s3.Substring(iS3));
            else if (iS2 == s2.Length)
                return s1.Substring(iS1).Equals(s3.Substring(iS3));
            if (dp[iS1][iS2] > 0)
                return dp[iS1][iS2] == 1 ? true : false;

            bool ans = false;
            if ((s1[iS1] == s3[iS3] && IsInterleaveR(s1, s2, s3, iS1 + 1, iS2, iS3 + 1, dp)) || (s2[iS2] == s3[iS3] && IsInterleaveR(s1, s2, s3, iS1, iS2 + 1, iS3 + 1, dp)))
                ans = true;

            dp[iS1][iS2] = ans == true ? 1 : 2;
            return ans;
        }


        /// <summary>
        /// 1696. Jump Game VI
        /// https://leetcode.com/problems/jump-game-vi/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxResult(int[] nums, int k)
        {
            //Bruce Force
            //dp[i] = Max(dp[i-k], ..., dp[i-1]) + nums[i]
            //int[] dp = new int[nums.Length];
            //dp[0] = nums[0];

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    int maxVal = dp[i-1];
            //    for(int j = i - 2; j >= 0 && j >= i - k; j--)
            //        maxVal = Math.Max(maxVal, dp[j]);

            //    dp[i] = maxVal + nums[i];
            //}
            //return dp[dp.Length-1];

            //value, index
            Dictionary<int, Queue<int>> dic = new Dictionary<int, Queue<int>>();
            //index, value
            PriorityQueue<int, int> pQ = new PriorityQueue<int, int>(new OrdercComparer(true));
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            Queue<int> tmp = new Queue<int>();
            tmp.Enqueue(0);
            dic.Add(nums[0], tmp);
            pQ.Enqueue(0, nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                int idx, maxVal;
                pQ.TryPeek(out idx, out maxVal);
                dp[i] = maxVal + nums[i];
                if (dic.ContainsKey(dp[i]))
                    dic[dp[i]].Enqueue(i);
                else
                {
                    Queue<int> buff = new Queue<int>();
                    buff.Enqueue(i);
                    dic.Add(dp[i], buff);
                }
                pQ.Enqueue(i, dp[i]);

                while (pQ.Count > k && pQ.TryPeek(out idx, out maxVal)
                    && dic.ContainsKey(maxVal) && dic[maxVal].Peek() <= i - k)
                {
                    dic[maxVal].Dequeue();
                    if (dic[maxVal].Count == 0)
                        dic.Remove(maxVal);
                    pQ.Dequeue();
                }
            }
            return dp[dp.Length - 1];
        }


        /// <summary>
        /// 542. 01 Matrix
        /// https://leetcode.com/problems/01-matrix/
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[][] UpdateMatrix(int[][] mat)
        {
            if (mat == null || mat.Length < 1)
                return null;

            int lenRows = mat.Length;
            int lenCols = mat[0].Length;

            int[][] dist = new int[lenRows][];
            for (int row = 0; row < lenRows; row++)
            {
                dist[row] = new int[lenCols];
                for (int col = 0; col < lenCols; col++)
                    dist[row][col] = int.MaxValue - 1;
            }

            //Scan for Left and Top
            for (int row = 0; row < lenRows; row++)
            {
                for (int col = 0; col < lenCols; col++)
                {
                    if (mat[row][col] == 0)
                        dist[row][col] = 0;
                    else
                    {
                        if (row > 0)
                            dist[row][col] = Math.Min(dist[row][col], dist[row - 1][col] + 1);
                        if (col > 0)
                            dist[row][col] = Math.Min(dist[row][col], dist[row][col - 1] + 1);

                    }
                }
            }

            //Scan for Right and Bottom
            for (int row = lenRows - 1; row >= 0; row--)
            {
                for (int col = lenCols - 1; col >= 0; col--)
                {
                    if (row + 1 < lenRows)
                        dist[row][col] = Math.Min(dist[row][col], dist[row + 1][col] + 1);
                    if (col + 1 < lenCols)
                        dist[row][col] = Math.Min(dist[row][col], dist[row][col + 1] + 1);
                }
            }

            return dist;
        }


        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;

            //char, index
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int startIdx = 0;
            int longestLen = 1;
            dic.Add(s[0], 0);
            for (int i = 1; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    int dupPos = dic[s[i]];
                    while (startIdx <= dupPos)
                        dic.Remove(s[startIdx++]);
                }

                dic.Add(s[i], i);
                longestLen = Math.Max(longestLen, dic.Count);
            }
            return longestLen;
        }

        /// <summary>
        /// 567. Permutation in String
        /// https://leetcode.com/problems/permutation-in-string/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckInclusion(string s1, string s2)
        {
            //Length of string p and s
            int s1Len = s1.Length;
            int s2Len = s2.Length;

            //Return empty result if any of the condition
            if (s2.Length == 0 || s1Len > s2Len)
                return false;

            int[] s1Arr = new int[26];
            int[] s2Arr = new int[26];

            for (int i = 0; i < s1Len; i++)
            {
                s1Arr[s1[i] - 'a']++;
                s2Arr[s2[i] - 'a']++;
            }

            for (int i = 0; i < s2Len - s1Len; i++)
            {
                if (isPermutation(s1Arr, s2Arr))
                    return true;

                s2Arr[s2[i] - 'a']--;
                s2Arr[s2[i + s1Len] - 'a']++;
            }

            if (isPermutation(s1Arr, s2Arr))
                return true;

            return false;
        }
        private bool isPermutation(int[] s1Arr, int[] s2Arr)
        {
            for (int i = 0; i < s1Arr.Length; i++)
            {
                if (s1Arr[i] != s2Arr[i])
                    return false;
            }

            return true;
        }



        /// <summary>
        /// 994. Rotting Oranges
        /// https://leetcode.com/problems/rotting-oranges/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            int[][] directions = new int[4][];
            directions[0] = new int[2] { 1, 0 };
            directions[1] = new int[2] { 0, 1 };
            directions[2] = new int[2] { -1, 0 };
            directions[3] = new int[2] { 0, -1 };
            int rowLen = grid.Length;
            int colLen = grid[0].Length;

            Queue<int[]> rottenOrangs = new Queue<int[]>();
            int freshOranges = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        List<int> loc = new List<int>();
                        loc.Add(r); loc.Add(c);
                        rottenOrangs.Enqueue(new int[] { r, c, 0 });
                    }
                    else if (grid[r][c] == 1)
                        freshOranges++;
                }
            }

            int numfMins = 0;
            while (rottenOrangs.Count > 0)
            {
                var map = rottenOrangs.Dequeue();
                //numfMins = Math.Max(map[2], numfMins);
                numfMins = map[2];
                for (int i = 0; i < directions.Length; i++)
                {
                    int x = map[0] + directions[i][0];
                    int y = map[1] + directions[i][1];
                    if (x >= 0 && x < rowLen && y >= 0 && y < colLen && grid[x][y] == 1)
                    {
                        grid[x][y] = 2;
                        freshOranges--;
                        rottenOrangs.Enqueue(new int[] { x, y, (map[2] + 1) });
                    }
                }
            }

            return freshOranges > 0 ? -1 : numfMins;
        }

    }

}

