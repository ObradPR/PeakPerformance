namespace PeakPerformance.Common.Extensions;

public static partial class Extensions
{
    public static bool In<T>(this T item, IEnumerable<T> source)
        => source.Contains(item);

    public static bool IsEmpty<T>(this IEnumerable<T> source)
        => !source.Any();

    public static bool HasDuplicates<T>(this IEnumerable<T> source)
    {
        var set = new HashSet<T>();

        foreach (var item in source)
            if (!set.Add(item))
                return true;

        return false;
    }

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
            action(item);
    }

    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        var seenKeys = new HashSet<TKey>();

        foreach (var item in source)
            if (seenKeys.Add(keySelector(item)))
                yield return item;
    }

    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
    {
        while (source.Any())
        {
            yield return source.Take(chunkSize);
            source = source.Skip(chunkSize);
        }
    }

    public static Dictionary<TKey, T> ToDictionary<TKey, T>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        => source.ToDictionary(keySelector, v => v);

    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        => new HashSet<T>(source);

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        var rnd = new Random();
        var list = source.ToList();
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return list;
    }

    public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
    {
        var batch = new List<T>(batchSize);

        foreach (var item in source)
        {
            batch.Add(item);

            if (batch.Count == batchSize)
            {
                yield return batch;
                batch = new List<T>(batchSize);
            }
        }

        if (batch.Any())
            yield return batch;
    }
}