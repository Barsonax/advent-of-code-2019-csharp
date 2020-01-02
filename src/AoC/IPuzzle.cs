namespace AoC
{
    public interface IPuzzle<TParsedInput> : IPuzzle
    {
        new TParsedInput ParseInput(string input);
        object Part1(TParsedInput input);
        object Part2(TParsedInput input);

        object IPuzzle.ParseInput(string input) => ParseInput(input);
        object IPuzzle.Part1(object input) => Part1((TParsedInput)input);
        object IPuzzle.Part2(object input) => Part2((TParsedInput)input);
    }

    public interface IPuzzle
    {
        object ParseInput(string input);
        object Part1(object input);

        object Part2(object input);
    }
}