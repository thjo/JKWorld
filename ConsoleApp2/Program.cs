// See https://aka.ms/new-console-template for more information
using ConsoleApp2;

Console.WriteLine("Hello, World!");

//*L1 = [-3, -1, 2, 5, 6, 22]
//*L2 = [-2, 0, 1, 3, 4, 11]
// 4
//L1= [-3,-2,-1]
//L2= [1,2,3]
//4
//L1=[0,1]
//L2=[1]
//5
Merger mg = new Merger();
//int[] l1 = new int[] { -3, -1, 2, 5, 6, 22 };
//int[] l2 = new int[] { -2, 0, 1, 3, 4, 11 };
int[] l1 = new int[] { -3, -2, -1 };
int[] l2 = new int[] { 1, 2, 3 };
List<int> ans = mg.Merge(l1, l2, 4);
Console.WriteLine(ans.Count);
foreach (int i in ans)
    Console.WriteLine(i.ToString());

Console.ReadLine();
/*
 * Design a function to merge any two lists, up to a specified
 * limit of elements.
 *
 * The lists will be integers in ascending order.
 *
 * For example:
 *   L1 = [-3, -1, 2, 5, 6, 22]
 *   L2 = [-2,  0, 1, 3, 4, 11]
 *
 *   merge(L1, L2, 4) = [-3, -2, -1, 0]
 *   //validation
 *   L1 = [-3]
 *   L2 = [-2, 0]
 *   4
*/


