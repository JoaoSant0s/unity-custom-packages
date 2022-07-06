using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Pool
{
    public abstract partial class PoolBase : MonoBehaviour
    {
        internal delegate void OnDisposePoolElement(PoolBase element);
        internal OnDisposePoolElement DisposePoolElement;

        internal int indexOrdering;

        public void Dispose()
        {
            OnDispose();
            DisposePoolElement?.Invoke(this);
        }

        public void Show()
        {
            OnShow();
        }

        protected virtual void OnDispose() { }

        protected virtual void OnShow() { }
    }
}