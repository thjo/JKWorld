using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
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




    }
}
