using NUnit.Framework;
using PingPongTask.ScoreCounter;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.EditMode.ScoreCounterTests
{
    public class ScoreCounterTextTests
    {
        private ScoreCounterText _scoreCounterText;
        private Text _text;

        [SetUp]
        public void BeforeEachTest()
        {
            _text = new GameObject().AddComponent<Text>();
            _text.text = "0";
            _scoreCounterText = new ScoreCounterText(_text);
        }

        public class ScoreCounterTextUpdateScore : ScoreCounterTextTests
        {
            [Test]
            public void _0_Should_Increment_Score()
            {
                _scoreCounterText.UpdateScore(1);
                
                Assert.AreEqual("1", _text.text);
            }
        }
    }
}