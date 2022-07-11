using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "JoaoSant0s/CustomVariablePackage/FloatVariable")]
    public class FloatVariable : Variable<float>
    {
        #region Protected Override Methods

        protected sealed override void OnModify(float newValue)
        {
            Value = newValue;
        }

        #endregion        

        #region Public Methods

        public void Add(float increment)
        {
            Modify(Value + increment);
        }

        #endregion
    }
}
