namespace HW8
{
    public static class EnumerableExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (convertToNumber == null)
                throw new ArgumentNullException(nameof(convertToNumber));

            using IEnumerator<T> enumerator = collection.GetEnumerator();

            if (!enumerator.MoveNext())
                throw new InvalidOperationException("Коллекция пуста");

            T maxItem = enumerator.Current;
            float maxValue = convertToNumber(maxItem);

            while (enumerator.MoveNext())
            {
                T currentItem = enumerator.Current;
                float currentValue = convertToNumber(currentItem);

                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                    maxItem = currentItem;
                }
            }

            return maxItem;
        }
    }
}