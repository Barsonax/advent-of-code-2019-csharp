using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class Puzzle7 : IPuzzle<long[]>
    {
        public long[] ParseInput(string input) => input
                                                 .Split(new[] { "," }, StringSplitOptions.None)
                                                 .Select(long.Parse)
                                                 .ToArray();

        public long Part1(long[] input)
        {
            return new[] { 0, 1, 2, 3, 4 }.GetPermutations().Max(x => RunAmplifier(input, x).First());
        }

        public long Part2(long[] input)
        {
            return new[] { 5, 6, 7, 8, 9 }.GetPermutations().Max(x => RunAmplifier(input, x).Last());
        }

        private IEnumerable<long> RunAmplifier(long[] program, int[] phaseSettings)
        {
            var amplifiers = phaseSettings.Select(x => new Memory(program).AddInputs(x)).ToArray();

            long start = 0;

            while (true)
            {
                foreach (Memory amplifier in amplifiers)
                {
                    amplifier.Input.Enqueue(start);
                    var runner = new ProgramRunner(amplifier);
                    var hasOutput = runner.Any(x => x == OpCode.Output);
                    if (!hasOutput)
                    {
                        yield return start;
                        yield break;
                    }
                    start = amplifier.Output.Pop();
                }

                yield return start;
            }
        }
    }

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
