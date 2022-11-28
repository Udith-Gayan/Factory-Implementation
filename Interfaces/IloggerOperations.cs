namespace Factory_Implementation.Interfaces
{
    public interface ILoggerOperations
    {
        public Task LogAsync(string message);
        public Task Clear();
    }
}
