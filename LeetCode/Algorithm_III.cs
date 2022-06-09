using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_III
    {
        int[] solution(int[] balances, string[] requests)
        {
            if (balances == null || balances.Length == 0)
                return new int[] { -1 };

            Queue<TransInfo> hisWithdraws = new Queue<TransInfo>();
            for (int i = 0; i < requests.Length; i++)
            {
                string req = requests[i];
                TransInfo tran = ConvertToTranInfo(req);
                if (tran == null)
                    return new int[] { (i + 1) * -1 };

                //Calculate cashback 
                while (hisWithdraws.Count > 0 && (tran.Timestamp - hisWithdraws.Peek().Timestamp) >= (long)24 * 60 * 60)
                {
                    TransInfo cashbackTran = hisWithdraws.Dequeue();
                    balances[cashbackTran.AccountId - 1] += (int)Math.Floor(cashbackTran.Amount * 0.02);
                }

                if (tran.Cmd == -1)
                    hisWithdraws.Enqueue(tran);

                //Calculate balance
                //Invalid a transaction
                if (tran.AccountId < 1 || tran.AccountId > balances.Length)
                    return new int[] { (i + 1) * -1 };

                //Calculate balance
                int newBal = balances[tran.AccountId - 1] + tran.Cmd * tran.Amount;
                //Invalid balance
                if (newBal < 0)
                    return new int[] { (i + 1) * -1 };

                balances[tran.AccountId - 1] = newBal;
            }

            return balances;
        }
        private TransInfo ConvertToTranInfo(string request)
        {
            //Validate a request        
            if (string.IsNullOrWhiteSpace(request))
                return null;
            string[] cmds = request.Split(" ".ToCharArray());
            if (cmds.Length != 4)
                return null;

            int cmd = 1;  //deposit
            if (cmds[0] == "withdraw")
                cmd = -1; //withdraw
            long timestamp = long.Parse(cmds[1]);
            int acctId = int.Parse(cmds[2]);
            int amt = int.Parse(cmds[3]);
            return new TransInfo(cmd, timestamp, acctId, amt);
        }
        public class TransInfo
        {
            public int Cmd; //1: deposite, -1: withdraw
            public long Timestamp;
            public int AccountId;
            public int Amount;
            public TransInfo(int cmd, long timestamp, int accountId, int amount)
            {
                Cmd = cmd;
                Timestamp = timestamp;
                AccountId = accountId;
                Amount = amount;
            }
        }




        /// <summary>
        /// 1060. Missing Element in Sorted Array
        /// https://leetcode.com/problems/missing-element-in-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MissingElement(int[] nums, int k)
        {
            int min = nums[0];
            if (nums.Length == 1)
                return min + k;

            int l = 0, r = nums.Length - 1;
            if (k > getMissingNums(r, nums))
                return nums[r] + k - getMissingNums(r, nums);

            while (l < r)
            {
                int m = l + (r - l) / 2;
                int missing = getMissingNums(m, nums);
                if (missing < k)
                {
                    //search right side
                    l = m + 1;
                }
                else
                {
                    //search left side
                    r = m;
                }
            }

            return nums[l - 1] + k - getMissingNums(l - 1, nums);

        }
        private int getMissingNums(int idx, int[] nums)
        {
            return nums[idx] - (nums[0] + idx);
        }
    }
}
