using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class THJOMinHeap
    {
        //Insertion
        //Always insert next empty spot.
        //Bubble it up until we get to the right spot.

        //Remove
        //The minimum element will always be the root node and so that's easy to find
        //but then if we want to remove it we might have an empty spot. 
        //So what we do here is we remove the min element there, so we take out the root and then we swap that value at the root with the last element added.
        //And then we take the root element and bubble it down to the next spot so we compare the root with its children, its left child and its right child, 
        // and then swap it with the smaller of the two. And the we keep going down the tree until the heap property is restored.

        public int Capacity;
        private int size = 0;
        int[] items = null;

        public THJOMinHeap(int capacity)
        {
            Capacity = capacity;
            items = new int[Capacity];
        }

        //              0         --> left child. parent index * 2 + 1 right child. parent index*2 + 2
        //        1           2
        //      3   4      5     6
        //     7 8 9 10  11 12 13 14
        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }
        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
        private int GetParentIndex(int childIdex)
        {
            return (childIdex - 1) / 2;
        }
        private bool HasLeftChildIndex(int index)
        {
            return GetLeftChildIndex(index) < size;
        }
        private bool HasRightChildIndex(int index)
        {
            return GetRightChildIndex(index) < size;
        }
        private bool HasParentIndex(int index)
        {
            return GetParentIndex(index) >= 0;
        }

        private int LeftChild(int index)
        {
            return items[GetLeftChildIndex(index)];
        }
        private int RightChild(int index)
        {
            return items[GetRightChildIndex(index)];
        }
        private int Parent(int index)
        {
            return items[GetParentIndex(index)];
        }

        private void Swap(int index1, int index2)
        {
            int temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if( size == Capacity)
            {
                int[] newItems = new int[Capacity * 2];
                Array.Copy(items, newItems, size);
                items = newItems;
                Capacity = Capacity * 2;
            }
        }

        public int Peek()
        {
            if (size == 0) return -1;
            return items[0];
        }
        public int Poll()
        {
            if (size == 0) return -1;
            int item = items[0];

            items[0] = items[size - 1];
            size--;
            HeapifyDown();
            return item;
        }
        public void Add(int item)
        {
            EnsureExtraCapacity();
            items[size] = item;
            size++;
            HeapifyUp();
        }
        private void HeapifyDown()
        {
            int index = 0; 
            while(HasLeftChildIndex(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChildIndex(index) && RightChild(index) < LeftChild(index))
                    smallerChildIndex = GetRightChildIndex(index);

                if (items[index] > items[smallerChildIndex])
                {
                    Swap(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
                else
                    break;
            }
        }
        private void HeapifyUp()
        {
            int index = size - 1;
            while(HasParentIndex(index) && Parent(index) > items[index])
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }
}
