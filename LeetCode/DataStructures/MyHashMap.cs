using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructures
{
    public class MyHashMap
    {

        private int _keySpace;
        private List<CHashSet> _hashTable;
        public MyHashMap()
        {
            _keySpace = 2048;
            _hashTable = new List<CHashSet>();

            for (int i = 0; i < _keySpace; i++)
            {
                _hashTable.Add(new CHashSet());
            }
        }
        private int GetHashKey(int key)
        {
            return key % _keySpace;
        }
        public void Put(int key, int value)
        {
            int hKey = GetHashKey(key);
            _hashTable[hKey].Update(key, value);
        }

        public int Get(int key)
        {
            int hKey = GetHashKey(key);
            return _hashTable[hKey].Get(key);
        }

        public void Remove(int key)
        {
            int hKey = GetHashKey(key);
            _hashTable[hKey].Remove(key);
        }
    }
    public class CHashSet
    {
        private List<CPair> list;
        public CHashSet()
        {
            list = new List<CPair>();
        }

        private int GetIndex(int key)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Key == key)
                {
                    return i;
                }
            }
            return -1;
        }
        public int Get(int key)
        {
            int idx = GetIndex(key);
            return idx == -1 ? idx : list[idx].Value;
        }
        public void Update(int key, int val)
        {
            int idx = GetIndex(key);
            if (idx == -1)
                list.Add(new CPair(key, val));
            else
                list[idx].Value = val;
        }
        public void Remove(int key)
        {
            int idx = GetIndex(key);
            if (idx != -1)
                list.RemoveAt(idx);
        }
    }
    public class CPair
    {
        public int Key;
        public int Value;
        public CPair(int key, int val)
        {
            Key = key;
            Value = val;
        }
    }
}
