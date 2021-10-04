using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public static class StringCalculator 
    {
        private const string SEPARATOR = ",";

        public static int Add(string input){
            if (string.IsNullOrEmpty(input)) 
                return 0;
            if (input.Contains(SEPARATOR))
            {
                var transformedInput = Transform(input);
                return transformedInput.Sum();
            }
            
            return int.Parse(input);
        }


        private static IEnumerable<int> Transform(string input)
        {
            return input.Split(SEPARATOR).Select(int.Parse);
        }
    }
}

