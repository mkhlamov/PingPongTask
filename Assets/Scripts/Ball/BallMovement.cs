using System;
using PingPongTask.Interfaces;
using UnityEngine;

namespace PingPongTask.Ball
{
    public class BallMovement
    {
        public float Speed;

        private float _minSpeed;
        private float _maxSpeed;
        private Vector2 _velocity;

        public readonly IRandomService RandomService;

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

            _velocity = new Vector2(x, y).normalized * Speed;
            return _velocity;
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

        public void CollidedWithRacket(Vector2 ballPos, Vector2 racketPos, float racketWidth)
        {
            var x = (ballPos.x - racketPos.x) / (racketWidth / 2f);
            var newDirection = new Vector2(x, -_velocity.y).normalized;
            _velocity = newDirection * Speed;
        }

        public void CollidedWithWall()
        {
            _velocity = new Vector2(-_velocity.x, _velocity.y);
        }

        public Vector2 GetVelocity()
        {
            return _velocity;
        }
    }
}