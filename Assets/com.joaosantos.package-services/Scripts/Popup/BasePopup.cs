using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using DG.Tweening;

namespace Main.ServicePackage.Popup
{
    public class BasePopup : MonoBehaviour
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

        public void Hide(float duration = 0)
        {
            if (duration == 0)
            {
                Close();
                return;
            }

            this.canvasGroup.DOFade(0, duration).OnComplete(Close);
        }

        private void Close()
        {
            BeforeHide();

            Destroy(gameObject);
        }
    }
}