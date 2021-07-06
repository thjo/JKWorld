using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm.DataStructures
{
    public class MinIntHeap
    {
        private int capacity = 10;
        private int size = 0;

        int[] items = null;
        public MinIntHeap()
        {
            items = new int[capacity];
        }

        private int GetLeftChildIndex(int parentIdx) { return 2 * parentIdx + 1; }
        private int GetRightChildIndex(int parentIdx) { return 2 * parentIdx + 2; }
        private int GetParentIndex(int childIdx) { return (childIdx - 1) / 2; }

        private bool HasLeftChild(int idx) { return GetLeftChildIndex(idx) < size; }
        private bool HasRightChild(int idx) { return GetRightChildIndex(idx) < size; }
        private bool HasParent(int idx) { return GetParentIndex(idx) >= 0; }

        private int GetLeftChild(int idx) { return items[GetLeftChildIndex(idx)]; }
        private int GetRightChild(int idx) { return items[GetRightChildIndex(idx)]; }
        private int GetParent(int idx) { return items[GetParentIndex(idx)]; }

        private void swap(int idx1, int idx2)
        {
            int tmp = items[idx1];
            items[idx1] = items[idx2];
            items[idx2] = tmp;
        }
        private void EnsureExtraCapacity()
        {
            if(size == capacity)
            {
                capacity *= 2;
                Array.Resize<int>(ref items, capacity);
            }
        }

        public int? Peek()
        {
            if (size == 0)
                return null;

            int val = items[0];
            items[0] = items[size - 1];
            size--;
            HeapifyDown();

            return val;
        }
        public void Add(int value)
        {
            EnsureExtraCapacity();
            items[size] = value;
            size++;
            HeapifyUp();
        }


        public void HeapifyUp()
        {
            int idx = size - 1;
            while (HasParent(idx) && GetParent(idx) > items[idx])
            {
                swap(idx, GetParentIndex(idx));
                idx = GetParentIndex(idx);
            }
        }
        public void HeapifyDown()
        {
            int idx = 0;
            while (HasLeftChild(idx))
            {
                int smallestChildIdx = GetLeftChildIndex(idx);
                if (HasRightChild(idx) && GetRightChild(idx) < GetLeftChild(idx))
                    smallestChildIdx = GetRightChild(idx);

                if (items[idx] > items[smallestChildIdx])
                {
                    swap(idx, smallestChildIdx);
                    idx = smallestChildIdx;
                }
                else
                    break;
            }
        }
    }
}
