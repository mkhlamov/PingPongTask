using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.Ball
{
    public class BallAppearance
    {
        private Image _image;

        public BallAppearance(Image image)
        {
            _image = image;
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }
        
        
    }
}