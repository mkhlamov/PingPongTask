using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PingPongTask.Racket;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.RacketTests
{
    public class RacketMovementTests
    {
        public class RacketMovementCalculateMove
        {
            private LayerMask _layerMask;
            private float _width;
            private GameObject _wallRight;
            private GameObject _wallLeft;
            
            [SetUp]
            public void BeforeEachTest()
            {
                _layerMask = LayerMask.GetMask("Wall");
                _width = 0.6f;

                _wallRight = new GameObject {layer = LayerMask.NameToLayer("Wall")};
                var coll = _wallRight.AddComponent<BoxCollider2D>();
                coll.size = new Vector2(0.1f, 0.1f);
                _wallRight.transform.position = new Vector3(2, 0);
                
                _wallLeft = new GameObject {layer = LayerMask.NameToLayer("Wall")};
                coll = _wallLeft.AddComponent<BoxCollider2D>();
                coll.size = new Vector2(0.1f, 0.1f);
                _wallLeft.transform.position = new Vector3(-2, 0);
            }
            
            [UnityTest]
            public IEnumerator _0_Doesnt_Move_Right_After_Right_Wall()
            {
                var speed = 1f;
                var horizInputValue = 1f;
                var deltaTime = 1f;

                var move = new RacketMovement(speed, _layerMask, _width)
                    .CalculateMove(new Vector3(1.5f, 0f), horizInputValue, deltaTime);

                yield return null;
                
                var expectedResult = 1.7f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }
            
            [UnityTest]
            public IEnumerator _1_Doesnt_Move_Left_After_Left_Wall()
            {
                var speed = 1f;
                var horizInputValue = -1f;
                var deltaTime = 1f;

                var move = new RacketMovement(speed, _layerMask, _width)
                    .CalculateMove(new Vector3(-1.5f, 0f), horizInputValue, deltaTime);

                yield return null;
                
                var expectedResult = -1.7f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }

            [TearDown]
            public void AtferEachTest()
            {
                Object.DestroyImmediate(_wallLeft);
                Object.DestroyImmediate(_wallRight);
            }
        }
    }
}