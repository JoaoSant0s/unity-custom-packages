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

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.Screens
{
    public class ScreenService : Service
    {
        public event Action<BaseScreen, BaseScreen> OnScreenChanged;

        private Canvas screenArea;

        private BaseScreen current;
        private BaseScreen previous;

        public BaseScreen CurrentScreen => current;
        private ScreenConfig config;
        private Dictionary<Type, BaseScreen> prefabs;

        #region Override Methods

        public override void OnInit()
        {
            var canvasService = Services.Get<CanvasService>();

            config = ScreenConfig.Get();
            this.prefabs = config.screensInfos.ToDictionary(info => info.prefab.GetType(), info => info.prefab);            
            this.screenArea = canvasService.GetCanvas(config.mainScreenTag);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Instantiate a new BaseScreen of type T, replacing the previous BaseScreen
        /// </summary>       
        public T GoToScreen<T>() where T : BaseScreen
        {
            Debug.Assert(this.screenArea, $"Can't found the Screen area of tag: {config.mainScreenTag}");
            return PrepareScreen<T>((RectTransform)this.screenArea.transform);
        }

        /// <summary>
        /// Instantiate a new BaseScreen of type T, replacing the previous BaseScreen
        /// </summary>
        /// <param name="screenArea"> selecting a specific screen area </param>
        public T GoToScreen<T>(RectTransform screenArea) where T : BaseScreen
        {
            return PrepareScreen<T>(screenArea);
        }

        /// <summary>
        /// Closing the current screen
        /// </summary>
        public void CloseScreen()
        {
            current?.Release();

            current = null;
            previous = null;
        }

        #endregion

        #region Private Methods

        private T PrepareScreen<T>(RectTransform area) where T : BaseScreen
        {
            var type = typeof(T);
            if (current is T) return current as T;

            Debug.Assert(this.prefabs.ContainsKey(type), string.Format("No prefab for screen of type {0}", type.Name));

            previous = current;
            if (config.debugLog) Debug.Log($"Moving {previous?.GetType()} to {typeof(T)}");
            current = Instantiate<T>(this.prefabs[type] as T, area, false);

            current.Prepare();
            previous?.Release();

            OnScreenChanged?.Invoke(previous, current);

            return current as T;
        }

        #endregion

    }
}
