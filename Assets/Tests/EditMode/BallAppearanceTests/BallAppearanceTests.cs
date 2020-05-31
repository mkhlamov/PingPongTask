using NUnit.Framework;
using PingPongTask.Ball;
using PingPongTask.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.EditMode.BallAppearanceTests
{
    public class BallAppearanceTests
    {
        private Image _image;
        private BallAppearance _ballAppearance;

        [SetUp]
        public void BeforeEachTest()
        {
            _image = new GameObject().AddComponent<Image>();
            _ballAppearance = new BallAppearance(_image, new RandomUnityService());
        }
        public class BallAppearanceSetColor : BallAppearanceTests
        {
            [Test]
            public void _0_Should_Change_Color()
            {
                _image.color = Color.black;
                var expectedColor = Color.green;

                _ballAppearance.SetColor(expectedColor);

                Assert.AreEqual(expectedColor, _image.color);
            }
        }
        
        public class BallAppearanceSetDifferentColor : BallAppearanceTests
        {
            [Test]
            public void _0_Should_Change_For_New_Color()
            {
                _image.color = Color.black;
                var oldColor = _image.color;

                _ballAppearance.SetDifferentColor();

                Assert.AreNotEqual(oldColor, _image.color);
            }
        }
    }
}