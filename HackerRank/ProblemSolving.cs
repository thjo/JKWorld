using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class ProblemSolving
    {

        public static string catAndMouse(int x, int y, int z)
        {
            int distCatAandMouse = Math.Abs(x - z);
            int distCatBandMouse = Math.Abs(y - z);

            if (distCatAandMouse < distCatBandMouse)
                return "Cat A";
            else if(distCatAandMouse > distCatBandMouse)
                return "Cat B";
            else
                return "Mouse C";
        }


        //Forming a Magic Square
        //https://www.hackerrank.com/challenges/magic-square-forming/problem
        public static int formingMagicSquare(List<List<int>> s)
        {
            int[][] magicSquareLists = new int[8][];
            magicSquareLists[0] = new int[9] { 8, 1, 6, 3, 5, 7, 4, 9, 2};
            magicSquareLists[1] = new int[9] { 6, 1, 8, 7, 5, 3, 2, 9, 4 };
            magicSquareLists[2] = new int[9] {4, 9, 2, 3, 5, 7, 8, 1, 6 };
            magicSquareLists[3] = new int[9] {2, 9, 4, 7, 5, 3, 6, 1, 8 };
            magicSquareLists[4] = new int[9] {8, 3, 4, 1, 5, 9, 6, 7, 2 };
            magicSquareLists[5] = new int[9] {4, 3, 8, 9, 5, 1, 2, 7, 6 };
            magicSquareLists[6] = new int[9] {6, 7, 2, 1, 5, 9, 8, 3, 4 };
            magicSquareLists[7] = new int[9] { 2, 7, 6, 9, 5, 1, 4, 3, 8 };

            int? min = null;
            int[] newS = new int[9];
            int i = 0;
            for(int r = 0; r < 3; r++)
            {
                for(int c = 0; c < 3; c++)
                    newS[i++] = s[r][c];
            }
            foreach (int[] magicSquare in magicSquareLists)
            {
                int tmpMin = 0;
                for (int idx = 0; idx < 9; idx++)
                    tmpMin += Math.Abs(magicSquare[idx] - newS[idx]);

                if (min == null || min.Value > tmpMin)
                    min = tmpMin;
            }

            return min.Value;
        }

        //Picking Numbers
        //https://www.hackerrank.com/challenges/picking-numbers/problem?h_r=next-challenge&h_v=zen
        public static int pickingNumbers(List<int> a)
        {
            int maxLen = 1;
            int len = 1;
            int[] sortedArray = a.ToArray();
            Array.Sort(sortedArray);
            int compareIdx = 0;
            for(int i = 1; i < a.Count; i++)
            {
                if (Math.Abs(sortedArray[compareIdx] - sortedArray[i]) <= 1)
                {
                    len++;
                }
                else {
                    len = 1;
                    compareIdx = i;
                }

                if (maxLen < len)
                    maxLen = len;
            }

            return maxLen;
        }


        //Climbing the Leaderboard
        //https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> ranking = new List<int>();
            ranking.Add(ranked[0]);

            for(int i = 1; i < ranked.Count; i++)
            {
                if (ranked[i - 1] != ranked[i])
                    ranking.Add(ranked[i]);
            }

            List<int> leaderBoard = new List<int>();
            int startIdx = 0, endIdx = ranking.Count - 1;
            foreach (int p in player)
            {
                int idx = BSearchRanking(ranking, ranking.Count, startIdx, endIdx, p);
                if (idx <= startIdx)
                    leaderBoard.Add(1);
                else if( idx > endIdx)
                    leaderBoard.Add(ranking.Count + 1);
                else if (p == ranking[idx])
                    leaderBoard.Add(idx+1);
                else
                    leaderBoard.Add(idx+1);
            }

            return leaderBoard;
        }
        public static int BSearchRanking(List<int> ranked, int len, int startIdx, int endIdx, int val)
        {
            if(startIdx >= endIdx)
            {
                if(ranked[startIdx] > val)
                    return startIdx+1;
                else
                    return startIdx;
            }

            int midIdx = (startIdx + endIdx) / 2;
            if (ranked[midIdx] == val)
                return midIdx;
            else if (ranked[midIdx] > val)
            {
                if (midIdx + 1 > endIdx)
                    return endIdx + 1;
                else
                    return BSearchRanking(ranked, len, midIdx + 1, endIdx, val);
            }
            else
            {
                if (startIdx > midIdx - 1)
                    return startIdx;
                else
                    return BSearchRanking(ranked, len, startIdx, midIdx - 1, val);
            }
        }


        //Designer PDF Viewer
        //https://www.hackerrank.com/challenges/designer-pdf-viewer/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        public static int designerPdfViewer(List<int> h, string word)
        {
            int max = -1;
            int numOfletters = 0;
            foreach(char c in word)
            {
                int idx = c - 'z' + 25;
                if (idx >= 0 && idx <= 25)
                {
                    //Alpabet
                    numOfletters++;
                    if (max < h[idx])
                        max = h[idx];
                }
            }

            return max > -1 ? max * numOfletters : 0;
        }


        //Utopian Tree
        //https://www.hackerrank.com/challenges/utopian-tree/problem
        public static int utopianTree(int n)
        {
            if (n < 0)
                return 0;

            int h = 1;
            for(int i = 1; i <=n; i++)
            {
                if( i % 2 == 1)
                {
                    //Spring
                    h = h * 2;
                }
                else
                {
                    //Summer
                    h = h + 1;
                }
            }

            return h;
        }


        //Angry Professor
        //https://www.hackerrank.com/challenges/angry-professor/problem?h_r=next-challenge&h_v=zen
        public static string angryProfessor(int k, List<int> a)
        {
            int numOfAttendees = 0; 
            foreach(int t in a)
            {
                if (t <= 0)
                    numOfAttendees++;

                if (k <= numOfAttendees)
                    return "NO";
            }

            return k <= numOfAttendees ? "NO" : "YES";
        }

        //Beautiful Days at the Movies
        //https://www.hackerrank.com/challenges/beautiful-days-at-the-movies/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        public static int beautifulDays(int i, int j, int k)
        {
            int cntBeautifuldays = 0;
            for(int day = i; day <= j; day++)
            {
                if ( Math.Abs(day - Reverse(day)) % k == 0)
                    cntBeautifuldays++;
            }

            return cntBeautifuldays;
        }
        private static int Reverse(int n)
        {
            if (n < 10)
                return n;

            int reversedNum = n % 10;
            n = n / 10;
            while(n != 0)
            {
                reversedNum = reversedNum * 10 + n % 10;
                n = n / 10;
            }

            return reversedNum;
        }


        //Viral Advertising
        //https://www.hackerrank.com/challenges/strange-advertising/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        public static int viralAdvertising(int n)
        {
            int cumulative = 0;
            int shared = 5;
            for(int i = 1; i <= n; i++)
            {
                cumulative += shared / 2;
                shared = (shared / 2) * 3;
            }

            return cumulative;
        }


        //Save the Prisoner
        //https://www.hackerrank.com/challenges/save-the-prisoner/problem
        public static int saveThePrisoner(int n, int m, int s)
        {
            int leftover = m % n;
            if (s + leftover - 1 < 1)
                return n;
            else if((s + leftover - 1) > n)
                return (s + leftover - 1) - n;
            else
                return (s + leftover - 1);

        }

        //Sequence Equation
        //https://www.hackerrank.com/challenges/permutation-equation/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        public static List<int> permutationEquation(List<int> p)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            int i = 1;
            foreach(int v in p)
                hashMap.Add(v, i++);

            List<int> results = new List<int>();
            for(i = 1; i <=p.Count; i++)
                results.Add(hashMap[hashMap[i]]);

            return results;
        }


        //Jumping on the Clouds: Revisited
        //https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        public static int jumpingOnClouds(int[] c, int k)
        {
            int energy = 100;
            if (c == null || c.Length < 1)
                return energy;

            int n = c.Length;
            int i = 0;
            while( energy > 0)
            {
                energy--;
                i = (i + k) % n;

                if (c[i] == 1)
                    energy = energy - 2;

                if (i == 0)
                    break;
            }

            return energy;
        }



        public static string hackerrankInString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "NO";

            string hackerrank = "hackerrank";
            int lenHackerrank = hackerrank.Length;
            int lenStr = s.Length;
            int cursorStr = 0, cursorHacker = 0;
            while(cursorHacker < lenHackerrank && cursorStr < lenStr)
            {
                if(hackerrank[cursorHacker] == s[cursorStr])
                {
                    cursorHacker++; cursorStr++;
                }
                else
                {
                    cursorStr++;
                }
            }
            if (cursorHacker == lenHackerrank)
                return "YES";
            else
                return "NO";
        }
    }
}
