using System;
using System.Collections.Generic;
using System.Linq;

namespace code.util
{
    public static class EnumerableUtil
    {
        public static TElement GetRandomElement<TElement>(IList<TElement> elements)
        {
            return elements[new Random().Next(elements.Count)];
        }

        public static string toString<TElement>(IEnumerable<TElement> elements)
        {
            return string.Join(", ", elements.Select(element => element.ToString()).ToArray());
        }
    }
}