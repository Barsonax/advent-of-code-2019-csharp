using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class IntCodeComputer
    {
        public Memory Memory = new Memory();

        private OpCode ParseOpCode(ReadOnlySpan<char> code)
        {
            Memory.InstructionPointer++;
            return (OpCode)int.Parse(code[^2..]);
        }

        private void ParseParameters(ReadOnlySpan<char> code, Memory memory, int parameterCount)
        {
            for (int i = 0; i < parameterCount; i++)
            {
                var mode = ParseParameterMode(code, i);

                if (mode == ParameterMode.Immediate)
                {
                    memory.Parameters[i].Index = memory.InstructionPointer;
                }
                else
                {
                    memory.Parameters[i].Index = memory.Program[memory.InstructionPointer];
                }

                memory.Parameters[i].Mode = mode;
                memory.InstructionPointer++;
            }
        }

        private ParameterMode ParseParameterMode(ReadOnlySpan<char> code, int i)
        {
            var position = code.Length - (i + 3);
            if (position >= 0)
            {
                return (ParameterMode)int.Parse(code.Slice(position, 1));
            }

            return ParameterMode.Position;
        }

        public int ExecuteProgram(int[] program, int input = 0)
        {
            Memory.Input.Push(input);
            Memory.Program = program.ToArray();
            Memory.InstructionPointer = 0;

            for (var i = 0; i < Memory.Parameters.Length; i++)
            {
                Memory.Parameters[i] = new Parameter(Memory.Program);
            }

            var log = new List<InstructionLog>();
            while (true)
            {
                var code = Memory.Program[Memory.InstructionPointer].ToString("D2").AsSpan();
                var opCode = ParseOpCode(code);
                ExecuteOpCode(opCode, code, Memory);

                //log.Add(new InstructionLog(opCode, Memory.Parameters.Take(instruction.ParameterCount).Select(x => new ParameterLog(x)).ToArray()));
                if (opCode == OpCode.End)
                {
                    return Memory.Program[0];
                }
            }

            throw new InvalidOperationException();
        }

        private void ExecuteOpCode(OpCode opCode, ReadOnlySpan<char> code, Memory memory)
        {
            switch (opCode)
            {
                case OpCode.Add:
                    ParseParameters(code, Memory, 3);
                    memory.Parameters[2].Value = memory.Parameters[0].Value + memory.Parameters[1].Value;
                    break;
                case OpCode.Multiply:
                    ParseParameters(code, Memory, 3);
                    memory.Parameters[2].Value = memory.Parameters[0].Value * memory.Parameters[1].Value;
                    break;
                case OpCode.Input:
                    ParseParameters(code, Memory, 1);
                    memory.Parameters[0].Value = memory.Input.Pop();
                    break;
                case OpCode.Output:
                    ParseParameters(code, Memory, 1);
                    memory.Output.Push(memory.Parameters[0].Value);
                    break;
                case OpCode.JumpTrue:
                    ParseParameters(code, Memory, 2);
                    if (memory.Parameters[0].Value != 0) memory.InstructionPointer = memory.Parameters[1].Value;
                    break;
                case OpCode.JumpFalse:
                    ParseParameters(code, Memory, 2);
                    if (memory.Parameters[0].Value == 0) memory.InstructionPointer = memory.Parameters[1].Value;
                    break;
                case OpCode.LessThan:
                    ParseParameters(code, Memory, 3);
                    memory.Parameters[2].Value = memory.Parameters[0].Value < memory.Parameters[1].Value ? 1 : 0;
                    break;
                case OpCode.Equals:
                    ParseParameters(code, Memory, 3);
                    memory.Parameters[2].Value = memory.Parameters[0].Value == memory.Parameters[1].Value ? 1 : 0;
                    break;
                case OpCode.End:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opCode), opCode.ToString());
            }
        }

        public class InstructionLog
        {
            public InstructionLog(OpCode opCode, ParameterLog[] parameters)
            {
                OpCode = opCode;
                Parameters = parameters;
            }

            public OpCode OpCode { get; }
            public ParameterLog[] Parameters { get; }

            public override string ToString()
            {
                return $"{OpCode}({string.Join(',', Parameters.Select(x => x.ToString()))})";
            }
        }

        public class ParameterLog
        {
            public ParameterLog(Parameter parameter)
            {
                Value = parameter.Value;
                Mode = parameter.Mode;
                Index = parameter.Index;
            }

            public ParameterMode Mode { get; }
            public int Value { get; }
            public int Index { get; }

            public override string ToString()
            {
                if (Mode == ParameterMode.Immediate)
                {
                    return Value.ToString();
                }
                return $"{Value}*{Index}";
            }
        }
    }
}
