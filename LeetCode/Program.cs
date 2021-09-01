using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
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
