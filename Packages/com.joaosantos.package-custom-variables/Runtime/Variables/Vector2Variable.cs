using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.CustomVariable
{
    [CreateAssetMenu(fileName = "Vector2Variable", menuName = "JoaoSant0s/CustomVariablePackage/Vector2Variable")]
    public class Vector2Variable : Variable<Vector2>
    {
        #region Public Methods

        public void Add(Vector2 increment)
        {
            Modify(Value + increment);
        }

        public void AddXAxis(float xIncrementValue)
        {
            Modify(Value + new Vector2(xIncrementValue, 0));
        }

        public void AddYAxis(float yIncrementValue)
        {
            Modify(Value + new Vector2(0, yIncrementValue));
        }

        public void SetXAxis(float newXValue)
        {
            Modify(new Vector2(newXValue, Value.y));
        }

        public void SetYAxis(float newYValue)
        {
            Modify(new Vector2(Value.x, newYValue));
        }

        #endregion
    }
}
