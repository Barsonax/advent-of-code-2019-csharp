
using Xunit;

namespace AoC.Tests
{
    public class Puzzle2Tests
    {
        public class Part1
        {
            [Theory]
            [InlineData(new long[] { 1, 0, 0, 0, 99 }, new long[] { 2, 0, 0, 0, 99 })]
            [InlineData(new long[] { 2, 3, 0, 3, 99 }, new long[] { 2, 3, 0, 6, 99 })]
            [InlineData(new long[] { 2, 4, 4, 5, 99, 0 }, new long[] { 2, 4, 4, 5, 99, 9801 })]
            [InlineData(new long[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new long[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
            [InlineData(new long[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }, new long[] { 3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50 })]
            public void Examples(long[] program, long[] expectedOutput)
            {
                var vm = new IntCodeVM(program);
                var process = new Process(vm);
                process.Run();

                Assert.Equal(expectedOutput, vm.Memory);
            }
        }
    }
}
