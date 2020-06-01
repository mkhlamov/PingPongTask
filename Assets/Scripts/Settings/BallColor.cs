using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PingPongTask.Settings
{
    [RequireComponent(typeof(Image))]
    public class BallColor : MonoBehaviour, IPointerDownHandler
    {
        public event Action<Color> OnBallColorChosen;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnBallColorChosen?.Invoke(_image.color);
        }
    }
}