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
