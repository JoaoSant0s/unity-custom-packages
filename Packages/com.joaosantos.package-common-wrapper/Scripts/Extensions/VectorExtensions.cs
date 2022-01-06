using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoSant0s.Extensions.Vectors
{
    public static class VectorExtensions
    {
        #region Vector 2

        /// <summary>
        /// Negate axis values
        /// </summary>    
        public static Vector2 NegateVector(this Vector2 value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }

        #endregion

        #region Vector 3

        /// <summary>
        /// Negate axis values
        /// </summary>    
        public static Vector3 NegateVector(this Vector3 value)
        {
            value.x = -value.x;
            value.y = -value.y;
            value.z = -value.z;
            return value;
        }

        #endregion
    }
}
