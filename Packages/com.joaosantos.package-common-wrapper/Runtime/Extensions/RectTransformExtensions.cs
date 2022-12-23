using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.Extensions.RectTransforms
{
    public static class RectTransformExtensions
    {
        /// <summary>
        /// Increment the anchored y position by a value
        /// </summary>
        /// <param name="yAxis"> the value that will increment </param>
        public static void IncrementAnchoredPositionY(this RectTransform transform, float yAxis)
        {
            transform.anchoredPosition += new Vector2(0, yAxis);
        }

        /// <summary>
        /// Set the anchored y position by a value
        /// </summary>
        /// <param name="yAxis"> the value that will be set </param>
        public static void SetAnchoredPositionY(this RectTransform transform, float yAxis)
        {
            transform.anchoredPosition = new Vector2(transform.anchoredPosition.x, yAxis);
        }

        /// <summary>
        /// Increment the anchored x position by a value
        /// </summary>
        /// <param name="xAxis"> the value that will increment </param>
        public static void IncrementAnchoredPositionX(this RectTransform transform, float xAxis)
        {
            transform.anchoredPosition += new Vector2(xAxis, 0);
        }

        /// <summary>
        /// Set the anchored x position by a value
        /// </summary>
        /// <param name="xAxis"> the value that will be set </param>
        public static void SetAnchoredPositionX(this RectTransform transform, float xAxis)
        {
            transform.anchoredPosition = new Vector2(xAxis, transform.anchoredPosition.y);
        }
    }
}
