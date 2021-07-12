using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TopInterviewQuestions_Strings
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
            if (strs == null || strs.Length < 1)
                return "";

            int shortestLen = strs[0].Length;
            for (int sIdx = 1; sIdx < strs.Length; sIdx++)
            {
                if (strs[sIdx].Length < shortestLen)
                    shortestLen = strs[sIdx].Length;
            }
            StringBuilder sb = new StringBuilder();
            int i = 0;
            bool isContinue = true;
            while (isContinue && i < shortestLen)
            {
                char c = strs[0][i];
                for(int sIdx = 1; sIdx < strs.Length; sIdx++)
                {
                    if (c == strs[sIdx][i])
                        continue;
                    else
                    {
                        isContinue = false;
                        break;
                    }
                }

                if (isContinue)
                    sb.Append(c);
                i++;
            }
            return sb.ToString();
        }

        #endregion
    }
}
