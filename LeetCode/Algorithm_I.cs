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
            if(string.IsNullOrWhiteSpace(subStr))
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





        #endregion
    }
}
