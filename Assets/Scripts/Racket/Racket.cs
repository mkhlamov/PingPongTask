using System.Collections;
using System.Collections.Generic;
using PingPongTask.Racket;
using UnityEngine;
using UnityEngine.Serialization;

public class Racket : MonoBehaviour
{
    public IInputService InputService;

    public float Speed;

    private RacketMovement _racketMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        _racketMovement = new RacketMovement(Speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_racketMovement.CalculateMove(InputService.GetAxis("Horizontal"), 
                                                                        InputService.GetDeltaTime()));
    }
}
