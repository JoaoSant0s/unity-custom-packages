/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

namespace JoaoSant0s.CommonWrapper
{
    public static class RaycastPointerWrapper
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
    }
}