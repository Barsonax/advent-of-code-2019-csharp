using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class Memory
    {
        public Queue<long> Input { get; set; } = new Queue<long>();
        public Stack<long> Output { get; set; } = new Stack<long>();

        public long[] Program { get; set; }
        public long InstructionPointer { get; set; }

        public Memory(int[] program)
        {
            LoadProgram(program);
        }

        public Memory(long[] program) 
        {
            LoadProgram(program);
        }

        public void LoadProgram(int[] program)
        {
            Program = program.Select(x => (long)x).ToArray();
            InstructionPointer = 0;
        }

        public void LoadProgram(long[] program)
        {
            Program = program.ToArray();
            InstructionPointer = 0;
        }

        public Memory AddInputs(params int[] inputs)
        {
            foreach (var input in inputs)
            {
                Input.Enqueue(input);
            }

            return this;
        }
    }
}
