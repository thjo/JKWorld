using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm
{
    [TestClass]
    public class Recursion
    {
        void Print(object output, bool newLine = true)
        {
            if (newLine)
                System.Diagnostics.Debug.WriteLine(output);
            else
            {
                System.Diagnostics.Debug.Write(output);
                System.Diagnostics.Debug.Write(" ");
            }
        }
        void Print(int[] output, bool newLine = true)
        {
            foreach (int o in output)
            {
                Print(o, newLine);
            }
        }


        #region | Principle of Recursion | 

        [TestMethod]
        public void ReverseString()
        {
            ReverseString(new char[] { 'h', 'e', 'l', 'l', 'o' });
        }
        public void ReverseString(char[] s)
        {
            ReverseStringH(s, 0, s.Length - 1);
        }
        public void ReverseStringH(char[] s, int iStart, int iEnd)
        {
            if (s == null || s.Length < 1 || iStart >= iEnd)
                return;

            char tmp = s[iStart];
            s[iStart++] = s[iEnd];
            s[iEnd--] = tmp;

            ReverseStringH(s, iStart, iEnd);
        }

        [TestMethod]
        public void SwapPairs()
        {
            ListNode ln1 = new ListNode(1, null);
            ListNode ln2 = new ListNode(2, null);
            ln1.next = ln2;
            ListNode ln3 = new ListNode(3, null);
            ln2.next = ln3;
            ListNode ln4 = new ListNode(4, null);
            ln3.next = ln4;
            SwapPairs(ln1);
        }
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            int tmp = head.next.val;
            head.next.val = head.val;
            head.val = tmp;

            SwapPairs(head.next.next);
            return head;
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return head;
            return ReverseListHelper(null, head);

            //if (head == null || head.next == null)
            //    return head;

            //ListNode preNode = null;
            //ListNode currNode = head;
            //while (currNode != null)
            //{
            //    //Move currNode to Head
            //    ListNode nextNode = currNode.next;
            //    currNode.next = preNode;

            //    preNode = currNode;
            //    currNode = nextNode;
            //}

            //return preNode;
        }
        public ListNode ReverseListHelper(ListNode preNode, ListNode curentNode)
        {
            ListNode next = curentNode.next;
            curentNode.next = preNode;
            preNode = curentNode;
            curentNode = next;

            if (curentNode == null)
                return preNode;
            else
                return ReverseListHelper(preNode, curentNode);
        }


        [TestMethod]
        public void SearchBST()
        {
            TreeNode tn = new TreeNode();
            tn.val = 4;
            tn.right = new TreeNode(7);
            tn.left = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            SearchBST(tn, 2);
        }
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            else if (root.val == val)
                return root;
            else if (root.val > val)
                return SearchBST(root.left, val);
            else
                return SearchBST(root.right, val);
        }


        #endregion


        #region | Memoization | 

        [TestMethod]
        public void Fib()
        {
            Fib(3);
        }
        public int Fib(int n)
        {
            Dictionary<int,int> memFib = new Dictionary<int, int>();

            return FibSub(n, memFib);
        }
        private int FibSub(int n, Dictionary<int, int> memFib)
        {
            if (memFib.ContainsKey(n))
                return memFib[n];
            else if (n <= 1)
                return n;

            int n2 = FibSub(n - 2, memFib);
            if(memFib.ContainsKey(n-2) == false)
                memFib.Add(n - 2, n2);
            int n1 = FibSub(n - 1, memFib);
            if (memFib.ContainsKey(n - 1) == false)
                memFib.Add(n - 1, n1);
            return n2 + n1;
        }

        [TestMethod]
        public void ClimbStairs()
        {
            ClimbStairs(3);
        }
        public int ClimbStairs(int n)
        {
            if (n == 1)
                return 1;

            //int[] dp = new int[n + 1];
            //dp[1] = 1;
            //dp[2] = 2;
            //for (int i = 3; i <= n; i++)
            //    dp[i] = dp[i - 1] + dp[i - 2];

            //return dp[n];
            int first = 1;
            int second = 2;
            for(int i = 3; i <= n; i++)
            {
                int third = first + second;
                first = second;
                second = third;
            }

            return second;
        }


        [TestMethod]
        public void MyPow()
        {
            Print(MyPow(2.0, -2));
        }
        public double MyPow(double x, int n)
        {
            if(n < 0)
            {
                x = 1.0 / x;
                n = n * -1;
            }

            return MySubPow(x, n);
        }
        public double MySubPow(double x, int n)
        {
            if (x == 0)
                return 0;
            else if (n == 0)
                return 1;
            else if (n == 1 || x == 1)
                return x;

            double dVal = MySubPow(x * x, n / 2);
            if (n % 2 == 1)
                dVal *= x;

            return dVal;
        }

        #endregion
    }
}
