using System.IO;
using Photon.Pun;
using PingPongTask.Ball;
using PingPongTask.Utils;
using UnityEngine;

namespace PingPongTask.App
{
    public class MultiplayerApp : App
    {
        [SerializeField] private string racketPrefabName = "PhotonPlayer";
        
        protected override void CreateRackets()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                var go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", racketPrefabName), 
                    racketsStartPositions[0].position, Quaternion.identity);
                go.GetComponent<Racket.RacketMultiplayer>().InputService = _inputService;
            }
            else
            {
                var go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", racketPrefabName), 
                    racketsStartPositions[1].position, Quaternion.identity);
                go.GetComponent<Racket.Racket>().InputService = _inputService;
            }
        }

        protected override void CreateBall()
        {
            _ball = FindObjectOfType<BallNetwork>();
            _ballGO = _ball.gameObject;
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