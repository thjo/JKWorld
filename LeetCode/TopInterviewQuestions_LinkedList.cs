using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class TopInterviewQuestions_LinkedList
    {

    }

    /// <summary>
    ///  Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x=0, ListNode next = null) { this.val = x; this.next = next; }

    }

    public class LinkedList
    {
        public ListNode Head;

        public void Append(int value)
        {
            if (Head == null)
            {
                Head = new ListNode(value);
                return;
            }

            ListNode cursor = Head;
            while (cursor.next != null)
                cursor = cursor.next;
            cursor.next = new ListNode(value);
        }

        public void Prepend(int value)
        {
            ListNode node = new ListNode(value);
            node.next = Head;
            Head = node;
        }

        public void DeleteWithValue(int value)
        {
            if (Head == null)
                return;
            else if(Head.val == value)
            {
                Head = Head.next;
                return;
            }

            ListNode cursor = Head;
            while (cursor.next != null)
            {
                if(cursor.next.val == value)
                {
                    cursor.next = cursor.next.next;
                    break;
                }
                else
                    cursor = cursor.next;
            }
        }
    }

}
