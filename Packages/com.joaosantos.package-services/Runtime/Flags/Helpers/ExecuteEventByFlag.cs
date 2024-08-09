/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;
using UnityEngine.Events;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Flag
{
    public class ExecuteEventByFlag : MonoBehaviour
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

        private FlagEventObject flagEvent;

        #region Unity Methods

        private void Awake()
        {
            flagService = Services.Get<FlagService>();
            flagEvent = new(raiseEvent, lowerEvent);

            flagService.AddListening(enableFlag, flagEvent);
        }

        private void Start()
        {
            StartTrigger();
        }

        private void OnDestroy()
        {
            flagService.RemoveListening(enableFlag, flagEvent);
        }

        #endregion

        private void StartTrigger()
        {
            if (startState == FlagState.Lower)
            {
                flagService.Lower(enableFlag);
            }
            else if (startState == FlagState.Raise)
            {
                flagService.Raise(enableFlag);
            }
        }
    }
}