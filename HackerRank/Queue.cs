using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class CQueue
    {
        private class Node
        {
            public long data;
            public Node next;
            public Node(long data)
            {
                this.data = data;
            }
        }

        private Node head;
        private Node tail;
        public CQueue()
        {
            head = null;
            tail = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public long Peek()
        {
            if (IsEmpty()==false)
                return head.data;
            else
                return -1;
        }
        public void EnQueue(long data)
        {
            Node newNode = new Node(data);
            if (tail == null)
                tail = newNode;
            else
            {
                tail.next = newNode;
                tail = tail.next;
            }
            if (head == null)
                head = tail;
        }
        public long DeQueue()
        {
            long value = -1; 

            if(head != null)
            {
                value = head.data;
                head = head.next;

                if (head == null)
                    tail = null;
            }

            return value;
        }
    }
}
