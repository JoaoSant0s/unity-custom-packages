/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

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

            if (found.Length == 0)
            {
#if !UNITY_EDITOR
                Debug.Assert(false, $"You must create the {typeof(T).Name} asset on Unity Editor first");
#else
                instance = CreateDefault();
#endif
            }
            else
            {
                instance = found.OrderByDescending(o => o.priority).First();
            }
        }

#if UNITY_EDITOR
        private static T CreateDefault()
        {
            T result = ScriptableObject.CreateInstance<T>();
            var path = $"Assets/Resources/{typeof(T).Name}.asset";
            if (!AssetDatabase.IsValidFolder("Assets/Resources")) AssetDatabase.CreateFolder("Assets", "Resources");
            AssetDatabase.CreateAsset(result, path);
            Debugs.LogColor($"Asset {typeof(T).Name} was created in the path {path}", Color.green);
            return result;
        }
#endif

        #endregion

    }
}
