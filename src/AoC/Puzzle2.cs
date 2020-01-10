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
            var memory = new Memory(input);
            var runner = new ProgramRunner(memory);

            runner.Execute();

            return memory.Program[0];
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

                    var memory = new Memory(input);
                    var runner = new ProgramRunner(memory);
                    runner.Execute();
                    if (memory.Program[0] == desiredOutput)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
}
