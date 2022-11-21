/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Canvases
{
    public class CanvasService : Service
    {
        private CanvasConfig config;

        private Dictionary<string, Canvas> canvases;

        #region Override Methods

        public override void OnInit()
        {
            config = CanvasConfig.Get();
            this.canvases = new Dictionary<string, Canvas>();
            CreateCanvases();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get Canvas by id
        /// </summary>     
        /// <param name="canvasId"> the id of the Canvas </param>

        public Canvas GetCanvas(string canvasId)
        {
            Debug.Assert(this.canvases.ContainsKey(canvasId), $"Can't found a Canvas with id {canvasId}");
            return this.canvases[canvasId];
        }

        #endregion

        #region Private Methods

        private void CreateCanvases()
        {
            foreach (var info in config.CanvasInfos)
            {
                var prefab = info.overrideCanvasPrefab != null ? info.overrideCanvasPrefab : config.DefaultCanvasPrefab;
                var canvas = Instantiate(prefab, transform);
                canvas.name += $" - {info.id}";
                canvases.Add(info.id, canvas);
            }
        }

        #endregion

    }
}
