using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class SnapshotArray
    {
        int len = 0;
        Dictionary<int, int>[] snapshots = null;
        int snapCnt;
        public SnapshotArray(int length)
        {
            len = length;
            snapCnt = 0;
            snapshots = new Dictionary<int, int>[len];
            for (int i = 0; i < len; i++)
                snapshots[i] = new Dictionary<int, int>();
        }

        public void Set(int index, int val)
        {
            if (!snapshots[index].ContainsKey(snapCnt))
                snapshots[index].Add(snapCnt, val);
            else
                snapshots[index][snapCnt] = val;
        }

        public int Snap()
        {
            snapCnt++;
            return snapCnt - 1;
        }

        public int Get(int index, int snap_id)
        {
            if (snapshots[index].Count > 0)
            {
                while (!snapshots[index].ContainsKey(snap_id) && snap_id >= 0)
                    snap_id--;
                if (snap_id < 0)
                    return 0;
                else
                    return snapshots[index][snap_id];
            }
            else
                return 0;
        }
    }
}
