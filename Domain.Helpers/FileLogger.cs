using Factory_Implementation.Interfaces;

namespace Factory_Implementation.Domain.Helpers
{
    public class FileLogger : ILoggerOperations
    {
        private const string loggerFile = "logger.txt";
        private string docPath = Environment.CurrentDirectory;

        public async Task Clear()
        {
            using (FileStream fs = File.Open(Path.Join(docPath, loggerFile), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
                await fs.FlushAsync();
            }

        }

        public async Task LogAsync(string message)
        {
            message = DateTime.Now.ToLongDateString() + " - " + message.Trim();
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, loggerFile), append: true))
            {
                await outputFile.WriteLineAsync(message);
            }
        }
    }
}
