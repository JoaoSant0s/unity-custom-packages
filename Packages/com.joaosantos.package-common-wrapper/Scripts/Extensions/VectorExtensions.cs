using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JoaoSant0s.Extensions.Vectors
{
    public static class VectorExtensions
    {
        #region Vector 2

        /// <summary>
        /// Generate a random Vector 2
        /// </summary>
        /// <param name="min"> minimum value </param>
        /// <param name="max"> maximum value </param>
        public static Vector2 RandomVector2(float min, float max)
        {
            return new Vector2(Random.Range(min, max), Random.Range(min, max));
        }

        /// <summary>
        /// Generate a random Vector 2
        /// </summary>
        /// <param name="xMin"> X minimum value </param>
        /// <param name="xMax"> X maximum value </param>
        /// <param name="yMin"> Y minimum value </param>
        /// <param name="yMax"> Y maximum value </param>
        public static Vector2 RandomVector2(float xMin, float xMax, float yMin, float yMax)
        {
            return new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        }

        /// <summary>
        /// Negate vector
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
        /// Generate a random Vector 3
        /// </summary>
        /// <param name="min"> minimum value </param>
        /// <param name="max"> maximum value </param>
        public static Vector3 RandomVector3(float min, float max)
        {
            return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
        }

        /// <summary>
        /// Generate a random Vector 3
        /// </summary>
        /// <param name="xMin"> X minimum value </param>
        /// <param name="xMax"> X maximum value </param>
        /// <param name="yMin"> Y minimum value </param>
        /// <param name="yMax"> Y maximum value </param>
        /// <param name="zMin"> Z minimum value </param>
        /// <param name="zMax"> Z maximum value </param>
        public static Vector3 RandomVector3(float xMin, float xMax, float yMin, float yMax, float zMin, float zMax)
        {
            return new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
        }

        /// <summary>
        /// Negate vector
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
