﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator
    {
        private const char SEPARATOR_COMMA = ',';
        private const char SEPARATOR_NEW_LINE = '\n';
        private const string SEPARATOR_SELECTOR = "//";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            var numbers = Transform(input);
            CheckForNegatives(numbers);
            return numbers.Where(IsBetweenLimits).Sum();
        }

        public static int AddWithNegatives(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            return Transform(input).Where(IsBetweenLimits).Sum();
        }
        private static IEnumerable<int> Transform(string input)
        {
            if (input.Contains(SEPARATOR_SELECTOR))
            {
                input = ReplaceSeparator(input);
                input = input[4..];
            }
            input = input.Replace(SEPARATOR_NEW_LINE, SEPARATOR_COMMA);
            return input.Split(SEPARATOR_COMMA).Select(int.Parse);
        }

        private static string ReplaceSeparator(string input)
        {
            var newDelimiter = input[2];
            return input.Replace(newDelimiter, SEPARATOR_COMMA);
        }

        private static bool IsBetweenLimits(int number)
        {
            return number <= 1000 && number >= -1000;
        }

        private static void CheckForNegatives(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0);
            if (negativeNumbers.Any()) 
                throw new InvalidOperationException("negatives not allowed: " + string.Join(",", negativeNumbers));
        }
    }
}

