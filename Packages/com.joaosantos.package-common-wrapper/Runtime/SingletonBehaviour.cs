using System.Collections;
using System.Collections.Generic;
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