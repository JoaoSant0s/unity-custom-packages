/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        public event Action OnBeforeClose;
        private PopupService popupService;

        #region Unity Methods

        private void Awake()
        {
            popupService = Services.Get<PopupService>();
        }

        #endregion

        protected virtual void BeforeClose() { }

        public virtual void Close()
        {
            BeforeClose();
            OnBeforeClose?.Invoke();

            Destroy(gameObject);
        }
    }
}