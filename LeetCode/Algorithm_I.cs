using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_I
    {
        #region | Binary Search | 

        /// <summary>
        /// 704. Binary Search
        /// https://leetcode.com/problems/binary-search/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int targetIdx = -1;
            int len = nums.Length;

            int left = 0, right = len - 1;
            int mid = len / 2;

            while(left <= right)
            {
                if(nums[mid] == target)
                {
                    targetIdx = mid;
                    break;
                }
                else if (nums[mid] > target)
                {
                    //Search left area of the array
                    right = mid - 1;
                }
                else
                {
                    //Search right area of the array
                    left = mid + 1;
                }
                mid = (left + right) / 2;
            }

            return targetIdx;
        }


        /// <summary>
        /// 278. First Bad Version
        /// https://leetcode.com/problems/first-bad-version/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int l = 1, h = n;

            while (l <= h)
            {
                int m = l + (h - l) / 2;
                if (IsBadVersion(m) == false)
                {
                    l = m + 1;
                }
                else
                {
                    h = m - 1;
                }
            }

            return l;
        }
        private bool IsBadVersion(int version)
        {
            if (version == 1)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 35. Search Insert Position
        /// https://leetcode.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int mid = (left + right) / 2;

            while (left <= right)
            {
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

                mid = (left + right) / 2;
            }

            return left;
        }

        #endregion

        #region | Two Points |

        /// <summary>
        /// 977. Squares of a Sorted Array
        /// https://leetcode.com/problems/squares-of-a-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortedSquares(int[] nums)
        {
            int len = nums.Length;
            int negativPoint = -1;

            int[] newSorted = new int[len];
            int idxNew = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    //Positive value
                    while (negativPoint > -1 && negativPoint < len
                        && nums[negativPoint] * nums[negativPoint] < nums[i] * nums[i])
                    {
                        newSorted[idxNew++] = nums[negativPoint] * nums[negativPoint];
                        negativPoint--;
                    }
                    newSorted[idxNew] = nums[i] * nums[i]; 
                    idxNew++;
                }
                else
                {
                    //Negative value
                    negativPoint = i;
                }
            }

            while (negativPoint > -1 && negativPoint < len)
            {
                newSorted[idxNew] = nums[negativPoint] * nums[negativPoint];
                idxNew++;
                negativPoint--;
            }

            return newSorted;
        }


        /// <summary>
        /// 189. Rotate Array
        /// https://leetcode.com/problems/rotate-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length == 1)
                return;

            k = k % nums.Length;

            ReversalArray(nums, 0, nums.Length-1);
            ReversalArray(nums, 0, k-1);
            ReversalArray(nums, k, nums.Length-1);

        }
        private void ReversalArray(int[] nums, int start, int end)
        {
            while(start < end)
            {
                int tmp = nums[start];
                nums[start++] = nums[end];
                nums[end--] = tmp;
            }
        }


        /// <summary>
        /// 283. Move Zeroes
        /// https://leetcode.com/problems/move-zeroes/
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums) 
        {   
            int numOfZeros = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    numOfZeros++;
                else
                {
                    if (numOfZeros > 0)
                    {
                        nums[i - numOfZeros] = nums[i];
                        nums[i] = 0;
                    }
                }
            }
        }


        /// <summary>
        /// 167. Two Sum II - Input array is sorted
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            //Using two points
            int idxLeft = 0, idxRight = numbers.Length - 1;

            while(idxLeft < idxRight)
            {
                if (numbers[idxLeft] + numbers[idxRight] == target)
                    return new int[] { idxLeft+1, idxRight+1 };
                else if (numbers[idxLeft] + numbers[idxRight] > target)
                    idxRight--;
                else
                    idxLeft++;
            }
            return new int[] { -1, -1 };

            //Using Dictionary

            //Dictionary<int, int> numMap = new Dictionary<int, int>();
            //for(int i = 0; i < numbers.Length; i++)
            //{
            //    if (numMap.ContainsKey(target - numbers[i]))
            //    {
            //        return new int[] { numMap[target - numbers[i]], i + 1 };
            //    }
            //    else
            //    {
            //        if(numMap.ContainsKey(numbers[i]) == false)
            //            numMap.Add(numbers[i], i + 1);
            //    }
            //}

            //return new int[] { -1, -1 };
        }



        /// <summary>
        /// 344. Reverse String
        /// https://leetcode.com/problems/reverse-string/
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            int l = 0, r = s.Length - 1;

            while (l < r)
            {
                char tmp = s[l];
                s[l++] = s[r];
                s[r--] = tmp;
            }
        }

        /// <summary>
        /// 557. Reverse Words in a String III
        /// https://leetcode.com/problems/reverse-words-in-a-string-iii/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            string reverseStr = "";
            string subStr = "";
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] == ' ')
                {
                    reverseStr += string.Format("{0} ", ReverseString(subStr));
                    subStr = "";
                }
                else
                {
                    subStr += s[i]; 
                }
            }
            if(string.IsNullOrWhiteSpace(subStr) == false)
                reverseStr += string.Format("{0}", ReverseString(subStr));

            return reverseStr;
        }
        public string ReverseString(string s)
        {
            int l = 0, r = s.Length - 1;
            string reverseL = "", reverseR = "";

            while (l < r)
            {
                reverseL = string.Format("{0}{1}", reverseL, s[r]);
                reverseR = string.Format("{0}{1}", s[l], reverseR);
                l++; r--;
            }

            if (s.Length % 2 == 1)
                return string.Format("{0}{1}{2}", reverseL, s[l], reverseR);
            else
                return string.Format("{0}{1}", reverseL, reverseR);
        }


        /// <summary>
        /// 876. Middle of the Linked List
        /// https://leetcode.com/problems/middle-of-the-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode slow = dummy, fast = dummy;
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next != null ? fast.next.next : null;
            }

            return slow;
        }


        /// <summary>
        /// 19. Remove Nth Node From End of List
        /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //Using Two points
            ListNode dummy = new ListNode(0, head);

            ListNode rightPointer = head;
            ListNode leftPointer = dummy;

            for (int i = 0; i < n; i++)
            {
                rightPointer = rightPointer.next;
            }

            while (rightPointer != null)
            {
                leftPointer = leftPointer.next;
                rightPointer = rightPointer.next;
            }

            leftPointer.next = leftPointer.next.next;

            return dummy.next;

            // Using Extra Space
            //ListNode slow = head, fast = head;
            //List<ListNode> buff = new List<ListNode>();
            //buff.Add(head);
            //while(fast != null)
            //{
            //    slow = fast.next;
            //    fast = slow != null ? slow.next : null;

            //    if( slow != null)
            //        buff.Add(slow);
            //    if( fast != null)
            //        buff.Add(fast);
            //}

            //int removeAt = buff.Count - n;
            //ListNode nodeRmoveAt = buff[removeAt];
            //if (removeAt < 0)
            //    return null;
            //else if( removeAt == 0)
            //{
            //    head = head.next;
            //}
            //else
            //{
            //    buff[removeAt-1].next = nodeRmoveAt.next;
            //}
            //return head;
        }

        #endregion


        #region | Sliding Window | 

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
            Dictionary<char, int> subStr = new Dictionary<char, int>();
            int longestLen = 0;
            int startIdx = 0;
            subStr.Add(s[0], 0);
            longestLen = 1;
            for (int currIdx = 1; currIdx < s.Length; currIdx++)
            {
                if (subStr.ContainsKey(s[currIdx]))
                {
                    int duplicatedIdx = subStr[s[currIdx]];
                    while ( startIdx <= duplicatedIdx)
                    {
                        if (subStr.ContainsKey(s[startIdx]))
                        {
                            subStr.Remove(s[startIdx]);
                        }
                        startIdx++;
                    }
                }
                
                subStr.Add(s[currIdx], currIdx);
                longestLen = Math.Max(longestLen, subStr.Count);
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

            for(int i = 0; i < s2Len- s1Len; i++)
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
            for(int i = 0; i < s1Arr.Length; i++)
            {
                if (s1Arr[i] != s2Arr[i])
                    return false;
            }

            return true;
        }


        #endregion


        #region | Breadth-First Search / Depth-First Searc | 

        /// <summary>
        /// 733. Flood Fill
        /// https://leetcode.com/problems/flood-fill/
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int rowLen = image.Length;
            int colLen = image[0].Length;
            bool[][] visited = new bool[rowLen][];
            for (int i = 0; i < rowLen; i++)
                visited[i] = new bool[colLen];



            return image;
        }
        private void FloodFillRecursive(int[][] image, int sr, int sc, int rowLen, int colLen, bool[][] visited, int oldColor, int newColor)
        {
            if (sr < 0 || sr >= rowLen || sc < 0 || sc >= colLen)
                return;
            else if (visited[sr][sc])
                return;

            if (image[sr][sc] == oldColor)
            {
                image[sr][sc] = newColor;
                visited[sr][sc] = true;
                FloodFillRecursive(image, sr-1, sc, rowLen, colLen, visited, oldColor, newColor);
                FloodFillRecursive(image, sr, sc-1, rowLen, colLen, visited, oldColor, newColor);
                FloodFillRecursive(image, sr+1, sc, rowLen, colLen, visited, oldColor, newColor);
                FloodFillRecursive(image, sr, sc+1, rowLen, colLen, visited, oldColor, newColor);
            }
        }

        /// <summary>
        /// 695. Max Area of Island
        /// https://leetcode.com/problems/max-area-of-island/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxAreaOfIsland(int[][] grid)
        {
            return 0;
        }


        #endregion


    }
}
