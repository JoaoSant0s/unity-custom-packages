/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Canvases
{
    [CreateAssetMenu(fileName = "CanvasConfig", menuName = "JoaoSant0s/ServicePackage/Canvas/CanvasConfig")]
    public class CanvasConfig : CustomScriptableObject<CanvasConfig>
    {
        [SerializeField] 
        Canvas defaultCanvasPrefab;

        [SerializeField] 
        List<CanvasInfo> canvasInfos;

        public Canvas DefaultCanvasPrefab => defaultCanvasPrefab;

        public List<CanvasInfo> CanvasInfos => canvasInfos;

        public string[] Ids { get; private set; }

        #region Unity Methods

        private void OnValidate()
        {
            Ids = canvasInfos.Select(s => s.id).ToArray();
        }

        #endregion
    }

    [Serializable]
    public struct CanvasInfo
    {
        public string id;
        public int sortOrder;
        public Canvas overrideCanvasPrefab;
    }
}
