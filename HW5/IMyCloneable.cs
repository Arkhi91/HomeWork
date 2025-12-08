namespace HW5
{
    public interface IMyCloneable<T> where T : class
    {
        T Clone();
    }
}