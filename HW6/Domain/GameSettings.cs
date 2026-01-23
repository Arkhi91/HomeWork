namespace HW6.Domain
{
    public sealed class GameSettings
    {
        public int MinNumber { get; init; }
        public int MaxNumber { get; init; }
        public int MaxAttempts { get; init; }

        public void Validate()
        {
            if (MaxAttempts <= 0)
                throw new ArgumentOutOfRangeException(nameof(MaxAttempts), "MaxAttempts должен быть > 0.");

            if (MinNumber > MaxNumber)
                throw new ArgumentException("MinNumber не может быть больше MaxNumber.");
        }
    }
}