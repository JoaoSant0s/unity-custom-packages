using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "JoaoSant0s/CustomVariablePackage/IntVariable")]
    public class IntVariable : Variable<int>
    {
        #region Protected Override Methods

        protected sealed override void OnModify(int newValue)
        {
            Value = newValue;
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
