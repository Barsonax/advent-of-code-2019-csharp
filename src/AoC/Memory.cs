using System.Collections.Generic;

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
}
