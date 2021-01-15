using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject.Days
{
    public class Day1Alternate : DayRunnerWithProfiling
    {
        protected override void Task1(List<string> lines)
        {
            var inputIntegers = lines.Select(int.Parse).ToList();

            var (x, y) = inputIntegers
                .SelectMany(x => inputIntegers, (x, y) => (x, y))
                .FirstOrDefault(t => t.x + t.y == 2020);

            Console.WriteLine(x * y);
        }

        protected override void Task2(List<string> lines)
        {
            var inputIntegers = lines.Select(int.Parse).ToList();

            var (x, y, z) = inputIntegers
                .SelectMany(x => inputIntegers, (x, y) => (x, y))
                .SelectMany(t => inputIntegers, (t, z) => (t.x, t.y, z))
                .FirstOrDefault(t => t.x + t.y + t.z == 2020);

            Console.WriteLine(x * y * z);
        }

        public Day1Alternate() : base(nameof(Day1))
        {
        }
    }
}