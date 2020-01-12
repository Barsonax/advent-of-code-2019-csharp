using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class IntCodeVM
    {
        private static readonly int[] ParameterMasks = Enumerable.Range(0, 4).Select(x => 100 * (int)Math.Pow(10, x)).ToArray();

        public Queue<long> Input { get; set; } = new Queue<long>();
        public Stack<long> Output { get; set; } = new Stack<long>();

        public long[] Memory { get; set; }
        public long InstructionPointer { get; set; }

        public IntCodeVM(long[] memory) => Memory = memory.ToArray();

        public void ExecuteOpCode(long code, OpCode opCode)
        {
            InstructionPointer++;
            switch (opCode)
            {
                case OpCode.Add:
                    Execute(code, delegate (ref long p1, ref long p2, ref long p3) { p3 = p1 + p2; });
                    break;
                case OpCode.Multiply:
                    Execute(code, delegate (ref long p1, ref long p2, ref long p3) { p3 = p1 * p2; });
                    break;
                case OpCode.Input:
                    Execute(code, delegate (ref long p1) { p1 = Input.Dequeue(); });
                    break;
                case OpCode.Output:
                    Execute(code, delegate (ref long p1) { Output.Push(p1); });
                    break;
                case OpCode.JumpTrue:
                    Execute(code, delegate (ref long p1, ref long p2)
                    {
                        if (p1 != 0) InstructionPointer = p2;
                    });
                    break;
                case OpCode.JumpFalse:
                    Execute(code, delegate (ref long p1, ref long p2)
                    {
                        if (p1 == 0) InstructionPointer = p2;
                    });
                    break;
                case OpCode.LessThan:
                    Execute(code, delegate (ref long p1, ref long p2, ref long p3) { p3 = p1 < p2 ? 1 : 0; });
                    break;
                case OpCode.Equals:
                    Execute(code, delegate (ref long p1, ref long p2, ref long p3) { p3 = p1 == p2 ? 1 : 0; });
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opCode), opCode.ToString());
            }
        }

        public IntCodeVM AddInputs(params int[] inputs)
        {
            foreach (var input in inputs)
            {
                Input.Enqueue(input);
            }

            return this;
        }

        public static OpCode ParseOpCode(long code) => (OpCode)(code % 100);

        public static ParameterMode ParseParameterMode(long code, int parameterPosition) => (ParameterMode)(code / ParameterMasks[parameterPosition] % 10);

        private void Execute(long code, RefAction<long, long, long> action)
        {
            var p1 = ParseParameter(code, 0);
            var p2 = ParseParameter(code, 1);
            var p3 = ParseParameter(code, 2);
            action(ref Memory[p1], ref Memory[p2], ref Memory[p3]);
        }

        private void Execute(long code, RefAction<long, long> action)
        {
            var p1 = ParseParameter(code, 0);
            var p2 = ParseParameter(code, 1);
            action(ref Memory[p1], ref Memory[p2]);
        }

        private void Execute(long code, RefAction<long> action)
        {
            var p1 = ParseParameter(code, 0);
            action(ref Memory[p1]);
        }

        private long ParseParameter(long code, int position)
        {
            var index = ParseParameterMode(code, position) switch
            {
                ParameterMode.Immediate => InstructionPointer,
                ParameterMode.Position => Memory[InstructionPointer]
            };
            InstructionPointer++;

            return index;
        }
    }
}