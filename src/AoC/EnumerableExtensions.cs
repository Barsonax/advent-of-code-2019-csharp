using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T[]> GetPermutations<T>(this IEnumerable<T> items)
            where T : struct
        {
            if (items.Count() > 1)
            {
                return items.SelectMany(item => GetPermutations(items.Where(i => !i.Equals(item))),
                    (item, permutation) => new[] { item }.Concat(permutation).ToArray());
            }
            else
            {
                return new[] { items.ToArray() };
            }
        }
    }
}