using NSubstitute;
using NUnit.Framework;
using PingPongTask.Ball;
using PingPongTask.Interfaces;
using UnityEngine;

namespace Tests.EditMode.BallMovementTests
{
    public class BallMovementTests
    {
        private BallMovement _ballMovement;
        private const float Speed = 5f;
        private const float MinSpeed = 0.5f;
        private const float MaxSpeed = 10f;
        
        [SetUp]
        public void BeforeEachTest()
        {
            _ballMovement = new BallMovement(Speed, Substitute.For<IRandomService>(), MinSpeed, MaxSpeed);
            _ballMovement.RandomService.Value().ReturnsForAnyArgs(2);
        }
        
        public class BallMovementGetStartingVelocity : BallMovementTests
        {
            [Test]
            public void _0_Sets_Positive_Horizontal()
            {
                _ballMovement.RandomService.Range(0, 0).ReturnsForAnyArgs(1);

                var dir = Mathf.Sign(_ballMovement.GetStartingVelocity().x);
                
                Assert.AreEqual(1, dir);
            }
            
            [Test]
            public void _1_Sets_Negative_Horizontal()
            {
                _ballMovement.RandomService.Range(0, 0).ReturnsForAnyArgs(-1);

                var dir = Mathf.Sign(_ballMovement.GetStartingVelocity().x);
                
                Assert.AreEqual(-1, dir);
            }
            
            [Test]
            public void _2_Sets_Positive_Vertical()
            {
                _ballMovement.RandomService.Range(0, 0).ReturnsForAnyArgs(1);

                var dir = Mathf.Sign(_ballMovement.GetStartingVelocity().y);
                
                Assert.AreEqual(1, dir);
            }
            
            [Test]
            public void _3_Sets_Negative_Vertical()
            {
                _ballMovement.RandomService.Range(0, 0).ReturnsForAnyArgs(-1);

                var dir = Mathf.Sign(_ballMovement.GetStartingVelocity().y);
                
                Assert.AreEqual(-1, dir);
            }

            [Test]
            public void _4_Sets_Velocity_Magnitude()
            {
                _ballMovement.RandomService.Range(0, 0).ReturnsForAnyArgs(10);

                var magn = _ballMovement.GetStartingVelocity().magnitude;
                
                Assert.AreEqual(Speed, magn);
            }
        }
        
        public class BallMovementResetSpeed : BallMovementTests
        {
            [Test]
            public void _0_Sets_New_Speed()
            {
                var newSpeed = Speed + 1;
                _ballMovement.RandomService.Range(0f, 0f).ReturnsForAnyArgs(newSpeed);

                _ballMovement.ResetSpeed();
                
                Assert.AreNotEqual(Speed, _ballMovement.Speed);
            }
        }
    }
}