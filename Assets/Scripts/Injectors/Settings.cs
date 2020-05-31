using System;
using System.Collections;
using System.Collections.Generic;
using PingPongTask.Settings;
using PingPongTask.SettingsProviders;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

namespace PingPongTask.Injectors
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private Image currentBallColorImage;
        [SerializeField] private GameObject ballColorRootGO;
        [SerializeField] private List<Color> ballColors;

        private BallColorUpdater _ballColorUpdater;
        private BallColorSettingsUI _ballColorSettingsUi;
        private void Awake()
        {
            var settingsProvider = new PlayerPrefsSettingProvider();
            _ballColorUpdater = new BallColorUpdater(settingsProvider);
            
            _ballColorSettingsUi = new BallColorSettingsUI(currentBallColorImage);
            _ballColorUpdater.OnBallColorChanged += _ballColorSettingsUi.UpdateCurrent;
            
            var color = ColorUtility.TryParseHtmlString(settingsProvider.GetBallColor(), out var c) ? c : Color.white;
            _ballColorUpdater.UpdateBallColor(color);

            var prefab = Resources.Load("Prefabs/BallColor");
            foreach (var ballColor in ballColors)
            {
                var go = Instantiate(prefab, ballColorRootGO.transform) as GameObject;
                if (go != null)
                {
                    go.GetComponent<Image>().color = ballColor;
                    go.GetComponent<BallColor>().OnBallColorChosen += _ballColorUpdater.UpdateBallColor;
                }
                else
                {
                    throw new Exception("BallColor prefab is null!");
                }
            }
        }
    }
}