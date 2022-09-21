/*
Copyright (c) 2022, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    public abstract class Variable<T> : ScriptableObject
    {
        [SerializeField]
        private T startValue;

        public T Value
        {
            get => VariableWrapper<T>.GetValue(this, startValue);
            set => VariableWrapper<T>.SetValue(this, value);
        }

        #region Public Override Methods

        public override string ToString()
        {
            return string.Format("{0}: Value = {1}", this.GetType(), Value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a Change Listiner to the Variable
        /// </summary>
        /// <param name="onChange"> the event that will be triggered if a value was updated </param>

        public void AddChangeListener(Action<T, T> onChange)
        {
            CheckInitialized();
            VariableWrapper<T>.AddListener(this, onChange);
        }

        /// <summary>
        /// Remove a Change Listiner of the Variable
        /// </summary>
        /// <param name="onChange"> the event that was previously added </param>

        public void RemoveChangeListener(Action<T, T> onChange)
        {
            VariableWrapper<T>.RemoveListener(this, onChange);
        }

        #endregion

        #region Private Methods

        private void CheckInitialized()
        {
            VariableWrapper<T>.SetIfUninitialized(this, startValue);
        }

        #endregion
    }
}
