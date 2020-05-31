namespace PingPongTask.Interfaces
{
    public interface IRequireSettings
    {
        ISettingsProvider SettingsProvider { get; set; }
    }
}