/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

using JoaoSant0s.Extensions.Transforms;

namespace JoaoSant0s.CommonWrapper
{
    public static class UtilWrapper
    {
        /// <summary>
        /// Check if the input is over a UI element of type T        
        /// </summary>        
        public static bool IsPointOverUIObject<T>()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

            eventDataCurrentPosition.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            results = results.FindAll(r => r.gameObject.GetComponent<T>() == null);

            return results.Count > 0;
        }

        /// <summary>
        /// Check if the input is over a any UI element
        /// </summary>
        public static bool IsPointOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

            eventDataCurrentPosition.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            return results.Count > 0;
        }

        /// <summary>
        /// Return a list of RaycastResult objects after a input interaction
        /// </summary>
        public static List<RaycastResult> GetUIObjectsOverPoint()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

            eventDataCurrentPosition.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            return results;
        }

        /// <summary>
        /// Check if the Transforms distance is less that a value
        /// </summary>
        /// <param name="baseTransform"> base transform to compare </param>
        /// <param name="nextTransform"> next transform to compare </param>
        /// <param name="distance"> the comparable distance </param>
        public static bool IsDistanceLessThan(Transform baseTransform, Transform nextTransform, float distance)
        {
            if (distance < 0) return true;

            return baseTransform.Distance(nextTransform) < distance;
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

        /// <summary>
        /// Adding extra "0" on positive numbers between 0 and 9
        /// Eg: PositiveNumberFormat(9) => "09"
        /// Eg: PositiveNumberFormat(3) => "03"
        /// </summary>
        /// <param name="reference"> base vector2 to be comparable </param>
        /// <param name="list"> the list of comparable vectors2 </param>
        public static string PositiveNumberFormat(int value)
        {
            var convert = value.ToString();

            if (convert.Length == 1) convert = "0" + convert;

            return convert;
        }
    }
}