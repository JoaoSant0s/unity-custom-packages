/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Linq;

using UnityEngine;

namespace JoaoSant0s.CommonWrapper
{
    public abstract class CustomScriptableObject<T> : ScriptableObject where T : CustomScriptableObject<T>
    {
        [Header("Custom Scriptable Object")]
        [SerializeField]
        protected int priority = 0;

        protected static T instance;

        #region Public Methods

        /// <summary>
        /// Get and Cache the asset reference
        /// </summary>
        /// <param name="path"> select a custom path to search assets from. The '/' path search inside all Resources folders</param>
        public static T Get(string path = "/")
        {
            if (instance == null) SearchAndCacheInstance(path);
            return instance;
        }

        #endregion

        #region Private Methods

        private static void SearchAndCacheInstance(string path)
        {
            var found = Resources.LoadAll<T>(path);

            Debug.Assert(found.Length != 0, $"You must first create an asset of type {typeof(T).Name}. Place inside a Resources folder.");

            instance = found.OrderByDescending(o => o.priority).First();
        }
        #endregion

    }
}
