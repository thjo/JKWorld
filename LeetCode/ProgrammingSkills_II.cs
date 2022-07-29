using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ProgrammingSkills_II
    {
        /// <summary>
        /// 150. Evaluate Reverse Polish Notation
        /// https://leetcode.com/problems/evaluate-reverse-polish-notation/
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public int EvalRPN(string[] tokens)
        {
            Stack<int> nums = new Stack<int>();

            foreach (string t in tokens)
            {
                if (IsOperator(t))
                {
                    int num2 = nums.Pop();
                    int num1 = nums.Pop();
                    int result = Operation(num1, num2, t);
                    nums.Push(result);
                }
                else
                {
                    nums.Push(int.Parse(t));
                }
            }
            return nums.Pop();
        }
        private bool IsOperator(string token)
        {
            if (token == "+" || token == "-" || token == "*" || token == "/")
                return true;
            else
                return false;
        }
        private int Operation(int num1, int num2, string op)
        {
            if (op == "+")
                return num1 + num2;
            else if (op == "-")
                return num1 - num2;
            else if (op == "*")
                return num1 * num2;
            else
                return num1 / num2;
        }


        /// <summary>
        /// 66. Plus One
        /// https://leetcode.com/problems/plus-one/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            digits[digits.Length - 1]++;
            digits[digits.Length - 1] = digits[digits.Length - 1] % 10;
            if (digits[digits.Length - 1] == 0)
            {
                bool isMoreThanTen = true;
                for (int i = digits.Length - 2; i >= 0; i--)
                {
                    if (digits[i] + 1 < 10)
                    {
                        digits[i]++;
                        isMoreThanTen = false;
                        break;
                    }
                    else
                        digits[i] = 0;
                }

                if (isMoreThanTen)
                {
                    List<int> result = new List<int>();
                    result.Add(1);
                    result.AddRange(digits);

                    return result.ToArray();
                }
            }

            return digits;
        }


        /// <summary>
        /// 1367. Linked List in Binary Tree
        /// https://leetcode.com/problems/linked-list-in-binary-tree/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (head == null || root == null)
                return false;

            Queue<TreeNode> qBuff = new Queue<TreeNode>();
            qBuff.Enqueue(root);

            while (qBuff.Count > 0)
            {
                TreeNode nd = qBuff.Dequeue();
                if (nd.val == head.val && IsMatchDownwardPath(head, nd))
                    return true;
                if (nd.left != null)
                    qBuff.Enqueue(nd.left);
                if (nd.right != null)
                    qBuff.Enqueue(nd.right);
            }

            return false;
        }
        private bool IsMatchDownwardPath(ListNode head, TreeNode root)
        {
            if (head == null)
                return true;
            else if (root == null)
                return false;

            if (head.val != root.val)
                return false;

            return IsMatchDownwardPath(head.next, root.left) || IsMatchDownwardPath(head.next, root.right);
        }


        /// <summary>
        /// 43. Multiply Strings
        /// https://leetcode.com/problems/multiply-strings/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
                return "0";
            if (num1.Length > num2.Length)
            {
                String tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
            int num1_len = num1.Length, num2_len = num2.Length;
            int[] res = new int[num1_len + num2_len];
            for (int i = 0; i < res.Length; i++)
                res[i] = 0;

            for (int i = num1_len - 1; i >= 0; i--)
            {
                for (int j = num2_len - 1; j >= 0; j--)
                {
                    int p1 = i + j, p2 = p1 + 1;
                    int sum = (num1[i] - '0') * (num2[j] - '0') + res[p2];
                    res[p2] = sum % 10;
                    res[p1] += sum / 10;
                }
            }
            String output = ""; int idx = -1;
            for (int i = 0; i < num1_len + num2_len && res[i] == 0; i++)
                idx = i;
            for (int i = idx + 1; i < num1_len + num2_len; i++)
                output += res[i].ToString();
            return output;
        }

        // Multiply the current digit of secondNumber with firstNumber.
        List<int> MultiplyOneDigit(StringBuilder sbN1, char secondNumberDigit, int numZeros)
        {
            // Insert zeros at the beginning based on the current digit's place.
            List<int> currentResult = new List<int>();
            for (int i = 0; i < numZeros; ++i)
            {
                currentResult.Add(0);
            }

            int carry = 0;

            // Multiply firstNumber with the current digit of secondNumber.
            for (int i = 0; i < sbN1.Length; ++i)
            {
                char firstNumberDigit = sbN1[i];
                int multiplication = (secondNumberDigit - '0') * (firstNumberDigit - '0') + carry;
                // Set carry equal to the tens place digit of multiplication.
                carry = multiplication / 10;
                // Append last digit to the current result.
                currentResult.Add(multiplication % 10);
            }

            if (carry != 0)
            {
                currentResult.Add(carry);
            }
            return currentResult;
        }
        private List<int> AddStrings(List<int> num1, List<int> num2)
        {
            List<int> ans = new List<int>();
            int carry = 0;

            for (int i = 0; i < num1.Count || i < num2.Count; ++i)
            {
                // If num2 is shorter than num1 or vice versa, use 0 as the current digit.
                int digit1 = i < num1.Count ? num1[i] : 0;
                int digit2 = i < num2.Count ? num2[i] : 0;

                // Add current digits of both numbers.
                int sum = digit1 + digit2 + carry;
                // Set carry equal to the tens place digit of sum.
                carry = sum / 10;
                // Append the ones place digit of sum to answer.
                ans.Add(sum % 10);
            }

            if (carry != 0)
            {
                ans.Add(carry);
            }
            return ans;
        }


        /// <summary>
        /// 67. Add Binary
        /// https://leetcode.com/problems/add-binary/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            StringBuilder sum = new StringBuilder();

            int aIdx = a.Length - 1;
            int bIdx = b.Length - 1;
            int maxLen = Math.Max(a.Length - 1, b.Length - 1);
            int tmp = 0;
            for (int i = maxLen; i >= 0; i--)
            {
                tmp += (aIdx >= 0) ? a[aIdx--] - '0' : 0;
                tmp += (bIdx >= 0) ? b[bIdx--] - '0' : 0;
                sum.Insert(0, (char)(tmp % 2 + '0'));
                tmp = tmp / 2;
            }
            if (tmp == 1)
                sum.Insert(0, 1);

            return sum.ToString();
        }


        /// <summary>
        /// 989. Add to Array-Form of Integer
        /// https://leetcode.com/problems/add-to-array-form-of-integer/
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> AddToArrayForm(int[] num, int k)
        {
            IList<int> ans = new List<int>();
            string kStr = k.ToString();
            int[] kNum = new int[kStr.Length];
            for(int i = 0; i < kStr.Length; i++)
                kNum[i] = kStr[i] - '0';

            int idxN = num.Length - 1, idxK = kNum.Length - 1;
            int comp = 0;
            Stack<int> sum = new Stack<int>();
            while(idxN >= 0 || idxK >= 0)
            {
                int tmp = 0;
                if (idxN >= 0 && idxK >= 0)
                {
                    tmp = num[idxN--] + kNum[idxK--] + comp;
                }
                else if (idxK >= 0)
                {
                    tmp = kNum[idxK--] + comp;
                }
                else
                    tmp = num[idxN--] + comp;

                sum.Push(tmp % 10);
                comp = tmp / 10;
            }
            if(comp != 0)
                sum.Push(comp);

            foreach (var n in sum)
                ans.Add(n);

            return ans;
        }



        /// <summary>
        /// 1886. Determine Whether Matrix Can Be Obtained By Rotation
        /// https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindRotation(int[][] mat, int[][] target)
        {
            if (Compare(mat, target)) return true;

            int size = mat.Length;
            int layer = size / 2;
            for (int rotate = 0; rotate < 3; rotate++)
            {
                for (int i = 0; i < layer; i++)
                    mat = Rotate(mat, i, size);

                if (Compare(mat, target)) return true;
            }
            return false;
        }
        private bool Compare(int[][] mat, int[][] target)
        {
            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                    if (mat[i][j] != target[i][j])
                        return false;
            return true;
        }
        private int[][] Rotate(int[][] mat, int layer, int size)
        {
            int first = layer;
            int last = size - first - 1;
            for (int j = first; j < last; j++)
            {
                int offset = j - first;

                int tmp = mat[first][j];
                mat[first][j] = mat[last - offset][first];
                mat[last - offset][first] = mat[last][last - offset];
                mat[last][last - offset] = mat[j][last];
                mat[j][last] = tmp;
            }
            return mat;
        }


        /// <summary>
        /// 429. N-ary Tree Level Order Traversal
        /// https://leetcode.com/problems/n-ary-tree-level-order-traversal/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Queue<NodeLv> qBuff = new Queue<NodeLv>();
            if (root == null)
                return ans;

            qBuff.Enqueue(new NodeLv(root, 0));
            while (qBuff.Count > 0)
            {
                NodeLv nd = qBuff.Dequeue();
                if (ans.Count <= nd.Level)
                {
                    ans.Add(new List<int>());
                }
                ans[nd.Level].Add(nd.NodeInfo.val);
                foreach (var child in nd.NodeInfo.children)
                    qBuff.Enqueue(new NodeLv(child, nd.Level + 1));
            }

            return ans;
        }
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
        public class NodeLv
        {
            public Node NodeInfo = null;
            public int Level = 0;
            public NodeLv(Node nd, int lv)
            {
                NodeInfo = nd;
                Level = lv;
            }
        }


        /// <summary>
        /// 1630. Arithmetic Subarrays
        /// https://leetcode.com/problems/arithmetic-subarrays/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            List<bool> ans = new List<bool>();
            for (int i = 0; i < l.Length; i++)
            {
                ans.Add(IsArithmetic(nums, l[i], r[i]));
            }
            return ans;
        }
        private bool IsArithmetic(int[] nums, int start, int end)
        {
            List<int> list = new List<int>();
            for (int i = start; i <= end; i++)
                list.Add(nums[i]);
            list.Sort();
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] - list[i - 1] != list[1] - list[0])
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 503. Next Greater Element II
        /// https://leetcode.com/problems/next-greater-element-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] nextGreaterList = new int[n];
            for (int i = 0; i < n; i++)
                nextGreaterList[i] = -1;

            //0: value, 1: index
            Stack<int[]> sBuff = new Stack<int[]>();
            sBuff.Push(new int[] { nums[0], 0 });
            for (int i = 1; i < n * 2; i++)
            {
                while (sBuff.Count > 0 && sBuff.Peek()[0] < nums[i % n])
                {
                    int[] tmp = sBuff.Pop();
                    if (tmp[1] < n)
                        nextGreaterList[tmp[1]] = nums[i % n];
                }
                sBuff.Push(new int[] { nums[i % n], i });
            }
            while (sBuff.Count > 0)
            {
                int[] tmp = sBuff.Pop();
                if (tmp[1] < n)
                    nextGreaterList[tmp[1]] = -1;
            }
            return nextGreaterList;
        }


        /// <summary>
        /// 556. Next Greater Element III
        /// https://leetcode.com/problems/next-greater-element-iii/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NextGreaterElementIII(int n)
        {
            //No answer case
            //single number
            //numbers in descending order

            char[] nums = n.ToString().ToCharArray();
            //find the position where starting descending
            int firstIdx = nums.Length - 2;
            while (firstIdx >= 0 && nums[firstIdx] >= nums[firstIdx + 1])
                firstIdx--;
            if (firstIdx < 0)
                return -1;

            int secIdx = nums.Length - 1;
            //find a number which is greater than the position "firstIdx"
            while (secIdx >= 0 && nums[secIdx] <= nums[firstIdx])
                secIdx--;

            //swap 
            SwapChar(nums, firstIdx, secIdx);

            //In order to minimize, order >> reverse since it's in descending order
            Reverse(nums, firstIdx + 1);

            int ans = 0;
            try
            {
                string tmp = "";
                for (int i = 0; i < nums.Length; i++)
                    tmp += nums[i];
                ans = int.Parse(tmp);
            }
            catch { ans = -1; }
            return ans;
        }
        private void Reverse(char[] nums, int start)
        {
            int i = start, j = nums.Length - 1;
            while (i < j)
            {
                SwapChar(nums, i++, j--);
            }
        }
        private void SwapChar(char[] nums, int i, int j)
        {
            char tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
