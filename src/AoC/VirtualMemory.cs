using System.Collections;
using System.Collections.Generic;

namespace AoC
{
    public class VirtualMemory : IEnumerable<long>
    {
        public ref long this[long i] => ref _memory[i];

        private long[] _memory;

        public VirtualMemory(long[] memory) => _memory = memory;

        public void Reserve(long address1, long address2, long address3) => Reserve(Max(address1, address2, address3));
        public void Reserve(long address1, long address2) => Reserve(Max(address1, address2));

        public void Reserve(long address)
        {
            if (address >= _memory.Length)
            {
                var newMemory = new long[address + 1];
                for (int i = 0; i < _memory.Length; i++)
                {
                    newMemory[i] = _memory[i];
                }

                _memory = newMemory;
            }
        }

        private long Max(long value1, long value2, long value3) => value1 > value2 ? Max(value1, value3) : Max(value2, value3);
        private long Max(long value1, long value2) => value1 > value2 ? value1 : value2;

        public IEnumerator<long> GetEnumerator() => (IEnumerator<long>)_memory.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _memory.GetEnumerator();
    }
}
