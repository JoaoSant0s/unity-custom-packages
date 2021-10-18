using System.Collections;
using System.Collections.Generic;
using JoaoSant0s.ServicePackage.General;
using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Flag
{
    public class EnableByFlag : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField]
        private FlagAsset enableFlag;

        [SerializeField]
        private FlagState startState;

        [Header("Events")]

        [SerializeField]
        private UnityEvent raiseEvent;

        [SerializeField]
        private UnityEvent lowerEvent;

        private FlagService flagService;

        private void Start()
        {
            flagService = Services.Get<FlagService>();

            flagService.AddListening(enableFlag, raiseEvent, lowerEvent);
            if (startState == FlagState.Lower)
            {
                flagService.Lower(enableFlag);
            }
            else
            {
                flagService.Raise(enableFlag);
            }
        }

        private void OnDestroy()
        {
            flagService.RemoveListening(enableFlag);
        }
    }
}