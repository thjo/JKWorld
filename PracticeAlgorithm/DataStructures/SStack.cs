using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm.DataStructures
{
    public class SStack
    {
        SNode Top;

        public bool IsEmpty()
        {
            return Top == null;
        }

        public int? Peek()
        {
            return Top != null ? (int?)Top.Data : null;
        }

        public void Push(int value)
        {
            SNode newNode = new SNode(value);
            if (Top == null)
                Top = newNode;
            else
            {
                newNode.Next = Top;
                Top = newNode;
            }
        }

        public int? Pop()
        {
            int? data = null;
            if(Top != null)
            {
                data = Top.Data;
                Top = Top.Next;
            }
            return data;
        }
    }

    public class SNode
    {
        public int Data;
        public SNode Next;
        public SNode(int data)
        {
            this.Data = data;
        }
    }
}
