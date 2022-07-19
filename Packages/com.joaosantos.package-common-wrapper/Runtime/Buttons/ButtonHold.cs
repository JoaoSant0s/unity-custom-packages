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
        [SerializeField]
        private UnityEvent downEvent;

        [SerializeField]
        private UnityEvent holdEvent;

        [SerializeField]
        private UnityEvent upEvent;

        private bool isPressed;

        public UnityEvent onHoldEvent => holdEvent;

        private void OnValidate()
        {
            CheckButtonUse();
        }

        #region Unity Methods        

        public void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            downEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
            upEvent?.Invoke();
        }

        private void Update()
        {
            OnUpdateSelected();
        }

        #endregion

        #region UI Methods

        public void SetNotPressed()
        {
            Reset();
        }

        #endregion


        #region Private Methods

        private void CheckButtonUse()
        {
            if (!GetComponent<Button>()) return;

            Debug.LogError("The Component don't need a button. Just use a simple Image the RayCast Target Enabled");
        }

        private void Reset()
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
