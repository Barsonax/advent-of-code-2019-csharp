﻿
using Xunit;

namespace AoC.Tests
{
    public class Puzzle5Tests
    {
        [Fact]
        public void Test1()
        {
            var computer = new IntCodeComputer();
            var input = 923;
            var program = new[] { 3, 0, 4, 0, 99 };

            var result = computer.ExecuteProgram(program, input);

            Assert.Equal(input, computer.Memory.Output.Peek());
        }

        [Fact]
        public void Test2()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 1002, 4, 3, 4, 33 };

            var result = computer.ExecuteProgram(program);

            Assert.Equal(new[] { 1002, 4, 3, 4, 99 }, computer.Memory.Program);
        }

        [Fact]
        public void Test3()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 0102, 3, 4, 4, 33 };

            var result = computer.ExecuteProgram(program);

            Assert.Equal(new[] { 0102, 3, 4, 4, 99 }, computer.Memory.Program);
        }

        [Fact]
        public void Test4()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 1101, 100, -1, 4, 0 };

            var result = computer.ExecuteProgram(program);

            Assert.Equal(new[] { 1101, 100, -1, 4, 99 }, computer.Memory.Program);
        }

        [Fact]
        public void Test5()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1102, 72, 20, 224, 1001, 224, -1440, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 5, 224, 1, 224, 223, 223, 1002, 147, 33, 224, 101, -3036, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 5, 224, 1, 224, 223, 223, 1102, 32, 90, 225, 101, 65, 87, 224, 101, -85, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 4, 224, 224, 1, 223, 224, 223, 1102, 33, 92, 225, 1102, 20, 52, 225, 1101, 76, 89, 225, 1, 117, 122, 224, 101, -78, 224, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 223, 224, 223, 1102, 54, 22, 225, 1102, 5, 24, 225, 102, 50, 84, 224, 101, -4600, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 3, 224, 224, 1, 223, 224, 223, 1102, 92, 64, 225, 1101, 42, 83, 224, 101, -125, 224, 224, 4, 224, 102, 8, 223, 223, 101, 5, 224, 224, 1, 224, 223, 223, 2, 58, 195, 224, 1001, 224, -6840, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 223, 224, 223, 1101, 76, 48, 225, 1001, 92, 65, 224, 1001, 224, -154, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 223, 224, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 329, 101, 1, 223, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 344, 1001, 223, 1, 223, 1107, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 359, 1001, 223, 1, 223, 8, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 374, 101, 1, 223, 223, 108, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 389, 1001, 223, 1, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 404, 101, 1, 223, 223, 1107, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 101, 1, 223, 223, 1008, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 434, 101, 1, 223, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 449, 101, 1, 223, 223, 1108, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 464, 1001, 223, 1, 223, 107, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 479, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 7, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 509, 101, 1, 223, 223, 107, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 524, 1001, 223, 1, 223, 1007, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 539, 1001, 223, 1, 223, 108, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 554, 101, 1, 223, 223, 1007, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 569, 101, 1, 223, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 584, 1001, 223, 1, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 599, 1001, 223, 1, 223, 1007, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 614, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 629, 101, 1, 223, 223, 1108, 677, 677, 224, 1002, 223, 2, 223, 1005, 224, 644, 1001, 223, 1, 223, 8, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 659, 101, 1, 223, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 674, 101, 1, 223, 223, 4, 223, 99, 226 };

            var result = computer.ExecuteProgram(program, 1);

            Assert.Equal(new[] { 11933517, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, computer.Memory.Output);
        }

        [Fact]
        public void EqualTo_PositionMode_False()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };

            var result = computer.ExecuteProgram(program, 7);

            Assert.Equal(0, computer.Memory.Output.Peek());
        }

        [Fact]
        public void EqualTo_PositionMode_True()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };

            var result = computer.ExecuteProgram(program, 8);

            Assert.Equal(1, computer.Memory.Output.Peek());
        }

        [Fact]
        public void EqualTo_ImmediateMode_False()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };

            var result = computer.ExecuteProgram(program, 7);

            Assert.Equal(0, computer.Memory.Output.Peek());
        }

        [Fact]
        public void EqualTo_ImmediateMode_True()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };

            var result = computer.ExecuteProgram(program, 8);

            Assert.Equal(1, computer.Memory.Output.Peek());
        }

        [Fact]
        public void LessThan_PositionMode_False()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };

            var result = computer.ExecuteProgram(program, 8);

            Assert.Equal(0, computer.Memory.Output.Peek());
        }

        [Fact]
        public void LessThan_PositionMode_True()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };

            var result = computer.ExecuteProgram(program, 7);

            Assert.Equal(1, computer.Memory.Output.Peek());
        }

        [Fact]
        public void JumpIfFalse_PositionMode_True()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };

            var result = computer.ExecuteProgram(program, 7);

            Assert.Equal(1, computer.Memory.Output.Peek());
        }

        [Fact]
        public void JumpIfFalse_PositionMode_False()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };

            var result = computer.ExecuteProgram(program, 0);

            Assert.Equal(0, computer.Memory.Output.Peek());
        }

        [Fact]
        public void JumpIfTrue_ImmediateMode_True()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };

            var result = computer.ExecuteProgram(program, 7);

            Assert.Equal(1, computer.Memory.Output.Peek());
        }

        [Fact]
        public void JumpIfTrue_ImmediateMode_False()
        {
            var computer = new IntCodeComputer();
            var program = new[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 };

            var result = computer.ExecuteProgram(program, 0);

            Assert.Equal(0, computer.Memory.Output.Peek());
        }
    }
}
