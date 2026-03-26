using DelegatesAndEventsHomework;

namespace HW8
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs>? FileFound;

        public void Search(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentException("Путь к каталогу не задан.", nameof(directoryPath));

            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException($"Каталог не найден: {directoryPath}");

            SearchInternal(directoryPath);
        }

        private bool SearchInternal(string directoryPath)
        {
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                FileArgs args = new FileArgs(file);
                OnFileFound(args);

                if (args.Cancel)
                    return true;
            }

            foreach (string directory in Directory.GetDirectories(directoryPath))
            {
                bool shouldStop = SearchInternal(directory);

                if (shouldStop)
                    return true;
            }

            return false;
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
    }
}