namespace HW6.Abstractions
{
    public interface IRandomNumberGenerator
    {
        int Next(int minInclusive, int maxInclusive);
    }
}