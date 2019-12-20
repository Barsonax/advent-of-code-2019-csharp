using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
                    var input = File.ReadAllText($"{puzzleType.Name}/input.txt");
                    var puzzle = (IPuzzle)Activator.CreateInstance(puzzleType);

                    WriteLine($"{puzzleType.Name}:");
                    WriteLine("  part1");
                    WriteLine("    " + puzzle.Part1(input));

                    WriteLine("  part2");
                    WriteLine("    " + puzzle.Part2(input));
                }
                catch (Exception e)
                {
                    WriteLine(e);
                }
            }
        }
    }
}
