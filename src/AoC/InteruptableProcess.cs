using System.Collections;
using System.Collections.Generic;

namespace AoC
{
    public class InteruptableProcess : IEnumerator<OpCode>, IEnumerable<OpCode>
    {
        private readonly IntCodeVM _vm;

        public InteruptableProcess(IntCodeVM vm) => _vm = vm;

        public OpCode Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public IEnumerator<OpCode> GetEnumerator() => this;


        public bool MoveNext()
        {
            var code = _vm.Memory[_vm.InstructionPointer];
            var opCode = IntCodeVM.ParseOpCode(code);

            Current = opCode;
            if (opCode == OpCode.End)
            {
                return false;
            }

            _vm.ExecuteOpCode(code, opCode);
            return true;
        }

        public void Reset() { }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}