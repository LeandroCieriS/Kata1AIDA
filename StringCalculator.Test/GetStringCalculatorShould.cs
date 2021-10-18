using NSubstitute;
using NUnit.Framework;
using StringCalculator.Application.Actions;
using StringCalculator.Application.Models;

namespace StringCalculator.Test
{
    public class GetStringCalculatorShould
    {
        private IPrinterReader console;
        private ILogger logger;
        private GetStringCalculator stringCalculator;

        [SetUp]
        public void Setup()
        {
            console = Substitute.For<IPrinterReader>();
            logger = Substitute.For<ILogger>();
            stringCalculator = new GetStringCalculator(console, logger);
        }

        [TestCase("4,-1,-5,2", "negatives not allowed: -1,-5")]
        [TestCase("// \n1 2 5","8")]
        [TestCase("don't work", "Input string was not in a correct format.")]
        public void write_back_result(string input, string output)
        {

            stringCalculator.Execute(input);

            console.Received(1).Write(output);
            logger.Received(1).Write(input + " = " + output);
        }
    }
}