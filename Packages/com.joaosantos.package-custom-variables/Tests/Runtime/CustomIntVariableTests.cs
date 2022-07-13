using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NUnit.Framework;

namespace JoaoSant0s.CustomVariable.Tests
{
    public class CustomIntVariableTests
    {
        [Test]
        public void CreateIntVariable()
        {
            var intVariable = ScriptableObject.CreateInstance<IntVariable>();            

            Assert.AreEqual(true, intVariable != null, "The created instance can't be null");
        }

        [Test]
        [TestCase(4)]
        [TestCase(-4)]
        [TestCase(-403320)]
        [TestCase(-123)]
        public void SetValueOnIntVariable(int testValue)
        {
            var intVariable = ScriptableObject.CreateInstance<IntVariable>();
            intVariable.Set(testValue);

            Assert.AreEqual(testValue, intVariable.Value, "The value must be equals to Setted value");
        }

        [Test]
        [TestCase(12323, 0)]
        [TestCase(8842, -2224)]
        public void ModifyIntVariableToNewValue(int startValue, int nextValue)
        {
            var intVariable = ScriptableObject.CreateInstance<IntVariable>();
            intVariable.Set(startValue);
            intVariable.OnValueModified += (int previousValue, int newValue) =>
            {
                Assert.AreEqual(nextValue, newValue, "The next value must be equals to new value");
            };

            intVariable.Modify(nextValue);
        }

        [Test]
        [TestCase(0, 4, 4)]
        [TestCase(88542, -22, 88520)]
        [TestCase(-10, -22, -32)]
        [TestCase(-25, 15, -10)]
        public void AddValueOnIntVariable(int startValue, int addValue, int result)
        {
            var intVariable = ScriptableObject.CreateInstance<IntVariable>();
            intVariable.Set(startValue);

            intVariable.OnValueModified += (int previousValue, int newValue) =>
            {
                Assert.AreEqual(result, newValue, "The new Value must be equals the result value");
            };

            intVariable.Add(addValue);
        }

    }
}
