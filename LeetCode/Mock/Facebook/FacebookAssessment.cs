using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class FacebookAssessment
    {
        #region | Onlin Assessment - 4/22/2022 | 


        public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            int i1 = 0, i2 = 0, i3 = 0;
            int n1 = arr1.Length, n2 = arr2.Length, n3 = arr3.Length;
            IList<int> res = new List<int>();
            while (i1 < n1 && i2 < n2 && i3 < n3)
            {
                if (arr1[i1] == arr2[i2] && arr2[i2] == arr3[i3])
                {
                    res.Add(arr1[i1]);
                    i1++; i2++; i3++;
                }
                else
                {
                    int max = Math.Max(arr1[i1], arr2[i2]);
                    max = Math.Max(max, arr3[i3]);
                    if (arr1[i1] < max)
                        i1++;
                    if (arr2[i2] < max)
                        i2++;
                    if (arr3[i3] < max)
                        i3++;
                }
            }

            return res;
        }


        /// <summary>
        /// 496. Next Greater Element I
        /// https://leetcode.com/problems/next-greater-element-i/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            ////Bruce Force
            //int n1 = nums1.Length;
            //int n2 = nums2.Length;
            //Dictionary<int, int> map = new Dictionary<int, int>();
            //for (int i = 0; i < n2; i++)
            //{
            //    map.Add(nums2[i], i);
            //}
            //int[] res = new int[n1];
            //for (int idx = 0; idx < n1; idx++)
            //{
            //    int val = nums1[idx];
            //    res[idx] = -1;
            //    for (int i = map[val] + 1; i < n2; i++)
            //    {
            //        if (nums2[i] > val)
            //        {
            //            res[idx] = nums2[i];
            //            break;
            //        }
            //    }
            //}
            //return res;

            Dictionary<int, int> map = new Dictionary<int, int>();
            Stack<int> wait = new Stack<int>();

            for (int i = 0; i < nums2.Length; i++)
            {
                while (wait.Count > 0 && nums2[i] > wait.Peek())
                    map.Add(wait.Pop(), nums2[i]);
                wait.Push(nums2[i]);
            }

            while (wait.Count > 0)
                map.Add(wait.Pop(), -1);

            int[] res = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                res[i] = map[nums1[i]];
            }

            return res;
        }

        #endregion



        #region | Onlin Assessment - 4/23/2022 | 

        /// <summary>
        /// 938. Range Sum of BST
        /// https://leetcode.com/problems/range-sum-of-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            //IList<int> arr = new List<int>();
            int total = 0;
            InorderTraversals(root, low, high, ref total);
            return total;
        }
        private void InorderTraversals(TreeNode root, int low, int high, ref int total)
        {
            //, IList<int> arr) {
            if (root == null)
                return;

            if (root.val < low)
                InorderTraversals(root.right, low, high, ref total);
            else if (root.val > high)
                InorderTraversals(root.left, low, high, ref total);
            else
            {
                total += root.val;
                InorderTraversals(root.left, low, high, ref total);
                InorderTraversals(root.right, low, high, ref total);
            }
        }

        #endregion


        #region | Onlin Assessment - 4/24/2022 | 

        /// <summary>
        /// 121. Best Time to Buy and Sell Stock
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 1)
                return 0;

            int maxProfit = 0;
            int minVal = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (minVal > prices[i])
                {
                    minVal = prices[i];
                }
                else
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - minVal);
                }
            }
            return maxProfit;
        }

        /// <summary>
        /// 238. Product of Array Except Self
        /// https://leetcode.com/problems/product-of-array-except-self/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {

            int n = nums.Length;
            int[] answers = new int[n];

            int sum = 1;
            for (int i = 0; i < n; i++)
            {
                answers[i] = sum;
                sum *= nums[i];
            }
            sum = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                answers[i] = answers[i] * sum;
                sum *= nums[i];
            }

            return answers;
        }
        #endregion



    }
}
