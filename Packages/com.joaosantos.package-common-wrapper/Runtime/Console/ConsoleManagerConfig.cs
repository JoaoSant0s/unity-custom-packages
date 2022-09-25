/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.CommonWrapper.Console
{    
    public class ConsoleManagerConfig : CustomScriptableObject<ConsoleManagerConfig>
    {
        [Header("Console Manager Config")]
        public bool IsThreaded;
    }    
}
