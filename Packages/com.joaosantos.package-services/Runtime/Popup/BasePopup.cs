using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Popup
{
    public abstract class BasePopup : MonoBehaviour
    {
        public Action OnBeforeClose;

        protected virtual void BeforeClose() { }

        public virtual void Close()
        {
            BeforeClose();
            OnBeforeClose?.Invoke();

            Destroy(gameObject);
        }
    }
}