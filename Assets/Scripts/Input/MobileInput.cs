using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Input
{
    public class MobileInput : IInputService
    {
        public float GetAxis(string axisName)
        {
            if (!axisName.Equals("Horizontal")) { return 0; }
            if (UnityEngine.Input.touchCount <= 0) { return 0; }
            
            return UnityEngine.Input.touches[0].deltaPosition.x / Screen.width;
        }

        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}