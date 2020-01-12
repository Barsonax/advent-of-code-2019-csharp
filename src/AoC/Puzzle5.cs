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
            var vm = new IntCodeVM(input).AddInputs(1);

            var process = new Process(vm);
            process.Run();
            return vm.Output.Peek();
        }

        public long Part2(long[] input)
        {
            var vm = new IntCodeVM(input).AddInputs(5);

            var process = new Process(vm);
            process.Run();
            return vm.Output.Peek();
        }
    }
}
