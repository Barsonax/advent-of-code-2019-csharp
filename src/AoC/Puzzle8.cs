using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC
{
    public class Puzzle8 : IPuzzle<byte[][]>
    {
        public byte[][] ParseInput(string input) => input.Select(x => (byte)(x - 48)).Batch(25 * 6).Select(x => x.ToArray()).ToArray();

        public long Part1(byte[][] input)
        {
            throw new NotImplementedException();
        }

        public long Part2(byte[][] input)
        {
            throw new NotImplementedException();
        }

    }
}
