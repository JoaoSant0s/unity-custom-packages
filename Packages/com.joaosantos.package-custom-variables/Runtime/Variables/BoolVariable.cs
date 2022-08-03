using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "JoaoSant0s/CustomVariablePackage/BoolVariable")]

    public class BoolVariable : Variable<bool>
    {
        #region Public Methods

        public void OperationAnd(bool value)
        {
            Value &= value;
        }

        public void OperationOr(bool value)
        {
            Value |= value;
        }

        #endregion
    }
}
