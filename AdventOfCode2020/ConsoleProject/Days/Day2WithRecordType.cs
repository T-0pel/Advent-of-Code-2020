using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject.Days
{
    public class Day2WithRecordType : DayRunnerWithProfiling
    {
        protected override void Task1(List<string> lines)
        {
            IEnumerable<Line> GetLines() =>
                lines
                    .Select(x => x.Split(' ', '-'))
                    .Select(x => new Line(int.Parse(x[0]), int.Parse(x[1]), x[2][0], x[3]));

            bool ValidPassword(Line line) =>
                line.Password.Count(x => x == line.Letter) >= line.Min &&
                line.Password.Count(x => x == line.Letter) <= line.Max;

            Console.WriteLine(GetLines().Count(ValidPassword));
        }

        protected override void Task2(List<string> lines)
        {
            IEnumerable<Line> GetLines() =>
                lines
                    .Select(x => x.Split(' ', '-'))
                    .Select(x => new Line(int.Parse(x[0]), int.Parse(x[1]), x[2][0], x[3]));

            bool ValidPassword2(Line line) =>
                line.Password[line.Min - 1] == line.Letter ^
                line.Password[line.Max - 1] == line.Letter;

            Console.WriteLine(GetLines().Count(ValidPassword2));
        }

        public Day2WithRecordType() : base(nameof(Day2))
        {
        }
    }

    public record Line(int Min, int Max, char Letter, string Password);
}