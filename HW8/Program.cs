using HW8;

namespace DelegatesAndEventsHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Поиск максимального элемента");

            List<Student> students = new List<Student>
            {
                new Student("Иван", 78.5f),
                new Student("Мария", 91.2f),
                new Student("Алексей", 84.7f),
                new Student("Елена", 95.4f)
            };

            Student maxStudent = students.GetMax(s => s.Score);
            Console.WriteLine($"Максимальный элемент: {maxStudent}");

            Console.WriteLine();
            Console.WriteLine("начало поиска файлов:");

            string path = @"C:\Otus\Howework";

            FileSearcher searcher = new FileSearcher();
            int foundCount = 0;

            searcher.FileFound += Searcher_FileFound;

            try
            {
                searcher.Search(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            void Searcher_FileFound(object? sender, FileArgs e)
            {
                foundCount++;
                Console.WriteLine($"Найден файл: {e.FileName}");

                if (foundCount >= 3)
                {
                    Console.WriteLine("Поиск остановлен обработчиком события");
                    e.Cancel = true;
                }
            }
        }
    }
}