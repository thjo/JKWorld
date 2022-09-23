using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Study
{
    public class GraphTheoryI
    {
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
            int[][] directions = new int[4][];
            directions[0] = new int[2] { -1, 0 };//Left
            directions[1] = new int[2] { 1, 0 };//Right
            directions[2] = new int[2] { 0, -1 };//Up
            directions[3] = new int[2] { 0, 1 };//Down

            int n = image.Length;
            int m = image[0].Length;
            int[][] visited = new int[image.Length][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new int[m];
                for (int j = 0; j < m; j++)
                    visited[i][j] = 0;
            }

            int oldColor = image[sr][sc];
            FloodFillR(image, sr, sc, newColor, oldColor, n, m, visited, directions);
            return image;
        }
        private void FloodFillR(int[][] image, int sr, int sc, int newColor, int oldColor, int n, int m, int[][] visited, int[][] directions)
        {
            if (sr < 0 || sr >= n)
                return;
            if (sc < 0 || sc >= m)
                return;
            if (visited[sr][sc] == 1)
                return;

            visited[sr][sc] = 1;

            if (image[sr][sc] != oldColor)
                return;
            image[sr][sc] = newColor;
            for (int i = 0; i < 4; i++)
            {
                FloodFillR(image
                 , sr + directions[i][0], sc + directions[i][1]
                 , newColor, oldColor
                 , n, m, visited, directions);
            }
        }


        /// <summary>
        /// 200. Number of Islands
        /// https://leetcode.com/problems/number-of-islands/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int[][] directions = new int[4][];
            directions[0] = new int[2] { -1, 0 };//Left
            directions[1] = new int[2] { 1, 0 };//Right
            directions[2] = new int[2] { 0, -1 };//Up
            directions[3] = new int[2] { 0, 1 };//Down        
            int numOfIslands = 0;
            int n = grid.Length;
            int m = grid[0].Length;

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        numOfIslands++;
                        NumIslandsR(grid, r, c, n, m, directions);
                    }
                }
            }

            return numOfIslands;
        }
        private void NumIslandsR(char[][] grid, int sr, int sc, int n, int m, int[][] directions)
        {
            if (sr < 0 || sr >= n)
                return;
            if (sc < 0 || sc >= m)
                return;

            if (grid[sr][sc] != '1')
                return;

            grid[sr][sc] = '2';
            for (int d = 0; d < 4; d++)
            {
                NumIslandsR(grid, sr + directions[d][0], sc + directions[d][1]
                           , n, m, directions);
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
            int rowLen = grid.Length;
            int colLen = grid[0].Length;
            int[][] directions = new int[4][];
            directions[0] = new int[2] { 1, 0 };
            directions[1] = new int[2] { 0, 1 };
            directions[2] = new int[2] { -1, 0 };
            directions[3] = new int[2] { 0, -1 };

            int maxArea = 0;
            for (int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    if (grid[i][j] == 1)
                        maxArea = Math.Max(maxArea, VisitIsland(grid, i, j, directions));
                }
            }
            return maxArea;
        }
        private int VisitIsland(int[][] grid, int row, int col, int[][] directions)
        {
            if (row < 0 || row >= grid.Length
              || col < 0 || col >= grid[0].Length)
            {
                return 0;
            }
            if (grid[row][col] != 1)
                return 0;

            int area = 1;
            grid[row][col] = 2; //visited
            foreach (var d in directions)
            {
                area += VisitIsland(grid, row + d[0], col + d[1], directions);
            }

            return area;
        }

        /// <summary>
        /// 1254. Number of Closed Islands
        /// https://leetcode.com/problems/number-of-closed-islands/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ClosedIsland(int[][] grid)
        {
            int rowLen = grid.Length;
            int colLen = grid[0].Length;
            int[][] directions = new int[4][];
            directions[0] = new int[2] { 1, 0 };
            directions[1] = new int[2] { 0, 1 };
            directions[2] = new int[2] { -1, 0 };
            directions[3] = new int[2] { 0, -1 };

            int numOfClosedIsland = 0;
            for (int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen; j++)
                {
                    if (grid[i][j] == 0 && VisitIsland(grid, i, j, directions, true))
                        numOfClosedIsland++;
                }
            }
            return numOfClosedIsland;
        }
        private bool VisitIsland(int[][] grid, int row, int col, int[][] directions, bool isClosedIsland)
        {
            if (row < 0 || row >= grid.Length
              || col < 0 || col >= grid[0].Length)
                return false;

            if (grid[row][col] != 0)
                return isClosedIsland;

            grid[row][col] = 2; //visited
            if (row == 0 || row == grid.Length - 1
              || col == 0 || col == grid[0].Length - 1)
                isClosedIsland = false;
            foreach (var d in directions)
            {
                bool tmp = VisitIsland(grid, row + d[0], col + d[1], directions, isClosedIsland);
                isClosedIsland = isClosedIsland ? tmp : isClosedIsland;
            }

            return isClosedIsland;
        }

        /// <summary>
        /// 1020. Number of Enclaves
        /// https://leetcode.com/problems/number-of-enclaves/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumEnclaves(int[][] grid)
        {
            //1: land, 0: sea
            int rowLen = grid.Length;
            int colLen = grid[0].Length;
            int[][] directions = new int[4][];
            directions[0] = new int[2] { 1, 0 };
            directions[1] = new int[2] { 0, 1 };
            directions[2] = new int[2] { -1, 0 };
            directions[3] = new int[2] { 0, -1 };
            int ans = 0;
            for (int r = 0; r < rowLen; r++)
            {
                for (int c = 0; c < colLen; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        bool isAbleWalkOff = false;
                        int tmp = VisitIslandN(grid, r, c, rowLen, colLen, directions, ref isAbleWalkOff);
                        if (isAbleWalkOff == false)
                            ans += tmp;
                    }
                }
            }
            return ans;
        }
        private int VisitIslandN(int[][] grid, int row, int col, int rowLen, int colLen, int[][] directions, ref bool isAbleWalkOff)
        {
            if (row < 0 || row >= rowLen || col < 0 || col >= colLen)
                return 0;
            if (grid[row][col] != 1)
                return 0;

            int numOfIsland = 1;
            grid[row][col] = 2; //visited
            if (row == 0 || col == 0
               || row == rowLen - 1 || col == colLen - 1)
                isAbleWalkOff = true;
            foreach (var d in directions)
            {
                numOfIsland += VisitIslandN(grid, row + d[0], col + d[1], rowLen, colLen, directions, ref isAbleWalkOff);
            }

            return numOfIsland;
        }


        public int CountSubIslands(int[][] grid1, int[][] grid2)
        {
            int ans = 0;
            int[][] directions = new int[4][];
            directions[0] = new int[2] { 1, 0 };
            directions[1] = new int[2] { 0, 1 };
            directions[2] = new int[2] { -1, 0 };
            directions[3] = new int[2] { 0, -1 };
            for (int r = 0; r < grid2.Length; r++)
            {
                for (int c = 0; c < grid2[0].Length; c++)
                {
                    if (grid2[r][c] == 1)
                    {
                        if (CountSubIslandsR(grid1, grid2, r, c, true, directions))
                            ans++;
                    }
                }
            }
            return ans;
        }
        private bool CountSubIslandsR(int[][] grid1, int[][] grid2, int row, int col, bool isSubIsland, int[][] directions)
        {
            if (row < 0 || row >= grid2.Length
              || col < 0 || col >= grid2[0].Length)
                return isSubIsland;
            else if (grid2[row][col] != 1)
                return isSubIsland;

            grid2[row][col] = 2;
            if (isSubIsland)
                isSubIsland = grid1[row][col] == 1;

            foreach (var d in directions)
            {
                if (CountSubIslandsR(grid1, grid2, row + d[0], col + d[1], isSubIsland, directions) == false)
                    isSubIsland = false;
            }
            return isSubIsland;
        }





    }

}
