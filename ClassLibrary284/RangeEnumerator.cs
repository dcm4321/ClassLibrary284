
using System.Collections;

using System.Collections.Generic;

namespace ClassLibrary284
{
    /// <summary>
    /// enumerate over a low/high range of ints
    /// </summary>
    public class RangeEnumerator: IEnumerator<int>
    {
        private readonly int _low;
        private readonly int _high;

        private bool _isInited;

        public RangeEnumerator(int low, int high)
        {
            _low = low;
            _high = high;
        }

        public bool MoveNext()
        {
            if (!_isInited)
            {
                _isInited = true;
                Current = _low;
            }
            else if (Current <= _high)
                Current++;
            return Current <= _high;
        }

        public void Reset() => _isInited = false;

        public int Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
