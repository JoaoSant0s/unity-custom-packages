/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.Extensions.Transforms;

namespace JoaoSant0s.CommonWrapper
{
    public static class TransformWrapper
    {
        public static Transform FindTransformWithTag(string tagName)
        {
            var popupObjectArea = GameObject.FindGameObjectWithTag(tagName);

            return popupObjectArea.transform;
        }

        public static RectTransform FindRectTransformWithTag(string tagName)
        {
            return (RectTransform)FindTransformWithTag(tagName);
        }

        /// <summary>
        /// Get the nearest transform from a list of transforms
        /// </summary>
        /// <param name="reference"> base transform to be comparable </param>
        /// <param name="list"> the list of comparable transforms </param>
        public static Transform GetNearestElement(Transform reference, List<Transform> list)
        {
            if (list.Count == 0) return null;

            var minDistance = float.MaxValue;
            Transform nearestElement = null;

            for (int i = 0; i < list.Count; i++)
            {
                float distance = reference.Distance(list[i].transform);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestElement = list[i].transform;
                }
            }

            return nearestElement;
        }

        /// <summary>
        /// Get the nearest transform from a list of transforms inside a container
        /// </summary>
        /// <param name="reference"> base transform to be comparable </param>
        /// <param name="list"> the list of comparable transforms </param>
        /// <param name="container"> the width and height that comparable transform must be inside </param>
        public static Transform GetNearestElement(Transform reference, List<Transform> list, Vector2 container)
        {
            if (list.Count == 0) return null;

            var minDistance = float.MaxValue;
            Transform nearestElement = null;

            for (int i = 0; i < list.Count; i++)
            {
                var element = list[i].transform;

                float distance = reference.Distance(element);

                if (!UtilWrapper.ContainsAPoint(reference.position, element.position, container)) continue;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestElement = element;
                }
            }

            return nearestElement;
        }
    }
}