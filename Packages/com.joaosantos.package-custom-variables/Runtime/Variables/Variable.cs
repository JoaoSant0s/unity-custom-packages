using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace JoaoSant0s.CustomVariable
{
    public abstract class Variable<T> : ScriptableObject
    {
        public event Action<T, T> OnValueModified;

        public T Value { get; protected set; }

        #region Public Abstract Methods

        public abstract void OnModifyImplementation(T newValue);

        #endregion

        #region Public Methods

        public virtual void Set(T newValue)
        {
            Value = newValue;
        }

        public virtual void Modify(T newValue)
        {
            var previous = Value;
            OnModifyImplementation(newValue);
            OnValueModified?.Invoke(previous, Value);
        }

        #endregion
    }
}
