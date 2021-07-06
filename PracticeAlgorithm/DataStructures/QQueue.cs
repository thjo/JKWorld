using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm.DataStructures
{
    public class QQueue
    {
        QNode Head;
        QNode Tail;

        public bool IsEmpty()
        {
            return Head == null;
        }

        public int? Peek()
        {
            return Head != null ? (int?)Head.Data : null;
        }

        public void EnQueue(int value)
        {
            QNode newNode = new QNode(value);
            if (Tail != null)
                Tail.Next = newNode;
            else
                Tail = newNode;
            if (Head == null)
                Head = newNode;
        }

        public int? DeQueue()
        {
            int? data = null;
            if( Head != null)
            {
                data = Head.Data;
                Head = Head.Next;
            }
            if (Head == null)
                Tail = null;

            return data;
        }
    }

    public class QNode
    {
        public int Data;
        public QNode Next;
        public QNode(int data)
        {
            this.Data = data;
        }
    }
}
