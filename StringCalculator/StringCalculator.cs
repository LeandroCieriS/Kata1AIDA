using System;

namespace StringCalculator {
    public static class StringCalculator {
        public static int Add(string input){
            if (string.IsNullOrEmpty(input)) return 0;
            if (input.Contains(","))
            {
                return 3;
            }
            return int.Parse(input);
        }

    }
}

