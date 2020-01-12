using Xunit;

namespace AoC.Tests
{
    public class Puzzle3Tests
    {
        public class Part1
        {
            [Fact]
            public void Example1()
            {
                var puzzle = new Puzzle3();
                var input = puzzle.ParseInput("R8,U5,L5,D3" + "\r\n" + "U7,R6,D4,L4");
                var result = puzzle.Part1(input);
                Assert.Equal(6, result);
            }

            [Fact]
            public void Example2()
            {
                var puzzle = new Puzzle3();
                var input = puzzle.ParseInput("R75,D30,R83,U83,L12,D49,R71,U7,L72" + "\r\n" + "U62,R66,U55,R34,D71,R55,D58,R83");
                var result = puzzle.Part1(input);
                Assert.Equal(159, result);
            }

            [Fact]
            public void Example3()
            {
                var puzzle = new Puzzle3();
                var input = puzzle.ParseInput("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51" + "\r\n" + "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");
                var result = puzzle.Part1(input);
                Assert.Equal(135, result);
            }
        }

        public class Part2
        {
            [Fact]
            public void Example1()
            {
                var puzzle = new Puzzle3();
                var input = puzzle.ParseInput("R8,U5,L5,D3" + "\r\n" + "U7,R6,D4,L4");
                var result = puzzle.Part2(input);
                Assert.Equal(30, result);
            }

            [Fact]
            public void Example2()
            {
                var puzzle = new Puzzle3();
                var input = puzzle.ParseInput("R75,D30,R83,U83,L12,D49,R71,U7,L72" + "\r\n" + "U62,R66,U55,R34,D71,R55,D58,R83");
                var result = puzzle.Part2(input);
                Assert.Equal(610, result);
            }
        }


        [Fact]
        public void LineIntersects()
        {
            var line1 = new Line((0, 8), (6, 8));
            var line2 = new Line((3, 6), (3, 3));

            var intersection = Line.Intersects(line1, line2);

            Assert.Null(intersection);
        }
    }
}
