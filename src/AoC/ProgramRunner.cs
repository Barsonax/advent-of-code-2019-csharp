using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class ProgramRunner : IEnumerator<OpCode>, IEnumerable<OpCode>
    {
        private readonly Memory _memory;

        public ProgramRunner(Memory memory)
        {
            _memory = memory;
        }

        private static readonly int[] ParameterMasks = Enumerable.Range(0, 4).Select(x => 100 * (int)Math.Pow(10, x)).ToArray();

        public void Execute()
        {
            while (MoveNext()) { }
        }

        public static OpCode ParseOpCode(long code)
        {
            return (OpCode)(code % 100);
        }

        public static ParameterMode ParseParameterMode(long code, int parameterPosition)
        {
            return (ParameterMode)(code / ParameterMasks[parameterPosition] % 10);
        }

        private void ExecuteOpCode(long code, OpCode opCode, Memory memory)
        {
            switch (opCode)
            {
                case OpCode.Add:
                    Execute(code, (parameter1, parameter2, parameter3) => parameter3.Value = parameter1.Value + parameter2.Value);
                    break;
                case OpCode.Multiply:
                    Execute(code, (parameter1, parameter2, parameter3) => parameter3.Value = parameter1.Value * parameter2.Value);
                    break;
                case OpCode.Input:
                    Execute(code, parameter1 => parameter1.Value = memory.Input.Dequeue());
                    break;
                case OpCode.Output:
                    Execute(code, parameter1 => memory.Output.Push(parameter1.Value));
                    break;
                case OpCode.JumpTrue:
                    Execute(code, (parameter1, parameter2) =>
                    {
                        if (parameter1.Value != 0) memory.InstructionPointer = parameter2.Value;
                    });
                    break;
                case OpCode.JumpFalse:
                    Execute(code, (parameter1, parameter2) =>
                    {
                        if (parameter1.Value == 0) memory.InstructionPointer = parameter2.Value;
                    });
                    break;
                case OpCode.LessThan:
                    Execute(code, (parameter1, parameter2, parameter3) => parameter3.Value = parameter1.Value < parameter2.Value ? 1 : 0);
                    break;
                case OpCode.Equals:
                    Execute(code, (parameter1, parameter2, parameter3) => parameter3.Value = parameter1.Value == parameter2.Value ? 1 : 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(opCode), opCode.ToString());
            }
        }

        private void Execute(long code, Action<Parameter, Parameter, Parameter> action)
        {
            var parameters = ParseParameters(code, _memory, 3);
            action(parameters[0], parameters[1], parameters[2]);
        }

        private void Execute(long code, Action<Parameter, Parameter> action)
        {
            var parameters = ParseParameters(code, _memory, 2);
            action(parameters[0], parameters[1]);
        }

        private void Execute(long code, Action<Parameter> action)
        {
            var parameters = ParseParameters(code, _memory, 1);
            action(parameters[0]);
        }

        private Parameter[] ParseParameters(long code, Memory memory, int parameterCount)
        {
            var parameters = _memory.Parameters[parameterCount];
            for (int i = 0; i < parameters.Length; i++)
            {
                var mode = ParseParameterMode(code, i);

                if (mode == ParameterMode.Immediate)
                {
                    parameters[i].Index = memory.InstructionPointer;
                }
                else
                {
                    parameters[i].Index = memory.Program[memory.InstructionPointer];
                }

                parameters[i].Mode = mode;
                memory.InstructionPointer++;
            }

            return parameters;
        }

        public bool MoveNext()
        {
            var code = _memory.Program[_memory.InstructionPointer];

            var opCode = ParseOpCode(code);

            Current = opCode;
            if (opCode == OpCode.End)
            {
                return false;
            }
            _memory.InstructionPointer++;
            ExecuteOpCode(code, opCode, _memory);
            return true;
        }

        public void Reset()
        {
            _memory.InstructionPointer = 0;
        }

        public OpCode Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public IEnumerator<OpCode> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
