namespace AoC
{
    public static class IntExtensions
    {
        public static int Digit1(this int value) => value % 10;
        public static int Digit10(this int value) => value / 10 % 10;
        public static int Digit100(this int value) => value / 100 % 10;
        public static int Digit1000(this int value) => value / 1000 % 10;
        public static int Digit10000(this int value) => value / 10000 % 10;
        public static int Digit100000(this int value) => value / 100000 % 10;
    }
}
