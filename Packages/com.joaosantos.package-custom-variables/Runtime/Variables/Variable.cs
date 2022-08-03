using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    public abstract class Variable<T> : ScriptableObject
    {
        /// <summary>
        /// The action is triggered after the value is Modified. Parameters: [0] Previous Value ; [1] New Value
        /// </summary>
        public event Action<T, T> OnValueModified;

        [SerializeField]
        private T value;

        public T Value
        {
            get => this.value;
            protected set => this.value = value;
        }

        #region Public Override Methods

        public override string ToString()
        {
            return string.Format("{0}: Value = {1}", this.GetType(), Value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Assign the Custom Variable with a new value.
        /// </summary>
        /// <param name="newValue"> the new value to be assign to Custom Variable </param>
        public void Set(T newValue)
        {
            value = newValue;
        }

        /// <summary>
        /// Assign the Custom Variable with a new value. Trigger OnValueModified Action
        /// </summary>
        /// <param name="newValue"> the new value to be assign to Custom Variable </param>
        public void Modify(T newValue)
        {
            var previousValue = Value;
            Value = newValue;
            OnValueModified?.Invoke(previousValue, newValue);
        }

        #endregion
    }
}
