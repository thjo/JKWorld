using LeetCode.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Study
{
    public class DataStructureII
    {
        /// <summary>
        /// 136. Single Number
        /// https://leetcode.com/problems/single-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int retVal = nums[0];

            for (int i = 1; i < nums.Length; i++)
                retVal ^= nums[i];

            return retVal;
        }


        /// <summary>
        /// 169. Majority Element
        /// https://leetcode.com/problems/majority-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int count = 0;
            int? candidate = null;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate.Value) ? 1 : -1;
            }

            return candidate.Value;
        }

        /// <summary>
        /// 15. 3Sum
        /// https://leetcode.com/problems/3sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> groups = new List<IList<int>>();
            int n = nums.Length;
            Array.Sort(nums);

            for (int i = 0; i < n - 1; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i])
                    continue;

                int l = i + 1, r = n - 1;
                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        List<int> tmp = new List<int>();
                        tmp.Add(nums[i]); tmp.Add(nums[l]); tmp.Add(nums[r]);
                        groups.Add(tmp);
                    }
                    if (sum <= 0)
                    {
                        l++;
                        while (l < n && nums[l - 1] == nums[l])
                            l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }

            return groups;
        }



        //706. Design HashMap
        //https://leetcode.com/problems/design-hashmap/
        //DataStructures.MyHashMap


        /// <summary>
        /// 75. Sort Colors
        /// https://leetcode.com/problems/sort-colors/
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            int numOfRed = 0, numOfWhite = 0, numOfBlue = 0;
            foreach (int color in nums)
            {
                if (color == 0)
                    numOfRed++;
                else if (color == 1)
                    numOfWhite++;
                else
                    numOfBlue++;
            }
            int i = 0;
            while (i < nums.Length)
            {
                if (numOfRed > 0)
                {
                    nums[i] = 0;
                    numOfRed--;
                }
                else if (numOfWhite > 0)
                {
                    nums[i] = 1;
                    numOfWhite--;
                }
                else
                {
                    nums[i] = 2;
                    numOfBlue--;
                }
                i++;
            }
        }


        /// <summary>
        /// 56. Merge Intervals
        /// https://leetcode.com/problems/merge-intervals/
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] Merge(int[][] intervals)
        {
            List<IntervalInfo> list = new List<IntervalInfo>();
            foreach (var interval in intervals)
            {
                list.Add(new IntervalInfo(interval[0], false));
                list.Add(new IntervalInfo(interval[1], true));
            }
            var orderedList = list.OrderBy(x => x.Time).ThenBy(x => x.IsClosed);

            List<int[]> result = new List<int[]>();
            int startedCnt = 0;
            int? startedTime = null;
            foreach (var info in orderedList)
            {
                if (info.IsClosed == false)
                {
                    startedCnt++;
                    if (startedTime == null)
                        startedTime = info.Time;
                }
                else
                {
                    startedCnt--;
                    if (startedCnt == 0)
                    {
                        result.Add(new int[] { startedTime.Value, info.Time });
                        startedTime = null;
                    }
                }
            }
            int[][] ans = new int[result.Count][];
            for (int i = 0; i < result.Count; i++)
            {
                ans[i] = result[i];
            }
            return ans;
        }
        public class IntervalInfo
        {
            public int Time;
            public bool IsClosed;

            public IntervalInfo(int time, bool isClosed)
            {
                Time = time;
                IsClosed = isClosed;
            }
        }


        /// <summary>
        /// 435. Non-overlapping Intervals
        /// https://leetcode.com/problems/non-overlapping-intervals/
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int EraseOverlapIntervals(int[][] intervals)
        {
            List<IntervalTime> listOfIntervals = new List<IntervalTime>();
            for (int i = 0; i < intervals.Length; i++)
            {
                listOfIntervals.Add(new IntervalTime(i, intervals[i][0], intervals[i][1]));
            }
            var sortedList = listOfIntervals.OrderBy(x => x.STime).ThenBy(x => x.ETime);

            int ans = 0;
            int? end = null;
            foreach (var interval in sortedList)
            {
                if (end == null)
                    end = interval.ETime;
                else
                {
                    //not overlapping
                    if (interval.STime >= end)
                        end = interval.ETime;
                    else
                    {
                        //overlapping
                        end = Math.Min(end.Value, interval.ETime);
                        ans++;
                    }
                }
            }

            return ans;
        }
        public class IntervalTime
        {
            public int GroupId;
            public int STime;
            public int ETime;
            public IntervalTime(int groupId, int sTime, int eTime)
            {
                GroupId = groupId;
                STime = sTime;
                ETime = eTime;
            }
        }


        /// <summary>
        /// 334. Increasing Triplet Subsequence
        /// https://leetcode.com/problems/increasing-triplet-subsequence/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3)
                return false;
            int firstNum = int.MaxValue;
            int secNum = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= firstNum)
                    firstNum = nums[i];
                else if (nums[i] <= secNum)
                    secNum = nums[i];
                else
                    return true;
            }
            return false;
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


        /// <summary>
        /// 560. Subarray Sum Equals K
        /// https://leetcode.com/problems/subarray-sum-equals-k/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {

            int count = 0, sum = 0;
            int n = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, 1);  //one value is equal to k
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum - k))
                    count += map[sum - k];
                if (map.ContainsKey(sum))
                    map[sum]++;
                else
                    map.Add(sum, 1);
            }
            return count;

            /*
            int count = 0;
            for (int start = 0; start < nums.Length; start++) {
                int sum=0;
                for (int end = start; end < nums.Length; end++) {
                    sum+=nums[end];
                    if (sum == k)
                        count++;
                }
            }
            return count;
            */
        }


        /// <summary>
        /// 415. Add Strings
        /// https://leetcode.com/problems/add-strings/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string AddStrings(string num1, string num2)
        {
            int comp = 0;
            int idx1 = num1.Length - 1, idx2 = num2.Length - 1;

            string ans = "";
            while (idx1 >= 0 && idx2 >= 0)
            {
                int sum = (num1[idx1] - '0') + (num2[idx2] - '0');
                if (comp == 1)
                    sum++;
                ans = (sum % 10).ToString() + ans;
                comp = sum / 10;
                idx1--; idx2--;
            }
            while (idx1 >= 0)
            {
                int sum = (num1[idx1] - '0');
                if (comp == 1)
                    sum++;
                ans = (sum % 10).ToString() + ans;
                comp = sum / 10;
                idx1--;
            }
            while (idx2 >= 0)
            {
                int sum = (num2[idx2] - '0');
                if (comp == 1)
                    sum++;
                ans = (sum % 10).ToString() + ans;
                comp = sum / 10;
                idx2--;
            }
            if (comp == 1)
                ans = "1" + ans;
            return ans;
        }


        /// <summary>
        /// 290. Word Pattern
        /// https://leetcode.com/problems/word-pattern/
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool WordPattern(string pattern, string s)
        {

            int n = pattern.Length;
            string[] words = s.Split(" ".ToCharArray());
            if (words.Length != n)
                return false;

            Dictionary<char, string> dicPattern = new Dictionary<char, string>();
            Dictionary<string, char> dicStr = new Dictionary<string, char>();
            for (int i = 0; i < n; i++)
            {
                if (dicPattern.ContainsKey(pattern[i]))
                {
                    if (dicPattern[pattern[i]] != words[i])
                        return false;
                }
                else if (dicStr.ContainsKey(words[i]))
                {
                    if (dicStr[words[i]] != pattern[i])
                        return false;
                }

                if (dicPattern.ContainsKey(pattern[i]) == false)
                    dicPattern.Add(pattern[i], words[i]);
                if (dicStr.ContainsKey(words[i]) == false)
                    dicStr.Add(words[i], pattern[i]);
            }

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
            int[] last = new int[26];
            for (int i = 0; i < s.Length; i++)
                last[s[i] - 'a'] = i;

            IList<int> partitions = new List<int>();
            int endIdx = 0, startIdx = 0;
            for (int i = 0; i < s.Length; i++)
            {
                endIdx = Math.Max(endIdx, last[s[i] - 'a']);
                if (i == endIdx)
                {
                    partitions.Add(i - startIdx + 1);
                    startIdx = i + 1;
                }
            }
            return partitions;
        }


        /// <summary>
        /// 49. Group Anagrams
        /// https://leetcode.com/problems/group-anagrams/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> result = new List<IList<string>>();

            if (strs == null)
                return result;
            else if (strs.Length == 1)
            {
                IList<string> buff = new List<string>();
                buff.Add(strs[0]);
                result.Add(buff);
                return result;
            }

            IList<Dictionary<char, int>> words = new List<Dictionary<char, int>>();
            foreach (string s in strs)
            {
                Dictionary<char, int> word = new Dictionary<char, int>();
                foreach (char c in s)
                {
                    if (word.ContainsKey(c))
                        word[c]++;
                    else
                        word.Add(c, 1);
                }
                words.Add(word);
            }

            int[] checkedList = new int[strs.Length];
            for (int idx = 0; idx < words.Count; idx++)
            {
                if (checkedList[idx] == 1)
                    continue;

                Dictionary<char, int> word = words[idx];
                IList<string> buff = new List<string>();
                buff.Add(strs[idx]);
                checkedList[idx] = 1;

                if (idx + 1 == words.Count)
                {
                    result.Add(buff);
                    continue;
                }

                for (int curr = idx + 1; curr < words.Count; curr++)
                {
                    if (checkedList[curr] == 1)
                        continue;
                    if (GroupAnagramsCompareWords(word, words[curr]))
                    {
                        buff.Add(strs[curr]);
                        checkedList[curr] = 1;
                    }
                }
                result.Add(buff);
            }

            return result;
        }
        private bool GroupAnagramsCompareWords(Dictionary<char, int> word1, Dictionary<char, int> word2)
        {
            bool retVal = true;
            if (word1.Count != word2.Count)
                return false;
            else if (word1.Count == 0 && word2.Count == 0)
                return true;

            foreach (var c in word1)
            {
                if (word2.ContainsKey(c.Key) && word2[c.Key] == c.Value)
                    continue;
                else
                {
                    retVal = false;
                    break;
                }
            }

            return retVal;
        }



        /// <summary>
        /// 43. Multiply Strings
        /// https://leetcode.com/problems/multiply-strings/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";
            if (num1.Length > num2.Length)
            {
                String tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
            int num1_len = num1.Length, num2_len = num2.Length;
            int[] res = new int[num1_len + num2_len];
            for (int i = 0; i < res.Length; i++)
                res[i] = 0;

            for (int i = num1_len - 1; i >= 0; i--)
            {
                for (int j = num2_len - 1; j >= 0; j--)
                {
                    int p1 = i + j, p2 = p1 + 1;
                    int sum = (num1[i] - '0') * (num2[j] - '0') + res[p2];
                    res[p2] = sum % 10;
                    res[p1] += sum / 10;
                }
            }
            String output = ""; int idx = -1;
            for (int i = 0; i < num1_len + num2_len && res[i] == 0; i++)
                idx = i;
            for (int i = idx + 1; i < num1_len + num2_len; i++)
                output += res[i].ToString();
            return output;
        }

        // Multiply the current digit of secondNumber with firstNumber.
        List<int> MultiplyOneDigit(StringBuilder sbN1, char secondNumberDigit, int numZeros)
        {
            // Insert zeros at the beginning based on the current digit's place.
            List<int> currentResult = new List<int>();
            for (int i = 0; i < numZeros; ++i)
            {
                currentResult.Add(0);
            }

            int carry = 0;

            // Multiply firstNumber with the current digit of secondNumber.
            for (int i = 0; i < sbN1.Length; ++i)
            {
                char firstNumberDigit = sbN1[i];
                int multiplication = (secondNumberDigit - '0') * (firstNumberDigit - '0') + carry;
                // Set carry equal to the tens place digit of multiplication.
                carry = multiplication / 10;
                // Append last digit to the current result.
                currentResult.Add(multiplication % 10);
            }

            if (carry != 0)
            {
                currentResult.Add(carry);
            }
            return currentResult;
        }
        private List<int> AddStrings(List<int> num1, List<int> num2)
        {
            List<int> ans = new List<int>();
            int carry = 0;

            for (int i = 0; i < num1.Count || i < num2.Count; ++i)
            {
                // If num2 is shorter than num1 or vice versa, use 0 as the current digit.
                int digit1 = i < num1.Count ? num1[i] : 0;
                int digit2 = i < num2.Count ? num2[i] : 0;

                // Add current digits of both numbers.
                int sum = digit1 + digit2 + carry;
                // Set carry equal to the tens place digit of sum.
                carry = sum / 10;
                // Append the ones place digit of sum to answer.
                ans.Add(sum % 10);
            }

            if (carry != 0)
            {
                ans.Add(carry);
            }
            return ans;
        }


        /// <summary>
        /// 87. Repeated DNA Sequences
        /// https://leetcode.com/problems/repeated-dna-sequences/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            IList<string> repeatedSubSeqs = new List<string>();
            Dictionary<string, int> seen = new Dictionary<string, int>();
            int i = 0;
            while (i + 10 <= s.Length)
            {
                string subSeqs = s.Substring(i, 10);
                if (seen.ContainsKey(subSeqs))
                    seen[subSeqs]++;
                else
                    seen.Add(subSeqs, 1);
                if (seen[subSeqs] == 2)
                    repeatedSubSeqs.Add(subSeqs);
                i++;
            }

            return repeatedSubSeqs;
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


        /// <summary>
        /// 2. Add Two Numbers
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
        /// 142. Linked List Cycle II
        /// https://leetcode.com/problems/linked-list-cycle-ii/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return null;

            ListNode curr = head.next;
            ListNode fast = head.next.next;

            while (curr != fast && fast != null)
            {
                curr = curr.next;
                fast = fast.next != null ? fast.next.next : null;
            }
            if (fast == null)
                return null;

            ListNode ptr1 = head;
            while (ptr1 != fast)
            {
                ptr1 = ptr1.next;
                fast = fast.next;
            }

            return ptr1;
        }


        /// <summary>
        /// 160. Intersection of Two Linked Lists
        /// https://leetcode.com/problems/intersection-of-two-linked-lists/
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode pA = headA;
            ListNode pB = headB;
            bool isFirstA = true, isFirstB = true;
            while (pA != null || pB != null)
            {
                if (pA == pB)
                    return pA;

                pA = pA.next;
                if (pA == null && isFirstA)
                {
                    pA = headB;
                    isFirstA = false;
                }
                pB = pB.next;
                if (pB == null && isFirstB)
                {
                    pB = headA;
                    isFirstB = false;
                }
            }
            return null;
        }


        /// <summary>
        /// 82. Remove Duplicates from Sorted List II
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode newHead = new ListNode(-1, head);
            ListNode currNew = newHead;

            while (head != null)
            {
                if (head.next != null && head.val == head.next.val)
                {
                    while (head.next != null && head.val == head.next.val)
                        head = head.next;
                    currNew.next = head.next;
                }
                else
                    currNew = currNew.next;

                head = head.next;
            }

            return newHead.next;
        }


        /// <summary>
        /// 1249. Minimum Remove to Make Valid Parentheses
        /// https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MinRemoveToMakeValid(string s)
        {
            //Track '(' char - index
            Stack<int> sParenthes = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    sParenthes.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (sParenthes.Count > 0 && s[sParenthes.Peek()] == '(')
                    {
                        sParenthes.Pop();
                    }
                    else
                        sParenthes.Push(i);
                }
            }

            StringBuilder sbAns = new StringBuilder();
            int[] skipIdx = new int[sParenthes.Count];
            int idx = sParenthes.Count - 1;
            while (sParenthes.Count > 0)
            {
                skipIdx[idx] = sParenthes.Pop();
                idx--;
            }
            idx = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (idx < skipIdx.Length && skipIdx[idx] == i)
                {
                    idx++;
                    continue;
                }
                else
                    sbAns.Append(s[i]);
            }
            return sbAns.ToString();
        }


        /// <summary>
        /// 1557. Minimum Number of Vertices to Reach All Nodes
        /// https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            //find how many group of graphs exists.
            return null;
        }


        /// <summary>
        /// 1823. Find the Winner of the Circular Game
        /// https://leetcode.com/problems/find-the-winner-of-the-circular-game/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindTheWinner(int n, int k)
        {
            Queue<int> list = new Queue<int>();
            for (int i = 1; i <= n; i++)
                list.Enqueue(i);

            while(list.Count != 1)
            {
                for(int c = 1; c < k; c++)
                    list.Enqueue(list.Dequeue());
                list.Dequeue();
            }

            return list.Peek();
        }
        public int FindTheWinner2(int n, int k)
        {
            if (n == 1)
                return 1;

            //Build Linked List
            LinkedNode head = new LinkedNode(1, null, null);
            LinkedNode curr = head;
            int player = 2;
            while(player <= n)
            {
                LinkedNode newNode = new LinkedNode(player++, curr, null);
                curr.Next = newNode;
                curr = newNode;
            }

            //Play the game until one # leaves
            curr = head;
            while (head.Next != null)
            {
                for(int c = 2; c <= k; c++)
                {
                    curr = curr.Next;
                    if (curr == null)
                        curr = head;
                }

                //delete the current node
                if( curr.Prev == null)
                {
                    //If it's the head
                    head = head.Next;
                    head.Prev = null;
                    curr = head;
                }
                else
                {
                    LinkedNode prevNd = curr.Prev;
                    LinkedNode nextNd = curr.Next;
                    if (nextNd != null) {
                        prevNd.Next = nextNd;
                        nextNd.Prev = prevNd;
                        curr = nextNd;
                    }
                    else
                    {
                        //end node
                        prevNd.Next = null;
                        curr = head;
                    }
                }
            }

            return head.Val;
        }
        private class LinkedNode
        {
            public int Val;
            public LinkedNode Next = null;
            public LinkedNode Prev = null;
            public LinkedNode(int x = 0, LinkedNode prev = null, LinkedNode next = null) { 
                this.Val = x;
                this.Prev = prev;
                this.Next = next; 
            }

        }
    }
}
