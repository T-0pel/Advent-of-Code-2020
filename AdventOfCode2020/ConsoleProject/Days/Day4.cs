using System;
using System.Collections.Generic;

namespace ConsoleProject.Days
{
    public class Day4 : DayRunnerWithProfiling
    {
        private readonly HashSet<char> _allowedHairColors = new HashSet<char>
            {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};

        private readonly HashSet<string> _allowedEyeColors = new HashSet<string>
            {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

        protected override void Task1(List<string> lines)
        {
            var passportFields = new HashSet<string>();
            var validPassports = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    validPassports = CheckPassport(passportFields, validPassports);
                    continue;
                }

                foreach (var split in line.Split(' '))
                {
                    passportFields.Add(split.Split(':')[0]);
                }
            }

            validPassports = CheckPassport(passportFields, validPassports);

            Console.WriteLine(validPassports);
        }

        private static int CheckPassport(HashSet<string> passportFields, int validPassports)
        {
            if (passportFields.Count == 8 || passportFields.Count == 7 && !passportFields.Contains("cid"))
            {
                validPassports++;
            }

            passportFields.Clear();
            return validPassports;
        }

        protected override void Task2(List<string> lines)
        {
            var passportFields = new Dictionary<string, string>();
            var validPassports = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    validPassports = ValidatePassport(passportFields, validPassports);
                    continue;
                }

                foreach (var split in line.Split(' '))
                {
                    var colonSplit = split.Split(':');
                    passportFields.Add(colonSplit[0], colonSplit[1]);
                }
            }

            validPassports = ValidatePassport(passportFields, validPassports);

            Console.WriteLine(validPassports);
        }

        private int ValidatePassport(Dictionary<string, string> passportFields, int validPassports)
        {
            var isValid = true;
            if (passportFields.Count == 8 || passportFields.Count == 7 && !passportFields.ContainsKey("cid"))
            {
                foreach (var passportField in passportFields)
                {
                    switch (passportField.Key)
                    {
                        case "byr":
                            if (passportField.Value.Length != 4 || !int.TryParse(passportField.Value, out var year) ||
                                year < 1920 || year > 2002)
                            {
                                isValid = false;
                            }
                            break;
                        case "iyr":
                            if (passportField.Value.Length != 4 || !int.TryParse(passportField.Value, out var issueYear) ||
                                issueYear < 2010 || issueYear > 2020)
                            {
                                isValid = false;
                            }
                            break;
                        case "eyr":
                            if (passportField.Value.Length != 4 || !int.TryParse(passportField.Value, out var expYear) ||
                                expYear < 2020 || expYear > 2030)
                            {
                                isValid = false;
                            }
                            break;
                        case "hgt":
                            if (passportField.Value.Contains("cm"))
                            {
                                if (!int.TryParse(passportField.Value.Replace("cm", ""), out var centimeters) ||
                                    centimeters < 150 || centimeters > 193)
                                {
                                    isValid = false;
                                }
                            }
                            else if (passportField.Value.Contains("in"))
                            {
                                if (!int.TryParse(passportField.Value.Replace("in", ""), out var inches) ||
                                    inches < 59 || inches > 76)
                                {
                                    isValid = false;
                                }
                            }
                            else
                            {
                                isValid = false;
                            }
                            break;
                        case "hcl":
                            if (passportField.Value.Length == 7 && passportField.Value[0] == '#')
                            {
                                foreach (var character in passportField.Value.Substring(1))
                                {
                                    if (!_allowedHairColors.Contains(character))
                                    {
                                        isValid = false;
                                    }

                                    if (isValid) break;
                                }
                            }
                            else
                            {
                                isValid = false;
                            }
                            break;
                        case "ecl":
                            if (!_allowedEyeColors.Contains(passportField.Value))
                            {
                                isValid = false;
                            }
                            break;
                        case "pid":
                            if (passportField.Value.Length != 9 || !int.TryParse(passportField.Value, out var _))
                            {
                                isValid = false;
                            }

                            break;

                    }

                    if (!isValid) break;
                }
            }
            else
            {
                isValid = false;
            }

            passportFields.Clear();
            if (isValid) validPassports++;
            return validPassports;
        }

        public Day4() : base(nameof(Day4))
        {
        }
    }
}