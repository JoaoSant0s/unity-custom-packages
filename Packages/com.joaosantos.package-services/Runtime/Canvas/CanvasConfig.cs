using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
using System;

namespace JoaoSant0s.ServicePackage.Canvases
{
    [CreateAssetMenu(fileName = "CanvasConfig", menuName = "JoaoSant0s/ServicePackage/Canvas/CanvasConfig")]
    public class CanvasConfig : CustomScriptableObject<CanvasConfig>
    {
        [SerializeField] Canvas defaultCanvasPrefab;

        [SerializeField] List<CanvasInfo> canvasInfos;

        public Canvas DefaultCanvasPrefab => defaultCanvasPrefab;

        public List<CanvasInfo> CanvasInfos => canvasInfos;
    }

    [Serializable]
    public struct CanvasInfo
    {
        public string id;
        public Canvas overrideCanvasPrefab;
    }
}
