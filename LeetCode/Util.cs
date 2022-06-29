using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class Util
    {
        public static void Sort<T>(T[][] data, int col)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
        }
    }
}
