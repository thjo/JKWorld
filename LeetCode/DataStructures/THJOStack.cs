using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class THJOStack
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

        private THJONode _top = null;
        private int _count;

        public THJOStack()
        {
            _count = 0;
        }
        public THJOStack(int data)
            : this()
        {

        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsEmpty()
        {
            return _top == null;
        }

        public int? Peek()
        {
            return _top != null ? (int?)_top.Data : null;
        }
        public void Push(int data)
        {
            THJONode newNode = new THJONode(data);
            if (_top != null)
                _top.Next = _top;
            _top = newNode;
            _count++;
        }

        public int? Pop()
        {
            int? res = null;
            if(_top != null)
            {
                res = _top.Data;
                _top = _top.Next;

                _count--;
            }

            return res;
        }

    }
}
