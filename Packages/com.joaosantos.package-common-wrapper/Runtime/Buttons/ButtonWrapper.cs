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
    public class ButtonWrapper : MonoBehaviour
    {
        [Header("Button Wrapper")]
        [SerializeField]
        protected ButtonTuple[] buttons;

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
