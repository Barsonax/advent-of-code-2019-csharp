using System;
using System.Linq;

namespace AoC
{
    public class Puzzle1 : IPuzzle
    {
        public object Part1(string input)
        {
            var modules = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(int.Parse).ToArray();
            return modules.Sum(CalculateFuel);
        }

        public object Part2(string input)
        {
            var modules = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(int.Parse).ToArray();
            return modules.Sum(CalculateFuelRecursive);
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
