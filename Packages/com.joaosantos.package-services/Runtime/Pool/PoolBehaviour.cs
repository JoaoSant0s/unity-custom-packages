/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.ServicePackage.Pool
{
    public abstract class PoolBehaviour : MonoBehaviour
    {
        internal delegate void OnDisposePoolElement(PoolBehaviour element);
        internal OnDisposePoolElement DisposePoolBehaviour;

        public int IndexOrdering { get; internal set; }

        public void Dispose()
        {
            OnDispose();
            DisposePoolBehaviour?.Invoke(this);
        }

        public void Show()
        {
            OnShow();
        }

        protected virtual void OnDispose() { }

        protected virtual void OnShow() { }
    }
}