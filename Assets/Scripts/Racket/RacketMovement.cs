using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPongTask.Racket
{
    public class RacketMovement
    {
        private readonly float _speed;

        public RacketMovement(float speed)
        {
            _speed = speed;
        }

        public Vector3 CalculateMove(float horizontal, float deltaTime)
        {
            return Vector3.right * (_speed * horizontal * deltaTime);
        }
    }
}