using System;
using System.Collections;
using System.Collections.Generic;
using PingPongTask.Ball;
using PingPongTask.Utils;
using UnityEngine;

namespace PingPongTask.Injectors
{
    public class BallMovementRandomService : MonoBehaviour
    {
        [SerializeField] private GameObject ball;

        private void Awake()
        {
            var ballComponent = ball.GetComponent<Ball.Ball>();
            ballComponent.ballMovement = new BallMovement(ballComponent.speed, new RandomUnityService());
        }
    }
}