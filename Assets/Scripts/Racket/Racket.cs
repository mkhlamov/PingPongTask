using PingPongTask.Interfaces;
using PingPongTask.Racket;
using UnityEngine;

namespace PingPongTask.Racket
{
    public class Racket : MonoBehaviour, IRequireUserInput
    {
        public IInputService InputService { get; set; }

        public float Speed;

        private RacketMovement _racketMovement;
        private IRequireUserInput _requireUserInputImplementation;

        private void Start()
        {
            _racketMovement = new RacketMovement(Speed);
        }

        private void Update()
        {
            transform.Translate(_racketMovement.CalculateMove(InputService.GetAxis("Horizontal"),
                InputService.GetDeltaTime()));
        }
    }
}