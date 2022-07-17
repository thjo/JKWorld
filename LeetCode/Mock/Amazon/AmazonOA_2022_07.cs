using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AmazonOA_2022_07
    {
        //1.Find First Palindromic String in the Array
        /// <summary>
        /// 2108. Find First Palindromic String in the Array
        /// https://leetcode.com/problems/find-first-palindromic-string-in-the-array/
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string FirstPalindrome(string[] words)
        {
            foreach(string w in words)
            {
                if (IsPalindrome(w))
                    return w;
            }
            return string.Empty;
        }
        private bool IsPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l <= r)
            {
                if (s[l++] != s[r--])
                    return false;
            }
            return true;
        }


        //2.Adding Spaces to a String
        /// <summary>
        /// 2109. Adding Spaces to a String
        /// https://leetcode.com/problems/adding-spaces-to-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="spaces"></param>
        /// <returns></returns>
        public string AddSpaces(string s, int[] spaces)
        {
            StringBuilder ans = new StringBuilder();

            int startPos = 0;
            for (int p = 0; p < spaces.Length; p++)
            {
                int pos = spaces[p];
                ans.Append(s.Substring(startPos, pos - startPos));
                ans.Append(" ");
                startPos = pos;
            }
            if (startPos < s.Length)
                ans.Append(s.Substring(startPos, s.Length - startPos));

            return ans.ToString();
        }


        //3.Number of Smooth Descent Periods of a Stock
        /// <summary>
        /// 2110. Number of Smooth Descent Periods of a Stock
        /// https://leetcode.com/problems/number-of-smooth-descent-periods-of-a-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public long GetDescentPeriods(int[] prices)
        {

        }


        //4.Minimum Operations to Make the Array K-Increasing
        /// <summary>
        /// 2111. Minimum Operations to Make the Array K-Increasing
        /// https://leetcode.com/problems/minimum-operations-to-make-the-array-k-increasing/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KIncreasing(int[] arr, int k)
        {

        }


        //5.Divide a String Into Groups of Size k



        //6.Minimum Moves to Reach Target Score



        //7.Solving Questions With Brainpower



        //8.Maximum Running Time of N Computers



        //9.Keep Multiplying Found Values by Two



        //10.All Divisions With the Highest Score of a Binary Array



        //11.Find Substring With Given Hash Value



        //12.Groups of Strings



        //13.Count Operations to Obtain Zero



        //14.Minimum Operations to Make the Array Alternating



        //15.Removing Minimum Number of Magic Beans



        //16.Maximum AND Sum of Array
    }
}
