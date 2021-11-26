using System.Collections;
using System.Collections.Generic;
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
        /// Set the Z position from a transform, maintaining the X and Y axis
        /// </summary>
        /// <param name="zAxis"> Z Axis </param>
        public static void SetPositionZ(this Transform main, float zAxis)
        {
            main.position = new Vector3(main.position.x,  main.position.y, zAxis);
        }

    }
}
