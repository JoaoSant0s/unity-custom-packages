/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Flag
{
    public class EnableByFlag : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField]
        private FlagAsset enableFlag;

        [SerializeField]
        private FlagState startState;

        [SerializeField]
        private bool invert;

        [Header("Target")]

        [SerializeField]
        private GameObject target;

        private FlagService flagService;
        private FlagActionObject flagAction;

        #region Unity Methods
        private void Awake()
        {
            flagService = Services.Get<FlagService>();
            flagAction = new(EnableTarget, DisableTarget);

            flagService.AddListening(enableFlag, flagAction);
        }

        private void Start()
        {
            StartTrigger();
        }

        private void OnDestroy()
        {
            flagService?.RemoveListening(enableFlag, flagAction);
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

        private void EnableTarget()
        {
            target.SetActive(!invert);
        }

        private void DisableTarget()
        {
            target.SetActive(invert);
        }
    }
}
