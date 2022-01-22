using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class THJOQueue
    {
        class THJONode
        {
            public int Data;
            public THJONode Next;

            public THJONode()
            {
                Next = null;
            }
            public THJONode(int data)
                : this()
            {
                Data = data;
            }
            public THJONode(int data, THJONode next)
                : this(data)
            {
                Next = next;
            }
        }

        private THJONode head;
        private THJONode tail;
        private int count;

        public THJOQueue()
        {
            count = 0;
        }
        public THJOQueue(int data)
        {
            Enqueue(data);
        }

        public int Count
        {
            get { return count; }
        }
        public bool IsEmpty()
        {
            return head == null;
        }
        public int? Peek()
        {
            return head != null ? (int?)head.Data : null;
        }
        public void Enqueue(int data)
        {
            THJONode newNode = new THJONode(data);
            if(tail != null)
                tail.Next = newNode;
            tail = newNode;
            if (head == null)
                head = tail;
            count++;
        }
        public int? Dequeue()
        {
            int? res = null;
            if( head != null)
            {
                res = head.Data;
                head = head.Next;
                if (head == null)
                    tail = null;
                count--;
            }

            return res;
        }
    }
}
