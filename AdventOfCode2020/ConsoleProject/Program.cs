using ConsoleProject.Days;
using System;

namespace ConsoleProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Initializing Console...");
            RunDay1();
            RunDay1Alternate();
            
            Console.ReadKey();
        }

        private static void RunDay1Alternate()
        {
            var day1Alternate = new Day1Alternate();
            day1Alternate.RunTask1();
            day1Alternate.RunTask2();
        }

        private static void RunDay1()
        {
            var day1 = new Day1();
            day1.RunTask1();
            day1.RunTask2();
        }
    }
}
