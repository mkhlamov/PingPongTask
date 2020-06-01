using UnityEngine;

namespace PingPongTask.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New ball", menuName = "Ball")]
    public class BallData : ScriptableObject
    {
        public float minSize;
        public float maxSize;
        public float minSpeed;
        public float maxSpeed;
    }
}