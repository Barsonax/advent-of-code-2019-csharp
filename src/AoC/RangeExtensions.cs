using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public static class RangeExtensions
    {
        public static IEnumerable<int> ToSequence(this Range range) => Enumerable.Range(range.Start.Value, range.End.Value - range.Start.Value);
    }
}
