using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class AuguestChallenge2021
    {
        public static bool CanReorderDoubled(int[] arr)
        {
            List<int> negativeNums = new List<int>();
            List<int> positiveNums = new List<int>();
            List<int> zeroNums = new List<int>();
            Array.Sort(arr);
            foreach (int n in arr)
            {
                if (n == 0)
                    zeroNums.Add(0);
                else if (n < 0)
                    negativeNums.Add(n);
                else
                    positiveNums.Add(n);
            }

            if (zeroNums.Count % 2 != 0
                || positiveNums.Count % 2 != 0
                || negativeNums.Count % 2 != 0)
                return false;

            int i = 0;
            while (positiveNums.Count > 0)
            {
                if (positiveNums.Remove(2 * positiveNums[i]) == false)
                    break;
                else
                    positiveNums.RemoveAt(i);
            }

            if (positiveNums.Count == 0)
            {
                while (negativeNums.Count > 0)
                {
                    i = negativeNums.Count-1;
                    if (negativeNums.Contains(negativeNums[i] / 2))
                    {
                        int tmp = negativeNums[i] / 2;
                        negativeNums.RemoveAt(i);
                        negativeNums.Contains(tmp);
                    }
                    else
                        break;
                }

                if (negativeNums.Count == 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

    }
}
