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
    }
}
