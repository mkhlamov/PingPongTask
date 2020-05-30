using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace PingPongTask.Racket
{
    public class RacketMovement
    {
        private readonly float _speed;
        private LayerMask _wallsLayer;
        private float _width;

        public RacketMovement(float speed, LayerMask wallsLayer, float width)
        {
            _speed = speed;
            _wallsLayer = wallsLayer;
            _width = width;
        }

        public Vector3 CalculateMove(Vector2 startPos, float horizontal, float deltaTime)
        {
            var diff = Vector2.right * (_speed * horizontal * deltaTime);
            var newPos = startPos + diff;
            
            var hitLeft = Physics2D.Raycast(startPos, Vector2.left, diff.magnitude + _width / 2, _wallsLayer);
            var hitRight = Physics2D.Raycast(startPos, Vector2.right, diff.magnitude + _width / 2, _wallsLayer);

            if (hitLeft.collider != null)
            {
                newPos.x = Mathf.Max(newPos.x, hitLeft.point.x + _width / 2);
            }
            else if (hitRight.collider != null)
            {
                newPos.x = Mathf.Min(newPos.x, hitRight.point.x - _width / 2);
            }
            
            return newPos;
        }
    }
}