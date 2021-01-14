using System;
using System.Linq;
using IOLibrary;

namespace Day1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Part1();
            Part2();

            static void Part2()
            {
                var lines = FileHelper.GetLines("Day1");

                var inputIntegers = lines.Select(int.Parse).ToList();
                var numbersFound = false;

                for (var i = 0; i < inputIntegers.Count; i++)
                {
                    for (var j = i + 1; j < inputIntegers.Count; j++)
                    {
                        for (var k = j + 1; k < inputIntegers.Count; k++)
                        {
                            if (inputIntegers[i] + inputIntegers[j] + inputIntegers[k] == 2020)
                            {
                                Console.WriteLine(inputIntegers[i] * inputIntegers[j] * inputIntegers[k]);
                                numbersFound = true;
                            }

                            if (numbersFound) break;
                        }

                        if (numbersFound) break;
                    }

                    if (numbersFound) break;
                }

                if (!numbersFound) Console.WriteLine("No 3 numbers that add to 2020 found.");
            }

            static void Part1()
            {
                var lines = FileHelper.GetLines("Day1");

                var inputIntegers = lines.Select(int.Parse).ToList();
                var numbersFound = false;

                for (var i = 0; i < inputIntegers.Count; i++)
                {
                    for (var j = i + 1; j < inputIntegers.Count; j++)
                    {
                        if (inputIntegers[i] + inputIntegers[j] == 2020)
                        {
                            Console.WriteLine(inputIntegers[i] * inputIntegers[j]);
                            numbersFound = true;
                        }

                        if (numbersFound) break;
                    }

                    if (numbersFound) break;
                }

                if (!numbersFound) Console.WriteLine("No 2 numbers that add to 2020 found.");
            }
        }
    }
}
