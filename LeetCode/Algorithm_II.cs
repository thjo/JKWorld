using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_II
    {
        #region | Binary Search | 

        /// <summary>
        /// 34. Find First and Last Position of Element in Sorted Array
        /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };

            if (nums == null || nums.Length < 1)
                return result;

            int len = nums.Length - 1;
            result[0] = SearchRangeB(nums, target, 0, len, 0);
            result[1] = SearchRangeB(nums, target, 0, len, 1);

            return result;
        }
        private int SearchRangeB(int[] nums, int target, int startIdx, int endIdx, int flag)
        {
            //flag: 0, Starting position, 1: ending position
            if (startIdx > endIdx)
                return -1;

            int midIdx = (startIdx + endIdx) / 2;
            if (nums[midIdx] == target)
            {
                if (flag == 0)
                {
                    //Seeking starting position
                    while ((midIdx - 1) >= 0 && nums[midIdx - 1] == target)
                        midIdx--;

                    return midIdx;
                }
                else
                {
                    //Seeking ending position
                    while ((midIdx + 1) < nums.Length && nums[midIdx + 1] == target)
                        midIdx++;

                    return midIdx;
                }
            }
            else if (nums[midIdx] > target)
            {
                return SearchRangeB(nums, target, startIdx, midIdx - 1, flag);
            }
            else
            {
                return SearchRangeB(nums, target, midIdx + 1, nums.Length - 1, flag);
            }
        }


        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int retIdx = -1;
            int n = nums.Length - 1;
            retIdx = SearchB(nums, target, 0, n);

            return retIdx;
        }
        private int SearchB(int[] nums, int target, int startIdx, int endIdx)
        {
            if (startIdx > endIdx)
                return -1;

            int midIdx = (startIdx + endIdx) / 2;
            if (nums[midIdx] == target)
                return midIdx;

            /* If arr[l...mid] is sorted */
            if (nums[startIdx] <= nums[midIdx])
            {
                if (target >= nums[startIdx] && target <= nums[midIdx])
                    return SearchB(nums, target, startIdx, midIdx - 1);

                return SearchB(nums, target, midIdx + 1, nums.Length - 1);
            }
            else
            {
                /* If arr[l..mid] is not sorted, then arr[mid... r] must be sorted*/
                if (target >= nums[midIdx] && target <= nums[nums.Length - 1])
                    return SearchB(nums, target, midIdx + 1, nums.Length - 1);

                return SearchB(nums, target, startIdx, midIdx - 1);
            }
        }

        /// <summary>
        /// 74. Search a 2D Matrix
        /// https://leetcode.com/problems/search-a-2d-matrix/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rowLen = matrix.Length;
            int colLen = matrix[0].Length;

            int rowPos = SearchMatrixRowB(matrix, target, 0, rowLen - 1, rowLen, colLen);
            if (rowPos < 0 || rowPos > rowLen)
                return false;
            else if (matrix[rowPos][0] == target)
                return true;

            return SearchMatrixColB(matrix, target, rowPos, 0, colLen - 1, colLen);
        }
        private int SearchMatrixRowB(int[][] matrix, int target, int startIdx, int endIdx, int rowLen, int colLen)
        {
            if (startIdx > endIdx)
                return -1;

            int midIdx = (startIdx + endIdx) / 2;
            if (matrix[midIdx][0] <= target && matrix[midIdx][colLen - 1] >= target)
                return midIdx;

            if (matrix[midIdx][0] < target)
                return SearchMatrixRowB(matrix, target, midIdx + 1, rowLen - 1, rowLen, colLen);
            else
                return SearchMatrixRowB(matrix, target, startIdx, midIdx - 1, rowLen, colLen);
        }
        private bool SearchMatrixColB(int[][] matrix, int target, int row, int startIdx, int endIdx, int len)
        {
            if (startIdx > endIdx)
                return false;

            int midIdx = (startIdx + endIdx) / 2;
            if (matrix[row][midIdx] == target)
                return true;

            if (matrix[row][midIdx] < target)
                return SearchMatrixColB(matrix, target, row, midIdx + 1, len - 1, len);
            else
                return SearchMatrixColB(matrix, target, row, startIdx, midIdx - 1, len);
        }


        /// <summary>
        /// 153. Find Minimum in Rotated Sorted Array
        /// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];


            int left = 0, right = nums.Length - 1;

            //the array is sorted? 
            if (nums[left] < nums[right])
                return nums[left];


            while (right >= left)
            {
                int mid = left + (right - left) / 2;

                if (mid + 1 < nums.Length && nums[mid] > nums[mid + 1])
                    return nums[mid + 1];
                else if (mid - 1 >= 0 && nums[mid] < nums[mid - 1])
                    return nums[mid];

                if (nums[mid] > nums[0])
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// 162. Find Peak Element
        /// https://leetcode.com/problems/find-peak-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {
            return FindPeakElementB(nums, 0, nums.Length - 1);
        }
        private int FindPeakElementB(int[] nums, int l, int r)
        {
            if (l >= r)
                return l;

            int mid = (l + r) / 2;
            if (nums[mid] > nums[mid + 1])
                return FindPeakElementB(nums, l, mid);
            return FindPeakElementB(nums, mid + 1, r);
        }

        #endregion


        #region | Two Pointers | 

        /// <summary>
        /// 82. Remove Duplicates from Sorted List II
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

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

        /// <summary>
        /// 15. 3Sum
        /// https://leetcode.com/problems/3sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> groups = new List<IList<int>>();

            if (nums == null || nums.Length < 3)
                return groups;

            Array.Sort(nums);

            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1]) { continue; }
                int j = i + 1;
                int k = len - 1;
                while (j < k)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        IList<int> tmp = new List<int>();
                        tmp.Add(nums[i]); tmp.Add(nums[j]); tmp.Add(nums[k]);
                        groups.Add(tmp);
                        j++;
                        while (j < k && nums[j] == nums[j - 1]) { j++; }
                    }
                    else if (nums[i] + nums[j] + nums[k] > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return groups;
        }


        /// <summary>
        /// 844. Backspace String Compare
        /// https://leetcode.com/problems/backspace-string-compare/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool BackspaceCompare(string s, string t)
        {
            int sIdx = s.Length - 1, tIdx = t.Length - 1;
            int sBS = 0, tBS = 0;
            while (sIdx >= 0 || tIdx >= 0)
            {
                sBS = 0;
                tBS = 0;
                while (sIdx >= 0)
                {
                    if (s[sIdx] == '#') { sIdx--; sBS++; }
                    else if (sBS > 0) { sIdx--; sBS--; }
                    else { break; }
                }

                while (tIdx >= 0)
                {
                    if (t[tIdx] == '#') { tIdx--; tBS++; }
                    else if (tBS > 0) { tIdx--; tBS--; }
                    else { break; }
                }

                if ((sIdx >= 0) != (tIdx >= 0))
                    return false;
                if (sIdx >= 0 && tIdx >= 0 && s[sIdx] != t[tIdx])
                    return false;

                sIdx--; tIdx--;
            }

            return true;
        }



        #endregion



        #region | Sliding Window | 

        /// <summary>
        /// 438. Find All Anagrams in a String
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            IList<int> listOfAna = new List<int>();
            if (p.Length > s.Length)
                return listOfAna;

            Dictionary<char, int> pDic = new Dictionary<char, int>();
            Dictionary<char, int> slot = new Dictionary<char, int>();
            foreach (char c in p)
            {
                if (pDic.ContainsKey(c))
                    pDic[c]++;
                else
                    pDic.Add(c, 1);
            }
            int pLen = p.Length;
            for (int i = 0; i < pLen - 1; i++)
            {
                if (pDic.ContainsKey(s[i]))
                {
                    if (slot.ContainsKey(s[i]))
                        slot[s[i]]++;
                    else
                        slot.Add(s[i], 1);
                }
            }

            for (int i = pLen - 1; i < s.Length; i++)
            {
                int firstPos = i - pLen + 1;
                if (pDic.ContainsKey(s[i]))
                {
                    if (slot.ContainsKey(s[i]))
                        slot[s[i]]++;
                    else
                        slot.Add(s[i], 1);
                }

                if (CheckAnas(slot, pDic))
                    listOfAna.Add(firstPos);

                if (slot.ContainsKey(s[firstPos]))
                {
                    slot[s[firstPos]]--;
                    if (slot[s[firstPos]] == 0)
                        slot.Remove(s[firstPos]);
                }
            }

            return listOfAna;
        }
        private bool CheckAnas(Dictionary<char, int> slot, Dictionary<char, int> pDic)
        {
            foreach (var item in pDic)
            {
                if (slot.ContainsKey(item.Key) == false)
                    return false;

                else
                {
                    if (slot[item.Key] != item.Value)
                        return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 713. Subarray Product Less Than K
        /// https://leetcode.com/problems/subarray-product-less-than-k/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int start = 0, end = 0, mulVal = 1;
            int totalCnt = 0;
            while (end < nums.Length)
            {
                mulVal *= nums[end];

                while (mulVal >= k) mulVal /= nums[start++];
                totalCnt += end - start + 1;
                end++;
            }

            return totalCnt;
        }

        #endregion


        #region | Breadth-First Search / Depth-First Search | 

        /// <summary>
        /// 200. Number of Islands
        /// https://leetcode.com/problems/number-of-islands/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int cntIslands = 0;

            int rows = grid.Length;
            if (rows < 1)
                return 0;
            int cols = grid[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        visitIsland(grid, i, j, rows, cols);
                        cntIslands++;
                    }
                }
            }

            return cntIslands;
        }
        private void visitIsland(char[][] grid, int currRow, int currCol, int rows, int cols)
        {
            if (currRow < 0 || currRow >= rows
                || currCol < 0 || currCol >= cols
                || grid[currRow][currCol] != '1')
                return;

            grid[currRow][currCol] = '2';   //visited
            visitIsland(grid, currRow - 1, currCol, rows, cols);    //LEFT
            visitIsland(grid, currRow + 1, currCol, rows, cols);    //RIGHT
            visitIsland(grid, currRow, currCol - 1, rows, cols);    //TOP
            visitIsland(grid, currRow, currCol + 1, rows, cols);    //BOTTON
        }


        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            List<int> visited = new List<int>();
            int cntProvinces = 0;
            Queue<int> q = new Queue<int>();
            for (int city = 0; city < n; city++)
            {
                if (visited.Contains(city) == false)
                {
                    cntProvinces++;
                    FindCircleNumSearch(city, isConnected, n, visited);
                }
            }

            return cntProvinces;
        }
        private void FindCircleNumSearch(int start, int[][] isConnected, int n, List<int> visited)
        {
            visited.Add(start);

            for (int i = 0; i < n; i++)
            {
                if (isConnected[start][i] == 1 && visited.Contains(i) == false)
                    FindCircleNumSearch(i, isConnected, n, visited);
            }
        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;
            else if (s.val == t.val && IsSameTree(s, t))
                return true;
            else
                return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }
        private bool IsSameTree(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null)
            {
                return true;
            }

            if (n1 == null || n2 == null)
            {
                return false;
            }

            return n1.val == n2.val && IsSameTree(n1.left, n2.left) && IsSameTree(n1.right, n2.right);
        }

        /// <summary>
        /// 797. All Paths From Source to Target
        /// https://leetcode.com/problems/all-paths-from-source-to-target/
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<IList<int>> allPaths = new List<IList<int>>();
            List<int> path = new List<int>();
            path.Add(0);
            int targetNode = graph.Length - 1;
            AllPathsSourceTargetDFS(graph, 0, targetNode, path, allPaths);
            return allPaths;
        }
        private void AllPathsSourceTargetDFS(int[][] graph, int currNode, int targetNode, List<int> path, IList<IList<int>> allPaths)
        {
            if (currNode == targetNode)
            {
                IList<int> buff = new List<int>();
                foreach (int p in path)
                    buff.Add(p);

                allPaths.Add(buff);
            }
            else if (currNode > targetNode)
                return;

            if (graph[currNode] != null && graph[currNode].Length > 0)
            {
                for (int i = 0; i < graph[currNode].Length; i++)
                {
                    path.Add(graph[currNode][i]);
                    AllPathsSourceTargetDFS(graph, graph[currNode][i], targetNode, path, allPaths);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }



        #endregion



        #region | Recursion / Backtracking | 

        /// <summary>
        /// 78. Subsets
        /// https://leetcode.com/problems/subsets/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            res.Add(new List<int>());


            for(int i = 1; i<=nums.Length; i++)
                SubsetsR(nums, i, 0, new List<int>(), res);
            return res;
        }
        private void SubsetsR(int[] nums, int len, int start, IList<int> currSet, IList<IList<int>> res)
        {
            if (currSet.Count == len)
            {
                IList<int> tmp = new List<int>();
                foreach (int n in currSet)
                    tmp.Add(n);
                res.Add(tmp);
            }
            else if (start > nums.Length)
                return;

            for (int i = start; i < nums.Length; i++)
            {
                currSet.Add(nums[i]);
                SubsetsR(nums, len, start, currSet, res);
                currSet.RemoveAt(currSet.Count - 1);
            }
        }

        #endregion

    }




}
