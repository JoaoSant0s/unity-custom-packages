/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

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
        /// Generate a random Vector 2 Int
        /// </summary>
        /// <param name="min"> minimum value </param>
        /// <param name="max"> maximum value </param>
        public static Vector2Int RandomVector2(int min, int max)
        {
            return new Vector2Int(Random.Range(min, max), Random.Range(min, max));
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
        /// Generate a random Vector 2 Int
        /// </summary>
        /// <param name="xMin"> X minimum value </param>
        /// <param name="xMax"> X maximum value </param>
        /// <param name="yMin"> Y minimum value </param>
        /// <param name="yMax"> Y maximum value </param>
        public static Vector2Int RandomVector2(int xMin, int xMax, int yMin, int yMax)
        {
            return new Vector2Int(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
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
        /// Generate a random Vector 3 Int
        /// </summary>
        /// <param name="min"> minimum value </param>
        /// <param name="max"> maximum value </param>
        public static Vector3Int RandomVector3(int min, int max)
        {
            return new Vector3Int(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
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
        /// Generate a random Vector 3 Int
        /// </summary>
        /// <param name="xMin"> X minimum value </param>
        /// <param name="xMax"> X maximum value </param>
        /// <param name="yMin"> Y minimum value </param>
        /// <param name="yMax"> Y maximum value </param>
        /// <param name="zMin"> Z minimum value </param>
        /// <param name="zMax"> Z maximum value </param>
        public static Vector3Int RandomVector3Int(int xMin, int xMax, int yMin, int yMax, int zMin, int zMax)
        {
            return new Vector3Int(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
        }

        /// <summary>
        /// Check if a point is inside a other rectangle
        /// </summary>
        /// <param name="centerPoint"> the center point of the rectangle </param>
        /// <param name="nextPoint"> the point that will check if is inside </param>
        /// <param name="area"> the width and height of the rectangle </param>
        public static bool ContainsAPoint(Vector2 centerPoint, Vector2 nextPoint, Vector2 area)
        {
            var checkLeftHorizontal = nextPoint.x >= centerPoint.x - area.x / 2f;
            var checkRightHorizontal = nextPoint.x <= centerPoint.x + area.x / 2f;

            var checkTopVertical = nextPoint.y <= centerPoint.y + area.y / 2f;
            var checkDownVertical = nextPoint.y >= centerPoint.y - area.y / 2f;

            var checkHorizontal = checkLeftHorizontal && checkRightHorizontal;
            var checkVertical = checkTopVertical && checkDownVertical;

            return checkHorizontal && checkVertical;
        }

        #endregion
    }
}
