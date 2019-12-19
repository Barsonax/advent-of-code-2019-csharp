using System;
using System.Linq;

namespace AoC
{
    public static class Day1
    {
        public static void Calculate(string input)
        {
            var modules = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(int.Parse).ToArray();
            var result = modules.Sum(x => Math.Floor(x / 3f) - 2);
        }
    }
}
