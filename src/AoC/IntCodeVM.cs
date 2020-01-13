using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class IntCodeVM
    {
        public Queue<long> Input { get; } = new Queue<long>();
        public Queue<long> Output { get; } = new Queue<long>();
        public VirtualMemory Memory { get; }
        public IntCodeVM(long[] memory) => Memory = new VirtualMemory(memory.ToArray());
        public long ConsumeInstructionPointer() => _instructionPointer++;

        private long _instructionPointer, _relativeBase;

        public void ExecuteOpCode(int code, OpCode opCode)
        {
            switch (opCode)
            {
                case OpCode.Add:
                    Execute(code, (ref long p1, ref long p2, ref long p3) => p3 = p1 + p2);
                    break;
                case OpCode.Multiply:
                    Execute(code, (ref long p1, ref long p2, ref long p3) => p3 = p1 * p2);
                    break;
                case OpCode.Input:
                    Execute(code, (ref long p1) => p1 = Input.Dequeue());
                    break;
                case OpCode.Output:
                    Execute(code, (ref long p1) => Output.Enqueue(p1));
                    break;
                case OpCode.JumpTrue:
                    Execute(code, (ref long p1, ref long p2) =>
                    {
                        if (p1 != 0) _instructionPointer = p2;
                    });
                    break;
                case OpCode.JumpFalse:
                    Execute(code, (ref long p1, ref long p2) =>
                   {
                       if (p1 == 0) _instructionPointer = p2;
                   });
                    break;
                case OpCode.LessThan:
                    Execute(code, (ref long p1, ref long p2, ref long p3) => p3 = p1 < p2 ? 1 : 0);
                    break;
                case OpCode.Equals:
                    Execute(code, (ref long p1, ref long p2, ref long p3) => p3 = p1 == p2 ? 1 : 0);
                    break;
                case OpCode.Relative:
                    Execute(code, (ref long p1) => _relativeBase += p1);
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

        public static OpCode ParseOpCode(int code) => (OpCode)(code % 100);

        private void Execute(int code, RefAction<long, long, long> action)
        {
            var p1 = GetParameterAddress(code.Digit100());
            var p2 = GetParameterAddress(code.Digit1000());
            var p3 = GetParameterAddress(code.Digit10000());
            Memory.Reserve(p1, p2, p3);
            action(ref Memory[p1], ref Memory[p2], ref Memory[p3]);
        }

        private void Execute(int code, RefAction<long, long> action)
        {
            var p1 = GetParameterAddress(code.Digit100());
            var p2 = GetParameterAddress(code.Digit1000());
            Memory.Reserve(p1, p2);
            action(ref Memory[p1], ref Memory[p2]);
        }

        private void Execute(int code, RefAction<long> action)
        {
            var p1 = GetParameterAddress(code.Digit100());
            Memory.Reserve(p1);
            action(ref Memory[p1]);
        }

        private long GetParameterAddress(int mode) => (ParameterMode)mode switch
        {
            ParameterMode.Immediate => ConsumeInstructionPointer(),
            ParameterMode.Position => Memory[ConsumeInstructionPointer()],
            ParameterMode.Relative => _relativeBase + Memory[ConsumeInstructionPointer()],
        };
    }
}