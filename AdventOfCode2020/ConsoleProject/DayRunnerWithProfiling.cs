using IOLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleProject
{
    public class DayRunnerWithProfiling
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();
        protected readonly List<string> Lines;

        public DayRunnerWithProfiling(string inputName)
        {
            Lines = FileHelper.GetLines(inputName).ToList();
        }

        public void RunTask1()
        {
            var totalMemory = GC.GetTotalMemory(true);
            //Console.WriteLine($"Total memory used before Task 1: {totalMemory} bytes.");
            _stopwatch.Start();
            Task1(Lines);
            _stopwatch.Stop();
            Console.WriteLine($"Total memory used difference after Task 1: {GC.GetTotalMemory(false) - totalMemory} bytes.");
            Console.WriteLine($"Task 1 done in {_stopwatch.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine();
        }

        public void RunTask2()
        {
            var totalMemory = GC.GetTotalMemory(true);
            //Console.WriteLine($"Total memory used before Task 2: {GC.GetTotalMemory(false)} bytes.");
            _stopwatch.Start();
            Task2(Lines);
            _stopwatch.Stop();
            Console.WriteLine($"Total memory used difference after Task 2: {GC.GetTotalMemory(false) - totalMemory} bytes.");
            Console.WriteLine($"Task 2 done in {_stopwatch.Elapsed.TotalSeconds} seconds.");
            Console.WriteLine();
        }

        protected virtual void Task1(List<string> lines) { }

        protected virtual void Task2(List<string> lines) { }
    }
}