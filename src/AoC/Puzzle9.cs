using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC
{
    public class Puzzle9 : IPuzzle<long[]>
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
            throw new NotImplementedException();
        }
    }
}
