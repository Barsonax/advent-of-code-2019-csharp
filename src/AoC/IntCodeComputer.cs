using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class Memory
    {
        public Stack<int> Input { get; set; } = new Stack<int>();
        public Stack<int> Output { get; set; } = new Stack<int>();

        public Parameter[] Parameters { get; } = new Parameter[16];

        public int[] Program { get; set; }
        public int InstructionPointer { get; set; }
    }
    public class IntCodeComputer
    {
        public Memory Memory = new Memory();

        private Dictionary<OpCode, IInstruction> InstructionSet { get; } = new Dictionary<OpCode, IInstruction>
        {
            { OpCode.Add, new AddInstruction()},
            { OpCode.Multiply, new MultiplyInstruction() },
            { OpCode.Input, new InputInstruction()},
            { OpCode.Output, new OutputInstruction()},
            { OpCode.End, new EndInstruction()}
        };

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
                var instruction = InstructionSet[opCode];

                ParseParameters(code, Memory, instruction.ParameterCount);
                log.Add(new InstructionLog(opCode, Memory.Parameters.Take(instruction.ParameterCount).Select(x => new ParameterLog(x)).ToArray()));
                instruction.Execute(Memory);
                if (opCode == OpCode.End)
                {
                    return Memory.Program[0];
                }
            }

            throw new InvalidOperationException();
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
