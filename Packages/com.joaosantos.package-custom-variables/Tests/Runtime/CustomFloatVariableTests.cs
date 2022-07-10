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
    public class CustomFloatVariableTests
    {
        [Test]
        [TestCase(4f)]
        [TestCase(-4f)]
        [TestCase(-40000f)]
        [TestCase(-1.223f)]
        public void CreateFloatVariableAndSetValue(float testValue)
        {
            var floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
            floatVariable.Set(testValue);

            Assert.AreEqual(testValue, floatVariable.Value, "This values must be equals");
        }

        [Test]
        [TestCase(0f, 4f)]
        [TestCase(88542f, -22.24f)]
        public void ModifyFloatVariablesToNewValue(float startValue, float nextValue)
        {
            var floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
            floatVariable.Set(startValue);
            floatVariable.OnValueModified += (float previousValue, float newValue) =>
            {
                Assert.AreEqual(true, nextValue == newValue, "The next value must be equals to new value");
            };

            floatVariable.Modify(nextValue);
        }
    }
}