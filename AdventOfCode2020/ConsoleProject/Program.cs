using ConsoleProject.Days;
using System;

namespace ConsoleProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Initializing Console...");

            RunDay4();
            RunDay4Alternate();
            //RunDay3Linq();
            //RunDay3();
            //RunDay2();
            //RunDay2WithRecordType();
            //RunDay1();
            //RunDay1Alternate();

            Console.ReadKey();
        }

        private static void RunDay4Alternate()
        {
            var day4Alternate = new Day4Alternate();
            day4Alternate.RunTask1();
            day4Alternate.RunTask2();
        }

        private static void RunDay4()
        {
            var day4 = new Day4();
            day4.RunTask1();
            day4.RunTask2();
        }

        private static void RunDay3Linq()
        {
            var day3Linq = new Day3Linq();
            day3Linq.RunTask1();
            day3Linq.RunTask2();
        }

        private static void RunDay3()
        {
            var day3 = new Day3();
            day3.RunTask1();
            day3.RunTask2();
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
