/*
Copyright (c) 2022, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "Vector2Variable", menuName = "JoaoSant0s/CustomVariablePackage/Vector2Variable")]
    public class Vector2Variable : Variable<Vector2>
    {
        #region Public Methods

        public void Increment(Vector2 increment)
        {
            Value += increment;
        }

        public void IncrementXAxis(float xIncrementValue)
        {
            Value += new Vector2(xIncrementValue, 0);
        }

        public void IncrementYAxis(float yIncrementValue)
        {
            Value += new Vector2(0, yIncrementValue);
        }

        public void SetXAxis(float newXValue)
        {
            Value = new Vector2(newXValue, Value.y);
        }

        public void SetYAxis(float newYValue)
        {
            Value = new Vector2(Value.x, newYValue);
        }

        #endregion
    }
}
