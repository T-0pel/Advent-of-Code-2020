using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using IOLibrary;

namespace ConsoleProject.Days
{
    public class Day4Alternate : DayRunnerWithProfiling
    {
        protected override void Task1(List<string> lines)
        {
            var passports = FileHelper.GetText(nameof(Day4))
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(inputLine => new Passport(inputLine));
            var answerPart1 = passports.Count(passport => passport.RequiredFieldsPresent);
            
            Console.WriteLine(answerPart1);
        }

        protected override void Task2(List<string> lines)
        {
            var passports = FileHelper.GetText(nameof(Day4))
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(inputLine => new Passport(inputLine));
            var answerPart2 = passports.Count(passport => passport.RequiredFieldsPresent && passport.AllFieldsValid);

            Console.WriteLine(answerPart2);
        }

        public Day4Alternate() : base(nameof(Day4))
        {
        }
    }

    public record Passport(IEnumerable<Field> Fields)
    {
        private static readonly string[] RequiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

        public static readonly Dictionary<string, Func<string, bool>> FieldValidationRules = new()
        {
            ["byr"] = value => IsYearValid(value, 1920, 2002),
            ["iyr"] = value => IsYearValid(value, 2010, 2020),
            ["eyr"] = value => IsYearValid(value, 2020, 2030),
            ["hgt"] = value =>
            {
                var match = Regex.Match(value, @"^(?<year>\d+)(?<unit>cm|in)$");
                return match.Success && (int.Parse(match.Groups["year"].Value), match.Groups["unit"].Value) switch
                {
                    ( >= 150 and <= 193, "cm") => true,
                    ( >= 59 and <= 76, "in") => true,
                    _ => false
                };
            },
            ["hcl"] = value => Regex.IsMatch(value, @"^#(\d|[a-f]){6}$"),
            ["ecl"] = value => new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value),
            ["pid"] = value => Regex.IsMatch(value, @"^(\d){9}$"),
            ["cid"] = _ => true,
        };

        public Passport(string input) : this(input
            .Replace(Environment.NewLine, " ")
            .Split(" ")
            .Select(p => new Field(p.Split(':'))))
        { }

        private static bool IsYearValid(string value, int atLeast, int atMost) => int.TryParse(value, out var year) && year >= atLeast && year <= atMost;

        public bool RequiredFieldsPresent => RequiredFields.All(rf => Fields.Any(f => f.Name == rf));
        public bool AllFieldsValid => Fields.All(f => FieldValidationRules[f.Name](f.Value));
    }

    public record Field(string Name, string Value)
    {
        public Field(string[] keyValue) : this(keyValue[0], keyValue[1]) { }
    }
}