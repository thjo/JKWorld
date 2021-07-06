using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class CStack
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

        private Node top;
        public CStack()
        {
            top = null;
        }
        public bool IsEmpty()
        {
            return top == null;
        }

        public long Peek()
        {
            if (IsEmpty()==false)
                return top.data;
            else
                return -1;
        }
        public void Push(long data)
        {
            Node newNode = new Node(data);
            if (top != null)
                top.next = top;
            top = newNode;
        }
        public long Pop()
        {
            long value = -1;

            if (top != null)
            {
                value = top.data;
                top = top.next;
            }

            return value;
        }
    }
}
