using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
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

            if (nums == null || nums.Length < 3)
                return groups;

            Array.Sort(nums);

            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1]) { continue; }
                int j = i + 1;
                int k = len - 1;
                while (j < k)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        IList<int> tmp = new List<int>();
                        tmp.Add(nums[i]); tmp.Add(nums[j]); tmp.Add(nums[k]);
                        groups.Add(tmp);
                        j++;
                        while (j < k && nums[j] == nums[j - 1]) { j++; }
                    }
                    else if (nums[i] + nums[j] + nums[k] > 0)
                    {
                        k--;
                        while (j < k && nums[k] == nums[k + 1]) { k--; }
                    }
                    else
                    {
                        j++;
                        while (j < k && nums[j] == nums[j - 1]) { j++; }
                    }
                }
            }

            return groups;
        }


        //706. Design HashMap
        //https://leetcode.com/problems/design-hashmap/
        //DataStructures.MyHashMap



    }
}
