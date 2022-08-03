using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using JoaoSant0s.CustomVariable;
using JoaoSant0s.CommonWrapper;

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

            floatVariable.AddChangeListener(OnValueChanged);
            intVariable.AddChangeListener(OnValueChanged);
            stringVariable.AddChangeListener(OnValueChanged);

            floatVariable.Value = 1.1f;
            intVariable.Value = 1;
            stringVariable.Value = "Teste 2";
        }

        private void OnValueChanged(float previous, float newValue)
        {
            Debugs.Log(previous, newValue);
            Debug.Log(floatVariable);
        }

        private void OnValueChanged(int previous, int newValue)
        {
            Debugs.Log(previous, newValue);
            Debug.Log(intVariable);
        }

        private void OnValueChanged(string previous, string newValue)
        {
            Debugs.Log(previous, newValue);
            Debug.Log(stringVariable);
        }
    }
}
