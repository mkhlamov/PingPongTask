using System;
using PingPongTask.Interfaces;

namespace PingPongTask.ScoreCounter
{
    public class BestScoreUpdater
    {
        public event Action<int> OnBestScoreUpdated;
        
        private readonly ISettingsProvider _settingsProvider;
        private int _currentBestScore;
        private bool _wasUpdated = false;

        public BestScoreUpdater(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
            _currentBestScore = _settingsProvider.GetBestScore();
        }

        public void UpdateScore(int score)
        {
            if (score < 0) {return;}
            if (score <= _currentBestScore) {return;}

            _currentBestScore = score;
            _settingsProvider.SetBestScore(_currentBestScore);
            _wasUpdated = true;
            OnBestScoreUpdated?.Invoke(_currentBestScore);
        }

        public void SaveToDisk()
        {
            if (!_wasUpdated) return;
            _settingsProvider.Save();
            _wasUpdated = false;
        }
    }
}