using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPongTask.Ball
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Ball : MonoBehaviour
    {
        public float speed = 8f;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}