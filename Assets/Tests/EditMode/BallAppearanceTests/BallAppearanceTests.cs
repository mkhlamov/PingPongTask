using NUnit.Framework;
using PingPongTask.Ball;
using PingPongTask.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.EditMode.BallAppearanceTests
{
    public class BallAppearanceTests
    {
        private SpriteRenderer _image;
        private Transform _transform;
        private BallAppearance _ballAppearance;
        private float _minSize;
        private float _maxSize;

        [SetUp]
        public void BeforeEachTest()
        {
            _image = new GameObject().AddComponent<SpriteRenderer>();
            _transform = new GameObject().transform;
            _minSize = 0.2f;
            _maxSize = 2f;
            _ballAppearance = new BallAppearance(_image, new RandomUnityService(), _transform, 
                _minSize, _maxSize, "#FFFFFF");
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
        
        public class BallAppearanceSetSize : BallAppearanceTests
        {
            [Test]
            public void _0_Should_Set_Scale()
            {
                var expectedSize = 0.3f;

                _ballAppearance.SetSize(expectedSize);

                Assert.AreEqual(Vector3.one * expectedSize, _transform.localScale);
            }
            
            [Test]
            public void _1_Should_Not_Set_Scale_Lower_Than_Min()
            {
                _ballAppearance.SetSize(_minSize - 0.1f);

                Assert.AreEqual(Vector3.one * _minSize, _transform.localScale);
            }
            
            [Test]
            public void _2_Should_Not_Set_Scale_Greater_Than_Max()
            {
                _ballAppearance.SetSize(_maxSize + 0.1f);
                
                Assert.AreEqual(Vector3.one * _maxSize, _transform.localScale);
            }
        }
        
        public class BallAppearanceSetDifferentSize : BallAppearanceTests
        {
            [Test]
            public void _0_Should_Change_Size()
            {
                var oldSize = _transform.localScale.x;

                _ballAppearance.SetDifferentSize();

                Assert.AreNotEqual(oldSize, _transform.localScale.x);
            }
        }
        
        public class BallAppearanceSetNewBall : BallAppearanceTests
        {
            [Test]
            public void _0_Should_Change_Size()
            {
                var oldSize = _transform.localScale.x;

                _ballAppearance.SetNewBall();

                Assert.AreNotEqual(oldSize, _transform.localScale.x);
            }
        }
    }
}