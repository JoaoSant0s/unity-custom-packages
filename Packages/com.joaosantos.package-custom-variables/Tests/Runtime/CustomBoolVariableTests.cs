/*
Copyright (c) 2022, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

using NUnit.Framework;

namespace JoaoSant0s.CustomVariable.Tests
{
    public class CustomBoolVariableTests
    {
        [Test]
        public void CreateBoolVariable()
        {
            var boolVariable = ScriptableObject.CreateInstance<BoolVariable>();

            Assert.AreEqual(true, boolVariable != null, "The created instance can't be null");
        }

        [Test]
        [TestCase(true)]
        [TestCase(true && true)]
        [TestCase(true || false)]
        [TestCase(false && true)]
        public void SetValueOnBoolVariable(bool testValue)
        {
            var boolVariable = ScriptableObject.CreateInstance<BoolVariable>();
            boolVariable.Value = testValue;

            Assert.AreEqual(testValue, boolVariable.Value, "The value must be equals to Setted value");
        }

        [Test]
        [TestCase(true, false)]
        [TestCase(false && true, true)]
        [TestCase(true || (false && true), true)]
        public void ModifyBoolVariableToNewValue(bool startValue, bool nextValue)
        {
            var boolVariable = ScriptableObject.CreateInstance<BoolVariable>();
            boolVariable.Value = startValue;
            boolVariable.AddChangeListener((bool previousValue, bool newValue) =>
            {
                Assert.AreEqual(nextValue, newValue, "The next value must be equals to new value");
            });

            boolVariable.Value = nextValue;
        }

        [Test]
        [TestCase(true, false, false)]
        [TestCase(false && true, true, false)]
        [TestCase(true || (false && true), true, true)]
        public void OperationAndOnBoolVariable(bool startValue, bool operation, bool result)
        {
            var boolVariable = ScriptableObject.CreateInstance<BoolVariable>();
            boolVariable.Value = startValue;
            boolVariable.AddChangeListener((bool previousValue, bool newValue) =>
            {
                Assert.AreEqual(result, newValue, "The next value must be equals to new value");
            });

            boolVariable.OperationAnd(operation);
        }

        [Test]
        [TestCase(true, false, true)]
        [TestCase(false && true, true, true)]
        [TestCase(false && true, false, false)]
        public void OperationOrOnBoolVariable(bool startValue, bool operation, bool result)
        {
            var boolVariable = ScriptableObject.CreateInstance<BoolVariable>();
            boolVariable.Value = startValue;
            boolVariable.AddChangeListener((bool previousValue, bool newValue) =>
            {
                Assert.AreEqual(result, newValue, "The next value must be equals to new value");
            });

            boolVariable.OperationOr(operation);
        }
    }
}
