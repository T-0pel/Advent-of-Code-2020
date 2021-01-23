﻿using System;
using System.Collections.Generic;
using System.IO;

namespace IOLibrary
{
    public class FileHelper
    {
        private const string FileName = "PuzzleInput.txt";

        public static IEnumerable<string> GetLines(string directory, string fileName = FileName)
        {
            var inputPath = Path.Combine(Environment.CurrentDirectory, $@"Data\{directory}\", fileName);

            var lines = File.ReadLines(inputPath);

            return lines;
        }

        public static string GetText(string directory, string fileName = FileName)
        {
            var inputPath = Path.Combine(Environment.CurrentDirectory, $@"Data\{directory}\", fileName);

            var lines = File.ReadAllText(inputPath);

            return lines;
        }
    }
}
