/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using UnityEngine;

using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.Popups
{
    public abstract class PopupBehaviour : MonoBehaviour
    {
        [CanvasIdAttribute]
        [SerializeField]
        private string canvasId;

        public string CanvasId => canvasId;

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