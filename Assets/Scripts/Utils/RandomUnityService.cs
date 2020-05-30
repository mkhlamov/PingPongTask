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
    }
}