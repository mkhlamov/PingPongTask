using System;
using System.Collections;
using System.Collections.Generic;
using PingPongTask.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.ScoreCounter
{
    public class ScoreCounter : IRequireSettings
    {
        public int Score;
        public event Action<int> OnScoreUpdated;
        public ISettingsProvider SettingsProvider { get; set; }

        public void IncrementScore()
        {
            Score += 1;
            OnScoreUpdated?.Invoke(Score);
        }
    }
}