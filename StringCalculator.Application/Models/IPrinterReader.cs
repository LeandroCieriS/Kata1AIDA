namespace StringCalculator.Application.Models
{
    public interface IPrinterReader
    {
        void Write(string line);
        string Read();
    }
}