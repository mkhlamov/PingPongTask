using System;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Ball
{
    public class BallAppearance
    {
        private readonly IRandomService _randomService;
        
        private readonly SpriteRenderer _image;
        private readonly Transform _transform;
        private float _minSize;
        private float _maxSize;

        public BallAppearance(SpriteRenderer image, 
            IRandomService randomService, 
            Transform transform,
            float minSize,
            float maxSize,
            string colorStr)
        {
            if (minSize <= 0) throw new ArgumentException("Min size should be greater than 0");
            if (maxSize <= 0) throw new ArgumentException("Max size should be greater than 0");
            if (minSize >= maxSize) throw new ArgumentException("Max size should be greater than min size");
            
            _image = image;
            _randomService = randomService;
            _transform = transform;
            _minSize = minSize;
            _maxSize = maxSize;
            _image.color = ColorUtility.TryParseHtmlString(colorStr, out var color) ? color : Color.white;
        }

        public virtual void SetNewBall()
        {
            SetDifferentSize();
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
            var newSize = _randomService.Range(_minSize, _maxSize);
            while (newSize == oldSize)
            {
                newSize = _randomService.Range(_minSize, _maxSize);
            }
            SetSize(newSize);
        }

        private Color GetRandomColor()
        {
            var newColorStr = _randomService.Color();
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