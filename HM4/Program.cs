using System.Diagnostics;

class Program
{
    static void Main()
    {
        PrintEnvironmentInfo();

        int[] sizes = { 100000, 1000000, 10000000 };
        var table = new System.Text.StringBuilder();

        table.AppendLine("│ Размер массива │ Последовательное │ Паралл. (Task) │ PLINQ │");

        foreach (int size in sizes)
        {
            Console.WriteLine($"\nТестирование: {size:N0} элементов");
            int[] array = GenerateArray(size);

            long seq = Measure(SequentialSum, array, "Последовательное");
            long par = Measure(ParallelTaskSum, array, "Параллельное (Task)");
            long plinq = Measure(PlinqSum, array, "PLINQ (AsParallel)");

            table.AppendLine($"│ {size,14:N0} │ {seq,13} мс │ {par,11} мс │ {plinq,2} мс │");
        }

        PrintTable(table.ToString());

        Console.WriteLine("\nНажмите любую клавишу для выхода");
        Console.ReadKey();
    }

    static void PrintEnvironmentInfo()
    {
        Console.WriteLine("ОКРУЖЕНИЕ:");
        Console.WriteLine($"{"ОС:",-25} {Environment.OSVersion}");
        Console.WriteLine($"{"Процессор:",-25} x64 (Windows) | Ядер: {Environment.ProcessorCount}");
        Console.WriteLine($"{"Логических процессоров:",-25} {Environment.ProcessorCount}");
        Console.WriteLine($"{"Версия .NET:",-25} {Environment.Version}");
        Console.WriteLine($"{"64-битный процесс:",-25} {Environment.Is64BitProcess}");
        Console.WriteLine($"{"Время запуска:",-25} {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
        Console.WriteLine();
    }

    static int[] GenerateArray(int size)
    {
        var rnd = new Random(42);
        var arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = rnd.Next(1, 101);
        return arr;
    }

    static long SequentialSum(int[] arr) => arr.Sum(x => (long)x);
    static long PlinqSum(int[] arr) => arr.AsParallel().Sum(x => (long)x);

    static long ParallelTaskSum(int[] arr)
    {
        int cores = Environment.ProcessorCount;
        int chunk = Math.Max(1, arr.Length / cores);
        long total = 0;

        var tasks = new Task<long>[cores];
        for (int i = 0; i < cores; i++)
        {
            int start = i * chunk;
            int end = (i == cores - 1) ? arr.Length : start + chunk;
            tasks[i] = Task.Run(() =>
            {
                long sum = 0;
                for (int j = start; j < end; j++)
                    sum += arr[j];
                return sum;
            });
        }

        foreach (var t in tasks)
            total += t.Result;
        return total;
    }

    static long Measure(Func<int[], long> action, int[] arr, string name)
    {
        var sw = Stopwatch.StartNew();
        long result = action(arr);
        sw.Stop();
        Console.WriteLine($"  {name}: {sw.ElapsedMilliseconds} мс");
        return sw.ElapsedMilliseconds;
    }

    static void PrintTable(string table)
    {
        Console.WriteLine("\nРЕЗУЛЬТАТЫ ЗАМЕРОВ:");
        Console.WriteLine(table);
        Console.ResetColor();
    }
}