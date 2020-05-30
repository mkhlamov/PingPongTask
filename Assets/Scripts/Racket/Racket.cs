using PingPongTask.Interfaces;
using PingPongTask.Racket;
using UnityEngine;

namespace PingPongTask.Racket
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Racket : MonoBehaviour, IRequireUserInput
    {
        public IInputService InputService { get; set; }

        public float Speed;

        private RacketMovement _racketMovement;

        private void Start()
        {
            _racketMovement = new RacketMovement(Speed, 
                LayerMask.GetMask("Wall"), 
                GetComponent<BoxCollider2D>().size.x);
        }

        private void Update()
        {
            transform.position = _racketMovement.CalculateMove(transform.position, 
                InputService.GetAxis("Horizontal"),
                InputService.GetDeltaTime());
        }
    }
}