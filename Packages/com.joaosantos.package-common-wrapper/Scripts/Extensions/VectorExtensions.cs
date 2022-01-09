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

        /// <summary>
        /// Return a random int within [x..y)
        /// </summary>    
        public static int RandomInterval(this Vector2Int value)
        {
            return Random.Range(value.x, value.y);
        }

        /// <summary>
        /// Return a random float within [x..y)
        /// </summary>    
        public static float RandomInterval(this Vector2 value)
        {
            return Random.Range(value.x, value.y);
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
