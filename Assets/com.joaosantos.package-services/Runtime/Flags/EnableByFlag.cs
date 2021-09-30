using System.Collections;
using System.Collections.Generic;
using Main.ServicePackage.General;
using UnityEngine;
using UnityEngine.Events;

namespace Main.ServicePackage.Flag
{
    public class EnableByFlag : MonoBehaviour
    {
        [SerializeField]
        private FlagAsset enableHudFlag;

        [SerializeField]
        private FlagState startState;

        [SerializeField]
        private UnityEvent raiseEvent;

        [SerializeField]
        private UnityEvent lowerEvent;

        private FlagService flagService;

        private void Start()
        {
            flagService = Services.Get<FlagService>();

            flagService.AddListening(enableHudFlag, raiseEvent, lowerEvent);
            if (startState == FlagState.Lower)
            {
                flagService.Lower(enableHudFlag);
            }
            else
            {
                flagService.Raise(enableHudFlag);
            }
        }

        private void OnDestroy()
        {
            flagService.RemoveListening(enableHudFlag);
        }
    }
}