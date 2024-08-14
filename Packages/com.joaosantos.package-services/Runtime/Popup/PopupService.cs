/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.Popups
{
    public class PopupService : Service
    {
        private PopupConfig config;
        private Dictionary<Type, List<PopupBehaviour>> instantiatedPopups;
        private Dictionary<Type, PopupBehaviour> prefabs;
        private CanvasService canvasService;

        #region Override Methods

        public override void OnInit()
        {
            config = PopupConfig.Get();
            this.canvasService = Services.Get<CanvasService>();
            this.instantiatedPopups = new Dictionary<Type, List<PopupBehaviour>>();
            this.prefabs = config.popupPrefabs.ToDictionary(prefab => prefab.GetType(), prefab => prefab);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Instantiate a popup of a specific Type
        /// </summary>        
        public T Show<T>() where T : PopupBehaviour
        {
            return PreparePopup<T>();
        }

        /// <summary>
        /// You can pass a Popup prefab reference
        /// </summary>
        /// <param name="popupPrefab"> the basePrefab Popup </param>
        public T Show<T>(T popupPrefab) where T : PopupBehaviour
        {
            return PreparePopup<T>(popupPrefab);
        }

        /// <summary>
        /// Instantiate a popup of a specific Type
        /// </summary>
        /// <param name="overridePopupArea"> override the parent of the popup </param>
        public T Show<T>(RectTransform overridePopupArea) where T : PopupBehaviour
        {
            return PreparePopup<T>(overridePopupArea);
        }

        /// <summary>
        /// You can pass a Popup prefab reference
        /// </summary>
        /// <param name="popupPrefab"> the basePrefab Popup </param>
        /// <param name="overridePopupArea"> override the parent of the popup </param>
        public T Show<T>(T popupPrefab, RectTransform overridePopupArea) where T : PopupBehaviour
        {
            return CreatePopup<T>(popupPrefab, overridePopupArea);
        }

        /// <summary>
        /// Check if the popup of type T is a instance
        /// </summary>
        public bool IsOpened<T>() where T : PopupBehaviour
        {
            return instantiatedPopups.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Get all the popup instances of type T
        /// </summary>
        public List<T> GetOpenedPopups<T>() where T : PopupBehaviour
        {
            var type = typeof(T);
            return instantiatedPopups.ContainsKey(type) ? instantiatedPopups[type].Select(popup => (T)popup).ToList() : new List<T>();
        }

        #endregion

        #region Private Methods

        private T PreparePopup<T>() where T : PopupBehaviour
        {
            var type = typeof(T);
            Debug.Assert(this.prefabs.ContainsKey(type), string.Format("The pop-up {0} wasn't found inside the PopupConfig", typeof(T)));

            var popupPrefab = this.prefabs[type];

            var canvas = this.canvasService.GetCanvas(popupPrefab.CanvasId);
            return CreatePopup<T>(popupPrefab, (RectTransform)canvas.transform);
        }

        private T PreparePopup<T>(PopupBehaviour popupPrefab) where T : PopupBehaviour
        {
            var canvas = this.canvasService.GetCanvas(popupPrefab.CanvasId);
            return CreatePopup<T>(popupPrefab, (RectTransform)canvas.transform);
        }

        private T PreparePopup<T>(RectTransform overridePopupArea) where T : PopupBehaviour
        {
            var type = typeof(T);
            Debug.Assert(this.prefabs.ContainsKey(type), string.Format("The pop-up {0} wasn't found inside the PopupConfig", typeof(T)));

            var popupPrefab = this.prefabs[type];

            return CreatePopup<T>(popupPrefab, overridePopupArea);
        }

        private T CreatePopup<T>(PopupBehaviour popupPrefab, RectTransform popupArea) where T : PopupBehaviour
        {
            T popup = Instantiate((T)popupPrefab, popupArea, false);

            AddPopupCounter<T>(popup);
            popup.OnBeforeClose += () => RemovePopupCounter<T>(popup);
            return popup;
        }

        private void AddPopupCounter<T>(T popup) where T : PopupBehaviour
        {
            var type = typeof(T);
            if (!instantiatedPopups.ContainsKey(type)) instantiatedPopups.Add(typeof(T), new List<PopupBehaviour>());
            instantiatedPopups[type].Add(popup);
        }

        private void RemovePopupCounter<T>(T popup) where T : PopupBehaviour
        {
            var type = typeof(T);
            if (!instantiatedPopups.ContainsKey(type)) return;

            instantiatedPopups[type].Remove(popup);
            if (instantiatedPopups[type].Count == 0) instantiatedPopups.Remove(type);
        }

        #endregion
    }
}