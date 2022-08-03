using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "JoaoSant0s/CustomVariablePackage/IntVariable")]
    public class IntVariable : Variable<int>
    {
        #region Public Methods

        public void Increment(int value)
        {
            Value += value;
        }

        #endregion
    }
}
