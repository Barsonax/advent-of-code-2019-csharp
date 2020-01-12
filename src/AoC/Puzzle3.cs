using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AoC
{
    public class Puzzle3 : IPuzzle<(Wire wire1, Wire wire2)>
    {
        public (Wire wire1, Wire wire2) ParseInput(string input)
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

            var wires = lines.Select(translations =>
            {
                Vector2 position = Vector2.Zero;
                var wires = new List<Line>();
                foreach (Vector2 translation in translations)
                {
                    var newPosition = position + translation;
                    wires.Add(new Line(position, newPosition));
                    position = newPosition;
                }

                return new Wire(wires.ToArray());
            }).ToArray();
            return (wires[0], wires[1]);
        }


        public long Part2((Wire wire1, Wire wire2) input)
        {
            return Wire.Intersects(input.wire1, input.wire2).Select(x => 
            (int)(x.line1.DistanceFromStart + x.point.GetManhattanDistance(x.line1.From) + x.line2.DistanceFromStart + x.point.GetManhattanDistance(x.line2.From))).Min();
        }

        public long Part1((Wire wire1, Wire wire2) input)
        {
            return (long)Wire.Intersects(input.wire1, input.wire2).Min(x => x.point.GetManhattanDistance());
        }
    }

    public readonly struct WireSegment : ILine
    {
        public Line Line { get; }
        public int DistanceFromStart { get; }

        public Vector2 From => Line.From;

        public Vector2 To => Line.To;

        public WireSegment(Line line, int distanceFromStart)
        {
            Line = line;
            DistanceFromStart = distanceFromStart;
        }
    }

    public readonly struct Wire
    {
        public WireSegment[] Segments { get; }

        public Wire(Line[] parts)
        {
            Segments = new WireSegment[parts.Length];
            var distanceFromStart = 0;
            for (int i = 0; i < Segments.Length; i++)
            {
                Segments[i] = new WireSegment(parts[i], distanceFromStart);
                distanceFromStart += (int)parts[i].From.GetManhattanDistance(parts[i].To);
            }
        }

        public static IEnumerable<(Vector2 point, WireSegment line1, WireSegment line2)> Intersects(Wire A, Wire B) =>
            A.Segments.SelectMany(x => Line.Intersects(x, B.Segments).Where(x => x.Item1 != Vector2.Zero).Select(intersection => (intersection.point, x, intersection.line)));
    }
}
