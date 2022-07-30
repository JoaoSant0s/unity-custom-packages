using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "JoaoSant0s/CustomVariablePackage/BoolVariable")]

    public class BoolVariable : Variable<bool>
    {
        #region Protected Override Methods

        protected override void OnModify(bool newValue)
        {
            Value = newValue;
        }

        #endregion        

        #region Public Methods

        public void OperationAnd(bool value)
        {
            Modify(Value && value);
        }

        public void OperationOr(bool value)
        {
            Modify(Value || value);
        }

        #endregion
    }
}
