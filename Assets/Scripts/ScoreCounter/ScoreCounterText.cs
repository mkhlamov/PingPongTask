using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.ScoreCounter
{
    public class ScoreCounterText
    {
        private readonly Text _text;

        public ScoreCounterText(Text text, int initial=0)
        {
            if (text == null) throw new ArgumentException("Text is null!");
            _text = text;
            UpdateScore(initial);
        }

        public void UpdateScore(int score)
        {
            _text.text = score.ToString();
        }
    }
}