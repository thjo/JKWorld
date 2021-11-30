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
            while( i < bits.Length)
            {
                if(bits[i] == 0)
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

            for(int i = 0; i < nums.Length; i++)
            {
                if (dp.ContainsKey(target - nums[i]))
                    return new int[] { dp[target - nums[i]], i };
                else
                {
                    if(dp.ContainsKey(nums[i]) == false)
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

        }

        #endregion
    }
}
