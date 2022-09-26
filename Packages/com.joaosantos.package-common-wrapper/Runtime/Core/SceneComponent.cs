/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.CommonWrapper.Scenes
{
    public abstract class SceneComponent : MonoBehaviour
    {
        public virtual void Initialize()
        {
            Debug.LogError("This method must be implemented to work");
        }
    }
}