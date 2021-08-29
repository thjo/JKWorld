using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class Video_Algoriths
    {
        //Max Contiguous Subarray Sum
        //https://leetcode.com/problems/maximum-subarray/
        public int GetMaxContiguousSubarraySum(int[] nums)
        {
            if (nums == null || nums.Length < 1)
                return 0;

            int sum = nums[0];
            int max = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (sum + nums[i] > nums[i])
                    sum = sum + nums[i];
                else
                    sum = nums[i];

                if (max < sum)
                    max = sum;
            }

            return max;
        }


        //Clone A Linked List (With Random Pointers) - Linear Space Solution & Tricky Constant Space Solution
        //https://leetcode.com/problems/copy-list-with-random-pointer/
        //Time: O(n), Space: O(n)
        //Using Hashap
        public Node CopyRandomList1(Node head)
        {
            if (head == null)
                return head;

            Dictionary<int, Node> nodeMap = new Dictionary<int, Node>();
            int idx = 0;
            Node cpHead = CopyNode(head);
            nodeMap.Add(idx++, cpHead);
            Node currNode = head;
            while (currNode.next != null)
            {
                currNode = currNode.next;
                Node newND = CopyNode(currNode);
                nodeMap.Add(idx++, newND);
            }

            idx = 0;
            currNode = head;
            while (currNode.next != null)
            {
                currNode = currNode.next;
                nodeMap[idx].next = nodeMap.ContainsKey(idx + 1) ? nodeMap[idx + 1] : null;
                //nodeMap[idx].random = nodeMap.ContainsKey(currNode.randomIdx) ? nodeMap[currNode.randomIdx] : null; 
            }

            return cpHead;
        }

        //Time: O(n), Space: O(1)
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return head;

            //Set up Next Link
            Node currNode = head;
            Node newHead = null;
            while (currNode != null)
            {
                Node newND = CopyNode(currNode);
                if (newHead == null)
                    newHead = newND;
                newND.next = currNode.next;
                currNode.next = newND;
                currNode = newND.next;
            }

            //Set up Random Link
            currNode = head;
            while (currNode != null)
            {
                Node newNode = currNode.next;
                if (currNode.random != null)
                    newNode.random = currNode.random.next;
                else
                    newNode.random = null;

                currNode = newNode.next;
                //if (currNode != null)
                //    newNode.next = currNode.next;
                //else
                //    newNode.next = null;
            }

            currNode = head;
            while (currNode != null)
            {
                Node newNode = currNode.next;
                currNode.next = newNode.next;
                currNode = newNode.next;
                if (currNode != null)
                    newNode.next = currNode.next;
                else
                    newNode.next = null;
            }
            return newHead;
        }
        public Node CopyNode(Node nd)
        {
            Node copy = new Node(nd.val+100);
            return copy;
        }

        //Total Occurrences Of K In A Sorted Array (Facebook Software Engineering Interview Question)
        //1. Linear Scan Time: 0(n), Space: O(1)
        //2. Binary Search & Linea Scan: Time: O(log(n) + n), Space: O(1)
        //3. 2 Binary Search Time: O(log(n) log(n)), Space: O(1)
        //Similar problem from LetCode: Find First and Last Position of Element in Sorted Array
        //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        //1. Linear Scan Time: 0(n), Space: O(1)
        public int[] SearchRange1(int[] nums, int target)
        {
            int[] result = new int[2];
            result[0] = -1;
            result[1] = -1;
            if (nums == null || nums.Length < 1)
                return result;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    if (result[0] == -1)
                        result[0] = i;
                    result[1] = i;
                }
                else if (nums[i] > target)
                    break;
            }

            return result;
        }
        //2. Binary Search & Linea Scan: Time: O(log(n) + n), Space: O(1)
        public int[] SearchRange2(int[] nums, int target)
        {
            int[] result = new int[2];
            result[0] = -1;
            result[1] = -1;
            if (nums == null || nums.Length < 1)
                return result;

            int idxTarget = SearchRange2ByBSearch(nums, target, 0, nums.Length - 1);
            if (idxTarget < 0)
                return result;

            result[0] = idxTarget;
            result[1] = idxTarget;
            for (int i = idxTarget - 1; i >= 0; i--)
            {
                if (nums[i] < target)
                    break;
                else
                    result[0] = i;
            }
            for (int i = idxTarget + 1; i < nums.Length; i++)
            {
                if (nums[i] > target)
                    break;
                else
                    result[1] = i;
            }

            return result;
        }
        private int SearchRange2ByBSearch(int[] array, int target, int startIdx, int endIdx)
        {
            if (array == null || array.Length < 1)
                return -1;
            else if (startIdx > endIdx)
                return -1;

            int mid = startIdx + (endIdx - startIdx) / 2;
            if (array[mid] == target)
                return mid;
            else if (array[mid] > target)
                return SearchRange2ByBSearch(array, target, startIdx, mid - 1);
            else
                return SearchRange2ByBSearch(array, target, mid + 1, endIdx);
        }
        //3. 2 Binary Search Time: O(log(n) log(n)), Space: O(1)
        public int[] SearchRange3(int[] nums, int target)
        {
            int[] result = new int[2];
            result[0] = -1;
            result[1] = -1;
            if (nums == null || nums.Length < 1)
                return result;

            result[0] = SearchRange3ByBSearch(nums, target, 0, nums.Length-1, RangeIndicator.FIRST);
            if(result[0] != -1)
                result[1] = SearchRange3ByBSearch(nums, target, 0, nums.Length-1, RangeIndicator.LAST);

            return result;
        }
        private int SearchRange3ByBSearch(int[] array, int target, int startIdx, int endIdx, RangeIndicator rangeFlag)
        {
            if (array == null || array.Length < 1)
                return -1;
            else if (startIdx > endIdx)
                return -1;

            int mid = startIdx + (endIdx - startIdx) / 2;
            if (array[mid] == target)
            {
                if (rangeFlag == RangeIndicator.FIRST
                    && mid > startIdx && array[mid - 1] == array[mid])
                    return SearchRange3ByBSearch(array, target, startIdx, mid - 1, RangeIndicator.FIRST);
                else if (rangeFlag == RangeIndicator.LAST
                    && mid < endIdx && array[mid + 1] == array[mid])
                    return SearchRange3ByBSearch(array, target, mid + 1, endIdx, RangeIndicator.LAST);
                else
                    return mid;
            }
            else if (array[mid] > target)
                return SearchRange3ByBSearch(array, target, startIdx, mid - 1, rangeFlag);
            else
                return SearchRange3ByBSearch(array, target, mid + 1, endIdx, rangeFlag);
        }


        //Search A 2D Sorted Matrix
        //74. Search a 2D Matrix
        //https://leetcode.com/problems/search-a-2d-matrix/
        //https://www.youtube.com/watch?v=FOa55B9Ikfg&t=659s

        //Insertion Soft Analysis
        //https://www.youtube.com/watch?v=ufIET8dMnus


        //The 0/1 Knapsack Problem (Demystifying Dynamic Programming)
        //https://www.youtube.com/watch?v=xCbYmUPvc2Q

        //Implement A Sudoku Solver - Sudoku Solving Backtracking Algorithm ("Sudoku Solver" on LeetCode)
        //https://www.youtube.com/watch?v=JzONv5kaPJM
        //LeeCode
        //https://leetcode.com/problems/sudoku-solver/
        public void SolveSudoku(char[][] board)
        {
            //Brute Force
        }

        //The N Queens Placement Problem Clear Explanation (Backtracking/Recursion)
        //https://www.youtube.com/watch?v=wGbuCyNpxIg
        //N-Queens
        //https://leetcode.com/problems/n-queens/
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> solutions = new List<IList<string>>();

            SolveNQueensPro(n, 0, new List<int>(), solutions);
            return solutions;
        }
        private void SolveNQueensPro(int n, int row, List<int> colPlacements, IList<IList<string>> solutions)
        {
            if (row == n)
            {
                List<string> buff = new List<string>();
                foreach (int col in colPlacements)
                {
                    string tmp = "";
                    for (int i = 0; i < n; i++)
                    {
                        if (i == col)
                            tmp += "Q";
                        else
                            tmp += ".";
                    }
                    buff.Add(tmp);
                }
                solutions.Add(buff);
            }
            else
            {
                for (int col = 0; col < n; col++)
                {
                    colPlacements.Add(col);
                    if (IsValidNQueens(colPlacements))
                    {
                        SolveNQueensPro(n, row + 1, colPlacements, solutions);  //Constraints
                    }
                    colPlacements.Remove(colPlacements.Count - 1);      //Undo
                }
            }
        }
        private bool IsValidNQueens(List<int> colPacements)
        {
            int rowId = colPacements.Count - 1;
            for(int i = 0; i < rowId; i++)
            {
                int diff = Math.Abs(colPacements[i] - colPacements[rowId]);
                if (diff == 0 || diff == rowId - 1)
                    return false;
            }
            return true;
        }


        //Generate All Strings With n Matched Parentheses - Backtracking
        //https://www.youtube.com/watch?v=sz1qaKt0KGQ
        //https://www.youtube.com/watch?v=s9fokUqJ76A
        /// <summary>
        /// Generate Parentheses
        /// https://leetcode.com/problems/generate-parentheses/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            List<char> stack = new List<char>();
            GenerateParenthesisR(result, n, 0, 0, stack);
            return result;
        }
        private void GenerateParenthesisR(IList<string> result, int n, int usedOpened, int usedClosed, List<char> stack)
        {
            if(usedOpened == n && usedClosed == n)
            {
                result.Add(new string(stack.ToArray()));
                return;
            }

            if (usedOpened < n)
            {
                stack.Add('(');
                GenerateParenthesisR(result, n, usedOpened + 1, usedClosed, stack);
                stack.RemoveAt(stack.Count - 1);
            }

            if (usedClosed < n && usedOpened > usedClosed)
            {
                stack.Add(')');
                GenerateParenthesisR(result, n, usedOpened, usedClosed + 1, stack);
                stack.RemoveAt(stack.Count - 1);
            }
        }



    }
    public enum RangeIndicator
    {
        FIRST, LAST
    }
    public class Node
    {
        public int val;
        public Node next;
        public Node random;
        public int random_index;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
