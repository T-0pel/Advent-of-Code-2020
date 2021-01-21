using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject.Days
{
    public class Day3Linq : DayRunnerWithProfiling
    {
        private static int Solve(string[] input, int right, int down) =>
            input.Where((line, i) => i % down == 0 && line[right * (i / down) % line.Length] == '#').Count();

        protected override void Task1(List<string> lines)
        {
            Console.WriteLine(Solve(lines.ToArray(), 3, 1).ToString());
        }

        protected override void Task2(List<string> lines)
        {
            (int, int)[] cases =
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2)
            };

            Console.WriteLine(cases.Aggregate<(int right, int down), int>(1, (a, x) => a * Solve(lines.ToArray(), x.right, x.down)).ToString());
        }

        public Day3Linq() : base(nameof(Day3))
        {
        }
    }
}