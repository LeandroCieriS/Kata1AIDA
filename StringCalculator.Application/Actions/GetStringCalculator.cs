using System;
using StringCalculator.Application.Models;

namespace StringCalculator.Application.Actions
{
    public class GetStringCalculator
    {
        private readonly ILogger logger;

        public GetStringCalculator(ILogger logger)
        {
            this.logger = logger;
        }

        public string Execute(string input)
        {
            try
            {
                var result = StringCalculator.Add(input).ToString();
                logger.Write(input + " = " + result);
                return result;
            }
            catch (InvalidOperationException e)
            {
                logger.Write(input + " = " + e.Message);
                return e.Message;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}