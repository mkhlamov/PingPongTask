using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PingPongTask.Racket;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RacketMovementTests
    {
        public class RacketMovementCalculateMove
        {
            [Test]
            public void _0_Not_Moving_With_0_Speed()
            {
                var speed = 0f;
                var horizInputValue = 1f;
                var deltaTime = 1f;
                var move = new RacketMovement(speed).CalculateMove(horizInputValue, deltaTime);

                var expectedResult = 0f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }
            
            [Test]
            public void _1_Not_Moving_With_0_HorizontalInput()
            {
                var speed = 1f;
                var horizInputValue = 0f;
                var deltaTime = 1f;
                var move = new RacketMovement(speed).CalculateMove(horizInputValue, deltaTime);

                var expectedResult = 0f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }

            [Test]
            public void _2_Moves_Along_X_With_Horizontal_Input()
            {
                var speed = 1f;
                var horizInputValue = 1f;
                var deltaTime = 1f;
                var move = new RacketMovement(speed).CalculateMove(horizInputValue, deltaTime);
            
                var expectedResult = 1f;
                Assert.AreEqual(expectedResult, move.x, 0.1f);
            }
        }
    }
}
