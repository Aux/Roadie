namespace Roadie.Gumroad
{
    public interface IGumroadCollection<T> : IReadOnlyCollection<T>
        where T : class
    {
        bool IsSuccess { get; }
        IReadOnlyCollection<T> Data { get; }
    }
}
