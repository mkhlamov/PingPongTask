using System.Collections;
using NUnit.Framework;
using PingPongTask.Ball;
using PingPongTask.Utils;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.BallTests
{
    public class BallTests
    {
        private Ball _ball;
        private Vector2 _startPosition;
        private GameObject _ballGO;

        [SetUp]
        public void BeforeEachTest()
        {
            var prefab = Resources.Load("Prefabs/Ball");
            _startPosition = Vector2.zero;
            _ballGO = Object.Instantiate(prefab, _startPosition, Quaternion.identity) as GameObject;
            _ball = _ballGO.GetComponent<Ball>();
            var randomUnityService = new RandomUnityService();
            _ball.ballMovement = new BallMovement(_ball.speed, randomUnityService, 0.5f, 10f);
            _ball.ballAppearance = new BallAppearance(_ball.GetComponentInChildren<SpriteRenderer>(),
                randomUnityService, _ball.transform, 0.5f, 2f, "#FFFFFF");
        }

        [TearDown]
        public void AfterEachTest()
        {
            Object.Destroy(_ballGO);
        }
        
        public class BallTestsRestart : BallTests
        {
            [UnityTest]
            public IEnumerator _0_Should_Have_Positive_Velocity()
            {
                var rb = _ballGO.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                yield return new WaitForFixedUpdate();
                _ball.Restart();
                yield return new WaitForFixedUpdate();
                Assert.Greater(rb.velocity.magnitude, 0);
            }
            
            [UnityTest]
            public IEnumerator _1_Should_Have_New_Speed()
            {
                var rb = _ballGO.GetComponent<Rigidbody2D>();
                yield return new WaitForFixedUpdate();
                _ball.Restart();
                yield return new WaitForFixedUpdate();
                var oldSpeed = rb.velocity.magnitude;
                _ball.Restart();
                yield return new WaitForFixedUpdate();
                Assert.AreNotEqual(oldSpeed, rb.velocity.magnitude);
            }
            
            [UnityTest]
            public IEnumerator _2_Should_Have_New_Size()
            {
                var rb = _ballGO.GetComponent<Rigidbody2D>();
                yield return new WaitForFixedUpdate();
                _ball.Restart();
                yield return new WaitForFixedUpdate();
                var oldSize = _ball.transform.localScale.x;
                _ball.Restart();
                yield return new WaitForFixedUpdate();
                Assert.AreNotEqual(oldSize, _ball.transform.localScale.x);
            }
        }

        public class BallTestsResetPosition : BallTests
        {
            [UnityTest]
            public IEnumerator _0_Should_Return_To_Start_Position()
            {
                var rb = _ballGO.GetComponent<Rigidbody2D>();
                rb.position = Vector2.one;
                yield return new WaitForFixedUpdate();
                _ball.ResetPosition();
                yield return new WaitForFixedUpdate();
                Assert.AreEqual(_startPosition, rb.position);
            }
            
            [UnityTest]
            public IEnumerator _1_Should_Stop()
            {
                var rb = _ballGO.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.one;
                yield return new WaitForFixedUpdate();
                _ball.ResetPosition();
                yield return new WaitForFixedUpdate();
                Assert.AreEqual(Vector2.zero, rb.velocity);
            }
        }
        
        public class BallTestsAwake : BallTests
        {
            [UnityTest]
            public IEnumerator _0_Save_Start_Position()
            {
                yield return null;
                Assert.AreEqual(_startPosition, _ball.startPosition);
            }
        }
    }
}