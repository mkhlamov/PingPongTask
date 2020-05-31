using System.Collections;
using System.Collections.Generic;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.SettingsProviders
{
    public class PlayerPrefsSettingProvider : ISettingsProvider
    {
        private const string BEST_SCORE_KEY = "best_score";
        private const string BALL_COLOR_KEY = "ball_color";
        
        public int GetBestScore()
        {
            return PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);
        }

        public void SetBestScore(int score)
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, score);
        }

        public string GetBallColor()
        {
            return PlayerPrefs.GetString(BALL_COLOR_KEY, "#FFFFFF");
        }

        public void SetBallColor(string color)
        {
            var prefix = color.StartsWith("#") ? "" : "#";
            color = prefix + color;
            PlayerPrefs.SetString(BALL_COLOR_KEY, color);
        }

        public void Save()
        {
            PlayerPrefs.Save();
        }
    }
}