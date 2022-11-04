using LeetCode.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Study
{
    public class LeetCode75_III
    {

        /// <summary>
        /// 191. Number of 1 Bits
        /// https://leetcode.com/problems/number-of-1-bits/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int retVal = 0;

            while (n != 0)
            {
                if ((n & 1) == 1)
                    retVal++;
                n = n >> 1;
            }

            return retVal;
        }


        /// <summary>
        /// 136. Single Number
        /// https://leetcode.com/problems/single-number/?envType=study-plan&id=level-3
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
        /// 90. Subsets II
        /// https://leetcode.com/problems/subsets-ii/?envType=study-plan&id=level-3
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);
            SubsetsWithDupR(nums, 0, new List<int>(), result);
            return result;
        }
        private void SubsetsWithDupR(int[] nums, int start, IList<int> subset, IList<IList<int>> result)
        {
            IList<int> tmp = new List<int>();
            foreach (int n in subset)
                tmp.Add(n);
            result.Add(tmp);

            for (int i = start; i < nums.Length; i++)
            {
                if (i != start && nums[i] == nums[i - 1])
                    continue;

                subset.Add(nums[i]);
                SubsetsWithDupR(nums, i + 1, subset, result);
                subset.RemoveAt(subset.Count - 1);
            }
        }




        /// <summary>
        /// /658. Find K Closest Elements
        /// https://leetcode.com/problems/find-k-closest-elements/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int n = arr.Length;
            int l = 0, r = n - 1;
            IList<int> ans = new List<int>();
            if (n <= k)
            {
                int i = 0;
                while (i < n)
                    ans.Add(arr[i++]);
                return ans;
            }

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] == x)
                {
                    l = mid;
                    r = l + 1;
                    break;
                }
                else if (arr[mid] > x)
                {
                    r = mid - 1;
                }
                else

                    l = mid + 1;
            }

            l--;
            r = l + 1;

            while (r - l - 1 < k)
            {
                if (l == -1)
                {
                    r++;
                    continue;
                }

                if (r == n || Math.Abs(arr[l] - x) <= Math.Abs(arr[r] - x))
                    l--;
                else
                    r++;
            }
            for (int i = l + 1; i < r; i++)
                ans.Add(arr[i]);

            return ans;
        }
    }
}
