using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Main.Scene
{
    public class SceneComponent: MonoBehaviour
    {
        public virtual void Initialize()
        {
            Debug.LogError("This method must be implemented to work");
        }
    }
}