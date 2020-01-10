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
            var permutations = new[] { 0, 1, 2, 3, 4 }.GetPermutations();

            long maxScore = 0;

            foreach (var permutation in permutations)
            {
                var score = RunAmplifiers(input, permutation[0], permutation[1], permutation[2], permutation[3], permutation[4]);
                if (score > maxScore) maxScore = score;
            }

            return maxScore;
        }

        private long RunAmplifiers(long[] program, int phase1, int phase2, int phase3, int phase4, int phase5)
        {
            var amplifiers = Enumerable.Range(0, 5).Select(x => new Memory(program)).ToArray();

            long start = 0;
            amplifiers[0].AddInputs(phase1);
            amplifiers[1].AddInputs(phase2);
            amplifiers[2].AddInputs(phase3);
            amplifiers[3].AddInputs(phase4);
            amplifiers[4].AddInputs(phase5);

            for (int i = 0; i < amplifiers.Length; i++)
            {
                amplifiers[i].Input.Enqueue(start);
                var runner = new ProgramRunner(amplifiers[i]);
                runner.First(x => x == OpCode.Output);
                start = amplifiers[i].Output.Pop();
            }

            return start;
        }

        private long RunAmplifierLoop(long[] program, int phase1, int phase2, int phase3, int phase4, int phase5)
        {
            var amplifiers = Enumerable.Range(0, 5).Select(x => new Memory(program)).ToArray();

            long start = 0;
            amplifiers[0].AddInputs(phase1);
            amplifiers[1].AddInputs(phase2);
            amplifiers[2].AddInputs(phase3);
            amplifiers[3].AddInputs(phase4);
            amplifiers[4].AddInputs(phase5);

            var foo = 0;
            while (true)
            {
                for (int i = 0; i < amplifiers.Length; i++)
                {
                    amplifiers[i].Input.Enqueue(start);
                    var runner = new ProgramRunner(amplifiers[i]);
                    var hasOutput = runner.Any(x => x == OpCode.Output);
                    if (!hasOutput) return start;
                    start = amplifiers[i].Output.Pop();
                    
                }

                foo++;
            }
        }

        public long Part2(long[] input)
        {
            var permutations = new[] { 5, 6, 7, 8, 9 }.GetPermutations();

            long maxScore = 0;

            foreach (var permutation in permutations)
            {
                var score = RunAmplifierLoop(input, permutation[0], permutation[1], permutation[2], permutation[3], permutation[4]);
                if (score > maxScore) maxScore = score;
            }

            return maxScore;
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
