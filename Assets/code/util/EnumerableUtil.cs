using System;
using System.Collections.Generic;

namespace code.util
{
    public static class EnumerableUtil
    {
        public static TElement GetRandomElement<TElement>(IList<TElement> elements)
        {
            return elements[new Random().Next(elements.Count)];
        }
    }
}