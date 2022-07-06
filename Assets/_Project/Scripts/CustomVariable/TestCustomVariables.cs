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
        [SerializeField] FloatVariable floatVariable;

        private void Start()
        {
            Debug.Log(floatVariable);
        }
    }
}
