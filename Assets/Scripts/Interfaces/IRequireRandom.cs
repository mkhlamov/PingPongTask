namespace PingPongTask.Interfaces
{
    public interface IRequireRandom
    {
        IRandomService RandomService { get; set; }
    }
}