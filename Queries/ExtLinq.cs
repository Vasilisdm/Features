using System;
using System.Collections.Generic;

namespace Queries
{
    public static class ExtLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();

            foreach(var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
