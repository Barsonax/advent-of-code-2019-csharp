using System;
using System.Numerics;

namespace AoC
{
    public static class Vector2Extensions
    {
        public static float GetManhattanDistance(this Vector2 from, Vector2 to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        public static float GetManhattanDistance(this Vector2 from)
        {
            return Math.Abs(from.X) + Math.Abs(from.Y);
        }
    }
}
