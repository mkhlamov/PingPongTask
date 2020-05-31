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
        [SerializeField] private float minSize;
        [SerializeField] private float maxSize;

        private void Awake()
        {
            var ballComponent = ball.GetComponent<Ball.Ball>();
            var randomService = new RandomUnityService();
            ballComponent.ballMovement = new BallMovement(ballComponent.speed, randomService);
            ballComponent.ballAppearance = new BallAppearance(ballComponent.GetComponentInChildren<SpriteRenderer>(),
                randomService,
                ballComponent.transform,
                minSize,
                maxSize);
        }
    }
}