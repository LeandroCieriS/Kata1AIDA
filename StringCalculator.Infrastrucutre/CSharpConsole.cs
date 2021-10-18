using System;
using StringCalculator.Application.Models;

namespace StringCalculator.Infrastructure
{
    public class CSharpConsole : IPrinterReader
    {
        public void Write(string line)
        {
            System.Console.WriteLine(line);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}