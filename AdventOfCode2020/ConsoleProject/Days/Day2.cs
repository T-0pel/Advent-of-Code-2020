using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject.Days
{
    public class Day2 : DayRunnerWithProfiling
    {
        protected override void Task1(List<string> lines)
        {
            var validPasswords = 0;

            foreach (var line in lines)
            {
                var split = line.Split(' ', '-');
                var min = int.Parse(split[0]);
                var max = int.Parse(split[1]);
                var letter = split[2][0];
                var password = split[3];

                var letterCount = password.Count(c => c == letter);

                if (letterCount >= min && letterCount <= max) validPasswords++;
            }

            Console.WriteLine(validPasswords);
        }

        protected override void Task2(List<string> lines)
        {
            var validPasswords = 0;

            foreach (var line in lines)
            {
                var split = line.Split(' ', '-');
                var position1 = int.Parse(split[0]);
                var position2 = int.Parse(split[1]);
                var letter = split[2][0];
                var password = split[3];

                var letterAtPosition1 = password[position1 - 1];
                var letterAtPosition2 = password[position2 - 1];

                if ((letterAtPosition1 == letter || letterAtPosition2 == letter) && letterAtPosition1 != letterAtPosition2) validPasswords++;
            }

            Console.WriteLine(validPasswords);
        }

        public Day2() : base(nameof(Day2))
        {
        }
    }
}