
using Xunit;

namespace AoC.Tests
{
    public class Puzzle5Tests
    {
        public class Part1
        {
            [Theory]
            [InlineData(new long[] { 3, 0, 4, 0, 99 }, new long[] { 923, 0, 4, 0, 99 }, 923)]
            [InlineData(new long[] { 1002, 4, 3, 4, 33 }, new long[] { 1002, 4, 3, 4, 99 })]
            [InlineData(new long[] { 0102, 3, 4, 4, 33 }, new long[] { 0102, 3, 4, 4, 99 })]
            [InlineData(new long[] { 1101, 100, -1, 4, 0 }, new long[] { 1101, 100, -1, 4, 99 })]
            public void Examples(long[] program, long[] expectedProgramState, params int[] inputs)
            {
                var vm = new IntCodeVM(program).AddInputs(inputs);

                var process = new Process(vm);
                process.Run();

                Assert.Equal(expectedProgramState, vm.Memory);
            }
        }

        public class Part2
        {
            [Theory]
            [InlineData(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 0)]
            [InlineData(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 1)]
            [InlineData(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 7, 0)]
            [InlineData(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 }, 8, 1)]
            [InlineData(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 8, 0)]
            [InlineData(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 }, 7, 1)]
            [InlineData(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 7, 1)]
            [InlineData(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 }, 0, 0)]
            [InlineData(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 7, 1)]
            [InlineData(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 }, 0, 0)]
            public void Examples(long[] program, int input, int expectedOutput)
            {
                var vm = new IntCodeVM(program).AddInputs(input);

                var process = new Process(vm);
                process.Run();

                Assert.Equal(expectedOutput, vm.Output.Peek());
            }
        }

        public class OpCodeParseData : TheoryData<int, int, OpCode, ParameterMode[]>
        {
            public OpCodeParseData()
            {
                Add(1099, 3, OpCode.End, new[] { ParameterMode.Position, ParameterMode.Immediate, ParameterMode.Position });
                Add(1002, 3, OpCode.Multiply, new[] { ParameterMode.Position, ParameterMode.Immediate, ParameterMode.Position });
                Add(11002, 3, OpCode.Multiply, new[] { ParameterMode.Position, ParameterMode.Immediate, ParameterMode.Immediate });
            }
        }

        [Theory]
        [ClassData(typeof(OpCodeParseData))]
        public void ParseOpCode(int code, int parameterCount, OpCode expectedOpCode, ParameterMode[] expectedParameterModes)
        {
            var opCode = IntCodeVM.ParseOpCode(code);

            var parameters = new ParameterMode[parameterCount];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = IntCodeVM.ParseParameterMode(code, i);
            }

            Assert.Equal(expectedOpCode, opCode);
            Assert.Equal(expectedParameterModes, parameters);
        }
    }
}
