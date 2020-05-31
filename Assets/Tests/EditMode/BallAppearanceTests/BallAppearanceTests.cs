using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PingPongTask.Ball;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.EditMode.BallAppearanceTests
{
    public class BallAppearanceTests
    {
        public class BallAppearanceSetColor : BallAppearanceTests
        {
            [Test]
            public void _0_Should_Change_Color()
            {
                var image = new GameObject().AddComponent<Image>();
                image.color = Color.black;
                var appearance = new BallAppearance(image);
                var expectedColor = Color.green;

                appearance.SetColor(expectedColor);

                Assert.AreEqual(expectedColor, image.color);
            }
        }
    }
}