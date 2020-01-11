using System;
using System.Linq;

namespace AoC
{
    public class Puzzle5 : IPuzzle<long[]>
    {
        public long[] ParseInput(string input) => input
                                                 .Split(new[] { "," }, StringSplitOptions.None)
                                                 .Select(long.Parse)
                                                 .ToArray();

        public long Part1(long[] input)
        {
            var memory = new Memory(input).AddInputs(1);

            var runner = new ProgramRunner(memory);
            runner.Execute();
            return memory.Output.Peek();
        }

        public long Part2(long[] input)
        {
            var memory = new Memory(input).AddInputs(5);

            var runner = new ProgramRunner(memory);
            runner.Execute();
            return memory.Output.Peek();
        }
    }
}
