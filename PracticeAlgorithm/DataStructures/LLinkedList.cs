using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm.DataStructures
{
    public class LLinkedList
    {
        LNode Head;
        public void Append(int value)
        {
            if (Head == null)
            {
                Head = new LNode(value);
                return;
            }

            LNode curr = Head;
            while (curr.Next != null)
                curr = curr.Next;

            curr.Next = new LNode(value);
        }

        public void Prepend(int value)
        {
            LNode newHead = new LNode(value);
            newHead.Next = Head;
            Head = newHead;
        }

        public void DeleteWithValue(int value)
        {
            if (Head == null)
                return;
            else if (Head.Data == value)
            {
                Head = null;
                return;
            }

            LNode curr = Head;
            while (curr.Next != null)
            {
                if (curr.Next.Data == value)
                {
                    curr.Next = curr.Next.Next;
                    return;
                }
                else
                    curr = curr.Next;
            }
        }
    }

    public class LNode
    {
        public int Data;
        public LNode Next;

        public LNode(int data)
        {
            this.Data = data;
        }
    }
}
