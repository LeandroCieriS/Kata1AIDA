using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator 
    {
        private const string SEPARATOR_COMMA = ",";
        private const string SEPARATOR_NEW_LINE = "\n";

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return 0;
            if (!input.Contains(SEPARATOR_COMMA) && !input.Contains(SEPARATOR_NEW_LINE)) 
                return int.Parse(input);
            return Transform(input).Sum();

        }

        private static IEnumerable<int> Transform(string input)
        {
            input = input.Replace(SEPARATOR_NEW_LINE, SEPARATOR_COMMA);
            return input.Split(SEPARATOR_COMMA).Select(int.Parse);
        }
    }
}

