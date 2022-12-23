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

        public static T Get()
        {
            if (instance == null) SearchOrCreateInstance();
            return instance;
        }

        #endregion

        #region Private Methods

        private static void SearchOrCreateInstance()
        {
            var found = Resources.LoadAll<T>("/");

            Debug.Assert(found.Length != 0, $"You must first create an asset of type {typeof(T).Name}. Place inside a Resources folder.");

            instance = found.OrderByDescending(o => o.priority).First();
        }
        #endregion

    }
}
