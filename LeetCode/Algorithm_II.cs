﻿using System;
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


        /// <summary>
        /// 1091. Shortest Path in Binary Matrix
        /// https://leetcode.com/problems/shortest-path-in-binary-matrix/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid == null)
                return -1;
            else if (grid.Length <= 1)
                return grid.Length;

            int n = grid.Length;
            int[][] directions = new int[8][];
            directions[0] = new int[] { -1, 0 };    //Top
            directions[1] = new int[] { -1, -1 };    //Top & Left
            directions[2] = new int[] { -1, 1 };    //Top & Right
            directions[3] = new int[] { 0, -1 };    //Left
            directions[4] = new int[] { 0, 1 };    //Right
            directions[5] = new int[] { 1, 0 };    //Bottom
            directions[6] = new int[] { 1, -1 };    //Bottom & Left
            directions[7] = new int[] { 1, 1 };    //Bottom & Right

            return ShortestPathBinaryMatrixBFS(grid, 0, 0, n-1, n-1, n, directions);
        }
        private int ShortestPathBinaryMatrixBFS(int[][] grid, int sRow, int sCol, int eRow, int eCol, int n, int[][] directions)
        {
            if (grid[sRow][sCol] != 0 || grid[eRow][eCol] != 0)
                return -1;

            grid[sRow][sCol] = 2;   //Visited
            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[] { sRow, sCol, 1 });

            while(q.Count > 0)
            {
                int[] currNode = q.Dequeue();
                if (currNode[0] == eRow && currNode[1] == eCol)
                    return currNode[2];

                for (int d = 0; d < directions.Length; d++)
                {
                    int row = currNode[0] + directions[d][0];
                    int col = currNode[1] + directions[d][1];
                    if (row >= 0 && col >= 0 && row < n && col < n
                        && grid[row][col] == 0)
                    {
                        grid[row][col] = 2;
                        q.Enqueue(new int[] { row, col, currNode[2] + 1 });
                    }
                }
            }

            return -1;
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

            SubsetsR(nums, 0, new List<int>(), res);
            return res;
        }
        private void SubsetsR(int[] nums, int start, IList<int> currSet, IList<IList<int>> res)
        {
            IList<int> tmp = new List<int>();
            foreach (int n in currSet)
                tmp.Add(n);
            res.Add(tmp);
            for(int i = start; i < nums.Length; i++)
            {
                currSet.Add(nums[i]);
                SubsetsR(nums, i + 1, currSet, res);
                currSet.RemoveAt(currSet.Count - 1);
            }
        }

        /// <summary>
        /// 90. Subsets II
        /// https://leetcode.com/problems/subsets-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);
            SubsetsWithDupR(nums, 0, new List<int>(), result);
            return result;
        }
        private void SubsetsWithDupR(int[] nums, int start, IList<int> subset, IList<IList<int>> result)
        {
            IList<int> tmp = new List<int>();
            foreach (int n in subset)
                tmp.Add(n);
            result.Add(tmp);

            for(int i = start; i < nums.Length; i++)
            {
                if (i != start && nums[i] == nums[i - 1])
                    continue;

                subset.Add(nums[i]);
                SubsetsWithDupR(nums, i+1, subset, result);
                subset.RemoveAt(subset.Count - 1);
            }
        }

        /// <summary>
        /// 47. Permutations II
        /// https://leetcode.com/problems/permutations-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            // count the occurrence of each number
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach(int n in nums)
            {
                if (map.ContainsKey(n))
                    map[n]++;
                else
                    map.Add(n, 1);
            }

            PermuteUniqueR(nums, map, nums.Length, new List<int>(), result);

            return result;
        }
        private void PermuteUniqueR(int[] nums, Dictionary<int, int> map, int len, IList<int> subset, IList<IList<int>> result)
        {
            if( subset.Count == len)
            {
                IList<int> tmp = new List<int>();
                foreach (int n in subset)
                    tmp.Add(n);
                result.Add(tmp);
                return;
            }

            foreach(var v in map)
            {
                if (v.Value == 0)
                    continue;

                subset.Add(v.Key);
                map[v.Key]--;

                PermuteUniqueR(nums, map, nums.Length, subset, result);

                subset.RemoveAt(subset.Count-1);
                map[v.Key]++;
            }
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


        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(candidates);
            CombinationSum2(candidates, target, 0, new List<int>(), result);

            return result;
        }
        private void CombinationSum2(int[] candidates, int target, int startIdx, IList<int> subset, IList<IList<int>> result)
        {
            if (target == 0)
            {
                List<int> tmp = new List<int>();
                foreach (int i in subset)
                    tmp.Add(i);
                result.Add(tmp);
                return;
            }
            else if (target < 0)
                return;
            else
            {
                for(int i = startIdx; i < candidates.Length; i++)
                {
                    if (i > startIdx && candidates[i] == candidates[i - 1])
                        continue;

                    subset.Add(candidates[i]);
                    CombinationSum2(candidates, target- candidates[i], i+1, subset, result);
                    subset.RemoveAt(subset.Count - 1);
                }
            }
        }

        /// <summary>
        /// 22. Generate Parentheses
        /// https://leetcode.com/problems/generate-parentheses/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            List<char> pair = new List<char>();
            pair.Add('(');
            GenerateParenthesisR(result, n, 1, 0, pair);
            return result;
        }
        private void GenerateParenthesisR(IList<string> result, int n, int usedOpened, int usedClosed, List<char> pair)
        {
            if( usedOpened == n && usedClosed == n)
            {
                result.Add(new string(pair.ToArray()));
                return;
            }

            if( usedOpened < n)
            {
                pair.Add('(');
                GenerateParenthesisR(result, n, usedOpened+1, usedClosed, pair);
                pair.RemoveAt(pair.Count - 1);
            }
            if( usedClosed < n && usedClosed < usedOpened)
            {
                pair.Add(')');
                GenerateParenthesisR(result, n, usedOpened, usedClosed+1, pair);
                pair.RemoveAt(pair.Count - 1);
            }
        }

        /// <summary>
        /// 79. Word Search
        /// https://leetcode.com/problems/word-search/
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            for(int row = 0; row < board.Length; row++)
            {
                for(int col = 0; col < board[row].Length; col++)
                {
                    bool[][] visited = new bool[board.Length][];
                    for (int i = 0; i < board.Length; i++)
                        visited[i] = new bool[board[0].Length];

                    visited[row][col] = true;
                    if (Exist(board, word, board[row][col].ToString(), row, col, visited))
                        return true;
                }
            }

            return false;
        }
        private bool Exist(char[][] board, string word, string currWord, int row, int col, bool[][] visited)
        {
            if (currWord == word)
                return true;
            else if (currWord.Length >= word.Length)
                return false;
            else if (row > board.Length - 1 || row < 0)
                return false;
            else if (col > board[0].Length - 1 || col < 0)
                return false;

            bool retCheckd = false;
            if (currWord.Length < word.Length)
            {
                //left
                if (row > 0 && !visited[row - 1][col]) {
                    visited[row - 1][col] = true;
                    retCheckd = Exist(board, word, currWord + board[row - 1][col], row - 1, col, visited);
                    if (retCheckd) return retCheckd;
                    visited[row - 1][col] = false;
                    //currWord = currWord.Substring(0, currWord.Length - 1);
                }

                //right
                if (row < board.Length -1 && !visited[row + 1][col])
                {
                    visited[row + 1][col] = true;
                    retCheckd = Exist(board, word, currWord + board[row + 1][col], row + 1, col, visited);
                    if (retCheckd) return retCheckd;
                    visited[row + 1][col] = false;
                }

                //top
                if (col > 0 && !visited[row][col - 1])
                {
                    visited[row][col-1] = true;
                    retCheckd = Exist(board, word, currWord + board[row][col-1], row, col-1, visited);
                    if (retCheckd) return retCheckd;
                    visited[row][col-1] = false;
                }

                //bottom
                if (col < board[0].Length-1 && !visited[row][col + 1])
                {
                    visited[row][col + 1] = true;
                    retCheckd = Exist(board, word, currWord + board[row][col + 1], row, col + 1, visited);
                    if (retCheckd) return retCheckd;
                    visited[row][col + 1] = false;
                }
            }

            return retCheckd;
        }

        #endregion



        #region | Dynamic Programming | 


        /// <summary>
        /// 213. House Robber II
        /// https://leetcode.com/problems/house-robber-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            else if (nums.Length == 1)
                return nums[0];

            int max1 = RobRec(nums, 0, nums.Length - 2);
            int max2 = RobRec(nums, 1, nums.Length - 1);

            return Math.Max(max1, max2);

        }
        private int RobRec(int[] nums, int start, int end)
        {
            if (start == end)
                return nums[start];

            int[] dp = new int[nums.Length];
            dp[start] = nums[start];
            dp[start + 1] = Math.Max(nums[start], nums[start + 1]);

            for(int i = start + 2; i <= end; i++)
            {
                dp[i] = Math.Max(dp[i - 1], (dp[i - 2] + nums[i]));
            }

            return dp[end];
        }


        /// <summary>
        /// 55. Jump Game
        /// https://leetcode.com/problems/jump-game/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            //Dictionary<int, bool> dp = new Dictionary<int, bool>();
            //return CanJump(nums, nums.Length, 0, dp);

            //Greedy Algorithm
            if (nums.Length == 1)
                return true;

            int goal = nums.Length - 1;
            
            for(int currIdx = nums.Length - 2; currIdx >= 0; currIdx--)
            {
                if (nums[currIdx] + currIdx >= goal)
                    goal = Math.Min(currIdx, goal);
            }
            return goal == 0;
        }
        private bool CanJump(int[] nums, int n, int currIdx, Dictionary<int, bool> dp)
        {
            if (dp.ContainsKey(currIdx))
                return dp[currIdx];

            if (currIdx > n - 1)
            {
                dp.Add(currIdx, false);
                return false;
            }
            else if (currIdx == n - 1)
            {
                dp.Add(currIdx, true);
                return true;
            }

            int maxJumps = nums[currIdx];
            int jump = maxJumps;
            while ( jump > 0)
            {
                if (CanJump(nums, n, currIdx + jump, dp))
                    return true;
                
                jump--;
            }
            dp.Add(currIdx + jump, false);
            return false;
        }

        /// <summary>
        /// 62. Unique Paths
        /// https://leetcode.com/problems/unique-paths/
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();
            return UniquePathsDFS(0, 0, m, n, dp);
        }
        private int UniquePathsDFS(int i, int j, int m, int n, Dictionary<string, int> dp)
        {
            if (dp.ContainsKey(string.Format("{0}_{1}", i, j)))
                return dp[string.Format("{0}_{1}", i, j)];

            if (i == m - 1 && j == n - 1)
            {
                dp.Add(string.Format("{0}_{1}", i, j), 1);
                return 1;
            }

            int val = 0;
            if (i < m - 1 && j < n - 1)
            {
                val = UniquePathsDFS(i + 1, j, m, n, dp) + UniquePathsDFS(i, j + 1, m, n, dp);
            }
            else if (i < m - 1)
            {
                val = UniquePathsDFS(i + 1, j, m, n, dp);
            }
            else if (j < n - 1)
            {
                val = UniquePathsDFS(i, j + 1, m, n, dp);
            }

            dp.Add(string.Format("{0}_{1}", i, j), val);
            return val;
        }


        /// <summary>
        /// 413. Arithmetic Slices
        /// https://leetcode.com/problems/arithmetic-slices/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int numberOfArithmeticSlices(int[] nums)
        {
            if (nums == null || nums.Length < 3)
                return 0;

            int sum = 0;
            int[] dp = new int[nums.Length];
            dp[0] = 0; dp[1] = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2])
                    dp[i] = dp[i - 1] + 1;
                else
                    dp[i] = 0;

                sum += dp[i];
            }

            return sum;
        }



        /// <summary>
        /// 300. Longest Increasing Subsequence
        /// https://leetcode.com/problems/longest-increasing-subsequence/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            int[] longestDP = new int[nums.Length];
            int[] prevNums = new int[nums.Length];
            int longest = 1;
            for (int i = 0; i < longestDP.Length; i++)
                longestDP[i] = 1;

            for(int i = 1; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i] && longestDP[i] < longestDP[j] + 1)
                    {
                        longestDP[i] = longestDP[j] + 1;
                        prevNums[i] = nums[j];

                        longest = Math.Max(longest, longestDP[i]);
                    }
                }
            }

            return longest;
        }

        /// <summary>
        /// 673. Number of Longest Increasing Subsequence
        /// https://leetcode.com/problems/number-of-longest-increasing-subsequence/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindNumberOfLIS(int[] nums)
        {
            Dictionary<int,int> numOfSubSeqs = new Dictionary<int, int>();
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                dp[i] = 1;

            int longest = 1;
            numOfSubSeqs.Add(1, 1);
            for(int i = nums.Length -2; i >= 0; i--)
            {
                for(int j = nums.Length-1; j > i; j--)
                {
                    if (nums[j] > nums[i])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                        longest = Math.Max(longest, dp[i]);

                        if (numOfSubSeqs.ContainsKey(dp[i]))
                            numOfSubSeqs[dp[i]]++;
                        else
                            numOfSubSeqs.Add(dp[i], 1);
                    }
                }
            }

            return numOfSubSeqs[longest];
        }

        /// <summary>
        /// 1143. Longest Common Subsequence
        /// https://leetcode.com/problems/longest-common-subsequence/
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public int LongestCommonSubsequence(string text1, string text2)
        {
            //abcde      ace
            //     Equal: +1      abcd     ac     remove the last character
            // Not Equal: +0      MAX( (abcd, a) , (abc, ac) )
            //                   +0 
            //Focus on the last character.
            if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2))
                return 0;
            Dictionary<string, int> dp = new Dictionary<string, int>();
            return LongestCommonSubsequenceR(text1, text2, text1.Length-1, text2.Length-1, dp);
        }
        private int LongestCommonSubsequenceR(string text1, string text2, int end1, int end2, Dictionary<string,int> dp)
        {
            if (end1 < 0 || end2 < 0)
                return 0;
            else if (dp.ContainsKey(string.Format("{0}_{1}", end1, end2)))
                return dp[string.Format("{0}_{1}", end1, end2)];

            int longestLen = 0;
            if (text1[end1] == text2[end2])
                longestLen = 1 + LongestCommonSubsequenceR(text1, text2, end1-1, end2-1, dp);
            else
            {
                longestLen = Math.Max(LongestCommonSubsequenceR(text1, text2, end1-1, end2, dp)
                                    , LongestCommonSubsequenceR(text1, text2, end1, end2-1, dp));
            }

            dp.Add(string.Format("{0}_{1}", end1, end2), longestLen);
            return longestLen;
        }


        /// <summary>
        /// 583. Delete Operation for Two Strings
        /// https://leetcode.com/problems/delete-operation-for-two-strings/
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            if (string.IsNullOrWhiteSpace(word1) && !string.IsNullOrWhiteSpace(word2))
                return word2.Length;
            else if (!string.IsNullOrWhiteSpace(word1) && string.IsNullOrWhiteSpace(word2))
                return word1.Length;

            Dictionary<string, int> dp = new Dictionary<string, int>();
            int lcs = LongestCommonSubsequenceR(word1, word2, word1.Length - 1, word2.Length - 1, dp);

            return word1.Length + word2.Length - (2 * lcs);
        }


        #endregion



        #region | Other | 


        /// <summary>
        /// 202. Happy Number
        /// https://leetcode.com/problems/happy-number/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {
            if (n == 1)
                return true;

            int slowRunner = n;
            int fastRunner = getNext(n);
            while (fastRunner != 1 && fastRunner != slowRunner)
            {
                slowRunner = getNext(slowRunner);
                fastRunner = getNext(getNext(fastRunner));
            }

            if (fastRunner == 1)
                return true;
            else
                return false;
        }

        private int getNext(int n)
        {
            int totalSum = 0;
            while (n > 0)
            {
                int d = n % 10;
                n = n / 10;
                totalSum += d * d;
            }

            return totalSum;
        }


        #endregion
    }




}
