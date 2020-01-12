using System;
using System.Linq;

namespace AoC
{
    public class Puzzle2 : IPuzzle<long[]>
    {
        public long[] ParseInput(string input) => input
                                                 .Split(new[] { "," }, StringSplitOptions.None)
                                                 .Select(long.Parse)
                                                 .ToArray();

        public long Part1(long[] input)
        {
            input[1] = 12;
            input[2] = 2;
            var vm = new IntCodeVM(input);
            var process = new Process(vm);

            process.Run();

            return vm.Memory[0];
        }

        public long Part2(long[] input)
        {
            var desiredOutput = 19690720;

            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    input[1] = noun;
                    input[2] = verb;

                    var vm = new IntCodeVM(input);
                    var process = new Process(vm);
                    process.Run();
                    if (vm.Memory[0] == desiredOutput)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
}
