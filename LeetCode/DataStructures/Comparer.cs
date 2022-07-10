using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DataStructures
{
    public class OrdercComparer : IComparer<int>
    {
        private bool IsDesc = false;
        public OrdercComparer(bool isDesc = false)
        {
            IsDesc = isDesc;
        }
        public int Compare(int val1, int val2)
        {
            int add = 1;
            if (IsDesc)
                add = -1;

            if (val1 == val2)
                return 0;
            else if (val1 > val2)
                return 1* add;
            else
                return -1* add;
        }
    }
    //PriorityQueue<int, int> pQueue = new PriorityQueue<int, int>(new OrdercComparer());
    //pQueue.Enqueue(1,1);
    //        pQueue.Enqueue(2, 2);
    //        pQueue.Enqueue(3, 3);
    //        pQueue.Enqueue(33, 3);
    //        pQueue.Enqueue(333, 3);
    //        pQueue.Enqueue(4, 4);
    //        Console.WriteLine("Clearing Customers Now");
    //        while (pQueue.TryDequeue(out int item, out int priority))
    //        {
    //            Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
    //        }
public class TitleComparer : IComparer<string>
    {
        public int Compare(string titleA, string titleB)
        {
            System.Diagnostics.Debug.WriteLine("titleA='{0}', titleB='{1}", titleA, titleB);
            var titleAIsFancy = titleA.Equals("sir", StringComparison.InvariantCultureIgnoreCase);
            var titleBIsFancy = titleB.Equals("sir", StringComparison.InvariantCultureIgnoreCase);

            if (titleAIsFancy == titleBIsFancy) //If both are fancy (Or both are not fancy, return 0 as they are equal)
            {
                return 0;
            }
            else if (titleAIsFancy) //Otherwise if A is fancy (And therefore B is not), then return -1
            {
                return -1;
            }
            else //Otherwise it must be that B is fancy (And A is not), so return 1
            {
                return 1;
            }
        }

        //PriorityQueue<string, string> pQueue = new PriorityQueue<string, string>(new TitleComparer());
        //pQueue.Enqueue("John Jones", "Sir");
        //    pQueue.Enqueue("Jim Smith", "Mr");
        //    pQueue.Enqueue("Sam Poll", "Mr");
        //    pQueue.Enqueue("Edward Jones", "Sir");
        //    Console.WriteLine("Clearing Customers Now");
        //    while (pQueue.TryDequeue(out string item, out string priority))
        //    {
        //        Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
        //    }
    }
}
