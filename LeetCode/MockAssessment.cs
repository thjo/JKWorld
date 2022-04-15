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
            while (i < bits.Length)
            {
                if (bits[i] == 0)
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

            for (int i = 0; i < nums.Length; i++)
            {
                if (dp.ContainsKey(target - nums[i]))
                    return new int[] { dp[target - nums[i]], i };
                else
                {
                    if (dp.ContainsKey(nums[i]) == false)
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

            if ((numerator < 0 && denominator > 0)
                || (numerator > 0 && denominator < 0))
            {
                isNegative = true;
            }

            long numer = numerator;
            long denom = denominator;
            if (numer < 0)
                numer = Math.Abs(numer);
            if (denom < 0)
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
                    rest = (numer % denom);
                    num = (numer / denom);
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
            while (firstIdx < firstList.Length && secIdx < secondList.Length)
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
            foreach (var t in trips)
            {
                timestamp[t[1]] += t[0];
                timestamp[t[2]] -= t[0];
            }

            foreach (int p in timestamp)
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
            while (l < s.Length)
            {
                if (char.IsLetter(s[l]))
                {
                    while (char.IsLetter(s[r]) == false || reverseStr[r] != '\0')
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

            for (int r = 0; r < n; r++)
            {
                sumPri += mat[r][r];
                sumSec += mat[r][n - 1 - r];
            }

            if (n % 2 == 0)
                return sumPri + sumSec;
            else
                return sumPri + sumSec - mat[n / 2][n / 2];
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

            while (l < r)
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

            while (ptr1 != ptr2)
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
                    if (coins[c] <= i)
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

            foreach (string word in words)
            {
                if (CanbeFormed(word, charSets))
                    totalLen += word.Length;
            }

            return totalLen;
        }
        private bool CanbeFormed(string word, Dictionary<char, int> charSets)
        {
            Dictionary<char, int> buffWords = new Dictionary<char, int>();
            foreach (char c in word)
            {
                if (buffWords.ContainsKey(c))
                    buffWords[c]++;
                else
                    buffWords.Add(c, 1);
            }

            foreach (var w in buffWords)
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
            while (i < s.Length)
            {
                if (i < s.Length - 1)
                {
                    if (map[s[i]] >= map[s[i + 1]])
                    {
                        //normal number
                        total += map[s[i]];
                        i += 1;
                    }
                    else
                    {
                        //for four
                        total += (map[s[i + 1]] - map[s[i]]);
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
                }
                else
                {
                    total = l1 != null ? l1.val : l2.val;
                    if (exraNum == 1)
                        total += 1;
                }
                if (total >= 10)
                    exraNum = 1;
                else
                    exraNum = 0;

                //Add a node
                ListNode node = new ListNode(total % 10);
                currNode.next = node;
                currNode = node;

                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }

            if (exraNum == 1)
            {
                ListNode node = new ListNode(1);
                currNode.next = node;
            }

            return head.next;
        }


        /// <summary>
        /// 5. Longest Palindromic Substring
        /// https://leetcode.com/problems/longest-palindromic-substring/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
                return s;

            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    if (len % 2 == 0)
                        start = i - (len - 1) / 2;
                    else
                        start = i - len / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }
        private int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--; right++;
            }
            return right - left - 1;
        }


        #region | PHONE INTERVIEW - 12/17/2021 | 

        /// <summary>
        /// 387. First Unique Character in a String
        /// https://leetcode.com/problems/first-unique-character-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> dp = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dp.ContainsKey(c))
                    dp[c]++;
                else
                    dp.Add(c, 1);
            }

            int idx = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (dp[s[i]] == 1)
                {
                    idx = i;
                    break;
                }
            }

            return idx;
        }

        /// <summary>
        /// 206. Reverse Linked List
        /// https://leetcode.com/problems/reverse-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            //ListNode newHead = new ListNode(-1);
            //newHead.next = head;

            ListNode prevNode = null;
            ListNode currNode = head;

            while (currNode != null)
            {
                ListNode nextNode = currNode.next;
                currNode.next = prevNode;

                prevNode = currNode;
                currNode = nextNode;
            }

            return prevNode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length < 1)
                return -1;

            return SearchPivot(nums, target, 0, nums.Length - 1);
        }
        private int SearchPivot(int[] nums, int target, int startIdx, int endIdx)
        {
            if (startIdx > endIdx)
                return -1;

            int mid = (startIdx + endIdx) / 2;
            if (nums[mid] == target)
                return mid;

            /* If arr[l...mid] is sorted */
            if (nums[startIdx] <= nums[mid])
            {
                if (target >= nums[startIdx] && target < nums[mid])
                    return SearchPivot(nums, target, startIdx, mid - 1);
                else
                    return SearchPivot(nums, target, mid + 1, endIdx);
            }
            else
            {
                /* If arr[l..mid] is not sorted, then arr[mid... r] must be sorted*/
                if (target > nums[mid] && target <= nums[endIdx])
                    return SearchPivot(nums, target, mid + 1, endIdx);
                else
                    return SearchPivot(nums, target, startIdx, mid - 1);
            }
        }

        #endregion


        #region | ONSITE INTERVIEW - 12/19/2021 |

        /// <summary>
        /// 141. Linked List Cycle
        /// https://leetcode.com/problems/linked-list-cycle/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            HashSet<ListNode> s = new HashSet<ListNode>();
            while (head != null)
            {
                if (s.Contains(head))
                    return true;

                s.Add(head);

                head = head.next;
            }

            return false;
        }


        /// <summary>
        /// 450. Delete Node in a BST
        /// https://leetcode.com/problems/delete-node-in-a-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            // Base case
            if (root == null)
                return root;

            // Recursive calls for ancestors of
            // node to be deleted
            if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
                return root;
            }
            else if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
                return root;
            }

            // We reach here when root is the node
            // to be deleted.

            // If one of the children is empty
            if (root.left == null)
            {
                TreeNode temp = root.right;
                return temp;
            }
            else if (root.right == null)
            {
                TreeNode temp = root.left;
                return temp;
            }
            // If both children exist
            else
            {
                TreeNode succParent = root;

                // Find successor
                TreeNode succ = root.right;

                while (succ.left != null)
                {
                    succParent = succ;
                    succ = succ.left;
                }

                // Delete successor. Since successor
                // is always left child of its parent
                // we can safely make successor's right
                // right child as left of its parent.
                // If there is no succ, then assign
                // succ->right to succParent->right
                if (succParent != root)
                    succParent.left = succ.right;
                else
                    succParent.right = succ.right;

                // Copy Successor Data to root
                root.val = succ.val;

                return root;
            }
        }


        public int Calculate(string s)
        {
            if (s == null || s.Length == 0) return 0;

            int len = s.Length;
            int currNum = 0, lastNum = 0, total = 0;
            Stack<int> nums = new Stack<int>();
            char operation = '+';
            for (int i = 0; i < len; i++)
            {
                char currChar = s[i];

                if (Char.IsDigit(currChar))
                    currNum = (currNum * 10) + (currChar - '0');

                if (!Char.IsDigit(currChar) && currChar != ' ' || i == len - 1)
                {
                    if (operation == '+' || operation == '-')
                    {
                        total += lastNum;
                        lastNum = operation == '+' ? currNum : -currNum;
                    }
                    else if (operation == '*')
                    {
                        lastNum = lastNum * currNum;
                    }
                    else if (operation == '/')
                    {
                        lastNum = lastNum / currNum;
                    }
                    operation = currChar;
                    currNum = 0;
                }
            }

            total += lastNum;
            return total;
        }



        #endregion

        #region | ONLINE ASSESSMENT -  12/22/2021 | 
        /// <summary>
        /// 836. Rectangle Overlap
        /// https://leetcode.com/problems/rectangle-overlap/
        /// </summary>
        enum DirectionR { LEFT = 0, BOTTOM = 1, RIGHT = 2, TOP = 3 }
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            //check bottom and left
            if (rec1[(int)DirectionR.RIGHT] <= rec2[(int)DirectionR.LEFT]
                || rec1[(int)DirectionR.TOP] <= rec2[(int)DirectionR.BOTTOM]
                || rec1[(int)DirectionR.LEFT] >= rec2[(int)DirectionR.RIGHT]
                || rec1[(int)DirectionR.BOTTOM] >= rec2[(int)DirectionR.TOP])
            {
                return false;
            }
            else
                return true;
        }


        /// <summary>
        /// 763. Partition Labels
        /// https://leetcode.com/problems/partition-labels/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<int> PartitionLabels(string s)
        {
            IList<int> partitions = new List<int>();
            if (s.Length == 1)
            {
                partitions.Add(s.Length);
                return partitions;
            }

            HashSet<char> scaned = new HashSet<char>();

            int startIdx = 0, endIdx = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (scaned.Contains(s[i]) == false)
                {
                    scaned.Add(s[i]);
                    for (int j = s.Length - 1; j > endIdx; j--)
                    {
                        if (s[i] == s[j])
                            endIdx = Math.Max(endIdx, j);
                    }
                }
                else if (endIdx > i)
                    continue;

                if (endIdx <= i)
                {
                    //It's an one sub-string
                    partitions.Add(endIdx - startIdx + 1);
                    startIdx = i + 1;
                    endIdx = i + 1;
                }
            }

            //last one
            //It's an one sub-string
            if (startIdx != endIdx)
            {
                partitions.Add(endIdx - startIdx + 1);
            }

            return partitions;
        }

        #endregion

        #region | ONLINE ASSESSMENT - 12/23/2021 | 


        public bool FindTarget(TreeNode root, int k)
        {
            HashSet<int> targetNums = new HashSet<int>();

            return FindTargetInOrder(root, k, targetNums);
        }
        private bool FindTargetInOrder(TreeNode root, int k, HashSet<int> targetNums)
        {
            if (root == null)
                return false;
            else if (targetNums.Contains(root.val))
                return true;

            targetNums.Add(k - root.val);
            bool existed = false;
            if (root.left != null)
                existed = FindTargetInOrder(root.left, k, targetNums);

            if (existed != true && root.right != null)
                existed = FindTargetInOrder(root.right, k, targetNums);
            return existed;
        }

        /// <summary>
        /// 1071. Greatest Common Divisor of Strings
        /// https://leetcode.com/problems/greatest-common-divisor-of-strings/
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string GcdOfStrings(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            int maxLen = Math.Max(len1, len2);

            for (int i = maxLen; i >= 1; i--)
            {
                if (len1 % i == 0 && len2 % i == 0 && str1.Substring(0, i).Equals(str2.Substring(0, i)))
                {
                    String tmp1 = str1.Substring(i) + str1.Substring(0, i);
                    String tmp2 = str2.Substring(i) + str2.Substring(0, i);
                    if (tmp1.Equals(str1) && tmp2.Equals(str2))
                    {
                        return str1.Substring(0, i);
                    }
                }
            }

            return "";
        }


        #endregion


        #region | ONLINE ASSESSMENT - 12/25/21 | 

        /// <summary>
        /// 796. Rotate String
        /// https://leetcode.com/problems/rotate-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public bool RotateString(string s, string goal)
        {
            if (s.Length != goal.Length)
                return false;

            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == goal[0])
                {
                    if (RotateStringB(s.Substring(i) + s.Substring(0, i), goal))
                        return true;
                }
            }

            return false;
        }
        private bool RotateStringB(string s, string goal)
        {
            return s.Equals(goal);
        }


        /// <summary>
        /// 229. Majority Element II
        /// https://leetcode.com/problems/majority-element-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MajorityElement(int[] nums)
        {
            int? candidate1 = null, candidate2 = null;
            int count1 = 0, count2 = 0;

            foreach (var n in nums)
            {
                if (candidate1 != null && candidate1.Value == n)
                    count1++;
                else if (candidate2 != null && candidate2.Value == n)
                    count2++;
                else if (candidate1 == null || count1 == 0)
                {
                    candidate1 = n;
                    count1++;
                }
                else if (candidate2 == null || count2 == 0)
                {
                    candidate2 = n;
                    count2++;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = 0;
            count2 = 0;
            foreach (var n in nums)
            {
                if (candidate1 == n)
                    count1++;
                else if (candidate2 == n)
                    count2++;
            }
            var result = new List<int>();
            if (count1 > nums.Length / 3)
                result.Add(candidate1.Value);
            if (count2 > nums.Length / 3)
                result.Add(candidate2.Value);

            return result;

            //IList<int> retVals = new List<int>();
            //int nTimes = nums.Length / 3;

            //Dictionary<int, int> map = new Dictionary<int, int>();

            //for(int i = 0; i < nums.Length; i++)
            //{
            //    if (map.ContainsKey(nums[i]))
            //        map[nums[i]]++;
            //    else
            //        map.Add(nums[i], 1);
            //}

            //foreach(var v in map)
            //{
            //    if (nTimes < v.Value)
            //        retVals.Add(v.Key);
            //}

            //return retVals;
        }

        #endregion



        #region | 01/02/2022 - OnSite | 


        /// <summary>
        /// 151. Reverse Words in a String
        /// https://leetcode.com/problems/reverse-words-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            string reversedSt = "";
            string currWord = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (c == ' ')
                {
                    if (currWord != "")
                    {
                        if (reversedSt != "")
                            reversedSt += " ";

                        reversedSt += currWord;

                        currWord = "";
                    }
                }
                else
                {
                    currWord = c + currWord;
                }
            }
            if (currWord != "")
            {
                if (reversedSt != "")
                    reversedSt += " ";

                reversedSt += currWord;
            }

            return reversedSt;
        }

        /// <summary>
        /// 236. Lowest Common Ancestor of a Binary Tree
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (root.val == p.val || root.val == q.val)
                return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
                return root;
            else if (left == null && right == null)
                return null;

            return left != null ? left : right;
        }

        /// <summary>
        /// 240. Search a 2D Matrix II
        /// https://leetcode.com/problems/search-a-2d-matrix-ii/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length < 1 || matrix[0].Length < 1)
                return false;

            int m = matrix.Length;
            int n = matrix[0].Length;

            int i = matrix.Length - 1;
            int j = 0;
            while (i >= 0 && j < matrix[0].Length)
            {
                if (matrix[i][j] > target)
                {
                    i--;
                }
                else if (matrix[i][j] < target)
                {
                    j++;
                }
                else
                {
                    return true;
                }
            }
            return false;

        }


        #endregion


        #region | 01/04/2022 - OnSite | 

        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            int len = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] != nums[i])
                {
                    nums[len] = nums[i];
                    len++;
                }
            }

            return len;
        }

        /// <summary>
        /// 93. Restore IP Addresses
        /// https://leetcode.com/problems/restore-ip-addresses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            IList<string> validAddrs = new List<string>();

            RestoreIpAddressesRR(s, validAddrs, "", 0, 12, 4);

            return validAddrs;
        }
        private void RestoreIpAddressesRR(string s, IList<string> validAddrs, string currIPAddr, int startIdx, int max, int min)
        {
            if (s.Length - startIdx > max || s.Length - startIdx < min)
                return;
            else if (max == 0 && startIdx == s.Length)
            {
                validAddrs.Add(currIPAddr.Substring(1));
                return;
            }

            //0.0.0.0
            if (s.Substring(startIdx, 1) == "0")
            {
                RestoreIpAddressesRR(s, validAddrs, currIPAddr + ".0", startIdx + 1, max - 3, min - 1);
                return;
            }
            for (int i = 1; i <= 3; i++)
            {
                if( startIdx + i <= s.Length)
                {
                    int tmp = int.Parse(s.Substring(startIdx, i));

                    if( tmp >= 0 && tmp <= 255 )
                    {
                        RestoreIpAddressesRR(s, validAddrs, currIPAddr+"."+tmp.ToString(), startIdx+i, max-3, min-1);
                    }
                }
            }
        }

        /// <summary>
        /// 135. Candy
        /// https://leetcode.com/problems/candy/
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public int Candy(int[] ratings)
        {
            if (ratings == null || ratings.Length < 1)
                return 0;

            int[] candies = new int[ratings.Length];
            candies[0] = 1;

            //from left to right
            for (int i = 1; i < ratings.Length; i++) {
                if (ratings[i] > ratings[i - 1])
                    candies[i] = candies[i - 1] + 1;
                else
                    candies[i] = 1;
            }

            int result = candies[ratings.Length - 1];
            //from right to left
            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                int cur = 1;
                if (ratings[i] > ratings[i + 1])
                {
                    cur = candies[i + 1] + 1;
                }

                result += Math.Max(cur, candies[i]);
                candies[i] = cur;
            }


            return result;
        }


        #endregion



        /// <summary>
        /// 1608. Special Array With X Elements Greater Than or Equal X
        /// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SpecialArray(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int min = Math.Min(nums[0], n);
            int max = Math.Min(nums[n - 1], n);
            int val = min;
            int idx = 0;
            while (val <= max)
            {
                if (val == n - idx)
                    return val;
                while (idx < n && nums[idx] <= val)
                    idx++;

                val++;
            }

            return -1;
        }


        /// <summary>
        /// 1365. How Many Numbers Are Smaller Than the Current Number
        /// https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            //int n = nums.Length;
            //int[] res = new int[n];

            //Dictionary<int, int> map = new Dictionary<int, int>();
            //int[] sortedNums = new int[n];
            //Array.Copy(nums, sortedNums, n);
            //Array.Sort(sortedNums);
            //int cnt = 0;
            //int idx = 0;
            //while (idx < n)
            //{
            //    int currVal = sortedNums[idx];
            //    int numOfVal = 1;
            //    while ((idx + numOfVal) < n && currVal == sortedNums[idx + numOfVal])
            //        numOfVal++;

            //    map.Add(currVal, cnt);
            //    idx += numOfVal;
            //    cnt += numOfVal;
            //}
            //for (int i = 0; i < n; i++)
            //{
            //    res[i] = map[nums[i]];
            //}

            //return res;


            int[] sort = new int[101];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sort[nums[i]]++;

            for (int i = 0; i < sort.Length; i++)
            {
                sum += sort[i];
                sort[i] = sum;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                    nums[i] = sort[nums[i] - 1];
                else
                    nums[i] = 0;
            }
            return nums;
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
