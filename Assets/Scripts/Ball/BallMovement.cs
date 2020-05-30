using System.Collections;
using System.Collections.Generic;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Ball
{
    public class BallMovement : IRequireRandom
    {
        public float Speed;

        public IRandomService RandomService { get; set; }

        public BallMovement(float speed, IRandomService randomService)
        {
            Speed = speed;
            RandomService = randomService;
        }

        public Vector2 GetStartingVelocity()
        {
            var x = RandomService.Value() * (RandomService.Range(0, 2) * 2 - 1);
            var y = RandomService.Value() * (RandomService.Range(0, 2) * 2 - 1);
            return new Vector2(x, y).normalized * Speed;
        }
    }
}