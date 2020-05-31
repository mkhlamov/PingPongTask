using PingPongTask.Ball;
using PingPongTask.Interfaces;
using PingPongTask.ScoreCounter;
using PingPongTask.ScriptableObjects;
using PingPongTask.SettingsProviders;
using PingPongTask.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace PingPongTask.App
{

    public class App : MonoBehaviour
    {
        [SerializeField] private BallData ballData; 
        [SerializeField] private Text scoreCounterTextGo;
        [SerializeField] private Text bestScoreCounterTextGo;
        
        private GameObject _ballGO;
        private Ball.Ball _ball;
        private ScoreCounter.ScoreCounter _scoreCounter;
        private ScoreCounterText _scoreCounterText;
        private ScoreCounterText _bestScoreCounterText;
        private BestScoreUpdater _bestScoreUpdater;
        private ISettingsProvider _settingsProvider;

        private void Awake()
        {
            _settingsProvider = new PlayerPrefsSettingProvider();
            CreateBall();
            
            _scoreCounter = new ScoreCounter.ScoreCounter();
            _ball.OnBallHitRacket += _scoreCounter.IncrementScore;
            _ball.OnBallRestart += _scoreCounter.ResetScore;

            _scoreCounterText = new ScoreCounterText(scoreCounterTextGo);
            _scoreCounter.OnScoreUpdated += _scoreCounterText.UpdateScore;
            
            _bestScoreUpdater = new BestScoreUpdater(_settingsProvider);
            _scoreCounter.OnScoreUpdated += _bestScoreUpdater.UpdateScore;
            _ball.OnBallRestart += _bestScoreUpdater.SaveToDisk;
            
            _bestScoreCounterText = new ScoreCounterText(bestScoreCounterTextGo, _settingsProvider.GetBestScore());
            _bestScoreUpdater.OnBestScoreUpdated += _bestScoreCounterText.UpdateScore;
        }

        private void CreateBall()
        {
            var ballPrefab = Resources.Load("Prefabs/Ball") as GameObject;
            _ballGO = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            _ball = _ballGO.GetComponent<Ball.Ball>();
            var randomService = new RandomUnityService();
            _ball.ballMovement = new BallMovement(_ball.speed, randomService, ballData.minSpeed, ballData.maxSpeed);
            _ball.ballAppearance = new BallAppearance(_ball.GetComponentInChildren<SpriteRenderer>(),
                randomService,
                _ball.transform,
                ballData.minSize,
                ballData.maxSize,
                _settingsProvider.GetBallColor());
        }
    }
}