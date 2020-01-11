using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AoC
{
    public class Puzzle3 : IPuzzle<Line[]>
    {
        public Line[] ParseInput(string input)
        {
            var lines = input.Split("\r\n").Select(x => x.Split(',').Select(x =>
            {
                var length = int.Parse(x.AsSpan().Slice(1, x.Length - 1));
                return x[0] switch
                {
                    'U' => new Vector2(0, length),
                    'D' => new Vector2(0, -length),
                    'L' => new Vector2(-length, 0),
                    'R' => new Vector2(length, 0),
                };
            }));

            return lines.Select(translations =>
            {
                Vector2 position = Vector2.Zero;
                var wires = new List<Wire>();
                foreach (Vector2 translation in translations)
                {
                    var newPosition = position + translation;
                    wires.Add(new Wire(position, newPosition));
                    position = newPosition;
                }

                return new Line(wires.ToArray());
            }).ToArray();
        }


        public long Part2(Line[] input)
        {
            throw new NotImplementedException();
        }

        public long Part1(Line[] input)
        {
            return (long)input[0].Intersects(input[1]).Min(x => x.GetManhattanDistance(input[0].Parts[0].From));
        }
    }

    public readonly struct Line
    {
        public Wire[] Parts { get; }

        public Line(Wire[] parts)
        {
            Parts = parts;
        }

        public IEnumerable<Vector2> Intersects(Line other)
        {
            throw new NotImplementedException();
        }
    }

    public readonly struct Wire
    {
        public Vector2 From { get; }
        public Vector2 To { get; }

        public Wire(Vector2 from, Vector2 to)
        {
            From = from;
            To = to;
        }

        public Vector2 Intersects(Wire other)
        {
            throw new NotImplementedException();
        }
    }

    public static class Vector2Extensions
    {
        public static float GetManhattanDistance(this Vector2 from, Vector2 to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }
    }
}
