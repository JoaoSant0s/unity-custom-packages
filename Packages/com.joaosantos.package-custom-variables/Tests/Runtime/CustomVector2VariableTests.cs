using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityAssert = UnityEngine.Assertions.Assert;

using NUnit.Framework;

namespace JoaoSant0s.CustomVariable.Tests
{
    public class CustomVector2VariableTests
    {
        [Test]
        public void CreateVector2Variable()
        {
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();

            Assert.AreEqual(true, vector2Variable != null, "The created instance can't be null");
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-27.4f, 3.3333f)]
        public void SetValueOnVector2Variable(float xValue, float yValue)
        {
            var testValue = new Vector2(xValue, yValue);
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            vector2Variable.Set(testValue);

            Assert.AreEqual(testValue, vector2Variable.Value, "The value must be equals to Setted value");
        }

        [Test]
        [TestCase(123.123f, 0.4f, 0.123f, -0.34424f)]
        [TestCase(88.542f, -22.24f, -4488.542f, 100011.24f)]
        public void ModifyVector2VariableToNewValue(float startXValue, float startYValue, float nextXValue, float nextYValue)
        {
            var startValue = new Vector2(startXValue, startYValue);
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            vector2Variable.Set(startValue);

            var nextValue = new Vector2(nextXValue, nextYValue);
            vector2Variable.OnValueModified += (Vector2 previousValue, Vector2 newValue) =>
            {
                Assert.AreEqual(nextValue, newValue, "The next value must be equals to new value");
            };

            vector2Variable.Modify(nextValue);
        }

        [Test]
        [TestCase(0f, 4f, 4f, 885.20f, 4f, 889.20f)]
        [TestCase(88542f, -22f, 885.20f, -23.8542f, 89427.2f, -45.8542f)]
        [TestCase(-10f, -0.22f, -32f, -32f, -42f, -32.22f)]
        [TestCase(-2.5f, 15f, 10f, -11.1f, 7.5f, 3.9f)]
        public void AddVector2ValueOnVector2Variable(float startXValue, float startYValue, float addXValue, float addYValue, float resultXValue, float resultYValue)
        {
            var testValue = new Vector2(startXValue, startYValue);
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            vector2Variable.Set(testValue);

            var result = new Vector2(resultXValue, resultYValue);
            vector2Variable.OnValueModified += (Vector2 previousValue, Vector2 newValue) =>
            {
                UnityAssert.AreApproximatelyEqual(result.x, newValue.x, "The new X value must be equals the result value");
                UnityAssert.AreApproximatelyEqual(result.y, newValue.y, "The new Y value must be equals the result value");
            };

            var addValue = new Vector2(addXValue, addYValue);
            vector2Variable.Add(addValue);
        }

        [Test]
        [TestCase(0f, 4f, 4f, 4f, 4f)]
        [TestCase(88542f, -22f, 885.2f, 89427.2f, -22f)]
        [TestCase(-10f, -0.22f, -32f, -42f, -0.22f)]
        [TestCase(-2.5f, 15f, 10f, 7.5f, 15f)]
        public void AddXValueOnVector2Variable(float startXValue, float startYValue, float addXValue, float resultXValue, float resultYValue)
        {
            var testValue = new Vector2(startXValue, startYValue);
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            vector2Variable.Set(testValue);

            var result = new Vector2(resultXValue, resultYValue);
            vector2Variable.OnValueModified += (Vector2 previousValue, Vector2 newValue) =>
            {
                UnityAssert.AreApproximatelyEqual(result.x, newValue.x, "The new X value must be equals the result value");
                UnityAssert.AreApproximatelyEqual(result.y, newValue.y, "The new Y value must be equals the result value");
            };

            vector2Variable.AddXAxis(addXValue);
        }

        [Test]
        [TestCase(0f, 4f, 4f, 0f, 8f)]
        [TestCase(88542f, -22f, 885.2f, 88542f, 863.2f)]
        [TestCase(-10f, -0.22f, -32f, -10f, -32.22f)]
        [TestCase(-2.5f, 15f, 10f, -2.5f, 25f)]
        public void AddYValueOnVector2Variable(float startXValue, float startYValue, float addYValue, float resultXValue, float resultYValue)
        {
            var testValue = new Vector2(startXValue, startYValue);
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            vector2Variable.Set(testValue);

            var result = new Vector2(resultXValue, resultYValue);
            vector2Variable.OnValueModified += (Vector2 previousValue, Vector2 newValue) =>
            {
                UnityAssert.AreApproximatelyEqual(result.x, newValue.x, "The new X value must be equals the result value");
                UnityAssert.AreApproximatelyEqual(result.y, newValue.y, "The new Y value must be equals the result value");
            };

            vector2Variable.AddYAxis(addYValue);
        }

        [Test]
        [TestCase(0f, 4f, 4f, 4f, 4f)]
        [TestCase(88542f, -22f, 885.2f, 885.2f, -22f)]
        [TestCase(-10f, -0.22f, -32f, -32f, -0.22f)]
        [TestCase(-2.5f, 15f, 10f, 10f, 15f)]
        public void SetXValueOnVector2Variable(float startXValue, float startYValue, float setXValue, float resultXValue, float resultYValue)
        {
            var testValue = new Vector2(startXValue, startYValue);
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            vector2Variable.Set(testValue);

            var result = new Vector2(resultXValue, resultYValue);
            vector2Variable.OnValueModified += (Vector2 previousValue, Vector2 newValue) =>
            {
                UnityAssert.AreApproximatelyEqual(result.x, newValue.x, "The new X value must be equals the result value");
                UnityAssert.AreApproximatelyEqual(result.y, newValue.y, "The new Y value must be equals the result value");
            };

            vector2Variable.SetXAxis(setXValue);
        }

        [Test]
        [TestCase(0f, 4f, 4f, 0f, 4f)]
        [TestCase(88542f, -22f, 885.2f, 88542f, 885.2f)]
        [TestCase(-10f, -0.22f, -32f, -10f, -32f)]
        [TestCase(-2.5f, 15f, 10f, -2.5f, 10f)]
        public void SetYValueOnVector2Variable(float startXValue, float startYValue, float setYValue, float resultXValue, float resultYValue)
        {
            var testValue = new Vector2(startXValue, startYValue);
            var vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            vector2Variable.Set(testValue);

            var result = new Vector2(resultXValue, resultYValue);
            vector2Variable.OnValueModified += (Vector2 previousValue, Vector2 newValue) =>
            {
                UnityAssert.AreApproximatelyEqual(result.x, newValue.x, "The new X value must be equals the result value");
                UnityAssert.AreApproximatelyEqual(result.y, newValue.y, "The new Y value must be equals the result value");
            };

            vector2Variable.SetYAxis(setYValue);
        }
    }
}
