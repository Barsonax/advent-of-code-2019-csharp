namespace AoC
{
    public class Parameter
    {
        private readonly Memory _memory;

        public Parameter(Memory memory)
        {
            _memory = memory;
        }

        public ParameterMode Mode { get; set; }
        public long Index { get; set; }

        public long Value
        {
            get => _memory.Program[Index];
            set => _memory.Program[Index] = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
