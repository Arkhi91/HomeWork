using HW6.Abstractions;

namespace HW6.Infrastructure
{
    public sealed class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}