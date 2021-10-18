using System;
using StringCalculator.Application.Models;

namespace StringCalculator.Application.Actions
{
    public class GetStringCalculator
    {
        private readonly IPrinterReader printerReader;
        private readonly ILogger logger;

        public GetStringCalculator(IPrinterReader printerReader, ILogger logger)
        {
            this.printerReader = printerReader;
            this.logger = logger;
        }

        public void Execute(string input)
        {
            try
            {
                var result = StringCalculator.Add(input).ToString();
                printerReader.Write(result);
                logger.Write(input + " = " + result);
            }
            catch (Exception e)
            {
                printerReader.Write(e.Message);
                logger.Write(input + " = " + e.Message);
            }
        }
    }
}