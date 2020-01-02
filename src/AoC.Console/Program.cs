using System;
using System.Diagnostics;
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
                    var watch = Stopwatch.StartNew();
                    WriteLine($"  Answer for part 1: {puzzle.Part1(parsedInput)}, solved in {watch.ElapsedMilliseconds} ms");

                    watch.Restart();
                    WriteLine($"  Answer for part 2: {puzzle.Part2(parsedInput)}, solved in {watch.ElapsedMilliseconds} ms ");
                }
                catch (Exception e)
                {
                    WriteLine($"The following error occurred while executing puzzle {puzzleType}: {e}");
                }
            }
        }
    }
}
