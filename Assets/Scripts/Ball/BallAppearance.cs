using System;
using PingPongTask.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.Ball
{
    public class BallAppearance : IRequireRandom
    {
        private Image _image;
        public IRandomService RandomService { get; set; }

        public BallAppearance(Image image, IRandomService randomService)
        {
            _image = image;
            RandomService = randomService;
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }

        public void SetDifferentColor()
        {
            var oldColor = _image.color;
            var newColor = GetRandomColor();
            while ((Camera.main != null && newColor == Camera.main.backgroundColor) || newColor == oldColor)
            {
                newColor = GetRandomColor();
            }

            SetColor(newColor);
        }

        private Color GetRandomColor()
        {
            var newColorStr = RandomService.Color();
            if (ColorUtility.TryParseHtmlString(newColorStr, out var newColor))
            {
                return newColor;
            } else
            {
                throw new Exception("Invalid color string");
            }
        }
    }
}