using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.Settings
{
    public class BallColorSettingsUI
    {
        private readonly Image _currentBallImage;

        public BallColorSettingsUI(Image image)
        {
            if (image == null) throw new ArgumentException("Image for ball color is null");
            _currentBallImage = image;
        }

        public void UpdateCurrent(Color color)
        {
            _currentBallImage.color = color;
        }
    }
}