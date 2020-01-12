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
            var amplifiers = phaseSettings.Select(x => new IntCodeVM(program).AddInputs(x)).ToArray();

            long start = 0;

            while (true)
            {
                foreach (IntCodeVM amplifier in amplifiers)
                {
                    amplifier.Input.Enqueue(start);
                    var runner = new InteruptableProcess(amplifier);
                    var hasOutput = runner.Any(x => x == OpCode.Output);
                    if (!hasOutput)
                    {
                        yield return start;
                        yield break;
                    }
                    start = amplifier.Output.Dequeue();
                }

                yield return start;
            }
        }
    }
}
