using ConsoleProject.Days;
using System;

namespace ConsoleProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Initializing Console...");

            RunDay2();
            RunDay2WithRecordType();
            //RunDay1();
            //RunDay1Alternate();

            Console.ReadKey();
        }

        private static void RunDay2WithRecordType()
        {
            var day2WithRecordType = new Day2WithRecordType();
            day2WithRecordType.RunTask1();
            day2WithRecordType.RunTask2();
        }

        private static void RunDay2()
        {
            var day2 = new Day2();
            day2.RunTask1();
            day2.RunTask2();
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
