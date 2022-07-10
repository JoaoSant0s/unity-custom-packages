using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace JoaoSant0s.CustomVariable
{
    public abstract class Variable<T> : ScriptableObject
    {
        /// <summary>
        /// The action is triggered after the value is Modified. Parameters: [0] Previous Value ; [1] New Value
        /// </summary>
        public event Action<T, T> OnValueModified;

        public T Value { get; protected set; }

        #region Protected Abstract Methods

        protected abstract void OnModify(T newValue);

        #endregion

        #region Public Methods

        /// <summary>
        /// Assign the Custom Variable with a new value.
        /// </summary>
        /// <param name="newValue"> the new value to be assign to Custom Variable </param>
        public virtual void Set(T newValue)
        {
            Value = newValue;
        }

        /// <summary>
        /// Assign the Custom Variable with a new value. Trigger OnValueModified Action
        /// </summary>
        /// <param name="newValue"> the new value to be assign to Custom Variable </param>
        public virtual void Modify(T newValue)
        {
            var previousValue = Value;
            OnModify(newValue);
            OnValueModified?.Invoke(previousValue, Value);
        }

        #endregion
    }
}
