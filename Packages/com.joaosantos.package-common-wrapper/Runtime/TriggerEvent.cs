/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.CommonWrapper
{
    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent events;

        #region Events Methods

        public virtual void OnTrigger()
        {
            events?.Invoke();
        }

        #endregion

    }
}