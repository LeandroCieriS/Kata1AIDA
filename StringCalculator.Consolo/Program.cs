using StringCalculator.Application.Actions;
using StringCalculator.Infrastructure;

namespace StringCalculator.Console
{
    public class Program
    {
        private static CSharpConsole printerReader;

        public static void Main(string[] args)
        {
            const string path = "./log.txt";
            printerReader = new CSharpConsole();
            var stringCalculator = new GetStringCalculator(printerReader, new TextFileLogger(path));

            PrintInstructions();

            var input = printerReader.Read();

            stringCalculator.Execute(Parse(input));
        }
        private static void PrintInstructions()
        {
            printerReader.Write("Introduzca los numeros a sumar separados por comas");
            printerReader.Write("o seleccione un nuevo separador [//*separador*\\n...]");
        }

        private static string Parse(string input)
        {
            return input.Replace("\\n", "\n");
        }
    }
}
