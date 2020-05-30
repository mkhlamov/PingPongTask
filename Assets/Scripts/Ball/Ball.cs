using System;
using System.Collections;
using System.Collections.Generic;
using PingPongTask.Interfaces;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace PingPongTask.Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Ball : MonoBehaviour
    {
        //public IRandomService RandomService { get; set; }
        public float speed = 8f;

        public BallMovement ballMovement;
        public Vector2 startPosition;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
        }

        public void Restart()
        {
            ResetPosition();
            _rb.velocity = ballMovement.GetStartingVelocity();
        }

        public void ResetPosition()
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0;
            transform.position = startPosition;
        }
    }
}