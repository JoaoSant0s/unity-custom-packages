using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Pool
{
    public class PoolBase : MonoBehaviour
    {
        public delegate void OnHidePoolElement(PoolBase element);
        public OnHidePoolElement HidePoolElement;

        public void Hide()
        {
            OnHide();
            HidePoolElement?.Invoke(this);
        }

        public void Show()
        {
            OnShow();
        }

        public virtual void OnHide() { }

        public virtual void OnShow() { }
    }
}