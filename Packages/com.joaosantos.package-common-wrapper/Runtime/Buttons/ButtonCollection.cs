/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;

using UnityEngine;
using UnityEngine.UI;

namespace JoaoSant0s.CommonWrapper
{
    public class ButtonCollection : MonoBehaviour
    {
        [Header("Button Wrapper")]
        [SerializeField]
        protected ButtonTuple[] buttons;

        #region Public Methods

        /// <summary>
        /// Active a Button on the list based on an id and disable the rest
        /// </summary>
        /// <param name="id"> id of a button </param>
        public void ActiveButton(string id)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(id);
            }
        }

        /// <summary>
        /// Make a button Interactable and apply the inverse for the rest
        /// </summary>
        /// <param name="id"> id of a button </param>
        public void SetInteractable(string id)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetInteractable(id);
            }
        }

        #endregion
    }

    [Serializable]
    public class ButtonTuple
    {
        public string id;
        public Button button;

        public void SetActive(string id)
        {
            button.gameObject.SetActive(id.Equals(this.id));
        }

        public void SetInteractable(string id)
        {
            button.interactable = id.Equals(this.id);
        }
    }
}
