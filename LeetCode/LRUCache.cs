using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    //The LRU Cache Eviction Policy ("LRU(Least Recently Used) Cache" on LeetCode)
    //https://leetcode.com/problems/lru-cache/
    public class LRUCache
    {
        DoubleLinkedList cacheMemory = null;
        public LRUCache(int capacity)
        {
            cacheMemory = new DoubleLinkedList(capacity);
        }

        public int Get(int key)
        {
            return cacheMemory.Get(key);
        }

        public void Put(int key, int value)
        {
            cacheMemory.Put(key, value);
        }
    }
    public class DoubleLinkedList
    {
        DoubleNode head;
        DoubleNode tail;
        int length = 0;
        int Capacity = 0;
        Dictionary<int, DoubleNode> memHashTable = null;

        public DoubleLinkedList(int size)
        {
            head = null;
            tail = null;
            Capacity = size;
            length = 0;
            memHashTable = new Dictionary<int, DoubleNode>();
        }

        public int Get(int key)
        {
            int retVal = -1;
            DoubleNode node = Contains(key);
            if (node != null)
            {
                retVal = node.Value;

                RemoveNode(key);
                AddNode(key, node.Value);
            }
            return retVal;
        }
        public void Put(int key, int val)
        {
            RemoveNode(key);
            AddNode(key, val);
        }
        private DoubleNode Contains(int key)
        {
            if (memHashTable.ContainsKey(key))
                return memHashTable[key];
            else
                return null;

            //DoubleNode currNode = head;
            //while (currNode != null && currNode.Key != key)
            //    currNode = currNode.Next;

            //return currNode;
        }

        private void AddNode(int key, int val)
        {
            DoubleNode node = new DoubleNode(key, val);
            if (head != null)
            {
                DoubleNode temp = head;
                head = node;
                head.Next = temp;
                temp.Prev = head;
            }
            else
            {
                head = node;
                tail = node;
            }
            if (memHashTable.ContainsKey(key))
                memHashTable[key] = node;
            else
                memHashTable.Add(key, node);
            length++;

            CheckCapability();
        }
        private void RemoveNode(int key)
        {
            DoubleNode node = Contains(key);
            if (node != null)
            {
                if (node.Prev != null)
                    node.Prev.Next = node.Next;

                if (node.Next != null)
                    node.Next.Prev = node.Prev;

                if (node == tail)
                    tail = node.Prev;
                if (node == head)
                    head = node.Next;

                if (memHashTable.ContainsKey(key))
                    memHashTable.Remove(key);
                length--;
            }
        }

        public void CheckCapability()
        {
            if (length > Capacity)
            {
                if (tail != null)
                {
                    RemoveNode(tail.Key);
                }
            }
        }
    }
    public class DoubleNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public DoubleNode Prev { get; set; }
        public DoubleNode Next { get; set; }

        public DoubleNode(int key, int val)
        {
            Key = key;
            Value = val;
        }
    }

}
