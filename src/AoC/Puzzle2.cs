using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AoC
{
    public class Puzzle2 : IPuzzle<int[]>
    {
        public int[] ParseInput(string input) => input
                                                 .Split(new[] { "," }, StringSplitOptions.None)
                                                 .Select(int.Parse)
                                                 .ToArray();

        public object Part1(int[] input)
        {
            input = new[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            var program = CompileIntCodeProgram(input);

            var result = program.Invoke();
            return result;
        }

        public object Part2(int[] input)
        {
            throw new System.NotImplementedException();
        }

        private Func<int> CompileIntCodeProgram(int[] input)
        {
            var arrayParameter = Expression.Parameter(typeof(int[]));
            var expressions = new List<Expression>
            {
                arrayParameter,
                Expression.Assign(arrayParameter, Expression.Constant(input))
            };

            for (var index = 0; index < input.Length; index += 4)
            {
                var opCode = input[index];
                Expression ex = opCode switch
                {
                    1 => Expression.Assign(
                        Expression.ArrayAccess(arrayParameter,
                            Expression.ArrayAccess(arrayParameter, Expression.Constant(index + 3))), Expression.Add(
                            Expression.ArrayAccess(arrayParameter, Expression.ArrayAccess(arrayParameter, Expression.Constant(index + 1))),
                            Expression.ArrayAccess(arrayParameter, Expression.ArrayAccess(arrayParameter, Expression.Constant(index + 2))))),
                    2 => Expression.Assign(
                        Expression.ArrayAccess(arrayParameter,
                            Expression.ArrayAccess(arrayParameter, Expression.Constant(index + 3))), Expression.Multiply(
                            Expression.ArrayAccess(arrayParameter, Expression.ArrayAccess(arrayParameter, Expression.Constant(index + 1))),
                            Expression.ArrayAccess(arrayParameter, Expression.ArrayAccess(arrayParameter, Expression.Constant(index + 2))))),
                    99 => Expression.ArrayAccess(arrayParameter, Expression.Constant(0)),
                };

                expressions.Add(ex);
            }

            return Expression.Lambda<Func<int>>(Expression.Block(new[] { arrayParameter }, expressions)).Compile();
        }
    }
}
