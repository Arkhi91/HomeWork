using HW6.Abstractions;

namespace HW6.Infrastructure
{
    public sealed class ConsoleInputReader : IInputReader
    {
        public string? ReadLine() => Console.ReadLine();
    }
}