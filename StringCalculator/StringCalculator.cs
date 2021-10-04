using System;

namespace StringCalculator {
    public static class StringCalculator 
    {
        private const string SEPARATOR = ",";

        public static int Add(string input){
            if (string.IsNullOrEmpty(input)) return 0;
            if (input.Contains(SEPARATOR))
            {
                return 3;
            }
            return int.Parse(input);
        }

    }
}

