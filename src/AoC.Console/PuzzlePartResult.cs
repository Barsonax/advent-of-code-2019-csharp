using System;

namespace AoC.Console
{
    public class PuzzlePartResult
    {
        public PuzzlePartResult(int result, long elapsedMilliseconds = 0)
        {
            Result = result;
            ElapsedMilliseconds = elapsedMilliseconds;
        }
        public PuzzlePartResult(object result, long elapsedMilliseconds)
        {
            Result = result;
            ElapsedMilliseconds = elapsedMilliseconds;
        }

        public PuzzlePartResult(Exception error)
        {
            Error = error;
        }

        public object? Result { get; }
        public long ElapsedMilliseconds { get; }
        public Exception? Error { get; }
    }
}
