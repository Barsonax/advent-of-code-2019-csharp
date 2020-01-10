using static System.Console;

namespace AoC.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var puzzle = new Puzzle2();
            //var input = puzzle.ParseInput(Inputs.puzzle2);
            //while (true)
            //{
            //    puzzle.Part2(input);
            //}

            var runner = new PuzzleRunner();

            foreach (var result in runner.Run())
            {
                WriteLine($"{result.PuzzleName}:");
                if (result.Part1.Error == null)
                {
                    WriteLine($"  Answer for part 1: {result.Part1.Result}, solved in {result.Part1.ElapsedMilliseconds} ms");
                }

                if (result.Part2.Error == null)
                {
                    WriteLine($"  Answer for part 2: {result.Part2.Result}, solved in {result.Part2.ElapsedMilliseconds} ms ");
                }
            }
        }
    }
}
