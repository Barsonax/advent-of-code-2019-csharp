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

            var digitBuffer = new int[6];
            foreach (int candidate in Enumerable.Range(input.Start.Value, input.End.Value - input.Start.Value))
            {
                if (IsValidPassword(candidate, digitBuffer))
                {
                    counter++;
                }
            }

            return counter;
        }

        public long Part2(Range input)
        {
            var counter = 0;

            var digitBuffer = new int[6];
            foreach (int candidate in Enumerable.Range(input.Start.Value, input.End.Value - input.Start.Value))
            {
                if (IsValidPassword2(candidate, digitBuffer))
                {
                    counter++;
                }
            }

            return counter;
        }

        public static bool IsValidPassword(int number, int[] digitBuffer)
        {
            ExtractDigits(number, digitBuffer);

            return DigitsNeverDecrease(digitBuffer) && AdjacentDigitsAreSame(digitBuffer);
        }

        public static bool IsValidPassword2(int number, int[] digitBuffer)
        {
            ExtractDigits(number, digitBuffer);

            return DigitsNeverDecrease(digitBuffer) && AdjacentDigitsAreSameAndNotPartOfGroup(digitBuffer);
        }

        public static void ExtractDigits(int number, int[] digitBuffer)
        {
            digitBuffer[0] = number / 100000 % 10;
            digitBuffer[1] = number / 10000 % 10;
            digitBuffer[2] = number / 1000 % 10;
            digitBuffer[3] = number / 100 % 10;
            digitBuffer[4] = number / 10 % 10;
            digitBuffer[5] = number % 10;
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

