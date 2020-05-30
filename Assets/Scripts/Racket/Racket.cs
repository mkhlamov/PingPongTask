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
        [SerializeField] private float mobileInputMultiplier = 10; 

        private RacketMovement _racketMovement;

        private void Start()
        {
            _racketMovement = new RacketMovement(Speed, 
                LayerMask.GetMask("Wall"), 
                GetComponent<BoxCollider2D>().size.x);
        }

        private void Update()
        {
            var axisValue = InputService.GetAxis("Horizontal");
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
            axisValue *= mobileInputMultiplier;
#endif
            transform.position = _racketMovement.CalculateMove(transform.position, 
                axisValue,
                InputService.GetDeltaTime());
        }
    }
}