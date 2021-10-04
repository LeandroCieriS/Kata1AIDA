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
                return transformedInput[0] + transformedInput[1];
            }
            
            return int.Parse(input);
        }


        private static int[] Transform(string input)
        {
            var splittedInput = input.Split(SEPARATOR);
            return new int[] { int.Parse(splittedInput[0]), int.Parse(splittedInput[1]) };
        }
    }
}

