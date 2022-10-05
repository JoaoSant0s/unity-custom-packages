/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;

using UnityEngine;

namespace JoaoSant0s.ServicePackage.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        public event Action OnBeforeClose;

        protected virtual void BeforeClose() { }

        public virtual void Close()
        {
            BeforeClose();
            OnBeforeClose?.Invoke();

            Destroy(gameObject);
        }
    }
}