﻿namespace AoC
{
    public class Process
    {
        private readonly IntCodeVM _vm;

        public Process(IntCodeVM vm) => _vm = vm;

        public void Run()
        {
            while (true)
            {
                var code = (int)_vm.Memory[_vm.ConsumeInstructionPointer()];
                var opCode = IntCodeVM.ParseOpCode(code);
                if (opCode == OpCode.End)
                {
                    return;
                }
                _vm.ExecuteOpCode(code, opCode);
            }
        }
    }
}