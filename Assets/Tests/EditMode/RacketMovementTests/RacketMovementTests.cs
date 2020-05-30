using NUnit.Framework;
using PingPongTask.Racket;
using UnityEngine;

namespace Tests.EditMode.RacketMovementTests
{
    public class RacketMovementTests
    {
        public class RacketMovementCalculateMove
        {
            private LayerMask _layerMask;
            private float _width;

            [SetUp]
            public void BeforeEachTest()
            {
                _layerMask = LayerMask.GetMask("Wall");
                _width = 0.6f;
            }
            
            [Test]
            public void _0_Not_Moving_With_0_Speed()
            {
                var speed = 0f;
                var horizInputValue = 1f;
                var deltaTime = 1f;
                var layerMask = LayerMask.GetMask("Wall");
                var width = 0.6f;
                
                var move = new RacketMovement(speed, _layerMask, _width)
                    .CalculateMove(Vector3.zero, horizInputValue, deltaTime);

                var expectedResult = 0f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }
            
            [Test]
            public void _1_Not_Moving_With_0_HorizontalInput()
            {
                var speed = 1f;
                var horizInputValue = 0f;
                var deltaTime = 1f;
                
                var move = new RacketMovement(speed, _layerMask, _width)
                    .CalculateMove(Vector3.zero, horizInputValue, deltaTime);

                var expectedResult = 0f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }

            [Test]
            public void _2_Moves_Along_X_With_Horizontal_Input()
            {
                var speed = 1f;
                var horizInputValue = 1f;
                var deltaTime = 1f;
                
                var move = new RacketMovement(speed, _layerMask, _width)
                    .CalculateMove(Vector3.zero, horizInputValue, deltaTime);
            
                var expectedResult = 1f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }
        }
    }
}
