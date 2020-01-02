using System;
using System.IO;
using System.Linq;

using static System.Console;

namespace AoC.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzles = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("AoC"))
                                   .SelectMany(x => x.GetExportedTypes()).Where(x => typeof(IPuzzle).IsAssignableFrom(x)
                                                                                     && !x.IsInterface
                                                                                     && !x.IsAbstract).ToArray();

            foreach (Type puzzleType in puzzles)
            {
                try
                {
                    var puzzle = (IPuzzle)Activator.CreateInstance(puzzleType);
                    var puzzleName = puzzle.GetType().Name;
                    var input = File.ReadAllText($"{puzzleName}/input.txt");

                    var parsedInput = puzzle.ParseInput(input);
                    WriteLine($"{puzzleName}:");
                    WriteLine("  part1");
                    WriteLine("    " + puzzle.Part1(parsedInput));

                    WriteLine("  part2");
                    WriteLine("    " + puzzle.Part2(parsedInput));
                }
                catch (Exception e)
                {
                    WriteLine($"The following error occurred while executing puzzle {puzzleType}: {e}");
                }
            }
        }
    }
}
