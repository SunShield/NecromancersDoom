using System;
using System.Collections.Generic;
using System.Linq;

namespace NDoom.Unity.Service
{
    public static class ListExtensions
    {
        private static Random random = new Random();

        public static void Shuffle<T>(this IList<T> list) => list = list.OrderBy(a => random.Next()).ToList();
    }
}
