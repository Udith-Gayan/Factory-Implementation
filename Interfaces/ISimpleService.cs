namespace Factory_Implementation.Interfaces
{
    public interface ISimpleService
    {
        public Task WriteMessageAsync(string message = null);

        public Task ClearLogFiles();
    }
}
