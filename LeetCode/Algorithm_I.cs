using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Algorithm_I
    {
        #region | Binary Search | 

        /// <summary>
        /// 704. Binary Search
        /// https://leetcode.com/problems/binary-search/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int targetIdx = -1;
            int len = nums.Length;

            int left = 0, right = len - 1;
            int mid = len / 2;

            while (left <= right)
            {
                if (nums[mid] == target)
                {
                    targetIdx = mid;
                    break;
                }
                else if (nums[mid] > target)
                {
                    //Search left area of the array
                    right = mid - 1;
                }
                else
                {
                    //Search right area of the array
                    left = mid + 1;
                }
                mid = (left + right) / 2;
            }

            return targetIdx;
        }


        /// <summary>
        /// 278. First Bad Version
        /// https://leetcode.com/problems/first-bad-version/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int l = 1, h = n;

            while (l <= h)
            {
                int m = l + (h - l) / 2;
                if (IsBadVersion(m) == false)
                {
                    l = m + 1;
                }
                else
                {
                    h = m - 1;
                }
            }

            return l;
        }
        private bool IsBadVersion(int version)
        {
            if (version == 1)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 35. Search Insert Position
        /// https://leetcode.com/problems/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int mid = (left + right) / 2;

            while (left <= right)
            {
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

                mid = (left + right) / 2;
            }

            return left;
        }

        #endregion

        #region | Two Points |

        /// <summary>
        /// 977. Squares of a Sorted Array
        /// https://leetcode.com/problems/squares-of-a-sorted-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortedSquares(int[] nums)
        {
            int len = nums.Length;
            int negativPoint = -1;

            int[] newSorted = new int[len];
            int idxNew = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    //Positive value
                    while (negativPoint > -1 && negativPoint < len
                        && nums[negativPoint] * nums[negativPoint] < nums[i] * nums[i])
                    {
                        newSorted[idxNew++] = nums[negativPoint] * nums[negativPoint];
                        negativPoint--;
                    }
                    newSorted[idxNew] = nums[i] * nums[i];
                    idxNew++;
                }
                else
                {
                    //Negative value
                    negativPoint = i;
                }
            }

            while (negativPoint > -1 && negativPoint < len)
            {
                newSorted[idxNew] = nums[negativPoint] * nums[negativPoint];
                idxNew++;
                negativPoint--;
            }

            return newSorted;
        }


        /// <summary>
        /// 189. Rotate Array
        /// https://leetcode.com/problems/rotate-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length == 1)
                return;

            k = k % nums.Length;

            ReversalArray(nums, 0, nums.Length - 1);
            ReversalArray(nums, 0, k - 1);
            ReversalArray(nums, k, nums.Length - 1);

        }
        private void ReversalArray(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int tmp = nums[start];
                nums[start++] = nums[end];
                nums[end--] = tmp;
            }
        }


        /// <summary>
        /// 283. Move Zeroes
        /// https://leetcode.com/problems/move-zeroes/
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            int numOfZeros = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    numOfZeros++;
                else
                {
                    if (numOfZeros > 0)
                    {
                        nums[i - numOfZeros] = nums[i];
                        nums[i] = 0;
                    }
                }
            }
        }


        /// <summary>
        /// 167. Two Sum II - Input array is sorted
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            //Using two points
            int idxLeft = 0, idxRight = numbers.Length - 1;

            while (idxLeft < idxRight)
            {
                if (numbers[idxLeft] + numbers[idxRight] == target)
                    return new int[] { idxLeft + 1, idxRight + 1 };
                else if (numbers[idxLeft] + numbers[idxRight] > target)
                    idxRight--;
                else
                    idxLeft++;
            }
            return new int[] { -1, -1 };

            //Using Dictionary

            //Dictionary<int, int> numMap = new Dictionary<int, int>();
            //for(int i = 0; i < numbers.Length; i++)
            //{
            //    if (numMap.ContainsKey(target - numbers[i]))
            //    {
            //        return new int[] { numMap[target - numbers[i]], i + 1 };
            //    }
            //    else
            //    {
            //        if(numMap.ContainsKey(numbers[i]) == false)
            //            numMap.Add(numbers[i], i + 1);
            //    }
            //}

            //return new int[] { -1, -1 };
        }



        /// <summary>
        /// 344. Reverse String
        /// https://leetcode.com/problems/reverse-string/
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            int l = 0, r = s.Length - 1;

            while (l < r)
            {
                char tmp = s[l];
                s[l++] = s[r];
                s[r--] = tmp;
            }
        }

        /// <summary>
        /// 557. Reverse Words in a String III
        /// https://leetcode.com/problems/reverse-words-in-a-string-iii/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            string reverseStr = "";
            string subStr = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    reverseStr += string.Format("{0} ", ReverseString(subStr));
                    subStr = "";
                }
                else
                {
                    subStr += s[i];
                }
            }
            if (string.IsNullOrWhiteSpace(subStr) == false)
                reverseStr += string.Format("{0}", ReverseString(subStr));

            return reverseStr;
        }
        public string ReverseString(string s)
        {
            int l = 0, r = s.Length - 1;
            string reverseL = "", reverseR = "";

            while (l < r)
            {
                reverseL = string.Format("{0}{1}", reverseL, s[r]);
                reverseR = string.Format("{0}{1}", s[l], reverseR);
                l++; r--;
            }

            if (s.Length % 2 == 1)
                return string.Format("{0}{1}{2}", reverseL, s[l], reverseR);
            else
                return string.Format("{0}{1}", reverseL, reverseR);
        }


        /// <summary>
        /// 876. Middle of the Linked List
        /// https://leetcode.com/problems/middle-of-the-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode slow = dummy, fast = dummy;
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next != null ? fast.next.next : null;
            }

            return slow;
        }


        /// <summary>
        /// 19. Remove Nth Node From End of List
        /// https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //Using Two points
            ListNode dummy = new ListNode(0, head);

            ListNode rightPointer = head;
            ListNode leftPointer = dummy;

            for (int i = 0; i < n; i++)
            {
                rightPointer = rightPointer.next;
            }

            while (rightPointer != null)
            {
                leftPointer = leftPointer.next;
                rightPointer = rightPointer.next;
            }

            leftPointer.next = leftPointer.next.next;

            return dummy.next;

            // Using Extra Space
            //ListNode slow = head, fast = head;
            //List<ListNode> buff = new List<ListNode>();
            //buff.Add(head);
            //while(fast != null)
            //{
            //    slow = fast.next;
            //    fast = slow != null ? slow.next : null;

            //    if( slow != null)
            //        buff.Add(slow);
            //    if( fast != null)
            //        buff.Add(fast);
            //}

            //int removeAt = buff.Count - n;
            //ListNode nodeRmoveAt = buff[removeAt];
            //if (removeAt < 0)
            //    return null;
            //else if( removeAt == 0)
            //{
            //    head = head.next;
            //}
            //else
            //{
            //    buff[removeAt-1].next = nodeRmoveAt.next;
            //}
            //return head;
        }

        #endregion


        #region | Sliding Window | 

        /// <summary>
        /// 3. Longest Substring Without Repeating Characters
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            Dictionary<char, int> subStr = new Dictionary<char, int>();
            int longestLen = 0;
            int startIdx = 0;
            subStr.Add(s[0], 0);
            longestLen = 1;
            for (int currIdx = 1; currIdx < s.Length; currIdx++)
            {
                if (subStr.ContainsKey(s[currIdx]))
                {
                    int duplicatedIdx = subStr[s[currIdx]];
                    while (startIdx <= duplicatedIdx)
                    {
                        if (subStr.ContainsKey(s[startIdx]))
                        {
                            subStr.Remove(s[startIdx]);
                        }
                        startIdx++;
                    }
                }

                subStr.Add(s[currIdx], currIdx);
                longestLen = Math.Max(longestLen, subStr.Count);
            }

            return longestLen;
        }


        /// <summary>
        /// 567. Permutation in String
        /// https://leetcode.com/problems/permutation-in-string/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckInclusion(string s1, string s2)
        {
            //Length of string p and s
            int s1Len = s1.Length;
            int s2Len = s2.Length;

            //Return empty result if any of the condition
            if (s2.Length == 0 || s1Len > s2Len)
                return false;

            int[] s1Arr = new int[26];
            int[] s2Arr = new int[26];

            for (int i = 0; i < s1Len; i++)
            {
                s1Arr[s1[i] - 'a']++;
                s2Arr[s2[i] - 'a']++;
            }

            for (int i = 0; i < s2Len - s1Len; i++)
            {
                if (isPermutation(s1Arr, s2Arr))
                    return true;

                s2Arr[s2[i] - 'a']--;
                s2Arr[s2[i + s1Len] - 'a']++;
            }

            if (isPermutation(s1Arr, s2Arr))
                return true;

            return false;
        }
        private bool isPermutation(int[] s1Arr, int[] s2Arr)
        {
            for (int i = 0; i < s1Arr.Length; i++)
            {
                if (s1Arr[i] != s2Arr[i])
                    return false;
            }

            return true;
        }


        #endregion


        #region | Breadth-First Search / Depth-First Searc | 

        /// <summary>
        /// 733. Flood Fill
        /// https://leetcode.com/problems/flood-fill/
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int rowLen = image.Length;
            int colLen = image[0].Length;
            bool[][] visited = new bool[rowLen][];
            for (int i = 0; i < rowLen; i++)
                visited[i] = new bool[colLen];

            FloodFillRecursive(image, sr, sc, rowLen, colLen, visited, image[sr][sc], newColor);
            return image;
        }
        private void FloodFillRecursive(int[][] image, int sr, int sc, int rowLen, int colLen, bool[][] visited, int oldColor, int newColor)
        {
            if (sr < 0 || sr >= rowLen || sc < 0 || sc >= colLen)
                return;
            else if (visited[sr][sc])
                return;

            if (image[sr][sc] == oldColor)
            {
                image[sr][sc] = newColor;
                visited[sr][sc] = true;
                FloodFillRecursive(image, sr - 1, sc, rowLen, colLen, visited, oldColor, newColor);
                FloodFillRecursive(image, sr, sc - 1, rowLen, colLen, visited, oldColor, newColor);
                FloodFillRecursive(image, sr + 1, sc, rowLen, colLen, visited, oldColor, newColor);
                FloodFillRecursive(image, sr, sc + 1, rowLen, colLen, visited, oldColor, newColor);
            }
        }

        /// <summary>
        /// 695. Max Area of Island
        /// https://leetcode.com/problems/max-area-of-island/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxAreaOfIsland = 0;

            int rowLen = grid.Length;
            int colLen = grid[0].Length;
            int[][] visited = new int[rowLen][];
            for (int i = 0; i < rowLen; i++)
                visited[i] = new int[colLen];

            for (int r = 0; r < rowLen; r++)
            {
                for (int c = 0; c < colLen; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        maxAreaOfIsland = Math.Max(VisitIsland(grid, r, c, rowLen, colLen), maxAreaOfIsland);
                    }
                }
            }

            return maxAreaOfIsland;
        }
        private int VisitIsland(int[][] grid, int pointRow, int pointCol, int rowLen, int colLen)
        {
            int sizeOfIsland = 0;
            if (pointRow < 0 || pointRow >= rowLen || pointCol < 0 || pointCol >= colLen)
                return sizeOfIsland;
            else if (grid[pointRow][pointCol] != 1)
                return sizeOfIsland;

            grid[pointRow][pointCol] = 2;       //Visied
            sizeOfIsland++;
            sizeOfIsland += VisitIsland(grid, pointRow - 1, pointCol, rowLen, colLen);
            sizeOfIsland += VisitIsland(grid, pointRow, pointCol - 1, rowLen, colLen);
            sizeOfIsland += VisitIsland(grid, pointRow, pointCol + 1, rowLen, colLen);
            sizeOfIsland += VisitIsland(grid, pointRow + 1, pointCol, rowLen, colLen);

            return sizeOfIsland;
        }


        /// <summary>
        /// 617. Merge Two Binary Trees
        /// https://leetcode.com/problems/merge-two-binary-trees/
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return null;

            int mergeVal = 0;
            if (root1 != null)
                mergeVal += root1.val;
            if (root2 != null)
                mergeVal += root2.val;

            TreeNode newTree = new TreeNode();
            newTree.val = mergeVal;

            //Left
            newTree.left = MergeTrees((root1 != null ? root1.left : null), (root2 != null ? root2.left : null));

            //Right
            newTree.right = MergeTrees((root1 != null ? root1.right : null), (root2 != null ? root2.right : null));

            return newTree;
        }

        /// <summary>
        /// 116. Populating Next Right Pointers in Each Node
        /// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node ConnectI(Node root)
        {
            Node leftNode = root;

            while (leftNode != null && leftNode.left != null)
            {
                ConnectNextNodes(leftNode);
                leftNode = leftNode.left;
            }
            return root;
        }
        private void ConnectNextNodes(Node node)
        {
            while (node != null)
            {
                node.left.next = node.right;
                if (node.next != null)
                    node.right.next = node.next.left;
                node = node.next;
            }
        }


        /// <summary>
        /// 542. 01 Matrix
        /// https://leetcode.com/problems/01-matrix/
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[][] UpdateMatrix(int[][] mat)
        {
            int lenRows = mat.Length;
            int lenCols = mat[0].Length;
            int[][] dist = new int[lenRows][];
            for (int row = 0; row < lenRows; row++)
                dist[row] = new int[lenCols];

            for (int row = 0; row < lenRows; row++)
            {
                for (int col = 0; col < lenCols; col++)
                {
                    dist[row][col] = UpdateMatrixHelper(mat, lenRows, lenCols, row, col, dist);
                }
            }

            return dist;
        }
        public int UpdateMatrixHelper(int[][] mat, int lenRows, int lenCols, int iRow, int iCol, int[][] dist)
        {
            if (dist[iRow][iCol] != 0)
                return dist[iRow][iCol];
            else if (mat[iRow][iCol] == 0)
            {
                dist[iRow][iCol] = 0;
                return dist[iRow][iCol];
            }

            int? minVal = null;

            //Check Top
            if (iRow - 1 >= 0 && mat[iRow - 1][iCol] == 1)
            {
                int tmp = UpdateMatrixHelper(mat, lenRows, lenCols, iRow - 1, iCol, dist) + 1;
                if (minVal == null)
                    minVal = tmp;
                else
                    minVal = Math.Min(minVal.Value, tmp);
            }
            //Right
            if (iCol + 1 < lenCols && mat[iRow][iCol + 1] == 1)
            {
                int tmp = UpdateMatrixHelper(mat, lenRows, lenCols, iRow, iCol + 1, dist) + 1;
                if (minVal == null)
                    minVal = tmp;
                else
                    minVal = Math.Min(minVal.Value, tmp);
            }

            //Check left
            if (iCol - 1 >= 0 && mat[iRow][iCol - 1] == 1)
            {
                int tmp = UpdateMatrixHelper(mat, lenRows, lenCols, iRow, iCol - 1, dist) + 1;
                if (minVal == null)
                    minVal = tmp;
                else
                    minVal = Math.Min(minVal.Value, tmp);
            }

            //Check Bottom
            if (iRow + 1 < lenRows && mat[iRow + 1][iCol] == 1)
            {
                int tmp = UpdateMatrixHelper(mat, lenRows, lenCols, iRow + 1, iCol, dist) + 1;
                if (minVal == null)
                    minVal = tmp;
                else
                    minVal = Math.Min(minVal.Value, tmp);
            }

            dist[iRow][iCol] = minVal != null ? minVal.Value : mat[iRow][iCol];
            return dist[iRow][iCol];
        }



        /// <summary>
        /// 994. Rotting Oranges
        /// https://leetcode.com/problems/rotting-oranges/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            int[][] directions = new int[4][];
            directions[0] = new int[] { 1, 0 };
            directions[1] = new int[] { 0, 1 };
            directions[2] = new int[] { -1, 0 };
            directions[3] = new int[] { 0, -1 };

            Queue<int[]> rottenOrangs = new Queue<int[]>();
            int freshOranges = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        List<int> loc = new List<int>();
                        loc.Add(r); loc.Add(c);
                        rottenOrangs.Enqueue(new int[] { r, c, 0 });
                    }
                    else if (grid[r][c] == 1)
                        freshOranges++;
                }
            }

            int numfMins = 0;
            while (rottenOrangs.Count > 0)
            {
                var map = rottenOrangs.Dequeue();
                numfMins = Math.Max(map[2], numfMins);
                for (int i = 0; i < directions.Length; i++)
                {
                    int x = map[0] + directions[i][0];
                    int y = map[1] + directions[i][1];
                    if (grid[x][y] == 1)
                    {
                        grid[x][y] = 2;
                        freshOranges--;
                        rottenOrangs.Enqueue(new int[] { x, y, (map[2] + 1) });
                    }
                }
            }

            return freshOranges > 0 ? -1 : numfMins;
        }



        #endregion



        #region | Recursion / Backtracking | 

        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode newHead = new ListNode(-1);
            ListNode currNode = newHead;

            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    currNode.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    currNode.next = l1;
                    l1 = l1.next;
                }

                currNode = currNode.next;
            }

            if (l1 != null)
                currNode.next = l1;
            if (l2 != null)
                currNode.next = l2;

            return newHead.next;
        }

        /// <summary>
        /// 206. Reverse Linked List
        /// https://leetcode.com/problems/reverse-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            ListNode preNode = null;
            ListNode currNode = head;
            while (currNode != null)
            {
                ListNode nextNode = currNode.next;
                currNode.next = preNode;

                preNode = currNode;
                currNode = nextNode;
            }

            return preNode;

            //if (head == null)
            //    return head;
            //return ReverseListHelper(null, head);
        }
        private ListNode ReverseListHelper(ListNode preNode, ListNode curentNode)
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

        #endregion



        #region | Bit Manipulation | 

        /// <summary>
        /// 231. Power of Two
        /// https://leetcode.com/problems/power-of-two/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {

        }

        /// <summary>
        /// 191. Number of 1 Bits
        /// https://leetcode.com/problems/number-of-1-bits/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            int retVal = 0;
            while ((n | 0) > 0)
            {
                if ((n & 1) > 0)
                    retVal++;
                n = n >> 1;
            }

            return retVal;
        }

        /// <summary>
        /// 190. Reverse Bits
        /// https://leetcode.com/problems/reverse-bits/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint reverseBits(uint n)
        {
            int len = sizeof(uint) * 8;
            uint reverse = 0;
            for(int i = 0; i < len; i++)
            {
                if ((n & (uint)1) == 1)
                    reverse = reverse | (uint)(1 << (len - (i+1)));

                n = n >> 1;
            }

            return reverse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int retVal = nums[0];

            for (int i = 1; i < nums.Length; i++)
                retVal ^= nums[i];

            return retVal;
        }

        #endregion
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    public class Orange
    {
        public int numOfMins;
        public int x, y;
    }
}
