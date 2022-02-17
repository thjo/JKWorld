using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class DataStructureI
    {

        /// <summary>
        /// 217. Contains Duplicate
        /// https://leetcode.com/problems/contains-duplicate/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            bool retVal = false;
            if (nums == null || nums.Length < 2)
                return retVal;

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    retVal = true;
                    break;
                }
                else
                    set.Add(nums[i]);
            }

            return retVal;
        }

        /// <summary>
        /// 53. Maximum Subarray
        /// https://leetcode.com/problems/maximum-subarray/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            int sum = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (sum + nums[i] > nums[i])
                    sum = sum + nums[i];
                else
                    sum = nums[i];

                if (max < sum)
                    max = sum;
            }

            return max;
        }

        /// <summary>
        /// 1. Two Sum
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dp = new Dictionary<int, int>();
            int[] res = new int[2];
            for(int i = 0; i < nums.Length; i++)
            {
                if (dp.ContainsKey(target - nums[i]))
                {
                    res[0] = dp[target - nums[i]];
                    res[1] = i;
                    break;
                }
                else
                    dp[nums[i]] = i;
            }

            return res;
        }


        /// <summary>
        /// 88. Merge Sorted Array
        /// https://leetcode.com/problems/merge-sorted-array/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int n1 = m - 1, n2 = n - 1;
            int p = nums1.Length - 1;

            while (n1 >= 0 && n2 >= 0)
            {
                if (nums1[n1] < nums2[n2])
                    nums1[p--] = nums2[n2--];
                else
                    nums1[p--] = nums1[n1--];
            }

            while (n1 >= 0)
                nums1[p--] = nums1[n1--];

            while (n2 >= 0)
                nums1[p--] = nums2[n2--];
        }

        /// <summary>
        /// 350. Intersection of Two Arrays II
        /// https://leetcode.com/problems/intersection-of-two-arrays-ii/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int n1 = 0, n2 = 0;
            List<int> res = new List<int>();
            while(n1 < nums1.Length && n2 < nums2.Length)
            {
                if (nums1[n1] == nums2[n2])
                {
                    res.Add(nums1[n1]);
                    n1++; n2++;
                }
                else if (nums1[n1] > nums2[n2])
                    n2++;
                else
                    n1++;
            }

            return res.ToArray();

            //Dictionary<int, int> map = new Dictionary<int, int>();
            //List<int> returnList = new List<int>();

            //foreach (int num1 in nums1)
            //{
            //    if (map.ContainsKey(num1))
            //        map[num1]++;
            //    else
            //        map.Add(num1, 1);
            //}

            //foreach (int num2 in nums2)
            //{
            //    if (map.ContainsKey(num2) && map[num2] != 0)
            //    {
            //        returnList.Add(num2);
            //        map[num2]--;
            //    }
            //}

            //return returnList.ToArray();
        }

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;

            if (prices.Length <= 1)
                return maxProfit;

            int startPrice = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (startPrice > prices[i])
                    startPrice = prices[i];
                else if (startPrice < prices[i])
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - startPrice);
                }

            }

            return maxProfit;
        }


        /// <summary>
        /// 566. Reshape the Matrix
        /// https://leetcode.com/problems/reshape-the-matrix/
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            int[][] res = new int[r][];
            for (int i = 0; i < r; i++)
                res[i] = new int[c];

            if (mat.Length == 0 || r * c != mat.Length * mat[0].Length)
                return mat;

            int count = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    res[count / c][count % c] = mat[i][j];
                    count++;
                }
            }
            return res;
        }


        /// <summary>
        /// 118. Pascal's Triangle
        /// https://leetcode.com/problems/pascals-triangle/
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> res = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                IList<int> row = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        row.Add(1);
                    else
                        row.Add(res[i - 1][j - 1] + res[i - 1][j]);
                }
                res.Add(row);
            }

            return res;
        }




        /// <summary>
        /// 74. Search a 2D Matrix
        /// https://leetcode.com/problems/search-a-2d-matrix/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            if (m == 0)
                return false;
            int n = matrix[0].Length;

            // binary search
            int left = 0, right = m * n - 1;
            int pivotIdx, pivotElement;
            while (left <= right)
            {
                pivotIdx = (left + right) / 2;
                pivotElement = matrix[pivotIdx / n][pivotIdx % n];
                if (target == pivotElement)
                    return true;
                else
                {
                    if (target < pivotElement)
                        right = pivotIdx - 1;
                    else
                        left = pivotIdx + 1;
                }
            }
            return false;
        }


        /// <summary>
        /// 387. First Unique Character in a String
        /// https://leetcode.com/problems/first-unique-character-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            int retIdx = -1;

            Dictionary<char, int> buff = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (buff.ContainsKey(c))
                    buff[c]++;
                else
                    buff.Add(c, 1);
            }


            for (int i = 0; i < s.Length; i++)
            {
                if (buff[s[i]] == 1)
                {
                    retIdx = i;
                    break;
                }
            }

            return retIdx;
        }


        /// <summary>
        /// 383. Ransom Note
        /// https://leetcode.com/problems/ransom-note/
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            foreach (char c in ransomNote)
            {
                if (dic.ContainsKey(c))
                    dic[c]--;
                else
                    return false;
                if (dic[c] < 0)
                    return false;
            }

            return true;
        }


        /// <summary>
        /// 242. Valid Anagram
        /// https://leetcode.com/problems/valid-anagram/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            bool isAnag = false;

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            foreach (char c in t)
            {
                if (dic.ContainsKey(c))
                {
                    if (dic[c] <= 1)
                        dic.Remove(c);

                    else
                        dic[c]--;
                }
                else
                    return false;
            }

            if (dic.Count == 0)
                isAnag = true;

            return isAnag;
        }


        /// <summary>
        /// 141. Linked List Cycle
        /// https://leetcode.com/problems/linked-list-cycle/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null)
                return false;

            ListNode slow = head;
            ListNode fast = head.next;

            while(slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;

                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }


        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode newHead = new ListNode(-1);
            ListNode currNode = newHead;

            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    currNode.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    currNode.next = l1;
                    l1 = l1.next;
                }

                currNode = currNode.next;
            }

            if (l1 != null)
                currNode.next = l1;
            if (l2 != null)
                currNode.next = l2;

            return newHead.next;
        }


        /// <summary>
        /// 203. Remove Linked List Elements
        /// https://leetcode.com/problems/remove-linked-list-elements/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;

            ListNode newHead = new ListNode(-1);
            newHead.next = head;
            ListNode prev = newHead;
            ListNode curr = head;

            while(curr != null)
            {
                if( curr.val == val)
                {
                    prev.next = curr.next;
                    curr = curr.next;
                }
                else
                {
                    prev = curr;
                    curr = curr.next;
                }
            }

            return newHead.next;
        }

        /// <summary>
        /// 206. Reverse Linked List
        /// https://leetcode.com/problems/reverse-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode prev = null;
            ListNode curr = head;
            ListNode next = head.next;

            while (curr != null)
            {
                curr.next = prev;
                prev = curr;
                curr = next;
                if (next != null)
                    next = next.next;
                else
                    next = null;
            }

            return prev;
        }


        /// <summary>
        /// 83. Remove Duplicates from Sorted List
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode prev = head;
            ListNode curr = head.next;
            while(curr != null)
            {
                if(prev.val == curr.val)
                {
                    //delete current node
                    prev.next = curr.next;
                    curr = curr.next;
                }
                else
                {
                    //move to next node
                    prev = curr;
                    curr = curr.next;
                }
            }

            return head;
        }

        /// <summary>
        /// 20. Valid Parentheses
        /// https://leetcode.com/problems/valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;
            else if (s.Length % 2 != 0)
                return false;

            bool isValid = true;

            
            //Stack
            Stack<char> sBuff = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                int val = convertParentheses(s[i]);
                if (val == 0)
                {
                    isValid = false;
                    break;
                }
                if (val < 10)
                    sBuff.Push(s[i]);
                else
                {
                    if (sBuff.Count > 0)
                    {
                        if (convertParentheses(sBuff.Pop()) == val % 10)
                            continue;
                    }

                    isValid = false;
                    break;
                }
            }
            if (isValid == true)
                isValid = (sBuff.Count == 0);

            return isValid;
        }
        int convertParentheses(char c)
        {
            if (c == '(')
                return 1;
            else if (c == '[')
                return 2;
            else if (c == '{')
                return 3;
            else if (c == ')')
                return 11;
            else if (c == ']')
                return 12;
            else if (c == '}')
                return 13;
            else
                return 0;
        }




    }
}
