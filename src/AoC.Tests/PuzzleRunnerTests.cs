
using AoC.Console;

using Xunit;

namespace AoC.Tests
{
    public class PuzzleRunnerTests
    {
        public class PuzzleTheoryData : TheoryData<PuzzleResult>
        {
            public PuzzleTheoryData()
            {
                Add(new PuzzleResult("puzzle1",
                    new PuzzlePartResult(3295206),
                    new PuzzlePartResult(4939939)));
                Add(new PuzzleResult("puzzle2",
                    new PuzzlePartResult(6627023),
                    new PuzzlePartResult(4019)));
                Add(new PuzzleResult("puzzle5",
                    new PuzzlePartResult(11933517),
                    new PuzzlePartResult(10428568)
                    ));

                Add(new PuzzleResult("puzzle7",
                    new PuzzlePartResult(422858),
                    new PuzzlePartResult(14897241)
                ));
            }
        }

        [Theory]
        [ClassData(typeof(PuzzleTheoryData))]
        public void Puzzles(PuzzleResult expectedPuzzleResult)
        {
            var runner = new PuzzleRunner();

            var puzzleResult = runner.Run(expectedPuzzleResult.PuzzleName);

            Assert.Equal(expectedPuzzleResult.Part1.Result, puzzleResult.Part1.Result);
            if (expectedPuzzleResult.Part2 != null)
            {
                Assert.Equal(expectedPuzzleResult.Part2.Result, puzzleResult.Part2.Result);
            }
        }
    }
}
