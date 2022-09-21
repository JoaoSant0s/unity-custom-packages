/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.CommonWrapper
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        protected static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null) CreateInstance();
                return instance;
            }
        }

        protected abstract bool IsDontDestroyOnLoad { get; }

        protected virtual void Init() { }

        protected static void CreateInstance()
        {
            GameObject obj = new GameObject($"{typeof(T).Name}");

            instance = obj.AddComponent<T>();
            instance.Init();
            if (instance.IsDontDestroyOnLoad) DontDestroyOnLoad(instance);
        }
    }
}