using System.Collections;
using System.Collections.Generic;

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

        private void Start()
        {
            flagService = Services.Get<FlagService>();
            flagService.AddListening(enableFlag, EnableTarget, DisableTarget);

            StartTrigger();
        }

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
            target.SetActive(true && !invert);
        }

        private void DisableTarget()
        {
            target.SetActive(false || invert);
        }

        private void OnDestroy()
        {
            flagService?.RemoveListening(enableFlag);
        }
    }
}
