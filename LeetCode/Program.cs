using LeetCode.Mock;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {

            ProgrammingSkills_II pp = new ProgrammingSkills_II();
            pp.AddToArrayForm(new int[] { 1, 2, 0, 0 }, 34);

            ProblemSolving pss = new ProblemSolving();
            pss.MaxResult(new int[] { 1, -1, -2, 4, -7, 3 }, 2);
            pss.MaxResult(new int[] { 10, -5, -2, 4, 0, 3 }, 3);
            DataStructures.DataStructureII dsII = new DataStructures.DataStructureII();
            //int[][] intervals = new int[4][];
            //intervals[0] = new int[2] { 1, 2 };
            //intervals[1] = new int[2] { 2, 3 };
            //intervals[2] = new int[2] { 3, 4 };
            //intervals[3] = new int[2] { 1, 3 };
            //dsII.EraseOverlapIntervals(intervals);

            Leetcode75Questions l75 = new Leetcode75Questions();
            //l75.LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 });
            //int[][] prerequisites = new int[1][];
            //prerequisites[0] = new int[2] { 1, 0 };
            //l75.CanFinish(2, prerequisites);

            BinarySearchI bs = new BinarySearchI();
          
            //int[][] grid = new int[2][];
            //grid[0] = new int[] { 5,1,0 };
            //grid[1] = new int[] { -5,-5,-5 };
            //bs.CountNegatives(grid);
            //bs.FindTheDistanceValue(new int[] { 1, 4, 2, 3 }, new int[] { -4, -3, 6, 10, 20, 30 }, 3);
            //bs.NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'd');
            //bs.FindKthPositive(new int[] { 2,3,4,7,11 }, 5);



            DynamicProgrammingI dp = new DynamicProgrammingI();
            //dp.MaxScoreSightseeingPair(new int[] { 2, 2, 2 });
            //dp.MaxSubarraySumCircular(new int[] { -10, -7, 9, -7, 6, 9, -9, -4, -8, -5 });




            GraphTheoryI gp1 = new GraphTheoryI();
            //int[][] grid = new int[5][];
            //grid[0] = new int[] { 1, 1, 1, 1, 1, 1, 1, 0  };
            //grid[1] = new int[] { 1, 0, 0, 0, 0, 1, 1, 0  };
            //grid[2] = new int[] { 1, 0, 1, 0, 1, 1, 1, 0  };
            //grid[3] = new int[] { 1, 0, 0, 0, 0, 1, 0, 1  };
            //grid[4] = new int[] { 1, 1, 1, 1, 1, 1, 1, 0  };
            //gp1.ClosedIsland(grid);
            //int[][] grid = new int[10][];
            //grid[0] = new int[] { 0, 0, 0, 1, 1, 1, 0, 1, 0, 0 };
            //grid[1] = new int[] { 1,1,0,0,0,1,0,1,1, 1 };
            //grid[2] = new int[] { 0,0,0,1,1,1,0,1,0,0 };
            //grid[3] = new int[] { 0,1,1,0,0,0,1,0,1,0 };
            //grid[4] = new int[] { 0,1,1,1,1,1,0,0,1,0 };
            //grid[5] = new int[] { 0,0,1,0,1,1,1,1,0,1 };
            //grid[6] = new int[] { 0,1,1,0,0,0,1,1,1,1 };
            //grid[7] = new int[] { 0,0,1,0,0,1,0,1,0,1 };
            //grid[8] = new int[] { 1,0,1,0,1,1,0,0,0,0 };
            //grid[9] = new int[] { 0,0,0,0,1,1,0,0,0,1 };
            //gp1.NumEnclaves(grid);




            FacebookAssessment fb = new FacebookAssessment();
            //fb.ReverseVowels(" ");




            AmazonAssessment aaaa = new AmazonAssessment();

            //aaaa.buildTree(new string[] { "4", "5", "2", "7", "+", "-", "*" });
            //aaaa.SortArrayByParityII(new int[] { 2, 3, 0, 4, 1, 3});
            //aaaa.PrisonAfterNDays(new int[] { 0, 1, 0, 1, 1, 0, 0, 1 }, 7);
            //int[][] grid = new int[3][];
            //grid[0] = new int[3] { 2, 1, 1 };
            //grid[1] = new int[3] { 1, 1, 0 };
            //grid[2] = new int[3] { 0, 1, 1 };
            //aaaa.OrangesRotting(grid);
            //aaaa.GenerateMatrix(3);
            //aaaa.CountDecreasingRatings(new int[] { 2, 1, 3 });
            //aaaa.RelativeSortArray(new int[] { 2, 21, 43, 38, 0, 42, 33, 7, 24, 13, 12, 27, 12, 24, 5, 23, 29, 48, 30, 31 }
            //                     , new int[] { 2, 42, 38, 0, 43, 21 });
            //aaaa.NumRollsToTarget(2, 6, 7);
            //IList <IList<string>> syn = new List<IList<string>>();
            //IList<string> buff = new List<string>();
            //buff.Add("happy");
            //buff.Add("joy");
            //syn.Add(buff);
            //buff = new List<string>();
            //buff.Add("sad");
            //buff.Add("sorroow");
            //syn.Add(buff);
            //buff = new List<string>();
            //buff.Add("joy");
            //buff.Add("cheerful");
            //syn.Add(buff);
            //aaaa.GenerateSentences(syn, "I am happy today but was sad yesterday");
            //aaaa.MaxUncrossedLines(new int[] {1, 4, 2 }, new int[] {1, 2, 4 });
            //Algorithm_II aII = new Algorithm_II();
            //aII.Find(0);
            //aII.Search(new int[] { 1, 3 }, 3);
            //ProgrammingSkills_I pk = new ProgrammingSkills_I();
            //pk.ToLowerCase("Hello");


            MicrosoftAssesment msAss = new MicrosoftAssesment();
            msAss.Solution2_06052022(2, "1A 2F 1C");
            //msAss.CountStudents(new int[] { 1,1,1,0,0,1 }, new int[] { 1,0,0,0,1,1 });
            //msAss.Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
            //char[][] board = new char[3][];
            //board[0] = new char[4] { 'A', 'B', 'C', 'E' };
            //board[1] = new char[4] { 'S', 'F', 'C', 'S' };
            //board[2] = new char[4] { 'A', 'D', 'E', 'E' };
            //string word = "ABCB";
            //msAss.Exist(board, word);
            //msAss.TitleToNumber("A");
            //int[][] grid = new int[4][];
            //grid[0] = new int[] { 0,1,0,0 };
            //grid[1] = new int[] { 1,1,1,0 };
            //grid[2] = new int[] { 0,1,0,0 };
            //grid[3] = new int[] { 1,1,0,0 };
            //msAss.IslandPerimeter(grid);

            //msAss.CountStudents(new int[] { 1, 1, 0, 0 }, new int[] { 0, 1, 0, 1 });
            //msAss.Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
            //msAss.SortColors(new int[] { 2, 0, 2, 1, 1, 0 });
            //msAss.solutionFix(new int[] { 1, 1, 2, 3, 3 }, 3);
            //msAss.KnightDialer(2);
            //msAss.ReverseWords("isxw(lpq(cz(w#vdzb s!lzrrl(b)km*&*eqvvc@&gum#iojjhw)c&*dta(@$erzf!sz#mke!xxc a$ol@j$$cesr*vhpdu$vopjvkoa%ppmxwcquwm)l@tf*nugbgtcmntobfp)t%f#b *%nwwlfxteafhh(ekzrp*rqob*nq%t!zquhjo^x(ncc^lz&@wynesnijvyfgeozw&uunq kkpw)o&g&ymh%ufpj)y)f$&^hdciln&wpmj#zvy&h(r$(w@e $)p#%bw&zuecvpn!vjek&(vq!tqid ab(icyobbx*su(!lmo^ lqhvtdsk @$u#tq(wfkp&lhwun&ejbez&qjy&rvju)d sdo(qonl!!mos^zcxslj%*(pqq&p)ned&gpp!#u%gwfbrr%uum@b zo!p!g^mr!bmck%jwhhjkdxio%nxnpnx*u&lrej l*l#zan*wtawfs!(zp$@qb*pdowwpl$cq)mwh&a^x*vlgrh&la$*o^omliwdu)*lb fpy^s#ricc@se^uit@wuskx)p(klgnwccyioivdlrb%#goc%!(lig(*e^kmnh@*&vw@%ig!&&gcxcqesrnsa i$hod) @tfi@uioisb@^wxduwexgwwxyihztuelw$aa&&jop$aw#^yyh(pztomnuwrwemdpjsw )qcp%omvmd$rmuqei@u qfnw$!kjyf(yngcisbcs(&xjqnl&^j)#ihdhoxkk$gcx edt$uii!#ei)&dxniyflxf *y%mrdan&q@ws$*!tnum^#ffehwkddgq!ss%#mnwdr!mb#a)evbgdqijsh( ujcqksuttbbkphwtzr*gd%qfrkwmfc*c@g@pi&bz&& xwlahz()*linzlarxk%p&)mlo*dqgh&a%ts(dk^ug$l@oa!roikwqn(ckzxt f@n^&(sxa#b!ai&pfne%!gfqakvw)jmvabkp(piojwairsoz!%x#xb)!$qeq@r!yari*j zz!");
            ListNode head = new ListNode(1, null);
            ListNode nex1 = new ListNode(2);
            head.next = nex1;
            ListNode nex2 = new ListNode(3);
            nex1.next = nex2;
            //ListNode nex3 = new ListNode(4);
            //nex2.next = nex3;
            msAss.SwapPairs(head);



            DataStructures.DataStructureI ds1 = new DataStructures.DataStructureI();
            //ds1.Generate(5);

            //int[][] mat = new int[2][];
            //mat[0] = new int[2] { 1, 2 };
            //mat[1] = new int[2] { 3, 4 };
            //ds1.MatrixReshape(mat, 2, 4);


            //SnapshotArray snapShot = new SnapshotArray(1);
            //snapShot.Set(0, 15);
            //snapShot.Snap();
            //snapShot.Snap();
            //snapShot.Snap();
            //snapShot.Get(0, 2);

            //Google_OnsiteInterview go = new Google_OnsiteInterview();
            //go.RemoveKdigits("10", 1);

            //go.LongestSubarray(new int[] { 10, 1, 2, 4, 7, 2 }, 5);
            //int[][] grid = new int[4][];
            //grid[0] = new int[3] { 3, 1, 1 };
            //grid[1] = new int[3] { 2, 5, 1 };
            //grid[2] = new int[3] { 1, 5, 5 };
            //grid[3] = new int[3] { 2, 1, 1 };
            //go.CherryPickup(grid);
            //go.ReorderSpaces("  this is a sentence ");

            //go.ConfusingNumberII(100);
            //int[][] mat = new int[3][];
            //mat[0] = new int[3] { 1, 0, 1 };
            //mat[1] = new int[3] { 1, 1, 0 };
            //mat[2] = new int[3] { 1, 1, 0 };
            //go.NumSubmat(mat);

            ////go.NumberOfPatterns(1, 2);
            //TreeNode root = new TreeNode(1);
            //root.left = new TreeNode(2);
            //TreeNode nd3 = new TreeNode(3);
            //root.left.right = nd3;
            //root.right = nd3;
            //go.CorrectBinaryTree(root);
            //IList<IList<string>> simiarPairs = new List<IList<string>>();
            //IList<string> tmp = new List<string>();
            //tmp.Add("great"); tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("fine"); tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("drama"); tmp.Add("acting");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("skills"); tmp.Add("talent");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //go.AreSentencesSimilarTwo(new string[] { "great", "acting", "skills" }, new string[] { "fine", "drama", "talent" }, simiarPairs);

            //tmp.Add("great");tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("extraordinary"); tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("well"); tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("wonderful"); tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("excellent"); tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("fine"); tmp.Add("good");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("nice"); tmp.Add("good");
            //simiarPairs.Add(tmp);

            //tmp = new List<string>();
            //tmp.Add("any"); tmp.Add("one");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("some"); tmp.Add("one");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("unique"); tmp.Add("one");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("the"); tmp.Add("one");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("an"); tmp.Add("one");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("single"); tmp.Add("one");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("a"); tmp.Add("one");
            //simiarPairs.Add(tmp);

            //tmp = new List<string>();
            //tmp.Add("truck"); tmp.Add("car");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("wagon"); tmp.Add("car");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("automobile"); tmp.Add("car");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("auto"); tmp.Add("car");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("vehicle"); tmp.Add("car");
            //simiarPairs.Add(tmp);

            //tmp = new List<string>();
            //tmp.Add("entertain"); tmp.Add("have");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("drink"); tmp.Add("have");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("eat"); tmp.Add("have");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("take"); tmp.Add("have");
            //simiarPairs.Add(tmp);

            //tmp = new List<string>();
            //tmp.Add("fruits"); tmp.Add("meal");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("brunch"); tmp.Add("meal");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("breakfast"); tmp.Add("meal");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("food"); tmp.Add("meal");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("dinner"); tmp.Add("meal");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("super"); tmp.Add("meal");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("lunch"); tmp.Add("meal");
            //simiarPairs.Add(tmp);

            //tmp = new List<string>();
            //tmp.Add("possess"); tmp.Add("own");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("keep"); tmp.Add("own");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("have"); tmp.Add("own");
            //simiarPairs.Add(tmp);

            //tmp = new List<string>();
            //tmp.Add("extremely"); tmp.Add("very");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("actually"); tmp.Add("very");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("really"); tmp.Add("very");
            //simiarPairs.Add(tmp);
            //tmp = new List<string>();
            //tmp.Add("super"); tmp.Add("very");
            //simiarPairs.Add(tmp);

            //go.AreSentencesSimilar(new string[] { "yesterday", "james", "have", "an", "extraordinary", "meal" }, new string[] { "yesterday", "james", "take", "one", "good", "dinner" }, simiarPairs);

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
            //int[][] grid = new int[3][];
            //grid[0] = new int[3] { 2, 1, 1 };
            //grid[1] = new int[3] { 1, 1, 0 };
            //grid[2] = new int[3] { 0, 1, 1 };
            //al.OrangesRotting(grid);

            //Mock.KthLargest kthLar = new Mock.KthLargest(1, new int[] { });
            //kthLar.Add(-3);
            //kthLar.Add(-4);
            //kthLar.Add(2);
            //kthLar.Add(0);

            //MyCircularQueue myQQ = new MyCircularQueue(6);
            //myQQ.EnQueue(6);
            //myQQ.Rear(); myQQ.Rear();
            //myQQ.DeQueue();
            //myQQ.EnQueue(5);
            //myQQ.Rear();
            //myQQ.DeQueue();
            //myQQ.Front();
            //myQQ.DeQueue(); myQQ.DeQueue(); myQQ.DeQueue();

            MockAssessment ma = new MockAssessment();
            //ma.ComputeArea(-2,-2,2,2,2,-2,4,2);
            //ma.InvalidTransactions(new string[] { "alice,20,800,mtv", "alice,50,100,mtv", "alice,51,100,frankfurt" });
            //ma.NumRollsToTarget(1, 6, 3);
            //ma.LongestPalindrome("babad");
            //ma.FirstUniqChar("dddccdbba");
            //ma.PrisonAfterNDays(new int[] { 1, 0, 0, 1, 0, 0, 1, 0 }, 1000000000);
            //ma.PrisonAfterNDays(new int[] { 1, 1, 0, 1, 1, 0, 1, 1 }, 6);
            //ma.PrisonAfterNDays(new int[] { 1, 1, 0, 1, 1, 0, 0, 1 }, 300663720);
            //ma.FractionToDecimal(-2147483648, 1);
            //ma.ReverseOnlyLetters("a-bC-dEf-ghIj");
            //ma.Calculate("  3/2  ");
            //ma.PartitionLabels("caedbdedda");
            //int[][] mat = new int[2][];
            //mat[0] = new int[1];
            //mat[0][0] = 3; 
            //mat[1] = new int[1];
            //mat[1][0] = 6;
            //ma.SearchMatrix(mat, 6);
            //TopVotedCandidate tvc = new TopVotedCandidate(new int[] { 0,0,0,0,1}, new int[] { 0,6,39,52,75 });
            //int retV = -1;
            //retV = tvc.Q(45);
            //retV = tvc.Q(49);
            //retV = tvc.Q(59);
            //retV = tvc.Q(68);
            //retV = tvc.Q(42);
            //retV = tvc.Q(37);
            //retV = tvc.Q(99);
            //retV = tvc.Q(26);
            //retV = tvc.Q(78);
            //retV = tvc.Q(43);
            Algorithm_II al2 = new Algorithm_II();
            //al2.FindNumberOfLIS(new int[] { 1,2,4,3,5,4,7,2 });
            //al2.MinSubArrayLen(15, new int[] { 1, 2, 3, 4, 5 });
            //al2.CoinChange(new int[] { 1, 2, 5 }, 11);
            char[][] param = new char[2][];
            param[0] = new char[2] { 'a' , 'a' };
            param[1] = new char[2] { 'a', 'a' };
            al2.Exist(param, "aaaaa");
            //al2.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            //al2.BackspaceCompare("ab##", "c#d#");
            //al2.FindAnagrams("cbaebabacd", "abc");
            //int[][] param = new int[3][];
            //param[0] = new int[3] { 0, 0, 0 };
            //param[1] = new int[3] { 1, 1, 0 };
            //param[2] = new int[3] { 1, 1, 0 };
            //al2.ShortestPathBinaryMatrix(param);
            //al2.UniquePaths(3, 7);
            //char[][] mmm = new char[1][];
            //mmm[0] = new char[1];
            //mmm[0][0] = 'a';
            //al2.Exist(mmm, "a");
            //al2.IsHappy(19);
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
            //ListNode head = new ListNode(1);
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
