using System.IO;

namespace AoC.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Day1/input.txt");
            Day1.Calculate(input);
        }
    }
}
