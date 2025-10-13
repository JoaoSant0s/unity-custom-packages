/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.Screens
{
    public abstract class BaseScreen : MonoBehaviour
    {
        [CanvasIdAttribute]
        [SerializeField]
        private string canvasId;

        public string CanvasId => canvasId;

        protected abstract void OnPrepare();
        protected abstract void OnRelease();

        #region Public Methods

        internal void Release()
        {
            OnRelease();
            Destroy(gameObject);
        }

        internal void Prepare()
        {
            OnPrepare();
        }

        #endregion
    }
}
