using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Popup
{
    public abstract partial class BasePopup : MonoBehaviour
    {
        public UnityAction OnBeforeHide;

        private CanvasGroup canvasGroup;

        protected virtual void Awake()
        {
            this.canvasGroup = GetComponent<CanvasGroup>();
        }

        protected virtual void BeforeHide()
        {
            OnBeforeHide?.Invoke();
        }

        public virtual void Hide()
        {
            Close();
        }

        private void Close()
        {
            BeforeHide();

            Destroy(gameObject);
        }
    }
}