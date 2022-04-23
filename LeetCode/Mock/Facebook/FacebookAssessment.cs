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
    }
}
