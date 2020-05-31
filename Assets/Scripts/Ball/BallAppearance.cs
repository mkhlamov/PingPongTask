using System;
using PingPongTask.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.Ball
{
    public class BallAppearance : IRequireRandom
    {
        public IRandomService RandomService { get; set; }
        
        private readonly Image _image;
        private readonly Transform _transform;
        private float _minSize;
        private float _maxSize;

        public BallAppearance(Image image, 
            IRandomService randomService, 
            Transform transform,
            float minSize,
            float maxSize)
        {
            _image = image;
            RandomService = randomService;
            _transform = transform;
            _minSize = minSize;
            _maxSize = maxSize;
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

        public void SetSize(float size)
        {
            var newSize = Mathf.Clamp(size, _minSize, _maxSize);
            _transform.localScale = Vector3.one * newSize;
        }

        public void SetDifferentSize()
        {
            var oldSize = _transform.localScale.x;
            var newSize = RandomService.Range(_minSize, _maxSize);
            while (newSize == oldSize)
            {
                newSize = RandomService.Range(_minSize, _maxSize);
            }
            SetSize(newSize);
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