using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
