using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator 
    {
        private const char SEPARATOR_COMMA = ',';
        private const char SEPARATOR_NEW_LINE = '\n';
        private const string DELIMITER_SELECTOR = "//";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return 0;
            var transformedInput = Transform(input);

            return FilterInput(transformedInput).Sum();
        }

        private static IEnumerable<int> Transform(string input)
        {
            if (input.Contains(DELIMITER_SELECTOR))
            {
                input = ReplaceDelimiter(input);
                input = input[4..];
            }

            input = input.Replace(SEPARATOR_NEW_LINE, SEPARATOR_COMMA);
            return input.Split(SEPARATOR_COMMA).Select(int.Parse);
        }

        private static List<int> FilterInput(IEnumerable<int> input)
        {
            CheckForNegatives(input);
            List<int> listInput = input.ToList();
            listInput.RemoveAll((i => i > 1000));
            return listInput;
        }

        private static void CheckForNegatives(IEnumerable<int> input)
        {
            var negativeNumbers = "";
            foreach (var number in input)
            {
                if (number < 0) negativeNumbers += number + ",";
            }

            if (negativeNumbers == "") return;
            negativeNumbers = FormatMessage(negativeNumbers);
            throw new InvalidOperationException("negatives not allowed: " + negativeNumbers);
        }

        private static string FormatMessage(string negativeNumbers)
        {
            return negativeNumbers[..^1];
        }

        private static string ReplaceDelimiter(string input)
        {
            var newDelimiter = input[2];
            return input.Replace(newDelimiter, SEPARATOR_COMMA);
        }
    }
}

