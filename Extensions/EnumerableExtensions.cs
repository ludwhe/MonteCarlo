using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var rand = new Random();
            return Shuffle(source, rand);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rand)
        {
            lock (rand)
            {
                return source?.OrderBy(_ => rand.Next());
            }
        }
    }
}