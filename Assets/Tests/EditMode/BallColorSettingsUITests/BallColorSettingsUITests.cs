using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PingPongTask.ScoreCounter;
using PingPongTask.Settings;
using Tests.EditMode.ScoreCounterTests;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.EditMode.BallColorSettingsUITests
{
    public class BallColorSettingsUITests : MonoBehaviour
    {
        private BallColorSettingsUI _ballColorSettingsUi;
        private Image _image;

        [SetUp]
        public void BeforeEachTest()
        {
            _image = new GameObject().AddComponent<Image>();
            _ballColorSettingsUi = new BallColorSettingsUI(_image);
        }

        public class BallColorSettingsUITestsUpdateCurrent : BallColorSettingsUITests
        {
            [Test]
            public void _0_Should_Update_Color()
            {
                _ballColorSettingsUi.UpdateCurrent(Color.blue);

                Assert.AreEqual(Color.blue, _image.color);
            }
        }
    }
}