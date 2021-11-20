using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.ServicePackage.Save
{
    [Serializable]
    internal class IntValue
    {
        public int value;

        public IntValue(int newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class FloatValue
    {
        public float value;

        public FloatValue(float newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class BoolValue
    {
        public bool value;

        public BoolValue(bool newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class DoubleValue
    {
        public double value;

        public DoubleValue(double newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class Vector2Value
    {
        public Vector2 value;

        public Vector2Value(Vector2 newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class Vector3Value
    {
        public Vector3 value;

        public Vector3Value(Vector3 newValue)
        {
            value = newValue;
        }
    }
}
