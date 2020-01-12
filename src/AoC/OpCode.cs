﻿namespace AoC
{
    public enum OpCode
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4,
        JumpTrue = 5,
        JumpFalse = 6,
        LessThan = 7,
        Equals = 8,
        Relative = 9,
        End = 99
    }
}
