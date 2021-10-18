using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.ServicePackage.General
{
    public class Service : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Init();
        }

        protected virtual void Init() { }

        public virtual void Reset() { }
    }
}