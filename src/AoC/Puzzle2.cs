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
            input[1] = 12;
            input[2] = 2;
            return ExecuteProgram(input);
        }

        public object Part2(int[] input)
        {
            var desiredOutput = 19690720;

            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    input[1] = noun;
                    input[2] = verb;

                    var result = ExecuteProgram(input);
                    if (result == desiredOutput)
                    {
                        return 100 * noun + verb;
                    }
                }
            }
            throw new InvalidOperationException();
        }


        private int ExecuteProgram(int[] input)
        {
            var array = input.ToArray();

            for (var index = 0; index < array.Length; index += 4)
            {
                var opCode = array[index];
                var instruction = new Instruction(array, index);

                switch (instruction.OpCode)
                {
                    case OpCode.Add:
                        array[instruction.Output] = array[instruction.Input1] + array[instruction.Input2];
                        break;
                    case OpCode.Multiply:
                        array[instruction.Output] = array[instruction.Input1] * array[instruction.Input2];
                        break;
                    case OpCode.End:
                        return array[0];
                }
            }

            throw new InvalidOperationException();
        }
    }
}
