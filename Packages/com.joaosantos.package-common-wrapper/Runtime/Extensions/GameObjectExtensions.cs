/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.Extensions.GameObjects
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Check if the gameObject has a Component
        /// </summary>
        public static bool HasComponent<T>(this GameObject gameObject)
        {
            return gameObject.GetComponent<T>() != null;
        }
    }
}
