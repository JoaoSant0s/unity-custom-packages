using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Pool
{
    public class PoolBase : MonoBehaviour
    {
        public delegate void OnDisposePoolElement(PoolBase element);
        public OnDisposePoolElement DisposePoolElement;

        public void Dispose()
        {
            OnDispose();
            DisposePoolElement?.Invoke(this);
        }

        public void Show()
        {
            OnShow();
        }

        public virtual void OnDispose() { }

        public virtual void OnShow() { }
    }
}