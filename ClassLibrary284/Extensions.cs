
using System.Collections.Generic;

namespace ClassLibrary284
{
    static public class Extensions
    {
        static public IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            foreach (var item in items)
                list.Add(item);
            return list;
        }

        static public IList<T> AddRange<T>(this IList<T> list, params T[] items)
        {
            foreach (var item in items)
                list.Add(item);
            return list;
        }
    }
}
