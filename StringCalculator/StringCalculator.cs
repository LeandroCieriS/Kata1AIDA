using System;

namespace StringCalculator {
    public static class StringCalculator 
    {
        private const string SEPARATOR = ",";

        public static int Add(string input){
            if (string.IsNullOrEmpty(input)) return 0;
            if (input.Contains(SEPARATOR))
            {
                var splittedInput = input.Split(",");
                return int.Parse(splittedInput[0]) + int.Parse(splittedInput[1]);
            }
            return int.Parse(input);
        }

    }
}

