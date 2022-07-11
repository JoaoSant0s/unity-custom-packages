using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "JoaoSant0s/CustomVariablePackage/StringVariable")]
    public class StringVariable : Variable<string>
    {
        #region Protected Override Methods

        protected sealed override void OnModify(string newValue)
        {
            Value = newValue;
        }

        #endregion
    }
}
