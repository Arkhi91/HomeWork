using HW6.Abstractions;

namespace HW6.Application
{
    public sealed class DefaultGuessParser : IGuessParser
    {
        public bool TryParse(string? input, out int guess, out string errorMessage)
        {
            guess = 0;
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "пустая строка";
                return false;
            }

            input = input.Trim();

            if (!int.TryParse(input, out guess))
            {
                errorMessage = "нужно целое число";
                return false;
            }

            return true;
        }
    }
}