namespace PingPongTask.Interfaces
{
    public interface ISettingsProvider
    {
        int GetBestScore();
        void SetBestScore(int score);
    }
}