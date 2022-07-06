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
        public override string ToString()
        {
            return string.Format("{0} {1}", typeof(FloatVariable), value);
        }
    }
}
