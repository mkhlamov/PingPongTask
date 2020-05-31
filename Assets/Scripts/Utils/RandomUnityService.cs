using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Utils
{
    public class RandomUnityService : IRandomService
    {
        public float Value()
        {
            return Random.value;
        }

        public int Range(int min, int max)
        {
            return Random.Range(min, max);
        }

        public float Range(float min, float max)
        {
            return Random.Range(min, max);
        }

        public string Color()
        {
            return "#" + ColorUtility.ToHtmlStringRGBA(Random.ColorHSV());
        }
    }
}