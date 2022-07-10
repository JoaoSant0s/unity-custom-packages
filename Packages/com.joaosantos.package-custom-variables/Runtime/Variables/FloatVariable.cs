using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "JoaoSant0s/CustomVariablePackage/FloatVariable")]
    public class FloatVariable : Variable<float>
    {
        #region Public Override Methods

        public override void OnModifyImplementation(float newValue)
        {
            Value = newValue;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", typeof(FloatVariable), Value);
        }

        #endregion
    }
}
