using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        await FirstStepAsync(); //задание 1
        await SecondStepAsync(); //задание 2
    }

    static private async Task FirstStepAsync()
    {
        try
        {
            Console.WriteLine("Задание 1: Чтение 3 файлов параллельно");
            var sw1 = Stopwatch.StartNew();
            var totalSpaces1 = await CountSpacesInThreeFilesAsync(
            "D:\\Учеба\\OTUS\\ДЗ 3\\file1.txt",
            "D:\\Учеба\\OTUS\\ДЗ 3\\file2.txt",
            "D:\\Учеба\\OTUS\\ДЗ 3\\file3.txt");
            sw1.Stop();

            Console.WriteLine($"Пробелов в 3 файлах: {totalSpaces1}");
            Console.WriteLine($"Время выполнения для 3 файлов (в мс): {sw1.ElapsedMilliseconds}");
            Console.ReadKey();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка чтения: {ex.Message}");
        }
    }

    static async Task SecondStepAsync()
    {
        Console.WriteLine("Задание 2. Чтения всей папки");
        Console.WriteLine("Введите путь до пупки полностью");
        string folderPath = Console.ReadLine().Trim('"'); //надо убрать экранирование потенциально
        if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
        {
            Console.WriteLine("Папка не существует! Проверьте путь");
            return;
        }
        var sw2 = Stopwatch.StartNew();
        var totalSpacesAll = await CountSpacesAllFilesAsync(folderPath);
        sw2.Stop();

        Console.WriteLine($"Всего пробелов во всех файлах: {totalSpacesAll}");
        Console.WriteLine($"Время выполнения (все файлы из папки): {sw2.ElapsedMilliseconds} мс");
        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }


    static async Task<int> CountSpacesInThreeFilesAsync(string file1, string file2, string file3)
    {
        var task1 = CountSpacesInFileAsync(file1);
        var task2 = CountSpacesInFileAsync(file2);
        var task3 = CountSpacesInFileAsync(file3);

        int[] results = await Task.WhenAll(task1, task2, task3);
        return results.Sum();
    }

    static async Task<int> CountSpacesInFileAsync(string file)
    {
        try
        {
            string content = await File.ReadAllTextAsync(file);
            var spaces = content.Count(x => x == ' ');
            Console.WriteLine($"Кол-во пробелов в файле по пути {file} - {spaces}");
            return spaces;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка чтения {file}: {ex.Message}");
            return 0;
        }
    }

    static async Task<int> CountSpacesAllFilesAsync(string folder)
    {
        string[] files = Directory.GetFiles(folder);
        if (files.Length == 0)
        {
            Console.WriteLine("В папке нет файлов!");
            return 0;
        }

        Console.WriteLine($"Найдено файлов: {files.Length}. Начинаем парал. чтение...");
        var tasks = files.Select(file => CountSpacesInFileAsync(file)).ToArray();
        var results = await Task.WhenAll(tasks);
        return results.Sum();
    }
}