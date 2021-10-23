using System;
using StringCalculator.Application.Models;

namespace StringCalculator.Application.Actions
{
    public class GetStringCalculator
    {
        private readonly CustomLogger logger;

        public GetStringCalculator(CustomLogger logger)
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
            catch (Exception e)
            {
                logger.Write(input + " = " + e.Message);
                return e.Message;
            }
        }
        public string ExecuteV2(string input)
        {
            try
            {
                var result = StringCalculator.AddWithNegatives(input).ToString();
                logger.Write(input + " = " + result);
                return result;
            }
            catch (Exception e)
            {
                logger.Write(input + " = " + e.Message);
                return e.Message;
            }
        }
    }
}