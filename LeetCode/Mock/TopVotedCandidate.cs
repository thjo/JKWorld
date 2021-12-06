using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Mock
{
    /// <summary>
    /// 911. Online Election
    /// https://leetcode.com/problems/online-election/solution/
    /// </summary>
    public class TopVotedCandidate
    {
        private int[] _persons = null;
        private int[] _times = null;
        public TopVotedCandidate(int[] persons, int[] times)
        {
            _persons = persons;
            _times = times;
        }

        public int Q(int t)
        {
            int sitPos = BSearchTimes(t, 0, _times.Length - 1);
            if (sitPos <= 0)
                return 0;
            else
                return _persons[sitPos];
        }
        private int BSearchTimes(int t, int startIdx, int endIdx)
        {
            if (startIdx > endIdx)
                return endIdx-1;

            int midIdx = (startIdx + endIdx) / 2;
            if (_times[midIdx] == t)
                return midIdx;
            else if (_times[midIdx] < t)
            {
                if (midIdx + 1 <= endIdx
                    && _times[midIdx + 1] > t)
                    return midIdx-1;
                else
                    return BSearchTimes(t, midIdx + 1, endIdx);
            }
            else
            {
                if( midIdx-1 >= startIdx
                    && _times[midIdx-1] < t)
                    return midIdx-2;
                else
                    return BSearchTimes(t, startIdx, midIdx-1);
            }
        }
    }
}
