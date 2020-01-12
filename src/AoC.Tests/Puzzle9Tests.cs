
using Xunit;

namespace AoC.Tests
{
    public class Puzzle9Tests
    {
        public class Part1
        {
            [Theory]
            [InlineData(new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 }, new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 })]
            [InlineData(new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 }, new long[] { 1219070632396864 })]
            [InlineData(new long[] { 104, 1125899906842624, 99 }, new long[] { 1125899906842624 })]
            public void Examples(long[] program, long[] expectedOutput)
            {
                var vm = new IntCodeVM(program);

                var process = new Process(vm);
                process.Run();

                Assert.Equal(expectedOutput, vm.Output);
            }
        }
    }
}
