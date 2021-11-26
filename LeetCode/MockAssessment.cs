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
    }
}
