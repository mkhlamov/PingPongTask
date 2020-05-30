using System.Collections;
using NSubstitute;
using NUnit.Framework;
using PingPongTask.Interfaces;
using PingPongTask.Racket;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode.RacketTests
{
    public class RacketTests
    {
        [UnityTest]
        public IEnumerator _0_Not_Moving_With_0_Speed()
        {
            var racket = new GameObject().AddComponent<Racket>();
            racket.Speed = 0;
            var inputService = Substitute.For<IInputService>();
            inputService.GetAxis("Horizontal").Returns(1);
            inputService.GetDeltaTime().Returns(1);
            racket.InputService = inputService;

            yield return null;
            Assert.AreEqual(0, racket.transform.position.x, 0.1f);
        }
        
        [UnityTest]
        public IEnumerator _1_Not_Moving_With_0_HorizontalInput()
        {
            var racket = new GameObject().AddComponent<Racket>();
            racket.Speed = 1;
            var inputService = Substitute.For<IInputService>();
            inputService.GetAxis("Horizontal").Returns(0);
            inputService.GetDeltaTime().Returns(1);
            racket.InputService = inputService;

            yield return null;
            Assert.AreEqual(0, racket.transform.position.x, 0.1f);
        }
        
        [UnityTest]
        public IEnumerator _2_Moves_Along_X_With_Horizontal_Input_2_Moves_Along_X_With_Horizontal_Input()
        {
            var racket = new GameObject().AddComponent<Racket>();
            racket.Speed = 1;
            var inputService = Substitute.For<IInputService>();
            inputService.GetAxis("Horizontal").Returns(1);
            inputService.GetDeltaTime().Returns(1);
            racket.InputService = inputService;

            yield return null;
            Assert.AreEqual(1, racket.transform.position.x, 0.1f);
        }
    }
}
