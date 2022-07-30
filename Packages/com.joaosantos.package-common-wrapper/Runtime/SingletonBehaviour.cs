using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.CommonWrapper
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        protected static T instance = null;

        public static T Instance => instance;

        protected abstract bool IsDontDestroyOnLoad { get; }

        protected virtual void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = GetComponent<T>();
                if (IsDontDestroyOnLoad) DontDestroyOnLoad(gameObject);
            }
        }
    }
}