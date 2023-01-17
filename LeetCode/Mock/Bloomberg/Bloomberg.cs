using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Mock.Bloomberg
{
    public class Bloomberg
    {
        #region | 12/06/2022 - Online Assessment | 

        /// <summary>
        /// 404. Sum of Left Leaves
        /// https://leetcode.com/problems/sum-of-left-leaves/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumOfLeftLeaves1(TreeNode root)
        {
            int sum = 0;
            Queue<CNode> q = new Queue<CNode>();
            q.Enqueue(new CNode() { Node = root, Type = 0 });

            while (q.Count > 0)
            {
                CNode currNode = q.Dequeue();
                if (currNode.Type == 1
                   && currNode.Node.left == null
                   && currNode.Node.right == null)
                    sum += currNode.Node.val;
                if (currNode.Node.left != null)
                    q.Enqueue(new CNode() { Node = currNode.Node.left, Type = 1 });
                if (currNode.Node.right != null)
                    q.Enqueue(new CNode() { Node = currNode.Node.right, Type = 2 });
            }

            return sum;
        }
        public class CNode
        {
            public TreeNode Node;
            public int Type;    //0, 1: left, 2:right
        }
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return 0;

            return SumOfLeftLeavesR(root, false);
        }
        private int SumOfLeftLeavesR(TreeNode root, bool isLeftNode)
        {
            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
                return isLeftNode == true ? root.val : 0;
            else
            {
                return SumOfLeftLeavesR(root.left, true) + SumOfLeftLeavesR(root.right, false);
            }
        }


        /// <summary>
        /// 746. Min Cost Climbing Stairs
        /// https://leetcode.com/problems/min-cost-climbing-stairs/
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int[] dp = new int[n];
            dp[0] = cost[0];
            dp[1] = cost[1];

            int i = 2;
            while (i < n)
            {
                dp[i] = Math.Min(dp[i - 2], dp[i - 1]) + cost[i];
                i++;
            }

            return Math.Min(dp[i - 1], dp[i - 2]);
        }

        #endregion

        #region | 12/06/2022 - Online Assessment | 

        /// <summary>
        /// 35. Search Insert Position
        /// https://leetcode.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int n = nums.Length;
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return right + 1;
        }


        /// <summary>
        /// 547. Number of Provinces
        /// https://leetcode.com/problems/number-of-provinces/
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum(int[][] isConnected)
        {
            int numOfCities = isConnected.Length;
            HashSet<int> visited = new HashSet<int>();
            int cntCircle = 0;
            for (int c = 0; c < numOfCities; c++)
            {
                if (visited.Contains(c) == false)
                {
                    cntCircle++;
                    FindCircleNumR(isConnected, c, visited);
                }
            }

            return cntCircle;
        }
        private void FindCircleNumR(int[][] isConnected, int start, HashSet<int> visited)
        {
            visited.Add(start);

            for (int i = 0; i < isConnected.Length; i++)
            {
                if (isConnected[start][i] == 1 && visited.Contains(i) == false)
                {
                    FindCircleNumR(isConnected, i, visited);
                }
            }
        }


        #endregion

        #region | 12/07/2022 - Online Assessment | 

        /// <summary>
        /// 118. Pascal's Triangle
        /// https://leetcode.com/problems/pascals-triangle/
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            for (int lv = 1; lv <= numRows; lv++)
            {
                //Per level
                ans.Add(new List<int>());
                ans[lv - 1].Add(1);
                for (int col = 2; col <= lv; col++)
                {
                    if (lv > 1 && col != lv)
                    {
                        ans[lv - 1].Add(ans[lv - 2][col - 2] + ans[lv - 2][col - 1]);
                    }
                    else
                        ans[lv - 1].Add(1);
                }
            }
            return ans;
        }


        /// <summary>
        /// 662. Maximum Width of Binary Tree
        /// https://leetcode.com/problems/maximum-width-of-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        int maxWidth;
        Dictionary<int, int> leftMostPos;
        public int WidthOfBinaryTree(TreeNode root)
        {
            maxWidth = 0;
            leftMostPos = new Dictionary<int, int>();
            GetWidth(root, 0, 0);

            return maxWidth;
        }
        private void GetWidth(TreeNode root, int depth, int position)
        {
            if (root == null) return;

            if (leftMostPos.ContainsKey(depth) == false)
                leftMostPos.Add(depth, position);

            maxWidth = Math.Max(maxWidth, position - leftMostPos[depth] + 1);

            GetWidth(root.left, depth + 1, position * 2);
            GetWidth(root.right, depth + 1, position * 2 + 1);
        }


        #endregion

        #region | 12/08/22 - Online Assessment | 

        /// <summary>
        /// 1169. Invalid Transactions
        /// https://leetcode.com/problems/invalid-transactions/description/
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public IList<string> InvalidTransactions(string[] transactions)
        {
            List<string> ans = new List<string>();
            if (transactions == null || transactions.Length < 1)
                return ans;

            var dict = new Dictionary<string, List<Transaction>>();
            var dupChecker = new Dictionary<string, int>();
            foreach (string t in transactions)
            {
                if (dupChecker.ContainsKey(t))
                    dupChecker[t]++;
                else
                    dupChecker.Add(t, 1);
            }

            HashSet<string> invalids = new HashSet<string>();
            foreach (var tInfo in dupChecker)
            {
                var tran = new Transaction(tInfo.Key);

                if( dict.ContainsKey(tran.Name) == false)
                {
                    List<Transaction> buff = new List<Transaction>();
                    buff.Add(tran);
                    dict.Add(tran.Name, buff);
                }
                else
                {
                    dict[tran.Name].Add(tran);
                }
            }

            foreach(var tVal in dict)
            {
                var sortedVal = from tRecord in tVal.Value
                                orderby tRecord.Time
                                select tRecord;
                List<Transaction> sTrans = sortedVal.ToList<Transaction>();

                for(int i = 0; i < sTrans.Count; i++)
                {
                    if(sTrans[i].Amount > 1000)
                    {
                        if (invalids.Contains(sTrans[i].ToString()) == false)
                            invalids.Add(sTrans[i].ToString());
                    }

                    for(int j = i+1; j < sTrans.Count; j++)
                    {
                        if (sTrans[j].Time - sTrans[i].Time > 60)
                            break;
                        else 
                        {
                            if (sTrans[j].City != sTrans[i].City)
                            {
                                if (invalids.Contains(sTrans[j].ToString()) == false)
                                    invalids.Add(sTrans[j].ToString());
                                if (invalids.Contains(sTrans[i].ToString()) == false)
                                    invalids.Add(sTrans[i].ToString());
                            }
                        }
                    }
                }
            }

            foreach (var invTran in invalids)
                ans.Add(invTran);

            foreach (var dd in dupChecker)
            {
                if( dd.Value >= 2 )
                {
                    for (int i = 0; i < dd.Value-1; i++)
                        ans.Add(dd.Key);
                }
            }
            return ans;
        }
        private class Transaction
        {
            private readonly string originTran;
            public string Name { get; }
            public int Time { get; }
            public int Amount { get; }
            public string City { get; }
            public Transaction(string tran)
            {
                originTran = tran;
                if (string.IsNullOrWhiteSpace(tran) == false)
                {
                    var t = tran.Split(',');
                    Name = t[0];
                    Time = Convert.ToInt32(t[1]);
                    Amount = Convert.ToInt32(t[2]);
                    City = t[3];
                }
            }
            public override string ToString()
            {
                return originTran;
            }
        }


        /// <summary>
        /// 1029. Two City Scheduling
        /// https://leetcode.com/problems/two-city-scheduling/description/
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public int TwoCitySchedCost1(int[][] costs)
        {
            //DFS
            Dictionary<string, int> dp = new Dictionary<string, int>();
            return TwoCitySchedCostDFS(costs, costs.Length, 0, 0, 0, dp);
        }
        private int TwoCitySchedCostDFS(int[][] costs, int len, int iPerson, int cntC1, int cntC2, Dictionary<string, int> dp)
        {
            if (iPerson >= len)
                return 0;
            string key = string.Format("{0}^{1}^{2}", iPerson, cntC1, cntC2);
            if (dp.ContainsKey(key))
                return dp[key];

            //Choose city1
            int c1 = int.MaxValue, c2 = int.MaxValue;
            if( cntC1 < len/2)
                c1 = costs[iPerson][0] + TwoCitySchedCostDFS(costs, len, iPerson + 1, cntC1+1, cntC2, dp);
            if( cntC2 < len/2)
                c2 = costs[iPerson][1] + TwoCitySchedCostDFS(costs, len, iPerson + 1, cntC1, cntC2+1, dp);

            dp.Add(key, Math.Min(c1, c2));
            return dp[key];
        }
        public int TwoCitySchedCost2(int[][] costs)
        {
            //Greedy
            //diff = [B-A]
            int n = costs.Length;
            int[][] diff = new int[n][];
            for(int i = 0; i < n; i++)
            {
                diff[i] = new int[3];
                //City2 - City1
                diff[i][0] = costs[i][1] - costs[i][0];
                diff[i][1] = costs[i][0];
                diff[i][2] = costs[i][1];
            }
            var sortedDiffs= diff.OrderBy(x => x[0]);
            int idx = 0;
            int ans = 0;
            foreach(var val in sortedDiffs)
            {
                if (idx < n / 2)
                {
                    //Take City 2;
                    ans += val[2];
                }
                else
                    ans += val[1];
                idx++;
            }

            return ans;
        }

        #endregion



        #region | 12/10/2022 - Phone Interview | 

        /// <summary>
        /// 1200. Minimum Absolute Difference
        /// https://leetcode.com/problems/minimum-absolute-difference/description/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            //Sort the array
            Array.Sort(arr);
            int minVal = 1000000 * 2 + 1;   //Max difference

            for (int i = 0; i < arr.Length - 1; i++)
            {
                //compute the difference between i, i+1
                int diff = Math.Abs(arr[i + 1] - arr[i]);
                if (diff <= minVal)
                {

                    if (diff < minVal)
                    {
                        //Update the minVal to the diff value
                        minVal = diff;
                        //Clear the answer array
                        ans.Clear();
                    }
                    //Add this pairs into the answer array
                    IList<int> newPairs = new List<int>();
                    newPairs.Add(arr[i]); newPairs.Add(arr[i + 1]);
                    ans.Add(newPairs);
                }
            }   //End for

            return ans;
        }


        /// <summary>
        /// 1396. Design Underground System
        /// https://leetcode.com/problems/design-underground-system/
        /// </summary>
        public class UndergroundSystem
        {
            private class BoardingInfo
            {
                public int ID;
                public string StationName;
                public int Time;
                public bool IsCheckIn;
                public BoardingInfo(int id, string station, int t, bool isCheckIn)
                {
                    ID = id;
                    StationName = station;
                    Time = t;
                    IsCheckIn = isCheckIn;
                }
            }

            private Dictionary<int, BoardingInfo> _onBoardingCustomers;
            private Dictionary<string, int> _numberOfRecords;
            private Dictionary<string, double> _avgTime;
            public UndergroundSystem()
            {
                //id, checkIn/Out information
                _onBoardingCustomers = new Dictionary<int, BoardingInfo>();
                //station key(start^end), # of records
                _numberOfRecords = new Dictionary<string, int>();
                //station key(start^end), average time
                _avgTime = new Dictionary<string, double>();
            }

            public void CheckIn(int id, string stationName, int t)
            {
                BoardingInfo newCust = new BoardingInfo(id, stationName, t, true);
                _onBoardingCustomers.Add(id, newCust);
            }

            public void CheckOut(int id, string stationName, int t)
            {
                if (_onBoardingCustomers.ContainsKey(id) == false)
                    return; //invalid args

                BoardingInfo cust = _onBoardingCustomers[id];
                _onBoardingCustomers.Remove(id);
                string tmpKey = GetDurationKey(cust.StationName, stationName);
                int durationTime = t - cust.Time;

                //compute the average time and add this record into the history.
                if (_numberOfRecords.ContainsKey(tmpKey) == false)
                    _numberOfRecords.Add(tmpKey, 0);
                if (_avgTime.ContainsKey(tmpKey) == false)
                    _avgTime.Add(tmpKey, 0.0);


                double newAvgTime = (_avgTime[tmpKey] * _numberOfRecords[tmpKey] + durationTime) / (_numberOfRecords[tmpKey] + 1);
                _numberOfRecords[tmpKey]++;
                _avgTime[tmpKey] = newAvgTime;
            }

            public double GetAverageTime(string startStation, string endStation)
            {
                string tmpKey = GetDurationKey(startStation, endStation);
                if (_avgTime.ContainsKey(tmpKey))
                    return _avgTime[tmpKey];
                else
                    return 0.0;
            }

            private string GetDurationKey(string startStation, string endStation)
            {
                return string.Format("{0}^{1}", startStation, endStation);
            }
        }

        #endregion

        #region | 12/12/2022 - Phone Interview | 

        /// <summary>
        /// 81. Search in Rotated Sorted Array II
        /// https://leetcode.com/problems/search-in-rotated-sorted-array-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            int n = nums.Length;
            int l = 0, r = n - 1;
            while(l <= r)
            {
                int m = l + (r - l) / 2;
                if (nums[m] == target)
                    return true;
                
                if(nums[l] == nums[m])
                {
                    l++;
                    continue;
                }

                bool neededPivot = IsSearchExist(nums, l, nums[m]);
                bool targetArray = IsSearchExist(nums, l, target);
                if ( neededPivot ^ targetArray )
                {
                    if (neededPivot)
                        l = m + 1;
                    else
                        r = m - 1;
                }
                else
                {
                    if (nums[m] < target)
                        l = m + 1;
                    else
                        r = m - 1;
                }
            }

            return false;
        }
        private bool IsSearchHelper(int[] nums, int startIdx, int target)
        {
            return nums[startIdx] != target;
        }
        private bool IsSearchExist(int[] nums, int startIdx, int target)
        {
            return nums[startIdx] <= target;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (root == null)
                return false;

            Queue<TNodeC> q = new Queue<TNodeC>();
            q.Enqueue(new TNodeC() { Node = root, ParentNode = null, Lv = 1 });
            List<TNodeC> nodes = new List<TNodeC>();
            while (q.Count > 0 && nodes.Count != 2)
            {
                TNodeC currNd = q.Dequeue();
                if (currNd.Node.val == x || currNd.Node.val == y)
                    nodes.Add(currNd);

                if (currNd.Node.left != null)
                    q.Enqueue(new TNodeC() { Node = currNd.Node.left, ParentNode = currNd.Node, Lv = currNd.Lv + 1 });
                if (currNd.Node.right != null)
                    q.Enqueue(new TNodeC() { Node = currNd.Node.right, ParentNode = currNd.Node, Lv = currNd.Lv + 1 });
            }

            if (nodes.Count != 2)
                return false;

            if (nodes[0].Lv == nodes[1].Lv && nodes[0].ParentNode.val != nodes[1].ParentNode.val)
                return true;
            else
                return false;
        }
        class TNodeC
        {
            public TreeNode Node;
            public TreeNode ParentNode;
            public int Lv;
        }

        #endregion


    }
}
