using System;
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


        public static IEnumerable<IEnumerable<T>> Batch<T>(
            this IEnumerable<T> source, int batchSize)
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                yield return YieldBatchElements(enumerator, batchSize - 1);
        }

        private static IEnumerable<T> YieldBatchElements<T>(
            IEnumerator<T> source, int batchSize)
        {
            yield return source.Current;
            for (int i = 0; i < batchSize && source.MoveNext(); i++)
                yield return source.Current;
        }
    }
}