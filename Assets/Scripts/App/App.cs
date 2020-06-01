using System.Collections.Generic;
using System.Linq;
using PingPongTask.Ball;
using PingPongTask.Input;
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
        [SerializeField] private Transform ballStartPosition;
        [SerializeField] private List<Transform> racketsStartPositions;
        [SerializeField] private Text scoreCounterTextGo;
        [SerializeField] private Text bestScoreCounterTextGo;
        
        private GameObject _ballGO;
        private Ball.Ball _ball;
        private List<GameObject> _rackets;
        private ScoreCounter.ScoreCounter _scoreCounter;
        private ScoreCounterText _scoreCounterText;
        private ScoreCounterText _bestScoreCounterText;
        private BestScoreUpdater _bestScoreUpdater;
        private ISettingsProvider _settingsProvider;
        private IInputService _inputService;

        private void Awake()
        {
            _settingsProvider = new PlayerPrefsSettingProvider();
#if UNITY_EDITOR
            _inputService = new KeyboardInput();
#elif (UNITY_ANDROID || UNITY_IOS)
            _inputService = new MobileInput();
#endif
            CreateBall();
            CreateRackets();
            
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
            _ballGO = Instantiate(ballPrefab, ballStartPosition.position, Quaternion.identity);
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
        
        private void CreateRackets()
        {
            _rackets = new List<GameObject>();
            var prefab = Resources.Load("Prefabs/Racket") as GameObject;
            foreach (var racketPos in racketsStartPositions)
            {
                var go = Instantiate(prefab, racketPos.position, Quaternion.identity);
                _rackets.Add(go);
            }
            
            var components = new List<MonoBehaviour>();
            foreach (var racket in _rackets)
            {
                components.AddRange(racket.GetComponents<MonoBehaviour>());
            }
            var withInput = components.Where(x => x is IRequireUserInput)
                .Cast<IRequireUserInput>();
            foreach (var x in withInput)
            {
                x.InputService = _inputService;
            }
        }
    }
}