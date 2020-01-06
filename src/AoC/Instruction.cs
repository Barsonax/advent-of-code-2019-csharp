namespace AoC
{
    public enum OpCode
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        End = 99
    }

    public enum ParameterMode
    {
        Position = 0,
        Immediate = 1
    }

    public interface IInstruction
    {
        int ParameterCount { get; }
        void Execute(Memory memory);
    }

    public class Parameter
    {
        private readonly int[] _array;

        public Parameter(int[] array)
        {
            _array = array;
        }

        public ParameterMode Mode { get; set; }
        public int Index { get; set; }

        public int Value
        {
            get => _array[Index];
            set => _array[Index] = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class AddInstruction : IInstruction
    {
        public int ParameterCount => 3;

        public void Execute(Memory memory)
        {
            memory.Parameters[2].Value = memory.Parameters[0].Value + memory.Parameters[1].Value;
        }
    }

    public class MultiplyInstruction : IInstruction
    {
        public int ParameterCount => 3;

        public void Execute(Memory memory)
        {
            memory.Parameters[2].Value = memory.Parameters[0].Value * memory.Parameters[1].Value;
        }
    }

    public class InputInstruction : IInstruction
    {
        public int ParameterCount => 1;

        public void Execute(Memory memory)
        {
            memory.Parameters[0].Value = memory.Input.Pop();
        }
    }

    public class OutputInstruction : IInstruction
    {
        public int ParameterCount => 1;

        public void Execute(Memory memory)
        {
            if (memory.Parameters[0].Value > 0)
            {

            }
            memory.Output.Push(memory.Parameters[0].Value);
        }
    }

    public class EndInstruction : IInstruction
    {
        public int ParameterCount => 0;

        public void Execute(Memory memory)
        {

        }
    }
}
