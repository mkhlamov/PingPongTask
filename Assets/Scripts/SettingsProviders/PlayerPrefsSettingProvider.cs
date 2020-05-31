using System.Collections;
using System.Collections.Generic;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.SettingsProviders
{
    public class PlayerPrefsSettingProvider : ISettingsProvider
    {
        private const string BEST_SCORE_KEY = "best_score";
        
        public int GetBestScore()
        {
            return PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);
        }

        public void SetBestScore(int score)
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, score);
        }

        public void Save()
        {
            PlayerPrefs.Save();
        }
    }
}