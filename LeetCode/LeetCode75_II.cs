using LeetCode.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class LeetCode75_II
    {


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


            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }


        /// <summary>
        /// 543. Diameter of Binary Tree
        /// https://leetcode.com/problems/diameter-of-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private int ans = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;

            DFS(root);
            return ans;
        }
        public int DFS(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = DFS(root.left);
            int right = DFS(root.right);
            ans = Math.Max(ans, left + right);
            return Math.Max(left, right) + 1;
        }


        /// <summary>
        /// 108. Convert Sorted Array to Binary Search Tree
        /// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return AddNodes(0, nums.Length - 1, nums);
        }
        private TreeNode AddNodes(int left, int right, int[] nums)
        {
            if (left > right)
                return null;

            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = AddNodes(left, mid - 1, nums);
            root.right = AddNodes(mid + 1, right, nums);

            return root;
        }


        /// <summary>
        /// 148. Sort List
        /// https://leetcode.com/problems/sort-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode mid = GetMid(head);
            ListNode left = SortList(head);
            ListNode right = SortList(mid);
            return Merge(left, right);
        }
        private ListNode GetMid(ListNode head)
        {
            ListNode midPrev = null;
            while (head != null && head.next != null)
            {
                midPrev = midPrev == null ? head : midPrev.next;
                head = head.next.next;
            }
            ListNode mid = midPrev.next;
            midPrev.next = null;
            return mid;
        }
        private ListNode Merge(ListNode left, ListNode right)
        {
            ListNode newHead = new ListNode();
            ListNode tail = newHead;
            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    tail.next = left;
                    left = left.next;
                    tail = tail.next;
                }
                else
                {
                    tail.next = right;
                    right = right.next;
                    tail = tail.next;
                }
            }
            tail.next = left != null ? left : right;
            return newHead.next;
        }



        /// <summary>
        /// 621. Task Scheduler
        /// https://leetcode.com/problems/task-scheduler/
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval(char[] tasks, int n)
        {
            int len = tasks.Length;
            if (n == 0)
                return len;

            int[] freq = new int[26];
            foreach (char t in tasks)
                freq[t - 'A']++;

            Array.Sort(freq);

            int fMax = freq[25];
            int idleTime = (fMax - 1) * n;
            for (int i = 24; i >= 0 && idleTime > 0; i--)
            {
                idleTime -= Math.Min(fMax - 1, freq[i]);
            }
            idleTime = Math.Max(0, idleTime);
            return idleTime + tasks.Length;
        }



        int cntOfPath = 0;
        public int PathSum(TreeNode root, int targetSum)
        {
            PathSumR(root, 0, targetSum);
            return cntOfPath;
        }

        private void PathSumR(TreeNode root, int currNum, int targetSum)
        {
            if (root == null)
                return;

            int sum = currNum + root.val;
            if (sum == targetSum)
            {
                cntOfPath++;
            }

            //with current root node
            PathSumR(root.left, sum, targetSum);
            PathSumR(root.right, sum, targetSum);

            //start at current root node
            PathSumR(root.left, root.val, targetSum);
            PathSumR(root.right, root.val, targetSum);
        }


        /// <summary>
        /// 173. Binary Search Tree Iterator
        /// https://leetcode.com/problems/binary-search-tree-iterator/
        /// </summary>
        public class BSTIterator
        {

            private TreeNode currPoint = null;
            Queue<TreeNode> q = new Queue<TreeNode>();
            public BSTIterator(TreeNode root)
            {
                currPoint = root;
                SetQueue(currPoint);
            }
            private void SetQueue(TreeNode root)
            {
                if (root == null)
                    return;
                SetQueue(root.left);
                q.Enqueue(root);
                SetQueue(root.right);
            }
            public int Next()
            {
                currPoint = q.Dequeue();
                return currPoint.val;
            }

            public bool HasNext()
            {
                return q.Count > 0;
            }

        }
    }
}
