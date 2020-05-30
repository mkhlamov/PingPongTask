using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PingPongTask.Input;
using PingPongTask.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace PingPongTask.Injectors
{
    public class RacketInput : MonoBehaviour
    {
        [SerializeField] private List<GameObject> rackets;
        [SerializeField] private IInputService inputService;

        private void Awake()
        {
#if UNITY_EDITOR
            inputService = new KeyboardInput();
#elif (UNITY_ANDROID || UNITY_IOS)
            inputService = new MobileInput();
#endif
            var components = new List<MonoBehaviour>();
            foreach (var racket in rackets)
            {
                components.AddRange(racket.GetComponents<MonoBehaviour>());
            }
            var withInput = components.Where(x => x is IRequireUserInput)
                                                                    .Cast<IRequireUserInput>();
            foreach (var x in withInput)
            {
                x.InputService = inputService;
            }
        }

    }
}