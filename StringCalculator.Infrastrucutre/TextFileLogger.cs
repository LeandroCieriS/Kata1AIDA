using System;
using System.IO;
using StringCalculator.Application.Models;

namespace StringCalculator.Infrastructure
{
    public class TextFileLogger : ILogger
    {
        private readonly string path;
        public TextFileLogger(string path)
        {
            this.path = path;
        }
        public void Write(string entry)
        {
            File.AppendAllText(path, FormatText(entry));
        }

        private static string FormatText(string entry)
        {
            return DateTime.UtcNow.ToString("yyyy-MMM-dd HH:mm") + "  -  " + entry + "\n";
        }
    }
}