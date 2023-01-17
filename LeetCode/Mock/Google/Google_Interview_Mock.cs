using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Mock.Google
{
    public class Google_Interview_Mock
    {
        #region | Online Interview - 2022/11/03 | 

        /// <summary>
        /// 1021. Remove Outermost Parentheses
        /// https://leetcode.com/problems/remove-outermost-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveOuterParentheses(string s)
        {
            Stack<int> buff = new Stack<int>();
            List<int[]> sets = new List<int[]>();
            buff.Push(0);   //push an index
            for (int i = 1; i < s.Length; i++)
            {
                int startIdx = -1;
                if (s[i] == '(')
                    buff.Push(i);
                else
                    startIdx = buff.Pop();

                if (buff.Count == 0)
                {
                    //one set
                    sets.Add(new int[] { startIdx, i });
                }
            }

            StringBuilder sbAns = new StringBuilder();
            foreach(var p in sets)
            {
                if(p[1] - p[0] - 1 > 0)
                    sbAns.Append(s.Substring(p[0] + 1, p[1] - p[0] - 1));
            }

            return sbAns.ToString();
        }


        /// <summary>
        /// 1025. Divisor Game
        /// https://leetcode.com/problems/divisor-game/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool DivisorGameI(int n)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i] = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    dp[i][j] = -1;
                }
            }

            return DivisorGameIR(n, 1, dp) == 1;
        }
        private int DivisorGameIR(int n, int player, int[][] dp)
        {
            if (n == 1 || n == 3)
                return 0;
            else if (n == 2)
                return 1;

            if (dp[n][player] != -1)
                return dp[n][player];

            //If currently it's A's turn, initialize the ans to 0
            int ans = player == 1 ? 0 : 1;

            //Traversing across all the divisor of n which are less than n
            for (int i = 1; i * i <= n; i++)
            {
                //Check if current value of i is a divisor of n
                if (n % i == 0)
                {
                    if (player == 1)
                        ans |= DivisorGameIR(n - i, 0, dp);
                    else
                        ans &= DivisorGameIR(n - i, 1, dp);
                }
            }

            return dp[n][player] = ans;
        }

        public bool DivisorGame(int n)
        {
            bool?[] dp = new bool?[n + 1];
            for(int i = 0; i < dp.Length; i++)
            {
                dp[i] = null;
            }

            return DivisorGameR(n, dp);
        }
        public bool DivisorGameR(int n, bool?[] dp)
        {
            if (n == 1) return false;
            if (dp[n] != null) return dp[n].Value;

            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0 && DivisorGameR(n - i, dp) == false)
                {
                    dp[n] = true;
                    return true;
                }
                if (n / i != n && n % (n / i) == 0 && DivisorGameR(n - n / i, dp) == false) { 
                    dp[n] = true;
                    return true;
                }
            }

            dp[n] = false;
            return false;
        }

        #endregion

        #region | Online Interview - 2022/11/05 | 

        /// <summary>
        /// 162. Find Peak Element
        /// https://leetcode.com/problems/find-peak-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElementI(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return i;
            }
            return nums.Length - 1;
        }
        public int FindPeakElement(int[] nums)
        {
            return FindPeakElementB(nums, 0, nums.Length - 1);
        }
        private int FindPeakElementB(int[] nums, int l, int r)
        {
            if (l >= r)
                return l;

            int mid = (l + r) / 2;
            if (nums[mid] > nums[mid + 1])
                return FindPeakElementB(nums, l, mid);
            return FindPeakElementB(nums, mid + 1, r);
        }


        /// <summary>
        /// 459. Repeated Substring Pattern
        /// https://leetcode.com/problems/repeated-substring-pattern/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool RepeatedSubstringPattern(string s)
        {
            int n = s.Length;
            if (n < 2) return false;
            else if (n == 2) return s[0] == s[1];

            for (int i = n / 2; i > 0; i--)
            {
                if (n % i == 0 && s.Substring(i) == s.Substring(0, s.Length - i))
                    return true;
            }

            return false;
        }

        #endregion

        #region | Online Interview - 2022/11/09 | 

        /// <summary>
        /// 1237. Find Positive Integer Solution for a Given Equation
        /// https://leetcode.com/problems/find-positive-integer-solution-for-a-given-equation/
        /// </summary>
        /// <param name="customfunction"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            int x = 1, y = z;
            IList<IList<int>> ans = new List<IList<int>>();
            while (x <= y)
            {
                int tmp = customfunction.f(x, y);
                if (tmp == z)
                {
                    IList<int> buff = new List<int>();
                    buff.Add(x);
                    buff.Add(y);
                    ans.Add(buff);
                    if (x != y)
                    {
                        IList<int> buff2 = new List<int>();
                        buff2.Add(y);
                        buff2.Add(x);
                        ans.Add(buff2);
                    }
                }
                else if (tmp > z)
                {
                    y--;
                }
                else
                {
                    x++;
                }
            }

            return ans;
        }
        public class CustomFunction
        {
            public int f(int x, int y)
            {
                return -1;
            }
        }


        /// <summary>
        /// 1466. Reorder Routes to Make All Paths Lead to the City Zero
        /// https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public int MinReorder(int n, int[][] connections)
        {
            return -1;
        }


        #endregion

        #region | Online Interview - 2022/11/12 | 

        /// <summary>
        /// 788. Rotated Digits
        /// https://leetcode.com/problems/rotated-digits/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RotatedDigits(int n)
        {
            int cnt = 0;
            for(int i = 1; i <= n; i++)
            {
                if (IsGoodRotated(i))
                    cnt++;
            }

            return cnt;
        }
        private bool IsGoodRotated(int num)
        {
            bool isGood = false;
            while(num > 0)
            {
                int n = num % 10;
                switch(n)
                {
                    case 0:
                    case 1:
                    case 8:
                        break;
                    case 2:
                    case 5:
                    case 6:
                    case 9:
                        isGood = true;
                        break;
                    default:
                        return false;
                }
                num /= 10;
            }

            return isGood;
        }


        /// <summary>
        /// 849. Maximize Distance to Closest Person
        /// https://leetcode.com/problems/maximize-distance-to-closest-person/
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        public int MaxDistToClosest(int[] seats)
        {
            //1  2  3  4  5  6  7  8  9
            //--------------------------
            //1  0  0  1  0  0  0  0  1

            //left to right
            //0  1  2  0  1  2  3  4  0
            //right to left
            //0  2  1  0  4  3  2  1  0
            //min between 2 values above
            //0  1  1  0  1  2  2  1  0        
            int maxDist = 1;
            int n = seats.Length;
            int[] dp1 = new int[n];
            int[] dp2 = new int[n];
            //left to right
            dp1[0] = seats[0] == 0 ? 1 : 0;
            for (int i = 1; i < n; i++)
            {
                if (seats[i] == 1)
                    dp1[i] = 0;
                else
                {
                    dp1[i] = dp1[i - 1] + 1;
                }
            }
            //right to left
            dp2[n - 1] = seats[n - 1] == 0 ? 1 : 0;
            for (int i = n - 2; i >= 0; i--)
            {
                if (seats[i] == 1)
                    dp2[i] = 0;
                else
                    dp2[i] = dp2[i + 1] + 1;
            }

            //index 0 - take a value from dp2 since this value should be calculated with right side
            maxDist = Math.Max(maxDist, dp2[0]);
            //index n - 1 >> take a value from dp1 since this value should be calculated with left side
            maxDist = Math.Max(maxDist, dp1[n - 1]);
            //take min value between dp1 and dp2 
            for (int i = 1; i < n - 1; i++)
            {
                maxDist = Math.Max(maxDist, Math.Min(dp1[i], dp2[i]));
            }
            return maxDist;
        }

        #endregion

        #region | Online Interview - 2022/11/15 | 

        /// <summary>
        /// 929. Unique Email Addresses
        /// https://leetcode.com/problems/unique-email-addresses/
        /// </summary>
        /// <param name="emails"></param>
        /// <returns></returns>
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> uniqEmails = new HashSet<string>();

            foreach (string email in emails)
            {
                string newEmail = ValidEmails(email);
                if (uniqEmails.Contains(newEmail) == false)
                    uniqEmails.Add(newEmail);
            }

            return uniqEmails.Count;
        }
        private string ValidEmails(string email)
        {
            StringBuilder sb = new StringBuilder();
            bool isIgnored = false;
            for (int i = 0; i < email.Length; i++)
            {
                char c = email[i];
                if (c == '.')
                {
                    continue;
                }
                else if (c == '+')
                {
                    isIgnored = true;
                }
                else if (c == '@')
                {
                    sb.Append(email.Substring(i));
                    break;
                }
                else if (isIgnored == false)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }


        /// <summary>
        /// 904. Fruit Into Baskets
        /// https://leetcode.com/problems/fruit-into-baskets/
        /// </summary>
        /// <param name="fruits"></param>
        /// <returns></returns>
        public int TotalFruit_BruceForce(int[] fruits)
        {
            int n = fruits.Length;
            int maxCnt = 0;
            for(int t = 0; t < n; t++)
            {
                int cnt = TotalFruitCnt(fruits, t);
                maxCnt = Math.Max(maxCnt, cnt);
            }

            return maxCnt;
        }
        private int TotalFruitCnt(int[] fruits, int startIdx)
        {
            int cnt = 1;
            HashSet<int> pickedTypes = new HashSet<int>();
            pickedTypes.Add(fruits[startIdx]);
            for (int i = startIdx+1; i < fruits.Length; i++)
            {
                if (pickedTypes.Contains(fruits[i]) == false)
                {
                    if (pickedTypes.Count >= 2)
                        break;
                    else
                        pickedTypes.Add(fruits[i]);
                }
                cnt++;
            }

            return cnt;
        }

        public int TotalFruit(int[] fruits)
        {
            Dictionary<int,int> addedTypes = new Dictionary<int, int>();
            int maxCnt = 0;
            int cnt = 0;
            int l = 0;
            for (int r = 0; r < fruits.Length; r++)
            {
                if (addedTypes.ContainsKey(fruits[r]) == false 
                    && addedTypes.Count >= 2)
                {
                    maxCnt = Math.Max(maxCnt, cnt);
                    while (addedTypes.Count >= 2)
                    {
                        addedTypes[fruits[l]]--;
                        if (addedTypes[fruits[l]] == 0)
                            addedTypes.Remove(fruits[l]);
                        l++;
                        cnt--;
                    }
                }

                if (addedTypes.ContainsKey(fruits[r]) == false)
                    addedTypes.Add(fruits[r], 0);
                addedTypes[fruits[r]]++;
                cnt++;                
            }

            return Math.Max(maxCnt, cnt);
        }
        #endregion

        #region | Online Interview - 2022/11/16 | 

        /// <summary>
        /// 681. Next Closest Time
        /// https://leetcode.com/problems/next-closest-time/
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string NextClosestTime(string time)
        {
            HashSet<int> digits = new HashSet<int>();
            foreach (char c in time)
            {
                if (c != ':')
                {
                    if (digits.Contains(c - '0') == false)
                        digits.Add(c - '0');
                }
            }

            HashSet<string> times = new HashSet<string>();
            NextClosestTime(digits, "", times);

            string ans = "";
            int diff = int.MaxValue;
            string tmpTime = time.Replace(":", "");
            foreach (string t in times)
            {
                int tmp = NextClosestTimeDiff(tmpTime, t);
                if (tmp < diff)
                {
                    diff = tmp;
                    ans = t.Substring(0, 2) + ":" + t.Substring(2);
                }
            }
            return diff == int.MaxValue ? time : ans;
        }
        private void NextClosestTime(HashSet<int> digits, string currTime, HashSet<string> times)
        {
            if (currTime.Length == 4)
            {
                if (times.Contains(currTime) == false)
                    times.Add(currTime);
                currTime = "";
                return;
            }

            foreach (int d in digits)
            {
                //hour - first digit
                if (currTime.Length == 0
                   && d > 2)
                    continue;
                //hour - second digit
                if (currTime.Length == 1
                   && (currTime[0] == '2' && d > 3))
                    continue;
                //minutes - first digit
                if (currTime.Length == 2
                   && d > 5)
                    continue;
                //minutes - second digit
                ;
                currTime += d.ToString();
                NextClosestTime(digits, currTime, times);
                currTime = currTime.Substring(0, currTime.Length - 1);
            }
        }
        private int NextClosestTimeDiff(string time1, string time2)
        {
            if (int.Parse(time2) == int.Parse(time1))
                return int.MaxValue;
            else if (int.Parse(time2) < int.Parse(time1))
                return 2400 - (int.Parse(time1) - int.Parse(time2));
            else
                return int.Parse(time2) - int.Parse(time1);
        }




        /// <summary>
        /// 683. K Empty Slots
        /// https://leetcode.com/problems/k-empty-slots/
        /// </summary>
        /// <param name="bulbs"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KEmptySlots(int[] bulbs, int k)
        {
            return -1;
        }

        #endregion

        #region | Online Interview - 2022/11/16 | 

        /// <summary>
        /// 482. License Key Formatting
        /// https://leetcode.com/problems/license-key-formatting/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string LicenseKeyFormatting(string s, int k)
        {
            StringBuilder sbAns = new StringBuilder();
            Stack<char> sBuff = new Stack<char>();
            int buffLen = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '-')
                    continue;
                sBuff.Push(char.ToUpper(s[i]));
                buffLen++;
                if (buffLen == k)
                {
                    sBuff.Push('-');
                    buffLen = 0;
                }
            }
            if (sBuff.Count > 0 && sBuff.Peek() == '-')
                sBuff.Pop();
            while(sBuff.Count > 0)
            {
                sbAns.Append(sBuff.Pop());
            }

            return sbAns.ToString();
        }

        /// <summary>
        /// 388. Longest Absolute File Path
        /// https://leetcode.com/problems/longest-absolute-file-path/
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int LengthLongestPath(string input)
        {
            //Another way 
            //Using directionary, save depth & length per directory
            int ans = 0;
            string[] items = input.Split("\n".ToCharArray());
            List<string> dirs = new List<string>();
            for(int i = 0; i < items.Length; i++)
            {
                int tabs = 0;
                while (items[i][tabs] == '\t')
                    tabs++;
                string name = items[i].Substring(tabs);
                bool isFile = IsFile(name);
                if (isFile)
                {
                    if(tabs != 0)
                        ans = Math.Max(ans, string.Format("{0}{1}", GetDirs(dirs, tabs), name).Length);
                    else
                        ans = Math.Max(ans, name.Length);
                }
                else
                {
                    //Directory
                    while (dirs.Count > tabs)
                        dirs.RemoveAt(dirs.Count - 1);
                    dirs.Add(name);
                }
            }

            return ans;
        }
        private bool IsFile(string name)
        {
            if (name.IndexOf(".") > 0)
                return true;
            return false;
        }
        private string GetDirs(List<string> dirs, int depth)
        {
            if (dirs.Count == 0)
                return "";
            StringBuilder sbDir = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                if( i == 0)
                    sbDir.Append(dirs[0]);
                else
                    sbDir.AppendFormat("/{0}", dirs[i]);
            }
            sbDir.Append("/");
            return sbDir.ToString();
        }


        #endregion

        #region | Online Interview - 2022/12/01 | 

        /// <summary>
        /// 949. Largest Time for Given Digits
        /// https://leetcode.com/problems/largest-time-for-given-digits/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public string LargestTimeFromDigits(int[] arr)
        {
            Array.Sort(arr);
            if (arr[0] > 2)
                return "";
            return "";
        }


        /// <summary>
        /// 307. Range Sum Query - Mutable
        /// https://leetcode.com/problems/range-sum-query-mutable/
        /// </summary>
        public class NumArray
        {
            int[] tree;
            int n;
            public NumArray(int[] nums)
            {
                if (nums.Length > 0)
                {
                    n = nums.Length;
                    tree = new int[n * 2];
                    BuildTree(nums);
                }
            }
            private void BuildTree(int[] nums) {
                for (int i = n, j = 0; i < 2 * n; i++, j++)
                    tree[i] = nums[j];
                for (int i = n - 1; i > 0; --i)
                    tree[i] = tree[i * 2] + tree[i * 2 + 1];
            }

            public void Update(int index, int val)
            {
                index += n;
                tree[index] = val;
                while( index > 0)
                {
                    int left = index;
                    int right = index;
                    if (index % 2 == 0)
                    {
                        right = index + 1;
                    }
                    else
                    {
                        left = index - 1;
                    }
                    // parent is updated after child is updated
                    tree[index / 2] = tree[left] + tree[right];
                    index /= 2;
                }
            }

            public int SumRange(int left, int right)
            {
                // get leaf with value 'l'
                left += n;
                // get leaf with value 'r'
                right += n;
                int sum = 0;
                while (left <= right)
                {
                    if ((left % 2) == 1)
                    {
                        sum += tree[left];
                        left++;
                    }
                    if ((right % 2) == 0)
                    {
                        sum += tree[right];
                        right--;
                    }
                    left /= 2;
                    right /= 2;
                }
                return sum;
            }
        }

        #endregion


        #region | Online Inerview - 2023/01/01 | 

        /// <summary>
        /// 1051. Height Checker
        /// https://leetcode.com/problems/height-checker/description/
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int HeightChecker(int[] heights)
        {
            ////# Case 1. O(nlongn)
            //int n = heights.Length;
            //int[] orgHeights = new int[n];
            //for (int i = 0; i < n; i++)
            //    orgHeights[i] = heights[i];

            //Array.Sort(heights);
            //int notMatched = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    if (orgHeights[i] != heights[i])
            //        notMatched++;
            //}

            //return notMatched;

            ////# Case 2. O(n)
            int[] heightFreq = new int[101];
            foreach (int height in heights)
                heightFreq[height]++;

            int ans = 0, currHeight = 0;
            for (int i = 0; i < heightFreq.Length; i++)
            {
                if (heightFreq[i] == 0)
                    continue;
                for (int idx = currHeight; idx < currHeight + heightFreq[i]; idx++)
                {
                    if (heights[idx] != i)
                        ans++;
                }
                currHeight += heightFreq[i];
            }

            return ans;
        }


        /// <summary>
        /// 925. Long Pressed Name
        /// https://leetcode.com/problems/long-pressed-name/
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typed"></param>
        /// <returns></returns>
        public bool IsLongPressedName(string name, string typed)
        {
            int nameIdx = 0, typedIdx = 0;
            int nameLen = name.Length;
            int typedLen = typed.Length;

            while (nameIdx < nameLen && typedIdx < typedLen)
            {
                if (name[nameIdx] == typed[typedIdx])
                {
                    nameIdx++;
                    typedIdx++;
                }
                else if (typedIdx > 0 && typed[typedIdx - 1] == typed[typedIdx])
                {
                    typedIdx++;
                }
                else
                    return false;
            }
            while (nameIdx == nameLen
                && typedIdx < typedLen
                && typedIdx > 0 && typed[typedIdx - 1] == typed[typedIdx])
                typedIdx++;

            return nameIdx == nameLen && typedIdx == typedLen ? true : false;
        }


        #endregion

    }
}
