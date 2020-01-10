using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC
{
    public class Puzzle3 : IPuzzle<Wire[]>
    {
        public Wire[] ParseInput(string input)
        {
            return input.Replace("\r\n", ",").Split(',').Select(x => new Wire(
                int.Parse(x.AsSpan().Slice(1, x.Length - 1)),
                x[0] switch
                {
                    'U' => Direction.Up,
                    'D' => Direction.Down,
                    'L' => Direction.Left,
                    'R' => Direction.Right,
                })).ToArray();
        }


        public long Part2(Wire[] input)
        {
            throw new NotImplementedException();
        }

        public long Part1(Wire[] input)
        {
            throw new NotImplementedException();
        }
    }

    public readonly struct Wire
    {
        public int Length { get; }
        public Direction Direction { get; }

        public Wire(int length, Direction direction)
        {
            Length = length;
            Direction = direction;
        }
    }

    public enum Direction { Right, Left, Down, Up }
}
