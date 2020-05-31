using System;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Settings
{
    public class BallColorUpdater
    {
        public event Action<Color> OnBallColorChanged;
        
        private readonly ISettingsProvider _settingsProvider;
        
        public BallColorUpdater(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public void UpdateBallColor(Color color)
        {
            var colorStr = ColorUtility.ToHtmlStringRGBA(color);
            _settingsProvider.SetBallColor(colorStr);
            _settingsProvider.Save();
            OnBallColorChanged?.Invoke(color);
        }
    }
}