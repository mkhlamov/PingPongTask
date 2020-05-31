using System;
using System.Collections;
using System.Collections.Generic;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Ball
{
    public class BallMovement : IRequireRandom
    {
        public float Speed;

        private float _minSpeed;
        private float _maxSpeed;

        public IRandomService RandomService { get; set; }

        public BallMovement(float speed, IRandomService randomService, float minSpeed, float maxSpeed)
        {
            if (minSpeed <= 0) throw new ArgumentException("Min speed should be greater than 0");
            if (maxSpeed <= 0) throw new ArgumentException("Max speed should be greater than 0");
            if (minSpeed >= maxSpeed) throw new ArgumentException("Max speed should be greater than min size");
            
            Speed = speed;
            RandomService = randomService;
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
        }

        public Vector2 GetStartingVelocity()
        {
            var x = RandomService.Value() * (RandomService.Range(0, 2) * 2 - 1);
            var y = RandomService.Value() * (RandomService.Range(0, 2) * 2 - 1);
            
            while (Math.Abs(x) < 0.1f || Math.Abs(y) < 0.1f)
            {
                x = RandomService.Value() * (RandomService.Range(0, 2) * 2 - 1);
                y = RandomService.Value() * (RandomService.Range(0, 2) * 2 - 1);
            }
            return new Vector2(x, y).normalized * Speed;
        }

        public void ResetSpeed()
        {
            var oldSpeed = Speed;
            var newSpeed = RandomService.Range(_minSpeed, _maxSpeed);
            while (newSpeed == oldSpeed)
            {
                newSpeed = RandomService.Range(_minSpeed, _maxSpeed);
            }

            Speed = newSpeed;
        }
    }
}