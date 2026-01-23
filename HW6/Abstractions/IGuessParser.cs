namespace HW6.Abstractions
{
    public interface IGuessParser
    {
        bool TryParse(string? input, out int guess, out string errorMessage);
    }
}