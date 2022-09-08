using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Mock.Uber
{
    public class PhoneInterview
    {
        /// <summary>
        /// 1640. Check Array Formation Through Concatenation
        /// https://leetcode.com/problems/check-array-formation-through-concatenation/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="pieces"></param>
        /// <returns></returns>
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            //value, index
            Dictionary<int, int> dataset = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
                dataset.Add(arr[i], i);

            foreach (int[] piece in pieces)
            {
                if (piece.Length == 0)
                    continue;
                if (dataset.ContainsKey(piece[0]))
                {
                    int arrIdx = dataset[piece[0]];
                    arrIdx = arrIdx + 1;
                    for (int i = 1; i < piece.Length; i++)
                    {
                        if (arr.Length <= arrIdx || arr[arrIdx] != piece[i])
                            return false;
                        arrIdx++;
                    }
                    dataset.Remove(piece[0]);
                }
                else
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 1400. Construct K Palindrome Strings
        /// https://leetcode.com/problems/construct-k-palindrome-strings/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanConstruct(string s, int k)
        {
            int[] chars = new int[26];
            foreach (char c in s)
                chars[c - 'a']++;

            //characters: 2 or more than 2 times and it's even.
            //characters: 1 or more than 2 times and it's odd.
            if (s.Length == k)
                return true;
            else if (s.Length < k)
                return false;

            //characters: 1 or more than 2 times and it's odd.
            int cnt = 0;
            foreach (int c in chars)
            {
                if (c != 0 && c % 2 != 0)
                    cnt++;
            }
            return cnt > k ? false : true;
        }

        /// <summary>
        /// 1281. Subtract the Product and Sum of Digits of an Integer
        /// https://leetcode.com/problems/subtract-the-product-and-sum-of-digits-of-an-integer/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SubtractProductAndSum(int n)
        {
            int product = n % 10;
            int sum = n % 10;
            while (n / 10 > 0)
            {
                n = n / 10;
                product *= n % 10;
                sum += n % 10;
            }
            return product - sum;
        }


        /// <summary>
        /// 226. Invert Binary Tree
        /// https://leetcode.com/problems/invert-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return root;

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;

            InvertTree(root.right);
            InvertTree(root.left);
            return root;
        }


        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }
        public int GetImportance(IList<Employee> employees, int id)
        {
            Dictionary<int, Employee> dicEmps = new Dictionary<int, Employee>();
            foreach (var emp in employees)
                dicEmps.Add(emp.id, emp);

            Queue<Employee> qEmp = new Queue<Employee>();
            qEmp.Enqueue(dicEmps[id]);
            int sum = 0;
            while (qEmp.Count > 0)
            {
                Employee empl = qEmp.Dequeue();
                sum += empl.importance;
                foreach (var eId in empl.subordinates)
                    qEmp.Enqueue(dicEmps[eId]);
            }
            return sum;
        }


        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;

            if (root.val == val)
                return root;
            else if (root.val > val)
                return SearchBST(root.left, val);
            else
                return SearchBST(root.right, val);
        }

        /// <summary>
        /// 1136. Parallel Courses
        /// https://leetcode.com/problems/parallel-courses/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="relations"></param>
        /// <returns></returns>
        public int MinimumSemesters(int n, int[][] relations)
        {
            //prevCoursei, nextCoursei
            //int[][] relations
            //course, prev-courses
            List<List<int>> graph = new List<List<int>>();
            int[] inDegree = new int[n + 1];
            for (int i = 0; i <= n; i++)
                graph.Add(new List<int>());

            foreach (var p in relations)
            {
                graph[p[0]].Add(p[1]);
                inDegree[p[1]]++;
            }


            Queue<int> qG = new Queue<int>();
            for (int i = 1; i <= n; i++)
            {
                if (inDegree[i] == 0)
                    qG.Enqueue(i);
            }

            int minSemester = 0;
            while (qG.Count > 0)
            {
                minSemester++;
                Queue<int> qNewG = new Queue<int>();
                while (qG.Count > 0)
                {
                    n--;
                    int c = qG.Dequeue();
                    foreach (int endCourse in graph[c])
                    {
                        inDegree[endCourse]--;
                        if (inDegree[endCourse] == 0)
                            qNewG.Enqueue(endCourse);
                    }
                }
                qG = qNewG;
            }
            return n == 0 ? minSemester : -1;
        }


        /// <summary>
        /// 1064. Fixed Point
        /// https://leetcode.com/problems/fixed-point/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FixedPoint(int[] arr)
        {
            int ans = -1;
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == mid)
                {
                    ans = mid;
                    //return the smallest index i that satisfies arr[i] == i
                    right = mid - 1;
                }
                else if (arr[mid] > mid)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return ans;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Node Construct(int[][] grid)
        {
            Node root = new Node(true, true);
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return root;
            root.isLeaf = false;
            int n = grid.Length;
            int m = grid[0].Length;
            int[] start = new int[] { 0, 0 };
            int[] end = new int[] { n - 1, m - 1 };
            if (IsSameValue(grid, n, m, start, end))
            {
                root.val = grid[start[0]][start[1]] == 1;
                root.isLeaf = true;
            }
            else
                ConstructR(grid, n, m, start, end, root);
            return root;
        }
        private void ConstructR(int[][] grid, int n, int m, int[] start, int[] end, Node root)
        {
            if (start[0] == end[0])
                return;
            int[] startP, endP;
            int rowMid = start[0] + (end[0] - start[0]) / 2;
            int colMid = start[1] + (end[1] - start[1]) / 2;
            //4,5,6,7
            //4+(7-4)/2
            //topLeft
            Node topLeft = new Node(true, false);
            startP = new int[] { start[0], start[1] };
            endP = new int[] { rowMid, colMid };
            if (IsSameValue(grid, n, m, startP, endP))
            {
                topLeft.val = grid[startP[0]][startP[1]] == 1;
                topLeft.isLeaf = true;
                root.topLeft = topLeft;
            }
            else
            {
                root.topLeft = topLeft;
                ConstructR(grid, n, m, startP, endP, topLeft);
            }
            //topRight
            Node topRight = new Node(true, false);
            startP = new int[] { start[0], colMid + 1 };
            endP = new int[] { rowMid, end[1] };
            if (IsSameValue(grid, n, m, startP, endP))
            {
                topRight.val = grid[startP[0]][startP[1]] == 1;
                topRight.isLeaf = true;
                root.topRight = topRight;
            }
            else
            {
                root.topRight = topRight;
                ConstructR(grid, n, m, startP, endP, topRight);
            }
            //bottomLeft
            Node bottomLeft = new Node(true, false);
            startP = new int[] { rowMid + 1, start[1] };
            endP = new int[] { end[0], colMid };
            if (IsSameValue(grid, n, m, startP, endP))
            {
                bottomLeft.val = grid[startP[0]][startP[1]] == 1;
                bottomLeft.isLeaf = true;
                root.bottomLeft = bottomLeft;
            }
            else
            {
                root.bottomLeft = bottomLeft;
                ConstructR(grid, n, m, startP, endP, bottomLeft);
            }
            //bottomRight        
            Node bottomRight = new Node(true, false);
            startP = new int[] { rowMid + 1, colMid + 1 };
            endP = new int[] { end[0], end[1] };
            if (IsSameValue(grid, n, m, startP, endP))
            {
                bottomRight.val = grid[startP[0]][startP[1]] == 1;
                bottomRight.isLeaf = true;
                root.bottomRight = bottomRight;
            }
            else
            {
                root.bottomRight = bottomRight;
                ConstructR(grid, n, m, startP, endP, bottomRight);
            }
        }
        private bool IsSameValue(int[][] grid, int n, int m, int[] start, int[] end)
        {
            int? val = null;
            for (int r = start[0]; r <= end[0]; r++)
            {
                for (int c = start[1]; c <= end[1]; c++)
                {
                    if (val == null)
                        val = grid[r][c];
                    else if (val.Value != grid[r][c])
                        return false;
                }
            }
            return true;
        }
        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node()
            {
                val = false;
                isLeaf = false;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }









    }

}
