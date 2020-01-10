using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC
{
    public class Puzzle4 : IPuzzle<Range>
    {
        public Range ParseInput(string input)
        {
            var array = input.Split('-').Select(int.Parse).ToArray();
            return array[0]..array[1];
        }

        public long Part1(Range input)
        {
            var counter = 0;

            foreach (int candidate in Enumerable.Range(input.Start.Value, input.End.Value - input.Start.Value))
            {
                if (IsValidPassword(candidate))
                {
                    counter++;
                }
            }

            return counter;
        }

        public long Part2(Range input)
        {
            var counter = 0;

            foreach (int candidate in Enumerable.Range(input.Start.Value, input.End.Value - input.Start.Value))
            {
                if (IsValidPassword2(candidate))
                {
                    counter++;
                }
            }

            return counter;
        }

        public static bool IsValidPassword(int number)
        {
            if (number / 100000 > 0)
            {
                var digits = number.ToString().Select(x => (int)x).ToArray();

                return DigitsNeverDecrease(digits) && AdjacentDigitsAreSame(digits);
            }

            return false;
        }

        public static bool IsValidPassword2(int number)
        {
            if (number / 100000 > 0)
            {
                var digits = number.ToString().Select(x => (int)x).ToArray();

                return DigitsNeverDecrease(digits) && AdjacentDigitsAreSameAndNotPartOfGroup(digits);
            }

            return false;
        }

        private static bool DigitsNeverDecrease(int[] digits)
        {
            var previousDigit = digits[0];
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] < previousDigit) return false;
                previousDigit = digits[i];
            }

            return true;
        }

        private static bool AdjacentDigitsAreSame(int[] digits)
        {
            var previousDigit = digits[0];
            for (int i = 1; i < digits.Length; i++)
            {
                if (previousDigit == digits[i]) return true;
                previousDigit = digits[i];
            }

            return false;
        }

        private static bool AdjacentDigitsAreSameAndNotPartOfGroup(int[] digits)
        {
            var length = 0;
            var previousDigit = digits[0];
            for (int i = 1; i < digits.Length; i++)
            {
                if (previousDigit == digits[i])
                {
                    length++;
                }
                else
                {
                    if (length == 1) return true;
                    length = 0;
                }
                previousDigit = digits[i];
            }

            return length == 1;
        }
    }
}
