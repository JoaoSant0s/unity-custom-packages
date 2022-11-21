/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.Screens
{
    [CreateAssetMenu(fileName = "ScreenConfig", menuName = "JoaoSant0s/ServicePackage/Screen/ScreenConfig")]
    public class ScreenConfig : CustomScriptableObject<ScreenConfig>
    {
        [Header("Screen Config")]
        public bool debugLog = true;
        public BaseScreen[] screenPrefabs;
    }
}
