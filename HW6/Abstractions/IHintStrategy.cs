using HW6.Domain;

namespace HW6.Abstractions
{
    public interface IHintStrategy
    {
        string GetHint(GuessResult result, int guess, int attemptsLeft);
    }
}