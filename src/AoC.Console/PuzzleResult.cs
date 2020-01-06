namespace AoC.Console
{
    public class PuzzleResult
    {
        public PuzzleResult(string puzzleName)
        {
            PuzzleName = puzzleName;
        }

        public PuzzleResult(string puzzleName, PuzzlePartResult part1, PuzzlePartResult? part2 = null)
        {
            PuzzleName = puzzleName;
            Part1 = part1;
            Part2 = part2;
        }

        public string PuzzleName { get; }
        public PuzzlePartResult Part1 { get; set; }
        public PuzzlePartResult? Part2 { get; set; }

    }
}
