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

        /// <summary>
        /// https://www.hackerrank.com/challenges/find-digits/problem
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int findDigits(int n)
        {
            int cntNums = 0;
            foreach (char d in n.ToString())
            {
                int div = int.Parse(d.ToString());
                if (div != 0 && n % div == 0)
                    cntNums++;
            }

            return cntNums;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/extra-long-factorials/problem?h_r=next-challenge&h_v=zen
        /// </summary>
        /// <param name="n"></param>
        public static void extraLongFactorials(int n)
        {
            if (n > 0)
            {
                int[] data = new int[200];
                data[0] = 1;
                int lenOfNum = 1;
                for (int i = 2; i <= n; i++)
                {
                    lenOfNum = multiply(i, data, lenOfNum);
                }

                for (int i = lenOfNum - 1; i >= 0; i--)
                    Console.Write(data[i].ToString());
            }
            else
                Console.WriteLine("0");
        }
        public static int multiply(int num, int[] data, int lenOfNum)
        {
            int carry = 0;
            for (int i = 0; i < lenOfNum; i++)
            {
                int result = num * data[i] + carry;
                carry = result / 10;
                data[i] = result % 10;
            }

            while (carry > 0)
            {
                data[lenOfNum] = carry % 10;
                carry = carry / 10;
                lenOfNum++;
            }

            return lenOfNum;
        }


        /// <summary>
        /// https://www.hackerrank.com/challenges/append-and-delete/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string appendAndDelete(string s, string t, int k)
        {
            int cnt = 0;

            if (string.IsNullOrWhiteSpace(t))
            {
                if (string.IsNullOrWhiteSpace(s) == false)
                    cnt = s.Length;
                return cnt <= k ? "Yes" : "No";
            }
            else if (s == t)
                return cnt <= k ? "Yes" : "No";

            int sCurr = 0, tCurr = 0;
            while (sCurr < s.Length && tCurr < t.Length && s[sCurr] == t[tCurr])
            {
                sCurr++;
                tCurr++;
            }

            //Delete
            cnt = s.Length - sCurr;
            //s = s.Substring(0, sCurr);

            //Append
            cnt += t.Length - tCurr;
            if (cnt == k || (cnt < k && (k - cnt) % 2 == 0) || (cnt + (2 * sCurr) <= k))
                return "Yes";
            else
                return "No";
        }


        /// <summary>
        /// Encryption
        /// https://www.hackerrank.com/challenges/encryption/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string encryption(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            //Remove spaces 
            s = s.Replace(" ", "");
            double len = Math.Sqrt(s.Length);
            int row = (int)len;
            int col = row;
            if (row < len)
                col++;
            string newS = "";
            for (int c = 0; c < col; c++)
            {
                for (int r = 0; r <= row; r++)
                {
                    if(c + (r * col) < s.Length)
                        newS += s[c + (r * col)];
                }
                newS += " ";
            }

            return newS;
        }


        /// <summary>
        /// Beautiful Binary String
        /// https://www.hackerrank.com/challenges/beautiful-binary-string/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int beautifulBinaryString(string b)
        {
            int cnt = 0;
            if (string.IsNullOrWhiteSpace(b) || b.Length < 3)
                return cnt;

            string pattern = b.Substring(0,2);
            int i = 2;
            do
            {
                pattern += b[i];
                if (pattern.Length < 3)
                    continue;
                if (pattern == "010")
                {
                    cnt++;
                    pattern = "";
                    //if((i+1) < b.Length)
                    //{
                    //    //Check next value
                    //    if(b[i+1] == '0')
                    //    {
                    //        //Change a value in second position to a 0
                    //    }
                    //}
                    ////else - change a value in third position to a 1
                }
                else
                    pattern = pattern.Substring(1, 2);
            }
            while (++i < b.Length);

            return cnt;
        }


        /// <summary>
        /// The Love-Letter Mystery
        /// https://www.hackerrank.com/challenges/the-love-letter-mystery/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int theLoveLetterMystery(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length == 1)
                return 0;

            int cnt = 0;
            int l = 0, r = s.Length - 1;
            int lMid = s.Length / 2;
            int rMid = lMid;
            if (s.Length % 2 == 0)
                rMid--;
            while (l < lMid && r > rMid)
            {
                if (s[l] == s[r])
                    ;
                else if (s[l] < s[r])
                    cnt += s[r] - s[l];
                else
                    cnt += s[l] - s[r];
                l++;r--;
            }

            return cnt;
        }

        /// <summary>
        /// Gemstones
        /// https://www.hackerrank.com/challenges/gem-stones/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int gemstones(List<string> arr)
        {
            if (arr == null || arr.Count == 0)
                return 0;
            else if (arr.Count == 1)
                return arr[0].Length;

            Dictionary<char, int> map = new Dictionary<char, int>();
            Dictionary<char, int> buff = new Dictionary<char, int>();
            int numOfGemstones = 0;
            int maxNum = arr.Count;
            foreach(string s in arr)
            {
                if (string.IsNullOrWhiteSpace(s))
                    continue;
                for(int i = 0; i < s.Length; i++)
                {
                    if (buff.ContainsKey(s[i]))
                        continue;

                    buff.Add(s[i], 0);
                    if (map.ContainsKey(s[i]))
                    {
                        map[s[i]]++;
                    }
                    else
                        map.Add(s[i], 1);
                }
                buff.Clear();
            }

            foreach(var c in map)
            {
                if (c.Value == maxNum)
                    numOfGemstones++;
            }

            return numOfGemstones;
        }


        /// <summary>
        /// Anagram
        /// https://www.hackerrank.com/challenges/anagram/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int anagram(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;
            else if (s.Length % 2 == 1)
                return -1;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s.Substring(0, s.Length / 2))
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }

            foreach (char c in s.Substring(s.Length / 2))
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]--;
                    if (dic[c] == 0)
                        dic.Remove(c);
                }
            }
            int num = 0;
            foreach (var v in dic)
                num += v.Value;

            return num;
        }

        /// <summary>
        /// Find Merge Point of Two Lists
        /// https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=linked-lists
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            //int foundVal = -1;
            SinglyLinkedListNode selNode = null;
            HashSet<SinglyLinkedListNode> nodes = new HashSet<SinglyLinkedListNode>();
            while(head1.next != null)
            {
                head1 = head1.next;
                nodes.Add(head1);
            }

            while (head2.next != null)
            {
                head2 = head2.next;
                if(nodes.Contains(head2))
                {
                    selNode = head2;
                    break;
                }
            }

            return selNode != null ? selNode.data : -1;
        }


        /// <summary>
        /// Inserting a Node Into a Sorted Doubly Linked List
        /// https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="llist"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode llist, int data)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
            if (llist == null)
                return newNode;
            else if(llist.data > data)
            {
                newNode.next = llist;
                newNode.prev = null;
                llist.prev = newNode;
                return newNode;
            }
            DoublyLinkedListNode currNode = llist;
            while (currNode.next != null)
            {
                currNode = currNode.next;
                if(currNode.data > data)
                {
                    DoublyLinkedListNode prevNode = currNode.prev;
                    prevNode.next = newNode;
                    newNode.prev = prevNode;
                    newNode.next = currNode;
                    currNode.prev = newNode;
                    return llist;
                }
            }
            currNode.next = newNode;
            newNode.prev = currNode;
            return llist;
        }


        /// <summary>
        /// Palindrome Index
        /// https://www.hackerrank.com/challenges/palindrome-index/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int palindromeIndex(string s)
        {
            int selIdx = -1;
            bool IsPalindrome = true;
            int i = 0, j = s.Length - 1;
            int marked_i = i, marked_j = j;

            if ( string.IsNullOrWhiteSpace(s) == false && s.Length > 2)
            {
                while(i <= j)
                {
                    if (s[i] != s[j])
                    {
                        if (IsPalindrome == false)
                            return marked_j;

                        IsPalindrome = false;
                        marked_i = i;
                        marked_j = j;
                        i++;
                    }
                    else
                    {
                        i++; j--;
                    }
                }
            }

            return IsPalindrome == false ? marked_i : selIdx;
        }

        /// <summary>
        /// Game of Thrones - I
        /// https://www.hackerrank.com/challenges/game-of-thrones/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string gameOfThrones(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return "YES";

            bool isEven = s.Length % 2 == 0;
            Dictionary<char, int> map = new Dictionary<char, int>(); 
            foreach(char c in s)
            {
                if (map.ContainsKey(c))
                    map[c]++;
                else
                    map.Add(c, 1);
            }

            int numOfOdd = 0;
            foreach(var v in map)
            {
                if (v.Value % 2 == 1)
                    numOfOdd++;
            }

            if (isEven && numOfOdd == 0)
                return "YES";
            else if (isEven == false && numOfOdd == 1)
                return "YES";
            else
                return "NO";
        }


        /// <summary>
        /// ACM ICPC Team
        /// https://www.hackerrank.com/challenges/acm-icpc-team/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public static List<int> acmTeam(List<string> topic)
        {
            int maxNum = 0;
            int numOfTeam = 0;
            for(int i = 0; i < topic.Count-1; i++)
            {
                for(int j = i+1; j < topic.Count; j++)
                {
                    int idx = 0;
                    int count = 0;
                    while(idx < topic[i].Length)
                    {
                        if (topic[i][idx] == '1' || topic[j][idx] == '1')
                            count++;
                        idx++;
                    }
                    if (maxNum < count)
                    {
                        maxNum = count;
                        numOfTeam = 1;
                    }
                    else if (maxNum == count)
                        numOfTeam++;
                }
            }

            List<int> result = new List<int>();
            result.Add(maxNum);
            result.Add(numOfTeam);
            return result;
        }

        /// <summary>
        /// Modified Kaprekar Numbers
        /// https://www.hackerrank.com/challenges/kaprekar-numbers/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public static void kaprekarNumbers(int p, int q)
        {
            bool isExist = false;
            for (int i = p; i <= q; i++) {

                if (i == sumOfNums(i*1.0* i))
                {
                    Console.Write(i.ToString() + " ");
                    isExist = true;
                }
            }
            if(isExist)
                Console.WriteLine("");
            else
                Console.WriteLine("INVALID RANGE");
        }
        private static int sumOfNums(double n)
        {
            string num = n.ToString();
            if(num.IndexOf(".")>0)
                num = num.Substring(0, num.IndexOf("."));

            if (num.Length == 1)
                return int.Parse(num);
            int lenInt = num.Length/2;
            int sum1 = int.Parse(num.Substring(0, lenInt));
            int sum2 = 0;
            if(lenInt > 0)
                sum2 = int.Parse(num.Substring(lenInt));

            return sum1 + sum2;
        }

        /// <summary>
        /// The Time in Words
        /// https://www.hackerrank.com/challenges/the-time-in-words/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string timeInWords(int h, int m)
        {
            Dictionary<int, string> timeMap = new Dictionary<int, string>();
            timeMap.Add(0, "o' clock");
            timeMap.Add(1, "one");
            timeMap.Add(2, "two");
            timeMap.Add(3, "three");
            timeMap.Add(4, "four");
            timeMap.Add(5, "five");
            timeMap.Add(6, "six");
            timeMap.Add(7, "seven");
            timeMap.Add(8, "eight");
            timeMap.Add(9, "nine");
            timeMap.Add(10, "ten");
            timeMap.Add(11, "eleven");
            timeMap.Add(12, "twelve");
            timeMap.Add(13, "thirteen");
            timeMap.Add(14, "fourteen");
            timeMap.Add(15, "fifthteen");
            timeMap.Add(16, "sixteen");
            timeMap.Add(17, "seventeen");
            timeMap.Add(18, "eighteen");
            timeMap.Add(19, "nineteen");
            timeMap.Add(20, "twenty");
            timeMap.Add(30, "thrity");
            timeMap.Add(40, "fourty");
            timeMap.Add(50, "fifty");

            string keyword = "past";
            string minutes = "minutes";
            if (m == 0)
            {
                // use o' clock
                return string.Format("{0} {1}", timeMap[h], timeMap[0]);
            }
            else if (m > 30)
            {
                keyword = "to";
                m = 60 - m;
                h++;
            }
            if (m == 1)
                minutes = "minute";

            //use past
            if (m == 15 || m == 45)
            {
                // use quarter
                return string.Format("{0} {1} {2}", "quarter", keyword, timeMap[h]);
            }
            else if (m == 30)
            {
                //use half
                return string.Format("{0} {1} {2}", "half", keyword, timeMap[h]);
            }
            else
            {
                string mins = "";
                if (m / 10 <= 1)
                    mins = timeMap[m];
                else
                {
                    mins = timeMap[(m / 10) * 10];
                    if (m % 10 != 0)
                        mins = mins + " " + timeMap[m % 10];
                }

                return string.Format("{0} {1} {2} {3}", mins, minutes, keyword, timeMap[h]);
            }
        }


        /// <summary>
        /// Sherlock and Squares
        /// https://www.hackerrank.com/challenges/sherlock-and-squares/problem
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int squares(int a, int b)
        {
            int sr = (int)Math.Sqrt(a);
            int count = 0;

            while ((sr * sr) <= b)
            {
                if ((sr * sr) >= a)
                    count++;
                sr++;
            }
            return count;
        }


        /// <summary>
        /// Library Fine
        /// https://www.hackerrank.com/challenges/library-fine/problem?h_r=next-challenge&h_v=zen
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="m1"></param>
        /// <param name="y1"></param>
        /// <param name="d2"></param>
        /// <param name="m2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            int totalFine = 0;

            if (y1 < y2
                || (y1 == y2 && m1 < m2)
                || (y1 == y2 && m1 == m2 && d1 < d2))
                totalFine = 0;
            else if( y1 > y2)
            {
                totalFine = 10000;
            }
            else if( m1 > m2)
            {
                totalFine = (m1 - m2) * 500;
            }
            else if(d1 > d2)
            {
                totalFine = (d1 - d2) * 15;
            }

            return totalFine;
        }


        /// <summary>
        /// Cut the sticks
        /// https://www.hackerrank.com/challenges/cut-the-sticks/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<int> cutTheSticks(List<int> arr)
        {
            List<int> iteration = new List<int>();
            int remainingStickNum = arr.Count;
            int minStick = 0;
            int[] buff = new int[1001];
            foreach (int n in arr)
                buff[n]++;

            for(int i = 1; i <= 1000; i++)
            {
                if (buff[i] == 0)
                    continue;
                else
                {
                    minStick += i;
                    iteration.Add(remainingStickNum);
                    remainingStickNum -= buff[i];
                }
            }

            return iteration;
        }


        public static List<int> missingNumbers(List<int> arr, List<int> brr)
        {
            List<int> retMissing = new List<int>();
            int[] arrSorted = arr.ToArray();
            Array.Sort(arrSorted);
            int[] brrSorted = brr.ToArray();
            Array.Sort(brrSorted);

            int aIdx = 0, bIdx = 0;
            while(aIdx < arrSorted.Length && bIdx < brrSorted.Length)
            {
                if (arrSorted[aIdx] == brrSorted[bIdx])
                {
                    aIdx++; bIdx++;
                }
                else if (brrSorted[bIdx] < arrSorted[aIdx])
                {
                    if (retMissing.Contains(brrSorted[bIdx]) == false)
                        retMissing.Add(brrSorted[bIdx]);
                    bIdx++;
                }
                else
                    aIdx++;
            }
            while (bIdx < brrSorted.Length)
            {
                if(retMissing.Contains(brrSorted[bIdx]) == false)
                    retMissing.Add(brrSorted[bIdx]);
                bIdx++;
            }

            return retMissing;
        }


        public static int maximumDraws(int n)
        {
            return n + 1;
        }


        public static List<string> bigSorting(List<string> unsorted)
        {
            string[] tmpUnsorted = unsorted.ToArray();
            MergeSort(tmpUnsorted, new string[tmpUnsorted.Length],  0, tmpUnsorted.Length - 1);

            return new List<string>(tmpUnsorted);
        }
        private static void MergeSort(string[] unsorted, string[] buff, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            int mid = (leftStart + rightEnd) / 2;
            MergeSort(unsorted, buff, leftStart, mid);
            MergeSort(unsorted, buff, mid + 1, rightEnd);
            MergeHalves(unsorted, buff, leftStart, rightEnd);
        }
        private static void MergeHalves(string[] unsorted, string[] buff, int leftStart, int rightEnd)
        {
            int leftEnd = (rightEnd + leftStart) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while(left <= leftEnd && right <= rightEnd)
            {
                if (CompareTwoStr(unsorted[left], unsorted[right]) <= 0)
                {
                    buff[index] = unsorted[left++];
                }
                else
                {
                    buff[index] = unsorted[right++];
                }
                index++; ;
            }

            Array.Copy(unsorted, left, buff, index, leftEnd - left + 1);
            Array.Copy(unsorted, right, buff, index, rightEnd - right + 1);
            Array.Copy(buff, leftStart, unsorted, leftStart, size);
        }
        private static int CompareTwoStr(string a, string b)
        {
            if (a.Length > b.Length)
                return 1;
            else if (a.Length < b.Length)
                return -1;
            else
            {
                int i = 0;
                while(i < a.Length)
                {
                    if (a[i] > b[i])
                        return 1;
                    else if (a[i] < b[i])
                        return -1;
                    i++;
                }
                return 0;
            }
        }

        /// <summary>
        /// Handshake
        /// https://www.hackerrank.com/challenges/handshake/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int handshake(int n)
        {
            return (n * (n - 1)) / 2;
        }


        /// <summary>
        /// Non-Divisible Subset
        /// https://www.hackerrank.com/challenges/non-divisible-subset/problem?h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen&h_r=next-challenge&h_v=zen
        /// </summary>
        /// <param name="k"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int nonDivisibleSubset(int k, List<int> s)
        {
            int numOfSubset = 0;
            int[] counter = new int[k];

            foreach (int n in s)
                counter[n % k]++;

            for(int i = 0; i < k/2+1; i++)
            {
                if (i == 0 || (k % 2 == 0 && i == (k / 2)))
                {
                    numOfSubset += Math.Min(counter[i], 1);
                }
                else
                    numOfSubset += Math.Max(counter[i], counter[k - i]);
            }

            return numOfSubset;
        }

        public static int lowestTriangle(int trianglebase, int area)
        {
            int height = 0;
            if (trianglebase <= 0 || area <= 0)
                return height;

            //(trianglebase * height) / 2 = area
            if ((area * 2) % trianglebase != 0)
                height = (area * 2) / trianglebase + 1;
            else
                height = (area * 2) / trianglebase;

            return height;
        }


        public static int equalizeArray(List<int> arr)
        {
            if (arr == null || arr.Count < 1)
                return 0;

            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (int n in arr)
            {
                if (counter.ContainsKey(n))
                    counter[n]++;
                else
                    counter.Add(n, 1);
            }

            int max = -1;
            foreach(var c in counter)
            {
                max = Math.Max(max, c.Value);
            }

            return arr.Count - max;
        }


        public static int summingSeries(long n)
        {
            //long sum = 0;
            //long[] dp = new long[n];
            //dp[0] = 0; dp[1] = 1;
            //for (long i = 1; i <= n; i++)
            //{
            //    sum += ((2 * i - 1) % (1000000007));
            //}
             n = n % 1000000007;
            return (int)((n*n) % 1000000007);
        }

        /// <summary>
        /// Restaurant
        /// https://www.hackerrank.com/challenges/restaurant/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="l"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        public static int restaurant(int l, int b)
        {

        }

    }

    public class DoublyLinkedListNode
    {
        public DoublyLinkedListNode(int d)
        {
            data = d;
        }
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev; 
    }
}
