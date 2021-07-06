using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HackerRank
{
    public class Interview
    {
        #region | Arrays | 

        private int minimumSwaps(int[] arr)
        {
            int cntOfSwap = 0;
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            Array.Sort(temp);
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
                map.Add(arr[i], i);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != temp[i])
                {
                    cntOfSwap++;
                    int newIdx = map[temp[i]];
                    map[arr[i]] = newIdx;
                    map[arr[newIdx]] = i;
                    minSwap(arr, i, newIdx);
                }
            }

            return cntOfSwap;
        }
        private void minSwap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }




        #endregion


        #region | Trees | 

        public int Height(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftHeight = 0, rightHeight = 0;
            if (root.left != null)
                leftHeight = Height(root.left) + 1;
            if (root.right != null)
                rightHeight = Height(root.right) + 1;

            return Math.Max(leftHeight, rightHeight);
        }     

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            else if (root.val == p.val || root.val == q.val)
                return root;

            TreeNode leftLCA = LowestCommonAncestor(root.left, p, q);
            TreeNode rightLCA = LowestCommonAncestor(root.right, p, q);

            if (leftLCA != null && rightLCA != null)
                return root;
            else if (leftLCA != null)
                return leftLCA;
            else
                return rightLCA;

        }


        //Trees: Is This a Binary Search Tree
        //For the purposes of this challenge, we define a binary search tree to be a binary tree with the following properties:
        // * The value of every node in a node's left subtree is less than the data value of that node.
        // * The value of every node in a node's right subtree is greater than the data value of that node.
        // * The value of every node is distinct.
        public bool CheckBST(TreeNode root)
        {
            bool isBTS = true;

            List<int> tree = new List<int>();
            InOrderTraversal(root, tree);

            for (int i = 0; i < tree.Count - 1; i++)
            {
                for (int j = i + 1; j < tree.Count; j++)
                {
                    if (tree[i] >= tree[j])
                    {
                        isBTS = false;
                        break;
                    }
                }
            }

            return isBTS;
        }
        public void InOrderTraversal(TreeNode node, List<int> data)
        {
            if (node == null)
                return;

            if (node.left != null)
                InOrderTraversal(node.left, data);

            data.Add(node.val);

            if (node.right != null)
                InOrderTraversal(node.right, data);
        }
        public bool IsValidBST(TreeNode root)
        {
            return Valid(root, null, null);
        }
        public bool Valid(TreeNode root, int? low, int? high)
        {
            if (root == null)
                return true;
            if ((low != null && root.val <= low.Value) || (high != null && root.val >= high.Value))
                return false;
            return Valid(root.right, root.val, high) && Valid(root.left, low, root.val);
        }



        //Tree: Huffman Decoding




        //You are given the root of a binary search tree (BST) and an integer val.
        //Find the node in the BST that the node's value equals val and return the subtree rooted with that node. 
        //If such a node does not exist, return null.
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
        public int BiarySearch(int[] nums, int target)
        {
            int retIdx = -1;
            if (nums == null || nums.Length < 1)
                return retIdx;

            int left = 0, right = nums.Length -1;
            while(left <= right)
            {
                int midIdx = (left + right) / 2;
                if(nums[midIdx] == target)
                {
                    retIdx = midIdx;
                    break;
                }
                else if (nums[midIdx] > target)
                {
                    //Search left part of the array
                    right = midIdx - 1;
                }
                else
                {
                    //Search right part of the array
                    left = midIdx + 1;
                }
            }


            return retIdx;
        }

        #endregion


        #region | Linked Lists | 

        public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            int i = 1;
            SinglyLinkedListNode targetNode = llist;
            while (i < position)
            {
                if (targetNode == null)
                    break;
                else
                    targetNode = targetNode.next;
                i++;
            }
            if( i == position && targetNode != null)
            {
                SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
                newNode.next = targetNode.next;
                targetNode.next = newNode;
            }

            return llist;
        }
        #endregion


        #region | Hash Tables | 

        public static void checkMagazine(List<string> magazine, List<string> note)
        {
            bool isContained = true;
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (string word in magazine)
            {
                if (map.ContainsKey(word))
                    map[word]++;
                else
                    map.Add(word, 1);
            }
            foreach (string word in note)
            {
                if (map.ContainsKey(word) && map[word] > 0)
                    map[word]--;
                else
                {
                    isContained = false;
                    break;
                }
            }

            if (isContained)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }

        public static string twoStrings(string s1, string s2)
        {
            string retVal = "NO";
            List<char> map = new List<char>();
            foreach (char c in s1)
            {
                if (map.Contains(c) == false)
                    map.Add(c);
            }

            foreach (char c in s2)
            {
                if (map.Contains(c))
                {
                    retVal = "YES";
                    break;
                }
            }

            return retVal;
        }

        public static int sherlockAndAnagrams(string s)
        {
            int totalCnt = 0;
            Dictionary<string, int> subStringMap = new Dictionary<string, int>();

            for (int len = 1; len < s.Length; len++)
            {
                //length of substring
                for (int idx = 0; idx <= s.Length - len; idx++)
                {
                    char[] tmp = s.Substring(idx, len).ToCharArray();
                    Array.Sort(tmp);
                    string buff = new string(tmp);
                    if (subStringMap.ContainsKey(buff))
                        subStringMap[buff]++;
                    else
                        subStringMap.Add(buff, 1);
                }
            }

            //Count
            foreach (var val in subStringMap)
            {
                if (val.Value >= 2)
                    totalCnt += (val.Value * (val.Value - 1)) / 2;
            }

            return totalCnt;
        }

        static long countTriplets(List<long> arr, long r)
        {
            if (arr == null || arr.Count < 3)
                return 0;
            //Examples of a geometric sequence are powers rk of a fixed non-zero number r, such as 2k and 3k. The general form of a geometric sequence is
            //a, ar, ar^2, ar^3, ar^4, ....

            //We need two hash maps. 
            //First map is keeping track of what we are looking for, and how many pairing w gain if found.
            long numTriplets = 0;
            Dictionary<long, long> first = new Dictionary<long, long>();
            Dictionary<long, long> middle = new Dictionary<long, long>();
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] % (r * r) == 0
                    && middle.ContainsKey(arr[i] / r))
                {
                    numTriplets += middle[arr[i] / r];
                }
                if (arr[i] % r == 0
                    && first.ContainsKey(arr[i] / r))
                {
                    if (middle.ContainsKey(arr[i]))
                        middle[arr[i]] += first[arr[i] / r];
                    else
                        middle.Add(arr[i], first[arr[i] / r]);
                }

                if (first.ContainsKey(arr[i]))
                    first[arr[i]]++;
                else
                    first.Add(arr[i], 1);
            }
            return numTriplets;
        }

        static List<int> freqQuery(List<List<int>> queries)
        {
            List<int> result = new List<int>();
            Dictionary<long, int> data = new Dictionary<long, int>();
            Dictionary<int, long> frequency = new Dictionary<int, long>();
            foreach (List<int> q in queries)
            {
                int type = q[0];
                int value = q[1];
                bool found = false;
                if (data.ContainsKey(value))
                    found = true;
                switch (type)
                {
                    case 1:
                        if (found)
                        {
                            frequency[data[value]]--;
                            data[value]++;

                            if (frequency.ContainsKey(data[value]))
                                frequency[data[value]]++;
                            else
                                frequency.Add(data[value], 1);
                        }
                        else
                        {
                            data.Add(value, 1);
                            if (frequency.ContainsKey(data[value]))
                                frequency[data[value]]++;
                            else
                                frequency.Add(data[value], 1);
                        }
                        break;
                    case 2:
                        if (found)
                        {
                            frequency[data[value]]--;
                            data[value]--;
                            if (data[value] <= 0)
                                data.Remove(value);
                            else
                            {
                                if (frequency.ContainsKey(data[value]))
                                    frequency[data[value]]++;
                                else
                                    frequency.Add(data[value], 1);
                            }
                        }
                        break;
                    case 3:
                        if (frequency.ContainsKey(value))
                            result.Add(frequency[value] > 0 ? 1 : 0);
                        else
                            result.Add(0);
                        break;
                    default:
                        break;
                }

                if (found && frequency.ContainsKey(value) && frequency[value] <= 0)
                    frequency.Remove(value);
            }

            return result;
        }

        public static void whatFlavors(List<int> cost, int money)
        {
            //10
            //2, 7, 5, 5, 10, 7
            Dictionary<int, int> iceComplement = new Dictionary<int, int>();

            for (int i = 0; i < cost.Count; i++)
            {
                int left = money - cost[i];
                if (left <= 0)
                    continue;
                if (iceComplement.ContainsKey(left))
                {
                    Console.WriteLine(string.Format("{0} {1}", iceComplement[left], i + 1));
                    return;
                }
                
                if(iceComplement.ContainsKey(cost[i]) == false)
                    iceComplement.Add(cost[i], i + 1);
            }
        }

        public static int pairs(int k, List<int> arr)
        {
            HashSet<int> complements = new HashSet<int>();
            int cntOfPairs = 0;
            complements.Add(arr[0]);
            for (int i = 1; i < arr.Count; i++)
            {
                if (complements.Contains(arr[i] - k))
                    cntOfPairs++;
                if (complements.Contains(arr[i] + k))
                    cntOfPairs++;

                complements.Add(arr[i]);
            }

            return cntOfPairs;
        }


        #endregion


        #region | Stacks and Queues | 

        public static string isBalanced(string s)
        {
            string retVal = "YES";
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> brackets = new Dictionary<char, char>();
            brackets.Add(')', '(');
            brackets.Add('}', '{');
            brackets.Add(']', '[');

            foreach (char c in s)
            {
                if (brackets.ContainsKey(c))
                {
                    if (stack.Count < 1 || !brackets[c].Equals(stack.Pop()))
                    {
                        retVal = "NO";
                        break;
                    }
                }
                else
                    stack.Push(c);
            }
            if (stack.Count != 0)
                retVal = "NO";

            return retVal;
        }

        public static long largestRectangle(List<int> h)
        {
            long maxArea = 0;
            Stack<int> sBuildings = new Stack<int>();
            int lenOfHighs = h.Count;
            int i = 0;
            int topStack = 0;
            while (i < lenOfHighs)
            {
                //If this building is equal or higher than the buliding on the top of the Stack, push it to the Stack.
                if (sBuildings.Count == 0 || h[sBuildings.Peek()] <= h[i])
                {
                    sBuildings.Push(i);
                    i++;
                }
                else
                {
                    //If this building is lower than the building on the top of Stack, 
                    //   then calculate area of rectangle with stack top as the smallest
                    topStack = sBuildings.Pop();
                    if (sBuildings.Count == 0)
                        maxArea = Math.Max(maxArea, h[topStack] * i);
                    else
                        maxArea = Math.Max(maxArea, h[topStack] * (i - sBuildings.Peek() - 1));
                }
            }

            while (sBuildings.Count > 0)
            {
                topStack = sBuildings.Pop();
                if (sBuildings.Count == 0)
                    maxArea = Math.Max(maxArea, h[topStack] * i);
                else
                    maxArea = Math.Max(maxArea, h[topStack] * (i - sBuildings.Peek() - 1));
            }


            return maxArea;
        }


        public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
        {
            string[] gridArr = grid.ToArray();
            string[][] map = new string[gridArr.Length][];
            char[][] visited = new char[gridArr.Length][];
            Queue<string> nextToVisit = new Queue<string>();
            for (int i = 0; i < gridArr.Length; i++)
            {
                map[i] = new string[gridArr[i].Length];
                visited[i] = new char[gridArr[i].Length];
                for (int j = 0; j < visited[i].Length; j++)
                    visited[i][j] = 'N';
            }

            int lenX = gridArr[0].Length;
            int lenY = gridArr.Length;
            nextToVisit.Enqueue(string.Format("{0}_{1}", startX, startY));
            visited[startX][startY] = 'V';
            while (nextToVisit.Count > 0)
            {
                int rowIdx = -1, colIdx = -1;
                string tmp = nextToVisit.Dequeue();
                string[] buff = tmp.Split("_".ToCharArray());
                rowIdx = int.Parse(buff[0]);
                colIdx = int.Parse(buff[1]);
                if (rowIdx == goalX && colIdx == goalY)
                    break;

                visited[rowIdx][colIdx] = 'V';

                int[][] directionMap = new int[4][];

                //To Left
                for(int col = colIdx - 1; col >= 0; col--)
                {
                    if (grid[rowIdx][col] == 'X')
                        break;
                    if (visited[rowIdx][col] == 'N')
                    {
                        nextToVisit.Enqueue(string.Format("{0}_{1}", rowIdx, col));
                        visited[rowIdx][col] = 'P';
                        map[rowIdx][col] = string.Format("{0}_{1}", rowIdx, colIdx);
                    }
                }
                //To Right
                for (int col = colIdx + 1; col < lenY; col++)
                {
                    if (grid[rowIdx][col] == 'X')
                        break;
                    if( visited[rowIdx][col] == 'N')
                    {
                        nextToVisit.Enqueue(string.Format("{0}_{1}", rowIdx, col));
                        visited[rowIdx][col] = 'P';
                        map[rowIdx][col] = string.Format("{0}_{1}", rowIdx, colIdx);
                    }
                }
                //To Up
                for (int row = rowIdx - 1; row >= 0; row--)
                {
                    if (grid[row][colIdx] == 'X')
                        break;
                    if (visited[row][colIdx] == 'N')
                    {
                        nextToVisit.Enqueue(string.Format("{0}_{1}", row, colIdx));
                        visited[row][colIdx] = 'P';
                        map[row][colIdx] = string.Format("{0}_{1}", rowIdx, colIdx);
                    }
                }
                //To down
                for (int row = rowIdx + 1; row < lenX; row++)
                {
                    if (grid[row][colIdx] == 'X')
                            break;
                    if (visited[row][colIdx] == 'N')
                    {
                        nextToVisit.Enqueue(string.Format("{0}_{1}", row, colIdx));
                        visited[row][colIdx] = 'P';
                        map[row][colIdx] = string.Format("{0}_{1}", rowIdx, colIdx);
                    }
                }
            }

            Stack<string> paths = new Stack<string>();
            int idxX = goalX, idxY = goalY;
            while (string.IsNullOrWhiteSpace(map[idxX][idxY]) == false)
            {
                paths.Push(map[idxX][idxY]);
                string tmp = map[idxX][idxY];
                string[] buff = tmp.Split("_".ToCharArray());
                idxX = int.Parse(buff[0]);
                idxY = int.Parse(buff[1]);
            }

            return paths.Count;
        }



        public static long[] riddleFailed(long[] arr)
        {
            long[] results = new long[arr.Length];

            //Window's size
            for(int ws = 1; ws <= arr.Length; ws++)
            {
                long maxVal = -1;
                //Look up the array
                for (int i = 0; i <= arr.Length - ws;i++)
                {
                    long minVal = arr[i];
                    for(int j = i + 1;j < i + ws; j++)
                    {
                        if (minVal > arr[j])
                            minVal = arr[j];
                    }
                    if (maxVal < minVal)
                        maxVal = minVal;
                }

                results[ws - 1] = maxVal;
            }

            return results;
        }



        #endregion



        #region | Sorting | 

        public static void countSwaps(List<int> a)
        {
            int countOfSwaps = 0;
            //Bubble Sort
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < a.Count - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        CSwaps(a, j, j + 1);
                        countOfSwaps++;
                    }
                }
            }

            Console.WriteLine("Array is sorted in {0} swaps.", countOfSwaps);
            Console.WriteLine("First Element: {0}", a[0]);
            Console.WriteLine("Last Element: {0}", a[a.Count - 1]);
        }
        public static void CSwaps(List<int> a, int idx1, int idx2)
        {
            int tmp = a[idx1];
            a[idx1] = a[idx2];
            a[idx2] = tmp;
        }
        private void BubbleSort(List<int> a)
        {
            int lastUnsortedIdx = a.Count - 1;
            while (lastUnsortedIdx > 0)
            {
                for (int j = 0; j < lastUnsortedIdx; j++)
                {
                    if (a[j] > a[j + 1])
                        CSwaps(a, j, j + 1);
                }
                lastUnsortedIdx--;
            }
        }

        public static int maximumToys(List<int> prices, int k)
        {
            int numOfToys = 0, totalPrice = 0;
            prices.Sort();
            foreach (int p in prices)
            {
                totalPrice += p;
                if (totalPrice > k)
                    break;
                else
                    numOfToys++;
            }
            return numOfToys;

            //int aux, countToys = 0, sumPrice = 0;

            //while (sumPrice < k)
            //{
            //    for (int index = prices.Length - 1; index > countToys; index--)
            //    {
            //        if (prices[index] < prices[index - 1])
            //        {
            //            //swap
            //            aux = prices[index];
            //            prices[index] = prices[index - 1];
            //            prices[index - 1] = aux;
            //        }
            //    }

            //    if (sumPrice + prices[countToys] <= k)
            //    {
            //        sumPrice += prices[countToys];
            //        countToys++;
            //    }
            //    else
            //        return countToys;
            //}

            //return countToys;
        }

        static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;

            int pivot = arr[(left + right) / 2];
            int idx = Partition(arr, left, right, pivot);
        }
        static int Partition(int[] arr, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (arr[left] < pivot)
                    left++;

                while (arr[right] > pivot)
                    right--;

                if (left <= right)
                {
                    SSwaps(arr, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }
        public static void SSwaps(int[] a, int idx1, int idx2)
        {
            int tmp = a[idx1];
            a[idx1] = a[idx2];
            a[idx2] = tmp;
        }

        //Fraudulent Activity Notifications
        //https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
        public static int activityNotifications(List<int> expenditure, int d)
        {
            int cntNotifications = 0;
            int maxExpenditure = GetMaxValue(expenditure);
            bool isOdd = d % 2 == 1;
            int n = expenditure.Count;
            int[] cntExpenditures = new int[maxExpenditure + 1];
            for (int i = 0; i < d; i++)
                cntExpenditures[expenditure[i]]++;

            for(int i = d; i < n; i++)
            {
                double medianVal = GetMedianValue(cntExpenditures, d, isOdd);
                if (expenditure[i] >= medianVal*2)
                    cntNotifications++;

                cntExpenditures[expenditure[i]]++;
                cntExpenditures[expenditure[i-d]]--;
            }

            return cntNotifications;
        }
        static int GetMaxValue(List<int> arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                if (max < arr[i])
                    max = arr[i];
            }

            return max;
        }
        static double GetMedianValue(int[] counting, int d, bool isOdd)
        {
            double result = 0.0;        
            int currCount = 0;
            int medianCount = d / 2;
            if (isOdd)
                medianCount++;

            int idx = 0;
            while (idx < counting.Length)
            {
                currCount += counting[idx];
                if (currCount >= medianCount)
                {
                    if( result > 0)
                    {
                        result = (result + idx) / 2.0;
                        break;
                    }

                    result = idx;
                    if( isOdd || currCount > medianCount)
                        break;
                }

                idx++;
            }

            return result;
        }


        public static long countInversions(List<int> arr)
        {
            return MergeSort(arr.ToArray(), new int[arr.Count], 0, arr.Count - 1);
        }
        public static long MergeSort(int[] arr, int[] temp, int startIdx, int endIdx)
        {
            long cntSwaps = 0;

            if (startIdx >= endIdx)
                return cntSwaps;

            int middleIdx = (startIdx + endIdx) / 2;

            cntSwaps += MergeSort(arr, temp, startIdx, middleIdx);
            cntSwaps += MergeSort(arr, temp, middleIdx+1, endIdx);
            cntSwaps += MergeHalves(arr, temp, startIdx, middleIdx+1, endIdx);

            return cntSwaps;
        }

        public static long MergeHalves(int[] arr, int[] temp, int startIdx, int middleIdx, int endIdx)
        {
            long cntSwaps = 0;

            int left = startIdx;
            int leftEnd = middleIdx - 1;
            int right = middleIdx;
            int rightEnd = endIdx;
            int tempIdx = startIdx;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (arr[left] > arr[right])
                {
                    //Needs to swap
                    temp[tempIdx] = arr[right];
                    right++;

                    cntSwaps += middleIdx - left;
                }
                else
                {
                    temp[tempIdx] = arr[left];
                    left++;
                }
                tempIdx++;
            }

            while (left <= leftEnd)
                temp[tempIdx++] = arr[left++];

            while (right <= rightEnd)
                temp[tempIdx++] = arr[right++];

            for (int i = startIdx; i <= endIdx; i++)
                arr[i] = temp[i];

            return cntSwaps;
        }



        static int RemoveDuplicates(int[] arr, int n)
        {
            int newLen = 0;
            for(int i = 0; i < n-1; i++)
            {
                if( arr[i] != arr[i+1])
                {
                    arr[newLen] = arr[i];
                    newLen++;
                }
            }
            arr[newLen] = arr[n - 1];
            newLen++;

            return newLen;
        }
        #endregion


        #region | String Manipulation | 

        public static int makeAnagram(string a, string b)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int numOfDeletions = 0;
            foreach (char c in a)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else
                    map.Add(c, 1);
            }

            foreach (char c in b)
            {
                if (map.ContainsKey(c))
                {
                    map[c]--;
                    if (map[c] == 0)
                        map.Remove(c);
                }
                else
                    numOfDeletions++;
            }

            foreach (var d in map)
                numOfDeletions += d.Value;

            return numOfDeletions;
        }

        public static int alternatingCharacters(string s)
        {
            int numOfDeletions = 0;

            char c = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == c)
                    numOfDeletions++;
                else
                {
                    c = s[i];
                }
            }

            return numOfDeletions;
        }

        public static string isValid(string s)
        {
            Dictionary<char, int> mapChars = new Dictionary<char, int>();
            Dictionary<int, int> mapCounts = new Dictionary<int, int>();

            foreach (char c in s)
            {
                if (mapChars.ContainsKey(c))
                {
                    if (mapCounts.ContainsKey(mapChars[c]))
                    {
                        if (mapCounts[mapChars[c]] > 1)
                            mapCounts[mapChars[c]]--;
                        else
                            mapCounts.Remove(mapChars[c]);
                    }
                    mapChars[c]++;
                }
                else
                    mapChars.Add(c, 1);

                if (mapCounts.ContainsKey(mapChars[c]))
                    mapCounts[mapChars[c]]++;
                else
                    mapCounts.Add(mapChars[c], 1);
            }

            bool isValid = false;
            if (mapCounts.Count == 1)
                isValid = true;
            else if (mapCounts.Count == 2)
            {
                if (mapCounts.ContainsKey(1) && mapCounts[1] == 1)
                    isValid = true;
                else
                {
                    int diff = -1;
                    bool oneExist = false;
                    foreach (var c in mapCounts)
                    {
                        if (diff < 0)
                            diff = c.Key;
                        else
                            diff = Math.Abs(diff - c.Key);
                        if (c.Value == 1)
                            oneExist = true;
                    }
                    if (diff == 1 && oneExist)
                        isValid = true;
                }
            }

            return isValid ? "YES" : "NO";
        }


        public static long substrCount(int n, string s)
        {
            long cntOfSS = 0;
            List<int> cnts = new List<int>();
            List<char> chars = new List<char>();
            int idxChar = 0;
            chars.Add(s[0]);
            cnts.Add(1);
            for (int i = 1; i < n; i++)
            {
                if (chars[idxChar] == s[i])
                    cnts[idxChar]++;
                else
                {
                    chars.Add(s[i]);
                    cnts.Add(1);
                    idxChar++;
                }
            }

            //check all sam letters
            for (int i = 0; i < chars.Count; i++)
            {
                cntOfSS += (cnts[i] * (cnts[i] + 1)) / 2;
            }

            for (int i = 1; i < chars.Count - 1; i++)
            {
                if (cnts[i] == 1 && chars[i - 1] == chars[i + 1])
                    cntOfSS += Math.Min(cnts[i - 1], cnts[i + 1]);
            }

            return cntOfSS;
        }

        //최장 공통 부분 문자열(LCS, Longest Common Substring)
        public static int commonChild(string s1, string s2)
        {
            int n = s1.Length + 1;
            int m = s2.Length + 1;
            int[][] martrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                martrix[i] = new int[m];
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (row == 0 || col == 0)
                        martrix[row][col] = 0;
                    else
                    {
                        if (s1[row - 1] == s2[col - 1])
                            martrix[row][col] = martrix[row - 1][col - 1] + 1;
                        else
                            martrix[row][col] = Math.Max(martrix[row - 1][col], martrix[row][col - 1]);
                    }
                }
            }

            return martrix[s1.Length][s2.Length];
        }


        public static long arrayManipulation(int n, List<List<int>> queries)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = 0;

            foreach (var operation in queries)
            {
                int from = operation[0] - 1;
                int to = operation[1];
                if (from >= 0 && from < n)
                    array[from] += operation[2];

                if (to >= 0 && to < n)
                    array[to] -= operation[2];
            }

            long sum = 0, max = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
                max = Math.Max(sum, max);
            }

            return max;
        }

        #endregion


        #region | Greedy Algorithms | 

        public static int minimumAbsoluteDifference(List<int> arr)
        {
            if (arr == null || arr.Count < 2)
                return -1;

            int[] sortedArr = arr.ToArray();
            Array.Sort(sortedArr);
            int min = Math.Abs(sortedArr[0] - sortedArr[1]);
            for (int i = 1; i < sortedArr.Length - 1; i++)
            {
                min = Math.Min(min, Math.Abs(sortedArr[i] - sortedArr[i + 1]));
            }

            return min;
        }

        public static int luckBalance(int k, List<List<int>> contests)
        {
            int luckBal = 0;

            List<int> importantContests = new List<int>();
            foreach (List<int> contest in contests)
            {
                if (contest[1] == 1)
                    importantContests.Add(contest[0]);
                else
                    luckBal += contest[0];
            }
            int[] sortedCon = importantContests.ToArray();
            Array.Sort(sortedCon);

            for (int i = 0; i < sortedCon.Length; i++)
            {
                if (i < (sortedCon.Length - k))
                    luckBal -= sortedCon[i];
                else
                    luckBal += sortedCon[i];
            }

            return luckBal;
        }

        public static int getMinimumCost(int k, int[] c)
        {
            int total = 0;
            Array.Sort(c);
            int n = c.Length;

            int idx = -1;
            for (int i = 0; i <= n / k; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    idx = i * k + j;
                    if (idx <= n)
                        total += c[n - idx] * (i + 1);
                    else
                        return total;
                }
            }

            return total;
        }


        public static int maxMin(int k, List<int> arr)
        {
            int[] sortedArr = arr.ToArray();
            Array.Sort(sortedArr);
            int minUnfairness = sortedArr[k - 1] - sortedArr[0];
            for (int i = 1; i <= sortedArr.Length - k; i++)
                minUnfairness = Math.Min(minUnfairness, (sortedArr[k - 1 + i] - sortedArr[i]));

            return minUnfairness;
        }

        #endregion


        #region | Dynamic Programming & Memorization | 

        //Recursive
        public static long Fibonacci(int n, Dictionary<int, long> memo)
        {
            if (n == 0)
                return 0;
            else if (n <= 2)
                return 1;

            if (memo.ContainsKey(n))
                return memo[n];

            long val = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
            memo.Add(n, val);
            return val;
        }
        //Repeat
        public static long Fibonacci2(int n)
        {
            Dictionary<int, long> memo = new Dictionary<int, long>();
            for (int i = 0; i <= n; i++)
            {
                if (i == 0)
                    memo.Add(0, 0);
                else if (i <= 2)
                    memo.Add(i, 1);
                else
                {
                    memo.Add(i, memo[i - 1] + memo[i - 2]);
                }
            }

            return memo[n];
        }



        public static int maxSubsetSum(int[] arr)
        {
            arr[0] = Math.Max(0, arr[0]);
            if (arr.Length == 1) return arr[0];
            arr[1] = Math.Max(arr[1], arr[0]);

            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = Math.Max(arr[i - 1], arr[i] + arr[i - 2]);
            }

            return arr[arr.Length - 1];
            //return Math.Max(maxSubSum(arr, arr.Length - 1), maxSubSum(arr, arr.Length - 2));
        }
        public static int maxSubSum(int[] arr, int n)
        {
            if (n < 0)
                return 0;

            int max = arr[n] < 0 ? 0 : arr[n];
            max = Math.Max(maxSubSum(arr, n - 2), maxSubSum(arr, n - 2) + max);
            return max;
        }

        //Longest common subsequence
        public static int LongesCommonSubsequence(string a, string b)
        {
            int lenSubSequence = 0;

            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
                return lenSubSequence;

            int lenA = a.Length;
            int lenB = b.Length;
            if (a[lenA - 1] == b[lenB - 1]) {
                lenSubSequence = lenSubSequence + 1 + LongesCommonSubsequence(a.Substring(0, lenA - 1), b.Substring(0, lenB - 1));
            }
            else
            {
                lenSubSequence = Math.Max(LongesCommonSubsequence(a.Substring(0, lenA - 1), b.Substring(0, lenB))
                                        , LongesCommonSubsequence(a.Substring(0, lenA), b.Substring(0, lenB - 1)));
            }

            return lenSubSequence;
        }
        public static string abbreviation(string a, string b)
        {
            Dictionary<string, bool> hashMap = new Dictionary<string, bool>();
            return AbbreviationHandle(a, a.Length, b, b.Length, hashMap) ? "YES" : "NO";

        }
        public static bool AbbreviationHandle(string a, int lenA, string b, int lenB, Dictionary<string, bool> hashMap)
        {
            bool isResult = false;
            string mapKey = string.Format("{0}_{1}", lenA, lenB);
            if (hashMap.ContainsKey(mapKey))
                return hashMap[mapKey];
            else if (string.IsNullOrWhiteSpace(b))
                isResult = true;
            else if ((string.IsNullOrWhiteSpace(a) && b.Length > 0)
                    || a.Length < b.Length)
                isResult = false;
            else
            {
                if (a[lenA-1] == b[lenB - 1])
                    isResult = AbbreviationHandle(a.Substring(0, lenA - 1), lenA - 1, b.Substring(0, lenB-1), lenB - 1, hashMap);
                else
                {

                    if (Char.IsLower(a[lenA - 1]) && char.ToUpper(a[lenA - 1]) == b[lenB - 1])
                    {
                        isResult = AbbreviationHandle(a.Substring(0, lenA - 1), lenA - 1, b.Substring(0, lenB-1), lenB - 1, hashMap)
                                || AbbreviationHandle(a.Substring(0, lenA - 1), lenA - 1, b.Substring(0, lenB), lenB, hashMap);
                    }
                    else if (Char.IsLower(a[lenA - 1]) && char.ToUpper(a[lenA - 1]) != b[lenB - 1])
                        isResult = AbbreviationHandle(a.Substring(0, lenA - 1), lenA - 1, b.Substring(0, lenB), lenB, hashMap);
                    else
                        isResult = false;
                }
            }
            if (hashMap.ContainsKey(mapKey) == false)
                hashMap.Add(mapKey, isResult);

            return isResult;
        }

        public static long candies(int n, List<int> arr)
        {
            long totalCnt = 0;
            if (n == 1)
                return 1;
            else if(n == 2)
            {
                if (arr[0] == arr[1])
                    return 2;
                else
                    return 3;
            }

            int[] candyMapLeft2Right = new int[n];
            candyMapLeft2Right[0] = 1;
            //Check left part 
            for(int i = 1;i < n; i++)
            {
                if (arr[i - 1] < arr[i])
                    candyMapLeft2Right[i] = candyMapLeft2Right[i - 1] + 1;
                else
                    candyMapLeft2Right[i] = 1;
            }

            //Check right part
            int[] candyMapRight2Left = new int[n];
            candyMapRight2Left[n - 1] = 1;
            for (int i = n -2; i >=0; i--)
            {
                if (arr[i] > arr[i + 1])
                    candyMapRight2Left[i] = candyMapRight2Left[i + 1] + 1;
                else
                    candyMapRight2Left[i] = 1;
            }

            for(int i = 0; i < n; i++)
                totalCnt += Math.Max(candyMapLeft2Right[i], candyMapRight2Left[i]);

            return totalCnt;
        }

        public static long stockmax(List<int> prices)
        {
            int max = prices[prices.Count - 1];
            long profit = 0;

            for(int i = prices.Count - 2; i >= 0; i--)
            {
                max = Math.Max(max, prices[i + 1]);
                if (prices[i] < max)
                    profit += max - prices[i];
            }

            return profit;
        }


        public static int ChangeMakingProblem(int[] coins, int amount)
        {
            if (amount <= 0)
                return 0;
            else if (coins == null || coins.Length < 1)
                return -1;

            
            Dictionary<int, int> mapAmount = new Dictionary<int, int>();
            mapAmount.Add(0, 0);
            Array.Sort(coins);
            //int numOfCoins = ChangeMakingProblemBottomUp(coins, amount, mapAmount);
            int numOfCoins = ChangeMakingProblemTopDown(coins, coins.Length, amount+1, amount, mapAmount);
            if (numOfCoins > amount)
                return -1;
            else
                return numOfCoins;

        }
        public static int ChangeMakingProblemBottomUp(int[] coins, int amount, Dictionary<int, int> mapAmount)
        {
            for (int i = 1; i <= amount; i++)
            {
                int minVal = amount + 1;
                foreach (int c in coins) {
                    if (i < c)
                        break;
                    else
                    {
                        if (mapAmount.ContainsKey(i - c))
                            minVal = Math.Min(mapAmount[i - c]+1, minVal);
                    }
                }
                mapAmount.Add(i, minVal);
            }

            return mapAmount[amount];
        }
        public static int ChangeMakingProblemTopDown(int[] coins, int n, int initMinVal, int amount, Dictionary<int, int> mapAmount)
        {
            if (amount <= 0)
                return 0;
            else if (mapAmount.ContainsKey(amount))
                return mapAmount[amount];

            int minVal = initMinVal;
            for(int i = 0; i < coins.Length; i++)
            {
                if (amount - coins[i] >= 0)
                {
                    int tmp = ChangeMakingProblemTopDown(coins, n, initMinVal, amount - coins[i], mapAmount);
                    minVal = Math.Min(minVal, tmp + 1);
                }
            }
            mapAmount.Add(amount, minVal);
            return minVal;
        }


        //
        //Edit Distance Between 2 Strings - The Levenshtein Distance ("Edit Distance" on LeetCode)
        //Replace
        //Insert
        //Delete

        //gg Dropping Problem: Dynamic Programming Fundamentals 
        //https://leetcode.com/problems/longest-common-subsequence/
        public int LongestCommonSubsequence(string text1, string text2)
        {
            //abcde      ace
            //     Equal: +1      abcd     ac     remove the last character
            // Not Equal: +0      MAX( (abcd, a) , (abc, ac) )
            //                   +0 
            //Focus on the last character. 

            Dictionary<string, int> dp = new Dictionary<string, int>();
            return LongestCommonSubsequence1(text1, text2, dp);
        }
        public int LongestCommonSubsequence1(string text1, string text2, Dictionary<string, int> dp)
        {
            //abcde      ace
            //     Equal: +1      abcd     ac     remove the last character
            // Not Equal: +0      MAX( (abcd, a) , (abc, ac) )
            //                   +0 
            //Focus on the last character. 

            if (string.IsNullOrWhiteSpace(text1) || string.IsNullOrWhiteSpace(text2))
                return 0;

            if (dp.ContainsKey(string.Format("{0}_{1}", text1.Length, text2.Length)))
                return dp[string.Format("{0}_{1}", text1.Length, text2.Length)];

            int longestLen = 0;
            if (text1[text1.Length - 1] == text2[text2.Length - 1])
            {

                longestLen = 1 + LongestCommonSubsequence1(text1.Substring(0, text1.Length - 1), text2.Substring(0, text2.Length - 1), dp);
            }
            else
            {
                longestLen = Math.Max(LongestCommonSubsequence1(text1.Substring(0, text1.Length - 1), text2, dp)
                    , LongestCommonSubsequence1(text1, text2.Substring(0, text2.Length - 1), dp));
            }

            dp.Add(string.Format("{0}_{1}", text1.Length, text2.Length), longestLen);
            return longestLen;
        }
        //1143. Longest Common Subsequence


        //Maximum Sum Rectangle In A 2D Matrix - Kadane's Algorithm Applications
        //https://www.youtube.com/watch?v=-FgseNO-6Gk
        //Time : O(cols*cols*rows)
        //Space: O(rows)



        #endregion


        #region | Search | 

        //Triple Sum
        //https://www.hackerrank.com/challenges/triple-sum/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        public static long triplets(int[] a, int[] b, int[] c)
        {
            long numOfTriplets = 0;

            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);
            if (a[0] > b[b.Length - 1] || c[0] > b[b.Length - 1])
                return 0;

            int[] newA = a.Distinct().ToArray();
            int[] newB = b.Distinct().ToArray();
            int[] newC = c.Distinct().ToArray();

            long idxA = 0, idxC = 0;
            for (int idxB = 0; idxB < newB.Length; idxB++)
            {
                while (idxA < newA.Length && newB[idxB] >= newA[idxA])
                    idxA++;

                while (idxC < newC.Length && newB[idxB] >= newC[idxC])
                    idxC++;

                numOfTriplets += idxA * idxC;
            }

            return numOfTriplets;
        }


        //Minimum Time Required
        //https://www.hackerrank.com/challenges/minimum-time-required/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        public static long minTime(long[] machines, long goal)
        {
            long maxDurationDays = machines[0];
            for (int i = 1; i < machines.Length; i++)
                maxDurationDays = Math.Max(maxDurationDays, machines[i]);


            return BSMachines(machines, machines.Length, goal, maxDurationDays * goal);
        }
        public static long BSMachines(long[] machines, int n, long goal, long maxDays)
        {
            long minDays = 1;

            //Doing Binary Search to find Minimum Time
            while(minDays < maxDays)
            {
                //Finding a middle value
                long middleDays = maxDays/2 + minDays/2;

                long numOfItems = FindNumOfItems(machines, middleDays);

                if (numOfItems < goal)
                {
                    minDays = middleDays + 1;
                }
                else
                    maxDays = middleDays;
            }

            return maxDays;
        }
        public static long FindNumOfItems(long[] machines, long days)
        {
            long numOfItems = 0;
            foreach(long m in machines)
            {
                numOfItems += days / m;
            }

            return numOfItems;
        }



        #endregion


        #region | Graph | 

        //Roads and Libraries
        public static long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
        {
            //If library cost is equal or less than road then build a library in all cities.
            if (c_lib <= c_road || n == 1 || cities == null || cities.Count <= 0)
                return c_lib * n;

            //How to collect all cities connected
            //Iteration 
            // First. Pick one node
            //        Using DFS to mark all connected cities as visited 
            // Build one library and build # of cities - 1 roads.
            // Second. Pick one node didn't visist yet.
            // Keep going until every city visit 

            //Step 01. Convert List<List<int>> to LinkedList
            LinkedList<int>[] listOfCities = new LinkedList<int>[n+1];

            for (int c = 0; c < cities.Count; c++)
            {
                if (listOfCities[cities[c][0]] == null)
                {
                    listOfCities[cities[c][0]] = new LinkedList<int>();
                    listOfCities[cities[c][0]].AddFirst(cities[c][0]);
                }
                listOfCities[cities[c][0]].AddLast(new LinkedListNode<int>(cities[c][1]));

                if (cities[0][0] != cities[0][1])
                {
                    if (listOfCities[cities[c][1]] == null)
                    {
                        listOfCities[cities[c][1]] = new LinkedList<int>();
                        listOfCities[cities[c][1]].AddFirst(cities[c][1]);
                    }
                    listOfCities[cities[c][1]].AddLast(new LinkedListNode<int>(cities[c][0]));
                }
            }

            //Step 02.
            bool[] visited = new bool[n];
            long totalCost = 0;
            for (int i = 0; i < n; i++)
            {
                if(visited[i] == false)
                {
                    int numOfCities = 1;
                    Queue<int> nextToVisit = new Queue<int>();
                    nextToVisit.Enqueue(i);
                    visited[i] = true;
                    while (nextToVisit.Count > 0)
                    {
                        int currCity = nextToVisit.Dequeue();

                        for (int c = cities.Count - 1; c >= 0; c--)
                        {
                            //Bidirectional road - Needs to both ways
                            int city = -1;
                            if ((cities[c][0] - 1) == currCity && visited[cities[c][1] - 1] == false)
                                city = cities[c][1] - 1;
                            else if ((cities[c][1] - 1) == currCity && visited[cities[c][0] - 1] == false)
                                city = cities[c][0] - 1;
                            if (city > -1)
                            {
                                nextToVisit.Enqueue(city);
                                visited[city] = true;
                                numOfCities++;

                                //Removed visited citi link 
                                cities.RemoveAt(c);
                            }
                        }
                    }

                    totalCost += c_lib + c_road * 1L * (numOfCities - 1);
                }
            }

            return totalCost;
        }


        public static int findShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] ids, int val)
        {
            List<int>[] graph = new List<int>[graphNodes];
            Dictionary<int, int> dist = new Dictionary<int, int>();
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < graphNodes; i++)
                graph[i] = new List<int>();

            for (int i = 0; i < graphFrom.Length; i++)
            {
                graph[graphFrom[i] - 1].Add(graphTo[i]);
                graph[graphTo[i] - 1].Add(graphFrom[i]);
            }

            Queue<int> nextToVisit = new Queue<int>();
            //EnQueue the color nodes we're looking for
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == val)
                {
                    nextToVisit.Enqueue(i + 1);
                    dist.Add(i + 1, 0);
                }
            }

            if (nextToVisit.Count < 2)
                return -1;

            while(nextToVisit.Count > 0)
            {
                int currNode = nextToVisit.Dequeue();
                if (visited.Contains(currNode))
                    continue;
                visited.Add(currNode);

                //Search adjacent nodes
                foreach(int adjacent in graph[currNode - 1])
                {
                    if (dist.ContainsKey(adjacent) && visited.Contains(adjacent) == false)
                    {
                        return dist[currNode] + dist[adjacent] + 1;
                    }
                    else
                    {
                        nextToVisit.Enqueue(adjacent);
                        if(dist.ContainsKey(adjacent) == false)
                            dist.Add(adjacent, dist[currNode] + 1);
                        else
                            dist[adjacent] = dist[currNode] + 1;
                    }
                }
            }

            return -1;
        }

        //
        public static int DijkstraAlgorithm()
        {
            int lenVertexes = 0;
            int[] dist = new int[lenVertexes];

            return -1;
        }
        #endregion

        #region |  Amazon | 

        public static int arraySum(List<int> numbers)
        {
            int sum = numbers[0];
            for(int i = 1; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
            
        }



        public static long howManySwaps1(List<int> arr)
        {
            return MergeSort1(arr.ToArray(), new int[arr.Count], 0, arr.Count - 1);
        }
        public static long MergeSort1(int[] arr, int[] temp, int left, int right)
        {
            long cntSwaps = 0;

            int mid = -1;
            if (right > left)
            {
                mid = (right + left) / 2;

                cntSwaps = MergeSort1(arr, temp, left, mid);
                cntSwaps += MergeSort1(arr, temp, mid + 1, right);
                cntSwaps += MergeHalves1(arr, temp, left, mid + 1, right);
            }

            return cntSwaps;
        }
        public static long MergeHalves1(int[] arr, int[] temp, int left, int mid, int right)
        {
            long cntSwaps = 0;

            int i = left;
            int j = mid;
            int sub = left;

            while ((i <= mid - 1) && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[sub++] = arr[i++];
                else
                {
                    temp[sub++] = arr[j++];

                    cntSwaps += mid - i;
                }
            }

            while (i <= mid - 1)
                temp[sub++] = arr[i++];

            while (j <= right)
                temp[sub++] = arr[j++];

            for (i = left; i <= right; i++)
                arr[i] = temp[i];

            return cntSwaps;
        }


        public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        {
            List<int> results = new List<int>();
            int n = s.Length;
            Dictionary<int, int> mapStocks = new Dictionary<int, int>();

            bool started = false;
            int itemSum = 0, totalTtemSum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '|')
                {
                    if (started)
                    {
                        totalTtemSum += itemSum;
                        mapStocks.Add(i, totalTtemSum);
                    }
                    else
                        mapStocks.Add(i, 0);
                    started = true;
                    itemSum = 0;
                }
                else
                    itemSum++;
            }

            for (int i = 0; i < startIndices.Count; i++)
            {
                int start = startIndices[i] - 1;
                int end = endIndices[i] - 1;
                int sTmp = 0, eTmp = 0;
                if (mapStocks.ContainsKey(start))
                    sTmp = mapStocks[start];
                if (mapStocks.ContainsKey(end))
                    eTmp = mapStocks[end];

                results.Add(eTmp - sTmp);
            }

            return results;

        }

        #endregion



        #region | LeetCode | 

        //01 Matrix
        //https://leetcode.com/problems/01-matrix/submissions/
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
            if (iCol - 1 >= 0 && mat[iRow][iCol-1] == 1)
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
        #endregion
    }


    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int data)
        {
            this.data = data;
        }
    }
}
