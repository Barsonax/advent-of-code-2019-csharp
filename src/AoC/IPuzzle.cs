namespace AoC
{
    public interface IPuzzle<TParsedInput> : IPuzzle
    {
        new TParsedInput ParseInput(string input);
        long Part1(TParsedInput input);
        long Part2(TParsedInput input);

        object IPuzzle.ParseInput(string input) => ParseInput(input);
        long IPuzzle.Part1(object input) => Part1((TParsedInput)input);
        long IPuzzle.Part2(object input) => Part2((TParsedInput)input);
    }

    public interface IPuzzle
    {
        object ParseInput(string input);
        long Part1(object input);

        long Part2(object input);
    }
}