using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.TestTools;

#if UNITY_EDITOR
using UnityEditor;
#endif

using NUnit.Framework;

namespace JoaoSant0s.CustomVariable.Tests
{
    public class CustomVariableInitializationTests
    {
        [Test]
        [TestCase(4f)]
        [TestCase(-4f)]
        [TestCase(-40000f)]
        [TestCase(-1.223f)]
        public void CreateFloatVariableWithValue(float testValue)
        {
            var floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
            floatVariable.value = testValue;

            Assert.AreEqual(testValue, floatVariable.value, "This values must be equals");
        }

        [Test]
        [TestCase(4f, 4f)]
        [TestCase(-22.24f, -22.24f)]
        public void TwoDiferentFloatVariablesAreNotEquals(float firstValue, float secondValue)
        {
            var firstVariable = ScriptableObject.CreateInstance<FloatVariable>();
            firstVariable.value = firstValue;

            var secondVariable = ScriptableObject.CreateInstance<FloatVariable>();
            secondVariable.value = secondValue;

            Assert.AreNotEqual(true, firstVariable == secondVariable, "Two different FloatVariables must be differents");
        }

        [Test]
        [TestCase(4f)]
        [TestCase(-22.24f)]
        public void TwoEqualsFloatVariablesAreEquals(float testValue)
        {
            var firstVariable = ScriptableObject.CreateInstance<FloatVariable>();
            firstVariable.value = testValue;

            var secondVariable = firstVariable;

            Assert.AreEqual(true, firstVariable == secondVariable, "The same FloatVariable references are equals");
        }
    }
}
