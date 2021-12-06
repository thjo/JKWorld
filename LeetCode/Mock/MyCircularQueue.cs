using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Mock
{
    public class MyCircularQueue
    {
        DoubleNode head = null;
        DoubleNode rear = null;
        int _maxlen = 0;
        int _realLen = 0;
        public MyCircularQueue(int k)
        {
            _maxlen = k;
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;

            DoubleNode newNode = new DoubleNode(value);
            newNode.Next = null;
            if (head == null)
                head = newNode;

            if(rear != null)
                rear.Next = newNode;
            newNode.Prev = rear;
            newNode.Next = head;
            rear = newNode;
            _realLen++;
            return true;
        }

        public bool DeQueue()
        {
            if (IsEmpty())
                return false;

            int delVal = head.Value;
            rear.Next = head.Next;
            head = rear.Next;
            if (head == null)
                rear = null;

            _realLen--;
            return true;
        }

        public int Front()
        {
            return head != null ? head.Value : -1;
        }

        public int Rear()
        {
            return rear != null ? rear.Value : -1;
        }

        public bool IsEmpty()
        {
            if (_realLen <= 0)
                return true;
            else
                return false;
        }

        public bool IsFull()
        {
            return (_realLen == _maxlen);
        }
    }
    public class DoubleNode
    {
        public int Value { get; set; }
        public DoubleNode Prev { get; set; }
        public DoubleNode Next { get; set; }

        public DoubleNode(int val)
        {
            Value = val;
        }
    }
}
