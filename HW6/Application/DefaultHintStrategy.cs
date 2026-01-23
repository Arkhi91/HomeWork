using HW6.Abstractions;
using HW6.Domain;

namespace HW6.Application
{
    public sealed class DefaultHintStrategy : IHintStrategy
    {
        public string GetHint(GuessResult result, int guess, int attemptsLeft)
        {
            return result switch
            {
                GuessResult.TooSmall => $"Моё число БОЛЬШЕ, чем {guess}.",
                GuessResult.TooLarge => $"Моё число МЕНЬШЕ, чем {guess}.",
                GuessResult.Correct => $"Да! Это {guess}. Попыток осталось: {attemptsLeft}.",
                _ => "Неизвестный результат."
            };
        }
    }
}