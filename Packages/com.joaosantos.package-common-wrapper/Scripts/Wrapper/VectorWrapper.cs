using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.CommonWrapper
{
    public class VectorWrapper
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
        /// Get the nearest Vector2 from a list of vectors2
        /// </summary>
        /// <param name="reference"> base vector2 to be comparable </param>
        /// <param name="list"> the list of comparable vectors2 </param>
        public static Vector2 GetNearestVector(Vector2 reference, Vector2[] list)
        {
            var minDistance = float.MaxValue;
            Vector2 nearestElement = reference;

            for (int i = 0; i < list.Length; i++)
            {
                float distance = Vector2.Distance(reference, list[i]);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestElement = list[i];
                }
            }

            return nearestElement;
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

        #endregion
    }
}
