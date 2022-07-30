using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace JoaoSant0s.CommonWrapper
{
    public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Button Hold")]
        [SerializeField]
        protected UnityEvent downEvent;

        [SerializeField]
        protected UnityEvent holdEvent;

        [SerializeField]
        protected UnityEvent upEvent;

        protected bool isPressed;

        public UnityEvent OnDownEvent => downEvent;
        public UnityEvent OnHoldEvent => holdEvent;
        public UnityEvent OnUpEvent => upEvent;
        public bool IsPressed => isPressed;

        #region Unity Implementations Methods

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            downEvent?.Invoke();
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            ReleaseHold();
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            OnUpdateSelected();
        }

        #endregion

        #region UI Methods

        public void SetNotPressed()
        {
            ReleaseHold();
        }

        #endregion

        #region Private Methods

        private void ReleaseHold()
        {
            isPressed = false;
            upEvent?.Invoke();
        }

        private void OnUpdateSelected()
        {
            if (!isPressed) return;

            holdEvent?.Invoke();
        }

        #endregion

    }
}
