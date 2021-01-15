using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject.Days
{
    public class Day1 : DayRunnerWithProfiling
    {
        private readonly List<int> _inputAsIntegers;

        protected override void Task1(List<string> lines)
        {
            FindTotalOf2(_inputAsIntegers);
        }

        private static void FindTotalOf2(IReadOnlyList<int> inputIntegers)
        {
            for (var i = 0; i < inputIntegers.Count; i++)
            {
                for (var j = i + 1; j < inputIntegers.Count; j++)
                {
                    if (inputIntegers[i] + inputIntegers[j] != 2020) continue;
                    Console.WriteLine(inputIntegers[i] * inputIntegers[j]);
                    return;
                }
            }

            Console.WriteLine("No 2 numbers that add to 2020 found.");
        }

        protected override void Task2(List<string> lines)
        {
            FindTotalOf3(_inputAsIntegers);
        }

        private static void FindTotalOf3(IReadOnlyList<int> inputIntegers)
        {
            for (var i = 0; i < inputIntegers.Count; i++)
            {
                for (var j = i + 1; j < inputIntegers.Count; j++)
                {
                    for (var k = j + 1; k < inputIntegers.Count; k++)
                    {
                        if (inputIntegers[i] + inputIntegers[j] + inputIntegers[k] != 2020) continue;
                        Console.WriteLine(inputIntegers[i] * inputIntegers[j] * inputIntegers[k]);
                        return;
                    }
                }
            }

            Console.WriteLine("No 3 numbers that add to 2020 found.");
        }

        public Day1() : base(nameof(Day1))
        {
            _inputAsIntegers = Lines.Select(int.Parse).ToList();
        }
    }
}