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

        protected virtual void Start()
        {
            Begin();
        }

        protected virtual void Init() { }
        
        protected virtual void Begin() { }
    }
}