/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.Extensions.Transforms
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Get a distance between two transform elements
        /// </summary>
        /// <param name="reference"> comparable transform element </param>
        public static float Distance(this Transform main, Transform reference)
        {
            return (reference.position - main.position).magnitude;
        }

        /// <summary>
        /// Set the X and Y position from a transform, maintaining the Z-axis
        /// </summary>
        /// <param name="position"> X and Y position </param>
        public static void SetPositionXY(this Transform main, Vector2 position)
        {
            main.position = new Vector3(position.x, position.y, main.position.z);
        }

        /// <summary>
        /// Set the X and Y position from a transform, maintaining the Z-axis
        /// </summary>
        /// <param name="xAxis"> X position value </param>
        /// <param name="yAxis"> Y position value </param>
        public static void SetPositionXY(this Transform main, float xAxis, float yAxis)
        {
            main.position = new Vector3(xAxis, yAxis, main.position.z);
        }

        /// <summary>
        /// Set the Z position from a transform, maintaining the X and Y axis
        /// </summary>
        /// <param name="zAxis"> Z Axis </param>
        public static void SetPositionZ(this Transform main, float zAxis)
        {
            main.position = new Vector3(main.position.x, main.position.y, zAxis);
        }

    }
}
