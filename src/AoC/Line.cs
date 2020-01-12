using System;
using System.Collections.Generic;
using System.Numerics;

namespace AoC
{
    public interface ILine
    {
        public Vector2 From { get; }
        public Vector2 To { get; }
    }

    public readonly struct Line : ILine
    {
        public Vector2 From { get; }
        public Vector2 To { get; }

        public Line(Vector2 from, Vector2 to)
        {
            From = from;
            To = to;
        }

        public Line((float x, float y) from, (float x, float y) to)
        {
            From = new Vector2(from.x, from.y);
            To = new Vector2(to.x, to.y);
        }

        public static IEnumerable<(Vector2 point, TLine line)> Intersects<TLine>(TLine A, IEnumerable<TLine> others)
            where TLine : ILine
        {
            foreach (var other in others)
            {
                var intersection = Intersects(A, other);
                if (intersection != null)
                {
                    yield return (intersection.Value, other);
                }
            }
        }

        public static Vector2? Intersects<TLine>(TLine A, TLine B)
            where TLine : ILine
        {
            return Intersects(A.From, A.To, B.From, B.To);
        }

        public static Vector2? Intersects(Vector2 A, Vector2 B, Vector2 C, Vector2 D)
        {
            // Line AB represented as a1x + b1y = c1  
            float a1 = B.Y - A.Y;
            float b1 = A.X - B.X;

            // Line CD represented as a2x + b2y = c2  
            float a2 = D.Y - C.Y;
            float b2 = C.X - D.X;

            float determinant = a1 * b2 - a2 * b1;

            if (determinant == 0)
            {
                // The lines are parallel so there is no intersection.
                return null;
            }
            else
            {
                float c1 = a1 * A.X + b1 * A.Y;
                float c2 = a2 * C.X + b2 * C.Y;
                float x = (b2 * c1 - b1 * c2) / determinant;
                float y = (a1 * c2 - a2 * c1) / determinant;

                var intersection = new Vector2(x, y);
                // Check if the intersection point lies on the line segment
                if (IsBetween(A, B, intersection) && IsBetween(C, D, intersection))
                {
                    return intersection;
                }
                else
                {
                    // The intersection point lies outside of the line segment.
                    return null;
                }
            }
        }

        public static bool IsBetween(Vector2 A, Vector2 B, Vector2 intersection) =>
            Math.Min(A.X, B.X) <= intersection.X && intersection.X <= Math.Max(A.X, B.X) &&
            Math.Min(A.Y, B.Y) <= intersection.Y && intersection.Y <= Math.Max(A.Y, B.Y);
    }
}
