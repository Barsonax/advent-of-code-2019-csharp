using Xunit;

namespace AoC.Tests
{
    public class Puzzle4Tests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(Puzzle4.IsValidPassword(111111));
        }

        [Fact]
        public void Test2()
        {
            Assert.False(Puzzle4.IsValidPassword(223450));
        }

        [Fact]
        public void Test3()
        {
            Assert.False(Puzzle4.IsValidPassword(123789));
        }

        [Fact]
        public void Test4()
        {
            Assert.True(Puzzle4.IsValidPassword2(112233));
        }

        [Fact]
        public void Test5()
        {
            Assert.False(Puzzle4.IsValidPassword2(123444));
        }

        [Fact]
        public void Test6()
        {
            Assert.True(Puzzle4.IsValidPassword2(111122));
        }
    }
}
