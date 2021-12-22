using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        private int[] original;
        private int[] shuffleList;

        public Solution(int[] nums)
        {
            original = nums;
        }

        public int[] Reset()
        {
            return original;
        }

        public int[] Shuffle()
        {
            shuffleList = (int[])original.Clone();
            for (int i = 0; i < shuffleList.Length; i++)
            {
                SwapAt(shuffleList, i, new Random().Next(i, shuffleList.Length));
            }

            return shuffleList;
        }
        private void SwapAt(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
