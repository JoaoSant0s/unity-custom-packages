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
        public void CreateFloatVariable(float testValue)
        {
            var floatVariable = ScriptableObject.CreateInstance<FloatVariable>();            

            Assert.AreEqual(true, floatVariable != null, "The created instance can't be null");
        }

        [Test]
        [TestCase(4f)]
        [TestCase(-4f)]
        [TestCase(-40000f)]
        [TestCase(-1.223f)]
        public void SetValueOnFloatVariable(float testValue)
        {
            var floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
            floatVariable.Set(testValue);

            Assert.AreEqual(testValue, floatVariable.Value, "The value must be equals to Setted value");
        }

        [Test]
        [TestCase(0f, 4f)]
        [TestCase(88542f, -22.24f)]
        public void ModifyFloatVariableToNewValue(float startValue, float nextValue)
        {
            var floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
            floatVariable.Set(startValue);
            floatVariable.OnValueModified += (float previousValue, float newValue) =>
            {
                Assert.AreEqual(nextValue, newValue, "The next value must be equals to new value");
            };

            floatVariable.Modify(nextValue);
        }

        [Test]
        [TestCase(0f, 4f, 4f)]
        [TestCase(88542f, -22f, 88520f)]
        [TestCase(-10f, -22f, -32f)]
        [TestCase(-25f, 15f, -10f)]
        public void AddValueOnFloatVariable(float startValue, float addValue, float result)
        {
            var floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
            floatVariable.Set(startValue);

            floatVariable.OnValueModified += (float previousValue, float newValue) =>
            {
                Assert.AreEqual(result, newValue, "The new Value must be equals the result value");
            };

            floatVariable.Add(addValue);
        }
    }
}