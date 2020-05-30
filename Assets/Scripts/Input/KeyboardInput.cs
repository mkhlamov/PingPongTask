using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Input
{
    public class KeyboardInput : IInputService
    {
        public float GetAxis(string axisName)
        {
            return UnityEngine.Input.GetAxis(axisName);
        }

        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}