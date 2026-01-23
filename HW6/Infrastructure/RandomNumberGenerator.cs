using HW6.Abstractions;

namespace HW6.Infrastructure
{
    public sealed class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random = new();

        public int Next(int minInclusive, int maxInclusive)
        {
            if (minInclusive > maxInclusive)
                throw new ArgumentException("minInclusive не может быть больше maxInclusive.");

            return _random.Next(minInclusive, maxInclusive + 1);
        }
    }
}