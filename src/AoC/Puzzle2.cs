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
            throw new System.NotImplementedException();
        }

        public object Part2(int[] input)
        {
            throw new System.NotImplementedException();
        }
    }
}
