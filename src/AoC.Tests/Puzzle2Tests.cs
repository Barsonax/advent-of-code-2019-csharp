
using Xunit;

namespace AoC.Tests
{
    public class Puzzle2Tests
    {
        [Fact]
        public void Test1()
        {
            var memory = new Memory(new[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 });
            var computer = new ProgramRunner(memory);
            computer.Execute();

            Assert.Equal(3500, memory.Program[0]);
        }

        [Fact]
        public void Test2()
        {
            var memory = new Memory(new[] { 1, 0, 0, 0, 99 });
            var computer = new ProgramRunner(memory);
            computer.Execute();

            Assert.Equal(2, memory.Program[0]);
        }

        [Fact]
        public void Test3()
        {
            var memory = new Memory(new[] { 2, 3, 0, 3, 99 });
            var computer = new ProgramRunner(memory);
            computer.Execute();

            Assert.Equal(2, memory.Program[0]);
        }

        [Fact]
        public void Test4()
        {
            var memory = new Memory(new[] { 2, 4, 4, 5, 99, 0 });
            var computer = new ProgramRunner(memory);
            computer.Execute();

            Assert.Equal(2, memory.Program[0]);
        }

        [Fact]
        public void Test5()
        {
            var memory = new Memory(new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 });
            var computer = new ProgramRunner(memory);
            computer.Execute();

            Assert.Equal(30, memory.Program[0]);
        }
    }
}
