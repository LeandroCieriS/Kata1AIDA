using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using StringCalculator.Infrastructure;

namespace StringCalculator.Test
{
    public class TextFileLoggerShould
    {
        private TextFileLogger logger;
        private const string path = "./testLog.txt";

        [SetUp]
        public void SetUp()
        {
            logger = new TextFileLogger(path);
        }
        
        [Test]
        public void write_a_given_line()
        {
            const string input = "Mock result";

            logger.Write(input);

            var result =  File.ReadAllText(path);
            result.Should().Be(DateTime.UtcNow.ToString("yyyy-MMM-dd HH:mm") +"  -  " + "Mock result\n");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}