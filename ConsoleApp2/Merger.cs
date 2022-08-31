using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    /*
     * Design a function to merge any two lists, up to a specified
     * limit of elements.
     *
     * The lists will be integers in ascending order.
     *
     * For example:
     *   L1 = [-3, -1, 2, 5, 6, 22]
     *   L2 = [-2,  0, 1, 3, 4, 11]
     *
     *   merge(L1, L2, 4) = [-3, -2, -1, 0]
     *   //validation
     *   L1 = [-3]
     *   L2 = [-2, 0]
     *   4
    */
    public class Merger
    {
        public List<int> Merge(int[] l1, int[] l2, int len)
        {
            if( l1 == null || l2 == null )
            {
                //TODO

            }

            int idx1 = 0, idx2 = 0;
            int n1 = l1.Length, n2 = l2.Length;
            List<int> ans = new List<int>();
            while( idx1 < n1 && idx2 < n2 && ans.Count < len )
            {
                if(l1[idx1] < l2[idx2])
                    ans.Add(l1[idx1++]);
                else
                {
                    ans.Add(l2[idx2++]);
                }
            }

            //if there are still aval data in L1
            while (ans.Count < len && idx1 < n1)
            {
                ans.Add(l1[idx1++]);
            }

            while (ans.Count < len && idx2 < n2)
            {
                ans.Add(l2[idx2++]);
            }

            return ans;
        }
    }
}
