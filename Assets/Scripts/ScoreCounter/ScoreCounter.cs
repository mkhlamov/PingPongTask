using System;
using System.Collections;
using System.Collections.Generic;
using PingPongTask.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.ScoreCounter
{
    public class ScoreCounter
    {
        public int Score;
        public event Action<int> OnScoreUpdated;

        public ScoreCounter(int initialValue=0)
        {
            Score = initialValue;
        }
        
        public void IncrementScore()
        {
            Score += 1;
            OnScoreUpdated?.Invoke(Score);
        }

        public void ResetScore()
        {
            Score = 0;
            OnScoreUpdated?.Invoke(Score);
        }
    }
}