using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NUnit.Framework;

namespace JoaoSant0s.CustomVariable.Tests
{
    public class CustomStringVariableTests
    {
        [Test]
        public void CreateIntVariable()
        {
            var stringVariable = ScriptableObject.CreateInstance<StringVariable>();

            Assert.AreEqual(true, stringVariable != null, "The created instance can't be null");
        }

        [Test]
        [TestCase("test")]
        [TestCase("c")]
        [TestCase("-403320")]
        [TestCase("null")]
        public void SetValueOnIntVariable(string testValue)
        {
            var stringVariable = ScriptableObject.CreateInstance<StringVariable>();
            stringVariable.Value = testValue;

            Assert.AreEqual(testValue, stringVariable.Value, "The value must be equals to Setted value");
        }

        [Test]
        [TestCase("test", "test2")]
        [TestCase("c", "casa")]
        [TestCase("-403320", "test")]
        [TestCase("null", null)]
        public void ModifyIntVariableToNewValue(string startValue, string nextValue)
        {
            var stringVariable = ScriptableObject.CreateInstance<StringVariable>();
            stringVariable.Value = startValue;
            stringVariable.AddChangeListener((string previousValue, string newValue) =>
            {
                Assert.AreEqual(nextValue, newValue, "The next value must be equals to new value");
            });

            stringVariable.Value = nextValue;
        }
    }
}
