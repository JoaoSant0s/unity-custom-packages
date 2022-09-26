using System;
using System.Collections;
using System.Collections.Generic;
using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Namespace
{
    public class TestScreenService : MonoBehaviour
    {
        [SerializeField]
        private RectTransform internalScreen;
        private ScreenService screenService;

        void Start()
        {
            screenService = Services.Get<ScreenService>();
            screenService.OnScreenChanged += ScreenChanged;
        }

        private void ScreenChanged(BaseScreen arg1, BaseScreen arg2)
        {
            Debugs.Log(arg1, arg2);
        }

        #region UI Methods

        public void ShowExternalScreen()
        {
            screenService.GoToScreen<Test1Screen>();
        }

        public void ShowInternalScreen()
        {
            screenService.GoToScreen<Test2Screen>(internalScreen);
        }

        #endregion
    }
}
