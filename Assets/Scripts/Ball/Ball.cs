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
        public float speed = 8f;
        
        public BallMovement ballMovement;
        public BallAppearance ballAppearance;
        public Vector2 startPosition;
        public event Action OnBallHitRacket;
        public event Action OnBallRestart;

        private Rigidbody2D _rb;
        

        #region Monobehavoiur methods
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            startPosition = transform.position;
        }

        private void Start()
        {
            Restart();
        }

        private void Update()
        {
            _rb.velocity = ballMovement.GetVelocity();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Restart();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Racket"))
            {
                //bounce angle
                ballMovement.CollidedWithRacket(transform.position,
                    other.transform.position, other.collider.bounds.size.x);
                _rb.velocity = ballMovement.GetVelocity();
                OnBallHitRacket?.Invoke();
            }
            else if (other.gameObject.CompareTag("Wall"))
            {
                ballMovement.CollidedWithWall();
                _rb.velocity = ballMovement.GetVelocity();
            }
        }

        #endregion

        #region Public methods
        
        public void Restart()
        {
            ResetPosition();
            ballMovement.ResetSpeed();
            _rb.velocity = ballMovement.GetStartingVelocity();
            ballAppearance.SetNewBall();
            OnBallRestart?.Invoke();
        }

        public void ResetPosition()
        {
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0;
            transform.position = startPosition;
        }
        
        #endregion
    }
}