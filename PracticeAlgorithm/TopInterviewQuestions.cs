using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm
{
    [TestClass]
    public class TopInterviewQuestions
    {
        #region | Print | 

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

        #endregion


        #region | Array | 

        [TestMethod]
        public void MaxProfit()
        {
            Print(MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));

        }
        public int MaxProfit(int[] prices)
        {
            int maxprofit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
            }
            return maxprofit;

            int totalProfit = 0;
            if (prices == null || prices.Length <= 0)
                return totalProfit;

            int currentPrice = -1;
            bool isBuy = true;
            for (int i = 1; i < prices.Length; i++)
            {
                if (isBuy)
                {
                    //BUY
                    if (prices[i - 1] < prices[i])
                    {
                        currentPrice = prices[i - 1];
                        isBuy = false;
                    }
                }
                else
                {
                    //SELL
                    if (prices[i - 1] > prices[i])
                    {
                        totalProfit += prices[i - 1] - currentPrice;
                        currentPrice = prices[i - 1];
                        isBuy = true;
                    }
                }
            }
            if (isBuy == false)
            {
                //SELL
                if (prices[prices.Length - 1] > currentPrice)
                    totalProfit += prices[prices.Length - 1] - currentPrice;
            }
            return totalProfit;
        }


        [TestMethod]
        public void Rotate()
        {
            Rotate(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3);
        }
        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length < 2)
                return;
            if (k > nums.Length)
                k = k % nums.Length;
            if (k == 0)
                return;

            RotateReverse(nums, 0, nums.Length - 1);
            RotateReverse(nums, 0, k - 1);
            RotateReverse(nums, k, nums.Length - 1);
        }
        private void RotateReverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int tmp = nums[start];
                nums[start] = nums[end];
                nums[end] = tmp;
                start++;
                end--;
            }
        }

        [TestMethod]
        public void ContainsDuplicate()
        {

        }
        public bool ContainsDuplicate(int[] nums)
        {
            bool retVal = false;
            if (nums == null || nums.Length < 2)
                return retVal;

            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    retVal = true;
                    break;
                }
                else
                    set.Add(nums[i]);
            }

            return retVal;
        }

        [TestMethod]
        public void SingleNumber()
        {
            SingleNumber(new int[] { 4, 1, 2, 1, 2 });
        }
        public int SingleNumber(int[] nums)
        {
            int singleNum = 0;
            if (nums.Length == 1)
                return nums[0];

            foreach (int n in nums)
            {
                singleNum ^= n;
            }
            return singleNum;

            Array.Sort(nums);

            int i = 0;
            for (; i < nums.Length - 1; i += 2)
            {
                if (nums[i] != nums[i + 1])
                {
                    singleNum = nums[i];
                    break;
                }
            }
            if (i == nums.Length - 1)
                singleNum = nums[nums.Length - 1];

            return singleNum;
        }

        [TestMethod]
        public void Intersect()
        {

        }
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            //Case 1
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> returnList = new List<int>();

            foreach (int num1 in nums1)
            {
                if (map.ContainsKey(num1))
                    map[num1]++;
                else
                    map.Add(num1, 1);
            }

            foreach (int num2 in nums2)
            {
                if (map.ContainsKey(num2) && map[num2] != 0)
                {
                    returnList.Add(num2);
                    map[num2]--;
                }
            }

            return returnList.ToArray();

            //Case 2.
            Array.Sort(nums1);
            Array.Sort(nums2);
            List<int> retVal = new List<int>();

            int i = 0, j = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    retVal.Add(nums1[i]);
                    i++; j++;
                }
                else if (nums1[i] > nums2[j])
                    j++;
                else
                    i++;
            }

            return retVal.ToArray<int>();
        }

        [TestMethod]
        public void PlusOne()
        {
            PlusOne(new int[] { 9, 9 });
        }
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


        [TestMethod]
        public void MoveZeroes()
        {
            MoveZeroes(new int[] { 0, 1, 0, 3, 12 });
        }
        public void MoveZeroes(int[] nums)
        {
            int numOfNotZero = 0;
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (nums[i] != 0)
                {
                    if (numOfNotZero != i)
                    {
                        nums[numOfNotZero] = nums[i];
                        nums[i] = 0;
                    }
                    numOfNotZero++;
                }
            }

            //for (int i = numOfNotZero; i <= nums.Length - 1; i++)
            //    nums[i] = 0;
        }


        [TestMethod]
        public void TwoSum()
        {

        }
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int[] retVal = new int[2];
            for(int i = 0; i < nums.Length; i++)
            {
                if(dic.ContainsKey(target - nums[i]))
                {
                    retVal[0] = dic[target - nums[i]];
                    retVal[1] = i;
                    break;
                }
                else
                    dic.Add(nums[i], i);
            }

            return retVal;
        }


        [TestMethod]
        public void IsValidSudoku()
        {
            //char[][] tmp = new char[9][];
            //tmp[0] = new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
            //tmp[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
            //tmp[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
            //tmp[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
            //tmp[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
            //tmp[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
            //tmp[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
            //tmp[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
            //tmp[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
            char[][] tmp = new char[9][];
            tmp[0] = new char[] { '.', '.', '4', '.', '.', '.', '6', '3', '.' };
            tmp[1] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            tmp[2] = new char[] { '5', '.', '.', '.', '.', '.', '.', '9', '.' };
            tmp[3] = new char[] { '.', '.', '.', '5', '6', '.', '.', '.', '.' };
            tmp[4] = new char[] { '4', '.', '3', '.', '.', '.', '.', '.', '1' };
            tmp[5] = new char[] { '.', '.', '.', '7', '.', '.', '.', '.', '.' };
            tmp[6] = new char[] { '.', '.', '.', '5', '.', '.', '.', '.', '.' };
            tmp[7] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            tmp[8] = new char[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };

            Print(IsValidSudoku(tmp));  
        }
        public bool IsValidSudoku(char[][] board)
        {
            bool isValid = true;

            List<char> rows = new List<char>();
            List<char>[] cols = new List<char>[9];
            List<char>[] boxes = new List<char>[9];
            for(int i = 0; i < 9; i++)
            {
                cols[i] = new List<char>();
                boxes[i] = new List<char>();
            }

            //Check row & column
            for (int i = 0; i< board.Length; i++)
            {
                rows.Clear();
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] != '.') {
                        //Rows
                        if (rows.Contains(board[i][j]))
                        {
                            isValid = false;
                            break;
                        }
                        else
                            rows.Add(board[i][j]);

                        //Cols 
                        if (cols[j].Contains(board[i][j]))
                        {
                            isValid = false;
                            break;
                        }
                        else
                            cols[j].Add(board[i][j]);

                        //Boxes
                        int idx = i / 3 + (j / 3)*3;
                        if (boxes[idx].Contains(board[i][j]))
                        {
                            isValid = false;
                            break;
                        }
                        else
                            boxes[idx].Add(board[i][j]);
                    }
                }

                if (isValid == false)
                    break;
            }

            return isValid;
        }


        [TestMethod]
        public void RotateImage()
        {

        }
        public void RotateImage(int[][] matrix)
        {
            Transpose(matrix);
            Reflect(matrix);
        }
        public void Transpose(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int tmp = matrix[j][i];
                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = tmp;
                }
            }
        }
        public void Reflect(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = tmp;
                }
            }
        }

        public int MyAtoi(string s)
        {
            int retVal = 0;
            bool isNegative = false;
            bool isFirst = true;
            foreach (char c in s)
            {

                int flag = isValidChar(c);
                if (flag == -2)
                {
                    if (isFirst)
                        continue;
                    else
                        break;
                }
                else if (flag == -1)
                {
                    if (isFirst)
                    {
                        if (c == '-')
                            isNegative = true;
                        isFirst = false;
                    }
                    else
                        break;
                }
                else if (flag >= 0 && flag <= 9)
                {
                    isFirst = false;
                    if (isNegative == false)
                    {
                        if (int.MaxValue / 10 < retVal ||
                            (int.MaxValue / 10 == retVal && int.MaxValue % 10 < flag))
                        {
                            retVal = int.MaxValue;
                            break;
                        }
                        else
                        {
                            retVal = retVal * 10 + flag;
                        }
                    }
                    else
                    {
                        if (Math.Abs(int.MinValue / 10) < retVal ||
                            (Math.Abs(int.MinValue / 10) == retVal && Math.Abs(int.MinValue % 10) < flag))
                        {
                            retVal = int.MinValue;
                            break;
                        }
                        else
                        {
                            retVal = retVal * 10 + flag;
                        }
                    }
                }
                else
                    break;
            }

            if ((isNegative == false && retVal == int.MaxValue) || (isNegative && retVal == int.MinValue))
                return retVal;
            else
            {
                if (isNegative)
                    return retVal * -1;
                else
                    return retVal;
            }
        }
        private int isValidChar(char c)
        {
            if (c == '+' || c == '-')
                return -1;
            else if (c == ' ')
                return -2;
            else if ((c - '0') >= 0 && (c - '0') <= 9)
            {
                return c - '0';
            }
            else
                return -9;
        }


        #endregion


        #region | Strings | 

        [TestMethod]
        public void ReverseString()
        {

        }
        public void ReverseString(char[] s)
        {
            ReverseStringEx(s, 0, s.Length-1);
        }
        private void ReverseStringEx(char[] s, int idx1, int idx2)
        {
            if (s == null || s.Length < 1 || idx1 >= idx2)
                return;

            char tmp = s[idx1];
            s[idx1] = s[idx2];
            s[idx2] = tmp;

            ReverseStringEx(s, idx1+1, idx2-1);
        }
        public int Reverse(int x)
        {
            bool isNegative = false;
            if (x < 0)
            {
                isNegative = true;
                x = x * -1;
            }
            int reverseVal = 0;

            while (x != 0){

                if (isNegative)
                {
                    if ( (int.MinValue + (x%10)) / 10 > reverseVal * -1)
                        return 0;
                }
                else
                {
                    if ( (int.MaxValue - (x%10)) / 10 < reverseVal)
                        return 0;
                }

                reverseVal = (int)(reverseVal * 10) + x % 10;
                x = x / 10;
            }

            if (isNegative)
                reverseVal *= -1;

            return reverseVal;
        }


        [TestMethod]
        public void FirstUniqChar()
        {
            FirstUniqChar("leetcode");
        }
        public int FirstUniqChar(string s)
        {
            int retIdx = -1;

            Dictionary<char, int> buff = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (buff.Keys.Contains<char>(c))
                    buff[c]++;
                else
                    buff.Add(c, 1);
            }


            for (int i = 0; i < s.Length; i++)
            {
                if(buff[s[i]] == 1)
                {
                    retIdx = i;
                    break;
                }
            }

            return retIdx;
        }

        public bool IsAnagram(string s, string t)
        {
            bool isAnag = false;

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach(char c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            foreach (char c in t)
            {
                if (dic.ContainsKey(c))
                {
                    if (dic[c] <= 1)
                        dic.Remove(c);

                    else
                        dic[c]--;
                }
                else
                    return false;
            }

            if (dic.Count == 0)
                isAnag = true;

            return isAnag;

            if (s.Length != t.Length) { return false; }
            int[] mylist = new int[26];

            for (int i = 0; i < s.Length; i++)
            {

                mylist[s[i] - 'a']++;
                mylist[t[i] - 'a']--;
            }
            for (int i = 0; i < mylist.Length; i++)
            {
                if (mylist[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void IsPalindrome()
        {
            Print(IsPalindrome("Marge, let's \"[went].\" I await {news} telegram."));
        }
        public bool IsPalindrome(string s)
        {
            s = s.ToUpper();
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (isAlphaNumberic(s[left]) == false)
                    left++;
                else if (isAlphaNumberic(s[right]) == false)
                    right--;
                else
                {
                    if (left < s.Length - 1 && right >= 0)
                    {
                        if (s[left++] != s[right--])
                            return false;
                    }
                    else
                        break;
                }
            }

            return true;
        }
        public bool isAlphaNumberic(char c)
        {
            return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'));
        }



        [TestMethod]
        public void NumIslands()
        {
            NumIslands(null);
        }
        public int NumIslands(char[][] grid)
        {
            int cntIslands = 0;

            int rows = grid.Length;
            if (rows < 1)
                return 0;
            int cols = grid[0].Length;

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
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

            grid[currRow][currCol] = '2';
            visitIsland(grid, currRow-1, currCol, rows, cols);    //UP
            visitIsland(grid, currRow, currCol-1, rows, cols);    //LEFT
            visitIsland(grid, currRow+1, currCol, rows, cols);    //DOWN
            visitIsland(grid, currRow, currCol+1, rows, cols);    //RIGHT
        }

        [TestMethod]
        public void StrStr()
        {
            StrStr("Hello", "ll");
        }
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(needle))
                return 0;
            else if (string.IsNullOrWhiteSpace(haystack))
                return -1;

            int n = haystack.Length;
            int m = needle.Length;
            for (int i = 0; i <= n - m; i++)
            {
                int j = 0;
                while (j < m && haystack[i + j] == needle[j])
                    j++;

                if (j == m)
                    return i;
            }
            return -1;
        }
    






        #endregion


        public int[][] UpdateMatrix(int[][] mat)
        {
            int lenRows = mat.Length;
            int lenCols = mat[0].Length;
            int[][] dist = new int[lenRows][];
            for (int row = 0; row < lenRows; row++)
                dist[row] = new int[lenCols];

            for (int row = 0; row < lenRows; row++)
            {
                for(int col = 0; col < lenCols; col++)
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
            if (iCol + 1 < lenCols && mat[iRow][iCol+1] == 1)
            {
                int tmp = UpdateMatrixHelper(mat, lenRows, lenCols, iRow, iCol+1, dist) + 1;
                if (minVal == null)
                    minVal = tmp;
                else
                    minVal = Math.Min(minVal.Value, tmp);
            }

            //Check left
            if (iCol - 1 >= 0 && mat[iRow][iCol] == 1)
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

            dist[iRow][iCol] = minVal.Value;
            return dist[iRow][iCol];
        }
    }
}
