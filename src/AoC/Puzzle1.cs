using System;
using System.Linq;

namespace AoC
{
    public class Puzzle1 : IPuzzle<int[]>
    {
        public int[] ParseInput(string input) => input
                                                 .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                                                 .Select(int.Parse)
                                                 .ToArray();

        public long Part1(int[] input)
        {
            return input.Sum(CalculateFuel);
        }

        public long Part2(int[] input)
        {
            return input.Sum(CalculateFuelRecursive);
        }

        private static int CalculateFuel(int mass)
        {
            return (int)Math.Floor(mass / 3f) - 2;
        }

        private static int CalculateFuelRecursive(int mass)
        {
            var fuel = CalculateFuel(mass);
            return fuel > 0 ? fuel + CalculateFuelRecursive(fuel) : 0;
        }
    }
}
