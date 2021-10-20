using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SeptemberChallenge2021
    {
        /// <summary>
        /// Basic Calculator
        /// https://leetcode.com/explore/featured/card/september-leetcoding-challenge-2021/637/week-2-september-8th-september-14th/3971/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            int result = 0;
            if (s.Length == 1)
                return s[0] - '0';

            Stack<string> sDigits = new Stack<string>();
            string buff = string.Empty;
            foreach(char d in s)
            {
                int tmp = d - '0';
                if ( d == '(')
                {
                    if( string.IsNullOrWhiteSpace(buff) == false)
                    { 
                        sDigits.Push(buff);
                        buff = string.Empty;
                    }
                }
                else if(d == ')')
                {
                    int subTotal = CalOneOperation(buff);
                    if (sDigits.Count > 0)
                    {
                        buff = sDigits.Pop();
                        if (subTotal < 0 )
                        {
                            if (buff[buff.Length - 1] == '-')
                            {
                                buff = buff.Substring(0, buff.Length - 1) + "+";
                                subTotal = subTotal * -1;
                            }
                            else
                                buff = buff.Substring(0, buff.Length - 1);
                        }
                        buff += subTotal.ToString();
                    }
                    else
                        buff = subTotal.ToString();
                }
                else if (d == '+' || d == '-')
                {
                    buff += d;
                }
                else if ( tmp >= 0 && tmp <= 9)
                {
                    //digits
                    buff += d;
                }
                //Others - ignore
            }

            return result;
        }
        private int CalOneOperation(string s)
        {
            int result = 0;
            if (s[0] == '-')
                s = "0" + s;

            char previousOperator = ' ';
            string buff = string.Empty;
            foreach (char d in s)
            {
                if (d == '+' || d == '-')
                {
                    if (previousOperator == '-')
                        result -= int.Parse(buff);
                    else
                        result += int.Parse(buff);
                    buff = string.Empty;
                    previousOperator = d;
                }
                else
                {
                    buff += d;
                }
            }   //End Foreach

            if (previousOperator == '-')
                result -= int.Parse(buff);
            else
                result += int.Parse(buff);

            return result;
        }




    }
}
