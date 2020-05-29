using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPongTask.Racket
{
    public class RacketMovement
    {
        public float Speed;

        public RacketMovement(float speed)
        {
            Speed = speed;
        }

        public Vector3 CalculateMove(float horizontal, float deltaTime)
        {
            return new Vector3();
        }
    }
}