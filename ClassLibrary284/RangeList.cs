
using System;

using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary284
{
    public class RangeList: IReadOnlyList<int>
    {
        public int Low { get; }
        public int High { get; }

        public int Count => Low > High ? 0 : 1 + High - Low;
        public int Max => Low + Count;

        public RangeList(int low, int high)
        {
            Low = low;
            High = high;
        }
        #region enumeration
        public IEnumerator<int> GetEnumerator() => new RangeEnumerator(Low, High);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion enumeration

        public bool Contains(int item) => Low <= item && item <= High;

        public void CopyTo(int[] array, int arrayIndex)
        {
            for (var i = 0; i < Count; i++)
                array[arrayIndex + i] = this[i];
        }

        public int IndexOf(int item) => Contains(item) ? item - Low : -1;

        static private int IndexOutOfRange()
        {
            throw new IndexOutOfRangeException();
        }
        public int this[int index] => 0 <= index && index < Count ? Low + index : IndexOutOfRange();
    }
}
