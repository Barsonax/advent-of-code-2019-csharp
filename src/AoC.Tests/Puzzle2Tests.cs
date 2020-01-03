
using Xunit;

namespace AoC.Tests
{
    public class Puzzle2Tests
    {
        [Fact]
        public void Test1()
        {
            var puzzle = new IntCodeComputer();
            var input = new[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
            var result = puzzle.ExecuteProgram(input);

            Assert.Equal(3500, result);
        }

        [Fact]
        public void Test2()
        {
            var puzzle = new IntCodeComputer();
            var input = new[] { 1, 0, 0, 0, 99 };
            var result = puzzle.ExecuteProgram(input);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Test3()
        {
            var puzzle = new IntCodeComputer();
            var input = new[] { 2, 3, 0, 3, 99 };
            var result = puzzle.ExecuteProgram(input);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Test4()
        {
            var puzzle = new IntCodeComputer();
            var input = new[] { 2, 4, 4, 5, 99, 0 };
            var result = puzzle.ExecuteProgram(input);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Test5()
        {
            var puzzle = new IntCodeComputer();
            var input = new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            var result = puzzle.ExecuteProgram(input);

            Assert.Equal(30, result);
        }
    }
}
