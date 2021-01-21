using System;
using System.Collections.Generic;

namespace ConsoleProject.Days
{
    public class Day3 : DayRunnerWithProfiling
    {
        protected override void Task1(List<string> lines)
        {
            var horizontalIndex = 3;
            var treesEncountered = 0;
            for (var index = 1; index < lines.Count; index++)
            {
                var line = lines[index];
                if (line[horizontalIndex % line.Length] == '#')
                {
                    treesEncountered++;
                }

                horizontalIndex += 3;
            }

            Console.WriteLine(treesEncountered);
        }

        protected override void Task2(List<string> lines)
        {
            var treesEncountered1 = GetTreesEncountered(lines, 1,1);
            var treesEncountered2 = GetTreesEncountered(lines, 3, 1);
            var treesEncountered3 = GetTreesEncountered(lines, 5, 1);
            var treesEncountered4 = GetTreesEncountered(lines, 7 ,1);
            var treesEncountered5 = GetTreesEncountered(lines, 1, 2);

            var encountered1 = (long)treesEncountered1 * treesEncountered2 * treesEncountered3 * treesEncountered4 * treesEncountered5;
            Console.WriteLine(encountered1);
        }

        private static int GetTreesEncountered(List<string> lines, int patternRight, int patterDown)
        {
            var horizontalIndex = patternRight;
            var treesEncountered = 0;
            for (var index = patterDown; index < lines.Count; index += patterDown)
            {
                var line = lines[index];
                if (line[horizontalIndex % line.Length] == '#')
                {
                    treesEncountered++;
                }

                horizontalIndex += patternRight;
            }

            return treesEncountered;
        }

        public Day3() : base(nameof(Day3))
        {
        }
    }
}