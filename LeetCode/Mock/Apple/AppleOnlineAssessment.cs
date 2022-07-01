using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Mock.Apple
{
    public class AppleOnlineAssessment
    {
        #region | Online Assessment #1 |

        /// <summary>
        /// 246. Strobogrammatic Number
        /// https://leetcode.com/problems/strobogrammatic-number/
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsStrobogrammatic(string num)
        {
            //0 1 2 3 4 5 6 7 8 9
            //0 1 8
            //6 9
            //6009
            //16091
            //10
            //01
            string newNum = "";
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '0' || num[i] == '1' || num[i] == '8')
                    newNum = num[i] + newNum;
                else if (num[i] == '6')
                    newNum = '9' + newNum;
                else if (num[i] == '9')
                    newNum = '6' + newNum;
                else
                    return false;
            }

            return newNum.Equals(num);
        }

        /// <summary>
        /// 82. Remove Duplicates from Sorted List II
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode newHead = new ListNode(-1, head);
            ListNode currNew = newHead;
            while (head != null)
            {
                if (head.next != null && head.val == head.next.val)
                {
                    while (head.next != null && head.val == head.next.val)
                        head = head.next;
                    currNew.next = head.next;
                }
                else
                    currNew = currNew.next;

                head = head.next;
            }

            return newHead.next;
        }

        #endregion

        #region | Online Assessment #2 | 

        /// <summary>
        /// 884. Uncommon Words from Two Sentences
        /// https://leetcode.com/problems/uncommon-words-from-two-sentences/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public string[] UncommonFromSentences(string s1, string s2)
        {
            //word, count
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] s1Arr = s1.Split(" ".ToCharArray());
            string[] s2Arr = s2.Split(" ".ToCharArray());
            AddWordInDic(dic, s1Arr);
            AddWordInDic(dic, s2Arr);
            List<string> ans = new List<string>();
            foreach(var w in dic)
            {
                if (w.Value == 1)
                    ans.Add(w.Key);
            }
            return ans.ToArray();
        }
        private void AddWordInDic(Dictionary<string, int> dic, string[] words)
        {
            foreach (string w in words)
            {
                if (dic.ContainsKey(w))
                    dic[w]++;
                else
                    dic.Add(w, 1);
            }
        }


        /// <summary>
        /// 1196. How Many Apples Can You Put into the Basket
        /// https://leetcode.com/problems/how-many-apples-can-you-put-into-the-basket/
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public int MaxNumberOfApples(int[] weight)
        {
            Array.Sort(weight);
            int sum = 0;
            int ans = 0;
            for (int i = 0; i < weight.Length; i++)
            {
                sum += weight[i];
                if (sum <= 5000)
                    ans++;
                else
                    return ans;
            }
            return ans;

            //Approach 3: Bucket Sort
            //// initialize the bucket to store all elements
            //int size = -1;
            //for (Integer weight: arr)
            //{
            //    size = Math.max(size, weight);
            //}
            //int[] bucket = new int[size + 1];
            //for (Integer weight: arr)
            //{
            //    bucket[weight]++;
            //}

            //int apples = 0, units = 0;
            //for (int i = 0; i < size + 1; i++)
            //{
            //    // if we have apples of i units of weight
            //    if (bucket[i] != 0)
            //    {
            //        // we need to make sure that:
            //        // 1. we do not take more apples than those provided
            //        // 2. we do not exceed 5000 units of weight
            //        int take = Math.min(bucket[i], (5000 - units) / i);

            //        if (take == 0)
            //        {
            //            break;
            //        }
            //        units += take * i;
            //        apples += take;

            //    }
            //}
            //return apples;
        }



        #endregion

        #region | Online Assessment #3 | 

        /// <summary>
        /// 27. Remove Element
        /// https://leetcode.com/problems/remove-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            int ans = 0;
            int cursor = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[cursor++] = nums[i];
                    ans++;
                }
            }
            return ans;
        }


        /// <summary>
        /// 39. Combination Sum
        /// https://leetcode.com/problems/combination-sum/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> results = new List<IList<int>>();
            CombinationCases(candidates, target, 0, new List<int>(), results);

            return results;
        }
        private void CombinationCases(int[] candidates, int target, int idx, IList<int> currCombination, IList<IList<int>> allCombinaions)
        {
            if (target == 0)
            {
                List<int> tmp = new List<int>();
                foreach (int i in currCombination)
                    tmp.Add(i);
                allCombinaions.Add(tmp);
                return;
            }
            else if (idx >= candidates.Length || target < 0)
                return;
            else
            {
                currCombination.Add(candidates[idx]);
                CombinationCases(candidates, target - candidates[idx], idx, currCombination, allCombinaions);
                currCombination.RemoveAt(currCombination.Count - 1);
                CombinationCases(candidates, target, idx + 1, currCombination, allCombinaions);
            }
            return;
        }

        #endregion

        #region | Online Assessment #4 | 




        #endregion
    }
}
