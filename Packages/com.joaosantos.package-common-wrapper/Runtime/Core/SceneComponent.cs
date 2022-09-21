using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.Scene
{
    public abstract class SceneComponent : MonoBehaviour
    {
        public virtual void Initialize()
        {
            Debug.LogError("This method must be implemented to work");
        }
    }
}