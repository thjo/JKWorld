using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Algorithm_I al = new Algorithm_I();
            //al.Search(new int[] { -1, 0, -3, 5, 9, 12 }, 9);
            //al.SortedSquares(new int[] { -4, -1, 0, 3, 10 });
            //al.MoveZeroes(new int[] { 0, 1, 0, 3, 12 });
            //al.TwoSum(new int[] {12, 13, 23, 28, 43, 44, 59, 60, 61, 68, 70, 86, 88, 92, 124, 125, 136, 168, 173, 173, 180, 199, 212, 221, 227, 230, 277, 282, 306, 314, 316, 321, 325, 328, 336, 337, 363, 365, 368, 370, 370, 371, 375, 384, 387, 394, 400, 404, 414, 422, 422, 427, 430, 435, 457, 493, 506, 527, 531, 538, 541, 546, 568, 583, 585, 587, 650, 652, 677, 691, 730, 737, 740, 751, 755, 764, 778, 783, 785, 789, 794, 803, 809, 815, 847, 858, 863, 863, 874, 887, 896, 916, 920, 926, 927, 930, 933, 957, 981, 997 }, 542);
            //al.LengthOfLongestSubstring("abcabcbb");
            //al.CheckInclusion("ab", "eidboaoo");
            //al.CheckInclusion("hello", "ooolleoooleh");
            //int[][] tmp = new int[8][];
            //tmp[0] = new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
            //tmp[1] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            //tmp[2] = new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            //tmp[3] = new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 };
            //tmp[4] = new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 };
            //tmp[5] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
            //tmp[6] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            //tmp[7] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 };
            //al.MaxAreaOfIsland(tmp);
            //int[][] tmp = new int[20][];
            //tmp[0] = new int[] { 1, 1, 1 };
            //tmp[1] = new int[] { 1, 1, 1 };
            //tmp[2] = new int[] { 1, 1, 1 };
            //tmp[3] = new int[] { 1, 1, 1 };
            //tmp[4] = new int[] { 1, 1, 1 };
            //tmp[5] = new int[] { 1, 1, 1 };
            //tmp[6] = new int[] { 1, 1, 1 };
            //tmp[7] = new int[] { 1, 1, 1 };
            //tmp[8] = new int[] { 1, 1, 1 };
            //tmp[9] = new int[] { 1, 1, 1 };
            //tmp[10] = new int[] { 1, 1, 1 };
            //tmp[11] = new int[] { 1, 1, 1 }; 
            //tmp[12] = new int[] { 1, 1, 1 };
            //tmp[13] = new int[] { 1, 1, 1 };
            //tmp[14] = new int[] { 1, 1, 1 };
            //tmp[15] = new int[] { 1, 1, 1 };
            //tmp[16] = new int[] { 1, 1, 1 };
            //tmp[17] = new int[] { 1, 1, 1 };
            //tmp[18] = new int[] { 1, 1, 1 };
            //tmp[19] = new int[] { 0, 0, 0 };
            //int[][] tmp = new int[3][];
            //tmp[0] = new int[] { 0, 0, 0 };
            //tmp[1] = new int[] { 0, 1, 0 };
            //tmp[2] = new int[] { 0, 0, 0 };
            //int[][] tmp = new int[5][];
            //tmp[0] = new int[] { 0 };
            //tmp[1] = new int[] { 0 };
            //tmp[2] = new int[] { 0 };
            //tmp[3] = new int[] { 0 };
            //tmp[4] = new int[] { 0 };
            //al.UpdateMatrix(tmp);
            int[][] grid = new int[3][];
            grid[0] = new int[3] { 2, 1, 1 };
            grid[1] = new int[3] { 1, 1, 0 };
            grid[2] = new int[3] { 0, 1, 1 };
            al.OrangesRotting(grid);

            //al.HammingWeight(11);
            //al.IsPowerOfTwo(16);
            //IList<IList<int>> triangle = new List<IList<int>>();
            //IList<int> row = new List<int>();
            //row.Add(2);
            //triangle.Add(row);
            //row = new List<int>();
            //row.Add(3);
            //row.Add(4);
            //triangle.Add(row);
            //row = new List<int>();
            //row.Add(6);
            //row.Add(5);
            //row.Add(7);
            //triangle.Add(row);
            //row = new List<int>();
            //row.Add(4);
            //row.Add(1);
            //row.Add(8);
            //row.Add(3);
            //triangle.Add(row);
            //al.MinimumTotal(triangle);
            //al.Rob(new int[] { 1, 2, 3, 1 });
            //al.Combine(4, 2);
            //int[][] tmp = new int[3][];
            //tmp[0] = new int[3] { 2, 1, 1 };
            //tmp[1] = new int[3] { 1, 1, 0 };
            //tmp[2] = new int[3] { 0, 1, 1 };
            //al.OrangesRotting(tmp);

            ProblemSolving PP = new ProblemSolving();
            ////int[][] martix = new int[3][];
            ////martix[0] = new int[3];
            ////martix[0][0] = 1;
            ////martix[0][1] = 2;
            ////martix[0][2] = 3;
            ////martix[1] = new int[3];
            ////martix[1][0] = 4;
            ////martix[1][1] = 5;
            ////martix[1][2] = 6;
            ////martix[2] = new int[3];
            ////martix[2][0] = 7;
            ////martix[2][1] = 8;
            ////martix[2][2] = 9;
            ////PP.SpiralOrder(martix);
            //PP.Divide(10, 3);
            //PP.Divide(-2147483648, -1);
            PP.CombinationSum(new int[] { 2, 3, 5 }, 8);


            SeptemberChallenge2021 sep = new SeptemberChallenge2021();
            sep.Calculate("1-(2+3-(4+(5-(1-(2+4-(5+6))))))");


            AuguestChallenge2021 aug = new AuguestChallenge2021();
            //aug.ComplexNumberMultiply("1+-1i", "0+0i");
            aug.FindMin(new int[] { 2, 3, 4, 5, 1 });
            //aug.GroupAnagrams(new string[] { "", "b" });
            //TreeNode tr = new TreeNode(1);
            //tr.left = new TreeNode(2);
            //tr.right = new TreeNode(3);
            //tr.left.left = new TreeNode(4);
            //tr.left.right = new TreeNode(5);
            //tr.right.left = new TreeNode(6);
            //aug.MaxProduct(tr);

            //Console.WriteLine("Hello World!");

            //TopInterviewQuestions_Strings interviewQ = new TopInterviewQuestions_Strings();

            //interviewQ.CountAndSay(4);

            Practices prac = new Practices();
            //prac.CoinChange(new int[] { 2 }, 3);

            //ListNode head = new ListNode(1);
            //ListNode node2 = new ListNode(2);
            //head.next = node2;
            //ListNode node3 = new ListNode(3);
            //node2.next = node3;
            //ListNode node4 = new ListNode(4);
            //node3.next = node4;
            //ListNode node5 = new ListNode(5);
            //node4.next = node5;
            ListNode head = new ListNode(1);
            //ListNode node2 = new ListNode(1);
            //head.next = node2;
            //ListNode node3 = new ListNode(2);
            //node2.next = node3;
            prac.RotateRight(head, 1);

            //LRUCache lRUCache = new LRUCache(2);
            //lRUCache.Put(1, 1); // cache is {1=1}
            //lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            //lRUCache.Get(1);    // return 1
            //lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            //lRUCache.Get(2);    // returns -1 (not found)
            //lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            //lRUCache.Get(1);    // return -1 (not found)
            //lRUCache.Get(3);    // return 3
            //lRUCache.Get(4);    // return 4

            
        }
    }
}
