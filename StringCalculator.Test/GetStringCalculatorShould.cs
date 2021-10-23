using NSubstitute;
using NUnit.Framework;
using StringCalculator.Application.Actions;
using StringCalculator.Application.Models;

namespace StringCalculator.Test
{
    public class GetStringCalculatorShould
    {
        private CustomLogger _customLogger;
        private GetStringCalculator stringCalculator;

        [SetUp]
        public void Setup()
        {
            _customLogger = Substitute.For<CustomLogger>();
            stringCalculator = new GetStringCalculator(_customLogger);
        }

        [TestCase("4,-1,-5,2", "negatives not allowed: -1,-5")]
        [TestCase("// \n1 2 5","8")]
        [TestCase("don't work", "Input string was not in a correct format.")]
        public void write_back_result(string input, string output)
        {

            stringCalculator.Execute(input);
            
            _customLogger.Received(1).Write(input + " = " + output);
        }

        [TestCase("4,-1,-5,2", "0")]
        [TestCase("//f\n5f4f2f-1", "10")]
        [TestCase("don't work", "Input string was not in a correct format.")]
        public void write_back_result_with_negatives(string input, string output)
        {

            stringCalculator.ExecuteV2(input);

            _customLogger.Received(1).Write(input + " = " + output);
        }
    }
}