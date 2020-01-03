namespace AoC
{
    public enum OpCode
    {
        Add = 1,
        Multiply = 2,
        End = 99
    }
    public readonly struct Instruction
    {
        public readonly OpCode OpCode;
        public readonly int Input1;
        public readonly int Input2;
        public readonly int Output;

        public Instruction(int[] array, int index)
        {
            OpCode = (OpCode)array[index];
            if (OpCode != OpCode.End)
            {
                Input1 = array[index + 1];
                Input2 = array[index + 2];
                Output = array[index + 3];
            }
            else
            {
                Input1 = 0;
                Input2 = 0;
                Output = 0;
            }
        }
    }
}
