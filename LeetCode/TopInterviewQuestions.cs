using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TopInterviewQuestions
    {
        #region | Strings | 

        //Count and Say
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/886/
        public string CountAndSay(int n)
        {
            if (n == 1)
                return "1";

            StringBuilder sbResult = new StringBuilder("1");
            for(int i = 2; i <= n; i++)
            {
                string strSeq = sbResult.ToString();
                sbResult.Clear();
                int count = 1;

                for (int idx = 1; idx < strSeq.Length; idx++)
                {
                    if (strSeq[idx - 1] == strSeq[idx])
                        count++;
                    else
                    {
                        sbResult.AppendFormat("{0}{1}", count, strSeq[idx-1]);
                        count = 1;
                    }
                }
                sbResult.AppendFormat("{0}{1}", count, strSeq[strSeq.Length - 1]);            
            }

            return sbResult.ToString();
        }


        //Longest Common Prefix
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/887/
        public string LongestCommonPrefix(string[] strs)
        {
            return "";
        }

        #endregion
    }
}
