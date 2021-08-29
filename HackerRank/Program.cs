using System;
using System.Collections.Generic;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            #region | Comments | 

            //Interview.sherlockAndAnagrams("abba");

            //List<int> arr = new List<int>();
            //arr.Add(10); arr.Add(20); arr.Add(30);
            //arr.Add(40); arr.Add(50);
            //Interview.ActivityNotifications(arr, 3);

            //List<int> arr = new List<int>();
            //arr.Add(2); arr.Add(1); arr.Add(3); arr.Add(1); arr.Add(2);
            //Interview.countInversions(arr);
            //;

            //Interview.isValid("ibfdgaeadiaefgbhbdghhhbgdfgeiccbiehhfcggchgghadhdhagfbahhddgghbdehidbibaeaagaeeigffcebfbaieggabcfbiiedcabfihchdfabifahcbhagccbdfifhghcadfiadeeaheeddddiecaicbgigccageicehfdhdgafaddhffadigfhhcaedcedecafeacbdacgfgfeeibgaiffdehigebhhehiaahfidibccdcdagifgaihacihadecgifihbebffebdfbchbgigeccahgihbcbcaggebaaafgfedbfgagfediddghdgbgehhhifhgcedechahidcbchebheihaadbbbiaiccededchdagfhccfdefigfibifabeiaccghcegfbcghaefifbachebaacbhbfgfddeceababbacgffbagidebeadfihaefefegbghgddbbgddeehgfbhafbccidebgehifafgbghafacgfdccgifdcbbbidfifhdaibgigebigaedeaaiadegfefbhacgddhchgcbgcaeaieiegiffchbgbebgbehbbfcebciiagacaiechdigbgbghefcahgbhfibhedaeeiffebdiabcifgccdefabccdghehfibfiifdaicfedagahhdcbhbicdgibgcedieihcichadgchgbdcdagaihebbabhibcihicadgadfcihdheefbhffiageddhgahaidfdhhdbgciiaciegchiiebfbcbhaeagccfhbfhaddagnfieihghfbaggiffbbfbecgaiiidccdceadbbdfgigibgcgchafccdchgifdeieicbaididhfcfdedbhaadedfageigfdehgcdaecaebebebfcieaecfagfdieaefdiedbcadchabhebgehiidfcgahcdhcdhgchhiiheffiifeegcfdgbdeffhgeghdfhbfbifgidcafbfcd");

            //List<List<int>> contests = new List<List<int>>();
            //List<int> c1 = new List<int>(); c1.Add(5); c1.Add(1);
            //List<int> c2 = new List<int>(); c2.Add(2); c2.Add(1);
            //List<int> c3 = new List<int>(); c3.Add(1); c3.Add(1);
            //List<int> c4 = new List<int>(); c4.Add(8); c4.Add(1);
            //List<int> c5 = new List<int>(); c5.Add(10); c5.Add(0);
            //List<int> c6 = new List<int>(); c6.Add(5); c6.Add(0);
            //contests.Add(c1);
            //contests.Add(c2);
            //contests.Add(c3);
            //contests.Add(c4);
            //contests.Add(c5);
            //contests.Add(c6);
            //Interview.luckBalance(3, contests);

            //Interview.getMinimumCost(3, new int[] { 1, 3, 5, 7, 9 });

            //string numOfQueries = Console.ReadLine();
            //CQueue qData = new CQueue();
            //CStack sData = new CStack();
            //int i = 0;
            //while (i < int.Parse(numOfQueries))
            //{
            //    string query = Console.ReadLine();
            //    if (string.IsNullOrWhiteSpace(query) || query.Length <= 0)
            //        continue;
            //    else if (query[0] == '1')
            //    {
            //        string[] tmp = query.Split(' ');
            //        qData.EnQueue(long.Parse(tmp[1]));
            //    }
            //    else if (query[0] == '2')
            //    {
            //        qData.DeQueue();
            //    }
            //    else if (query[0] == '3')
            //    {
            //        Console.WriteLine(qData.Peek());
            //    }
            //    else
            //        continue;

            //    i++;
            //}

            //Console.WriteLine(Interview.Fibonacci(14, new Dictionary<int, long>()));
            //Console.WriteLine(Interview.Fibonacci2(14));


            #endregion

            //List<int> arr1 = new List<int>();
            //arr1.Add(1);

            //List<int> arr2 = new List<int>();
            //arr2.Add(3);
            //Console.WriteLine(Interview.numberOfItems("*|*|", arr1, arr2));

            //Console.WriteLine(Interview.abbreviation("SYIHDDSMREKXOKRFDQAOZJQXRIDWXPYINFZCEFYyxu"
            //    , "SYIHDDSMREKXOKRFDQAOZJQXRIDWXPYINFZCEFY"));

            //string[] tmp = "1 5 3 4 2".Split(" ");
            //List<int> data = new List<int>();
            //foreach (string s in tmp)
            //    data.Add(int.Parse(s));
            //Interview.pairs(2, data);


            //Interview.triplets(new[] {1,3,5}, new[] {2,3}, new[] {1,2,3});

            //Interview.minTime(new long[] { 2, 3 }, 5);

            //Interview.activityNotifications(new List<int> {10,20,30,40,50 }, 3);

            //Console.WriteLine(Interview.ChangeMakingProblem(new int[] { 1, 2, 5 }, 6));

            //Interview.riddle(new long[] { 3, 5, 4, 7, 6, 2 });

            //List<string> map = new List<string>();
            //map.Add(".X.");
            //map.Add(".X.");
            //map.Add("...");
            //Interview.minimumMoves(map, 0, 0, 0, 2);

            //List<List<int>> cities = new List<List<int>>();
            //List<int> tmp = new List<int>();
            //tmp.Add(1); tmp.Add(2);
            //cities.Add(tmp);
            //tmp = new List<int>();
            //tmp.Add(1); tmp.Add(3);
            //cities.Add(tmp);
            //tmp = new List<int>();
            //tmp.Add(1); tmp.Add(4);
            //cities.Add(tmp);
            //Console.WriteLine(Interview.roadsAndLibraries(5, 6, 1, cities));
            //List<List<int>> cities = new List<List<int>>();
            //List<int> tmp = new List<int>();
            //tmp.Add(1); tmp.Add(2);
            //cities.Add(tmp);
            //tmp = new List<int>();
            //tmp.Add(3); tmp.Add(1);
            //cities.Add(tmp);
            //tmp = new List<int>();
            //tmp.Add(2); tmp.Add(3);
            //cities.Add(tmp);
            //Console.WriteLine(Interview.roadsAndLibraries(3, 2, 1, cities));

            //Console.WriteLine(Interview.findShortest(4, new int[] { 1, 1, 4 }, new int[] { 2, 3, 2 }, new long[] { 1, 2, 1, 1 }, 1));

            //List<int> a = new List<int>(); a.Add(100); a.Add(100); a.Add(50); a.Add(40); a.Add(40); a.Add(20); a.Add(10);
            //List<int> b = new List<int>(); b.Add(5); b.Add(25); b.Add(50); b.Add(120); b.Add(3); b.Add(1);
            //Console.WriteLine(ProblemSolving.climbingLeaderboard(a, b));
            List<int> a = new List<int>(); a.Add(-1); a.Add(-3); a.Add(4); a.Add(2);
            Console.WriteLine(ProblemSolving.angryProfessor(3, a));


            //Console.WriteLine(ProblemSolving.MyAtoi("-2147483647"));

            Video_Algoriths v = new Video_Algoriths();
            //Node head = new Node(7);
            //Node newNd13 = new Node(13);
            //Node newNd11 = new Node(11);
            //Node newNd10 = new Node(10);
            //Node newNd1 = new Node(1);
            //head.next = newNd13;
            //head.random = null;
            //newNd13.next = newNd11;
            //newNd13.random = head;
            //newNd11.next = newNd10;
            //newNd11.random = newNd1;
            //newNd10.next = newNd1;
            //newNd10.random = newNd11;
            //newNd1.next = null;
            //newNd1.random = head;
            //v.SolveNQueens(4);
            //Console.WriteLine(v.CopyRandomList(head));
            //Console.WriteLine(v.SearchRange3(new int[] { 2,2 }, 3));

            v.GenerateParenthesis(2);

            //Console.WriteLine(ProblemSolving.jumpingOnClouds(new int[] { 0, 0, 1, 0, 0, 1, 1, 0 }, 2));
            //ProblemSolving.hackerrankInString("hereiamstackerrank");
            ////Console.WriteLine(InterviewPreparationKit.stepPerms(3));
            //Console.ReadLine();

            
        }
    }
}
