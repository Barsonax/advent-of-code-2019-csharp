using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC.Console
{
    public class PuzzleRunner
    {
        private readonly Dictionary<string, IPuzzle> _puzzles;
        private readonly Dictionary<string, string> _inputs;

        public PuzzleRunner()
        {
            var puzzles = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("AoC"))
                                   .SelectMany(x => x.GetExportedTypes()).Where(x => typeof(IPuzzle).IsAssignableFrom(x)
                                                                                     && !x.IsInterface
                                                                                     && !x.IsAbstract)
                                   .Select(x => (IPuzzle)Activator.CreateInstance(x)).ToArray();

            _puzzles = puzzles.ToDictionary(x => x.GetType().Name, x => x, StringComparer.OrdinalIgnoreCase);

            var reader = new CustomResourceReader(Inputs.ResourceManager);
            _inputs = reader.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        }

        public PuzzleResult Run(string puzzleName)
        {
            var puzzle = _puzzles[puzzleName];

            return Run(puzzle);
        }

        public PuzzleResult Run(IPuzzle puzzle)
        {
            var puzzleName = puzzle.GetType().Name;
            var result = new PuzzleResult(puzzleName);

            var input = _inputs[puzzleName];
            var parsedInput = puzzle.ParseInput(input);

            try
            {
                var watch = Stopwatch.StartNew();
                result.Part1 = new PuzzlePartResult(puzzle.Part1(parsedInput), watch.ElapsedMilliseconds);

            }
            catch (Exception exception)
            {
                result.Part1 = new PuzzlePartResult(exception);
            }

            try
            {
                var watch = Stopwatch.StartNew();
                result.Part2 = new PuzzlePartResult(puzzle.Part2(parsedInput), watch.ElapsedMilliseconds);
            }
            catch (Exception exception)
            {
                result.Part2 = new PuzzlePartResult(exception);
            }

            return result;
        }

        public IEnumerable<PuzzleResult> Run()
        {
            foreach (var puzzle in _puzzles.Values)
            {
                yield return Run(puzzle);
            }
        }
    }
}
