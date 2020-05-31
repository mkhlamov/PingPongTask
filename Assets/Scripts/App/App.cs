using System.Collections;
using System.Collections.Generic;
using PingPongTask.Ball;
using PingPongTask.ScoreCounter;
using PingPongTask.ScriptableObjects;
using PingPongTask.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.App
{

    public class App : MonoBehaviour
    {
        [SerializeField] private BallData _ballData; 
        [SerializeField] private Text _scoreCounterTextGO;
        
        private GameObject _ballGO;
        private Ball.Ball _ball;
        private ScoreCounter.ScoreCounter _scoreCounter;
        private ScoreCounterText _scoreCounterText;

        private void Awake()
        {
            CreateBall();
            
            _scoreCounter = new ScoreCounter.ScoreCounter();
            _ball.OnBallHitRacket += _scoreCounter.IncrementScore;
            
            _scoreCounterText = new ScoreCounterText(_scoreCounterTextGO);
            _scoreCounter.OnScoreUpdated += _scoreCounterText.UpdateScore;
        }

        private void CreateBall()
        {
            var ballPrefab = Resources.Load("Prefabs/Ball") as GameObject;
            _ballGO = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            _ball = _ballGO.GetComponent<Ball.Ball>();
            var randomService = new RandomUnityService();
            _ball.ballMovement = new BallMovement(_ball.speed, randomService, _ballData.minSpeed, _ballData.maxSpeed);
            _ball.ballAppearance = new BallAppearance(_ball.GetComponentInChildren<SpriteRenderer>(),
                randomService,
                _ball.transform,
                _ballData.minSize,
                _ballData.maxSize);
        }
    }
}