using System;
using System.Linq;

namespace AoC
{
    public class Puzzle5 : IPuzzle<int[]>
    {
        public int[] ParseInput(string input) => input
                                                 .Split(new[] { "," }, StringSplitOptions.None)
                                                 .Select(int.Parse)
                                                 .ToArray();

        public object Part1(int[] input)
        {
            var computer = new IntCodeComputer();
            computer.ExecuteProgram(input, 1);
            return computer.Memory.Output.Peek();
        }

        public object Part2(int[] input)
        {
            var computer = new IntCodeComputer();
            computer.ExecuteProgram(input, 5);
            return computer.Memory.Output.Peek();
        }
    }
}
