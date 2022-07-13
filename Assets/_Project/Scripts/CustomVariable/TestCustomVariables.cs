using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using JoaoSant0s.CustomVariable;

namespace Namespace
{
    public class TestCustomVariables : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable floatVariable;

        [SerializeField]
        private IntVariable intVariable;

        [SerializeField]
        private StringVariable stringVariable;

        private void Start()
        {
            Debug.Log(floatVariable);
            Debug.Log(intVariable);
            Debug.Log(stringVariable);
        }
    }
}
