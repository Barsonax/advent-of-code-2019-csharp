namespace AoC
{
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
}
