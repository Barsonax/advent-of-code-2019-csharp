using System;
using System.Linq;

namespace AoC
{
    public class IntCodeComputer
    {
        public int ExecuteProgram(int[] input)
        {
            var array = input.ToArray();

            for (var index = 0; index < array.Length; index += 4)
            {
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
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            throw new InvalidOperationException();
        }
    }
}
