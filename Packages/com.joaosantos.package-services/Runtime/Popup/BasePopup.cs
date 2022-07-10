using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Popup
{
    public abstract partial class BasePopup : MonoBehaviour
    {
        public UnityAction OnBeforeClose;

        protected virtual void BeforeClose() { }

        public virtual void Close()
        {
            BeforeClose();
            OnBeforeClose?.Invoke();

            Destroy(gameObject);
        }
    }
}