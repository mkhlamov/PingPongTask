namespace PingPongTask.Interfaces
{
    public interface ISettingsProvider
    {
        void Save();
        int GetBestScore();
        void SetBestScore(int score);
    }
}