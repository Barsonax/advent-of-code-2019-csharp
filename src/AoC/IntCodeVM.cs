using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class IntCodeVM
    {
        private static readonly int[] ParameterMasks = Enumerable.Range(0, 4).Select(x => 100 * (int)Math.Pow(10, x)).ToArray();

        public Queue<long> Input { get; } = new Queue<long>();
        public Queue<long> Output { get; } = new Queue<long>();

        public long[] Memory { get; private set; }
        public long InstructionPointer { get; private set; }
        public long RelativeBase { get; private set; }

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
                    Execute(code, delegate (ref long p1) { Output.Enqueue(p1); });
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
                case OpCode.Relative:
                    Execute(code, delegate(ref long p1) { RelativeBase += p1; });
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
            var p1 = GetParameterMemoryAddress(code, 0);
            var p2 = GetParameterMemoryAddress(code, 1);
            var p3 = GetParameterMemoryAddress(code, 2);
            action(ref Memory[p1], ref Memory[p2], ref Memory[p3]);
        }

        private void Execute(long code, RefAction<long, long> action)
        {
            var p1 = GetParameterMemoryAddress(code, 0);
            var p2 = GetParameterMemoryAddress(code, 1);
            action(ref Memory[p1], ref Memory[p2]);
        }

        private void Execute(long code, RefAction<long> action)
        {
            var p1 = GetParameterMemoryAddress(code, 0);
            action(ref Memory[p1]);
        }

        private long GetParameterMemoryAddress(long code, int position)
        {
            var index = ParseParameterMode(code, position) switch
            {
                ParameterMode.Immediate => InstructionPointer,
                ParameterMode.Position => Memory[InstructionPointer],
                ParameterMode.Relative => RelativeBase + Memory[InstructionPointer],
            };
            InstructionPointer++;

            if (index >= Memory.Length)
            {
                var newMemory = new long[index + 1];
                for (int i = 0; i < Memory.Length; i++)
                {
                    newMemory[i] = Memory[i];
                }

                Memory = newMemory;
            }

            return index;
        }
    }
}