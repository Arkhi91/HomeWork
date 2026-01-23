using HW6.Abstractions;
using HW6.Domain;

namespace HW6.Application
{
    public sealed class GuessNumberGame
    {
        private readonly ISettingsProvider _settingsProvider;
        private readonly IRandomNumberGenerator _rng;
        private readonly IInputReader _input;
        private readonly IOutputWriter _output;
        private readonly IHintStrategy _hintStrategy;
        private readonly IGuessParser _guessParser;

        public GuessNumberGame(
            ISettingsProvider settingsProvider,
            IRandomNumberGenerator rng,
            IInputReader input,
            IOutputWriter output,
            IHintStrategy hintStrategy,
            IGuessParser guessParser)
        {
            _settingsProvider = settingsProvider;
            _rng = rng;
            _input = input;
            _output = output;
            _hintStrategy = hintStrategy;
            _guessParser = guessParser;
        }

        public void Run()
        {
            var settings = _settingsProvider.GetSettings();
            settings.Validate();

            var target = _rng.Next(settings.MinNumber, settings.MaxNumber);

            _output.WriteLine("Игра «Угадай число»!");
            _output.WriteLine($"Я загадал число в диапазоне [{settings.MinNumber}; {settings.MaxNumber}].");
            _output.WriteLine($"У тебя {settings.MaxAttempts} попыток.");

            var attemptsLeft = settings.MaxAttempts;

            while (attemptsLeft > 0)
            {
                _output.WriteLine("");
                _output.WriteLine($"Попыток осталось: {attemptsLeft}. Введи число:");

                var input = _input.ReadLine();

                if (!_guessParser.TryParse(input, out var guess, out var error))
                {
                    _output.WriteLine($"Ошибка ввода: {error}");
                    continue;
                }

                if (guess < settings.MinNumber || guess > settings.MaxNumber)
                {
                    _output.WriteLine($"Число должно быть в диапазоне [{settings.MinNumber}; {settings.MaxNumber}].");
                    continue;
                }

                attemptsLeft--;

                var result = Evaluate(guess, target);
                _output.WriteLine(_hintStrategy.GetHint(result, guess, attemptsLeft));

                if (result == GuessResult.Correct)
                {
                    _output.WriteLine("Победа! Ура!");
                    return;
                }
            }

            _output.WriteLine("");
            _output.WriteLine($"Попытки закончились. Я загадывал число: {target}.");
        }

        private static GuessResult Evaluate(int guess, int target)
        {
            if (guess < target) 
                return GuessResult.TooSmall;
            if (guess > target) 
                return GuessResult.TooLarge;
            return GuessResult.Correct;
        }
    }
}