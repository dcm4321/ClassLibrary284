
using System;

using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary284
{
    /// <summary>
    /// read-only range list.
    /// This list must be read-only since it's
    /// a) "fully populated" at creation time and
    /// b) by the definition of the list, changes are not allowed
    /// </summary>
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

        static public RangeList Range(int low, int count) => new RangeList(low, low + count - 1);

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

        public int this[int index] => 0 <= index && index < Count ? Low + index : throw new IndexOutOfRangeException();
    }
}
