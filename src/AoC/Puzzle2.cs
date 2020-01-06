using System;
using System.Linq;

namespace AoC
{
    public class Puzzle2 : IPuzzle<int[]>
    {
        public int[] ParseInput(string input) => input
                                                 .Split(new[] { "," }, StringSplitOptions.None)
                                                 .Select(int.Parse)
                                                 .ToArray();

        public object Part1(int[] input)
        {
            var computer = new IntCodeComputer();
            input[1] = 12;
            input[2] = 2;
            return computer.ExecuteProgram(input);
        }

        public object Part2(int[] input)
        {
            var computer = new IntCodeComputer();
            var desiredOutput = 19690720;

            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    input[1] = noun;
                    input[2] = verb;

                    var result = computer.ExecuteProgram(input);
                    if (result == desiredOutput)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
}
