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
            var splittedInput = input.Split(SEPARATOR);
            var parsedInput = new List<int>();
            
            foreach (var number in splittedInput)
                parsedInput.Add(int.Parse(number));

            return parsedInput.ToArray();
        }
    }
}

