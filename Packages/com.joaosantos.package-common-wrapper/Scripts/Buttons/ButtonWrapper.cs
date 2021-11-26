using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JoaoSant0s.CommonWrapper
{
    public class ButtonWrapper : MonoBehaviour
    {
        [SerializeField]
        private ButtonTuple[] buttons;

        #region Public Methods

        /// <summary>
        /// Active a Button on the list based on an id
        /// </summary>
        /// <param name="id"> id of a button </param>
        public void ActiveButton(string id)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Enable(id);
            }
        }

        #endregion
    }

    [Serializable]
    public class ButtonTuple
    {
        public string state;
        public Button button;

        public void Enable(string id)
        {
            button.gameObject.SetActive(id.Equals(this.state));
        }
    }
}
