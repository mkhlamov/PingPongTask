using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PingPongTask.Ball;
using PingPongTask.ScoreCounter;
using PingPongTask.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.EditMode.ScoreCounterTests
{
    public class ScoreCounterTests
    {
        private ScoreCounter _scoreCounter;

        [SetUp]
        public void BeforeEachTest()
        {
            _scoreCounter = new ScoreCounter();
        }
        
        public class ScoreCounterIncrementScore : ScoreCounterTests
        {
            [Test]
            public void _0_Should_Add_1_To_Score()
            {
                _scoreCounter.Score = 0;
                
                _scoreCounter.IncrementScore();
                
                Assert.AreEqual(1, _scoreCounter.Score);
            }
            
            [Test]
            public void _0_Should_Raise_Event_On_Score_Update()
            {
                var score = 0;
                _scoreCounter.Score = 0;
                _scoreCounter.OnScoreUpdated += i => score = i; 
                
                _scoreCounter.IncrementScore();
                
                Assert.AreEqual(1, score);
            }
        }
    }
}