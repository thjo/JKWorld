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
