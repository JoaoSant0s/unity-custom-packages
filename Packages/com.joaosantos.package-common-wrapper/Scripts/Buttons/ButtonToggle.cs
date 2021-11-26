using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace JoaoSant0s.CommonWrapper
{
    [RequireComponent(typeof(Button))]
    public class ButtonToggle : MonoBehaviour
    {
        [Header("Sprites")]

        [SerializeField]
        private Sprite spriteOn;

        [SerializeField]
        private Sprite spriteOff;

        private Button button;
        private bool toggleState;

        #region Unity Methods
        protected virtual void Awake()
        {
            this.button = GetComponent<Button>();
            this.button.onClick.AddListener(OnToggleButton);
        }

        #endregion        

        #region Private Methods
        private void OnToggleButton()
        {
            this.toggleState = !this.toggleState;
            SetButtonState(this.toggleState);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set button Action
        /// </summary>
        /// <param name="action"> the action to be toggled </param>
        public void SetButtonAction(UnityAction action)
        {
            this.button.onClick.AddListener(action);
        }

        /// <summary>
        /// Remove button Action
        /// </summary>
        /// <param name="id"> the action to be removed </param>
        public void RemoveButtonAction(UnityAction action)
        {
            this.button.onClick.RemoveListener(action);
        }

        /// <summary>
        /// Set button state visual
        /// </summary>
        /// <param name="value"> value state </param>
        public void SetButtonState(bool value)
        {
            this.toggleState = value;            

            this.button.image.sprite = this.toggleState ? this.spriteOn : this.spriteOff;
        }

        #endregion
    }
}