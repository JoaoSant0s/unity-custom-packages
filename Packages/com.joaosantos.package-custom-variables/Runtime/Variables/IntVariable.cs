using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using JoaoSant0s.CustomVariable;

namespace JoaoSant0s.CustomVariable
{
    public class IntVariable : Variable<int>
    {
        #region Protected Override Methods

        protected sealed override void OnModify(int newValue)
        {
            Value = newValue;
        }

        #endregion

        #region Public Override Methods

        public override string ToString()
        {
            return string.Format("{0} {1}", typeof(IntVariable), Value);
        }

        #endregion

        #region Public Methods

        public void Add(int increment)
        {
            Modify(Value + increment);
        }

        #endregion
    }
}
