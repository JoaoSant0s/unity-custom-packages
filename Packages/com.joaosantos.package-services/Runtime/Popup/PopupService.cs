/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Linq;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.General;
using System;
using System.Collections.Generic;
using JoaoSant0s.ServicePackage.Canvases;

namespace JoaoSant0s.ServicePackage.Popups
{
    public class PopupService : Service
    {
        private Canvas popupArea;
        private PopupConfig config;
        private Dictionary<Type, List<Popup>> instantiatedPopups;
        private Dictionary<Type, Popup> prefabs;

        #region Override Methods

        public override void OnInit()
        {
            var canvasService = Services.Get<CanvasService>();
            config = PopupConfig.Get();
            this.instantiatedPopups = new Dictionary<Type, List<Popup>>();
            this.prefabs = config.popupsInfos.ToDictionary(info => info.prefab.GetType(), info => info.prefab);
            this.popupArea = canvasService.GetCanvas(config.mainPopupTag);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Instantiate a popup of a specific Type
        /// </summary>        
        public T Show<T>() where T : Popup
        {
            Debug.Assert(this.popupArea, $"Can't found the Popup area of tag: {config.mainPopupTag}");
            return PreparePopup<T>((RectTransform)this.popupArea.transform);
        }

        /// <summary>
        /// You can pass a Popup prefab reference
        /// </summary>
        /// <param name="popupPrefab"> the basePrefab Popup </param>
        public T Show<T>(T popupPrefab) where T : Popup
        {
            Debug.Assert(this.popupArea, $"Can't found the Popup area of tag: {config.mainPopupTag}");
            return CreatePopup<T>(popupPrefab, (RectTransform)this.popupArea.transform);
        }

        /// <summary>
        /// Instantiate a popup of a specific Type
        /// </summary>
        /// <param name="popupArea"> parent of the popup </param>
        public T Show<T>(RectTransform popupArea) where T : Popup
        {
            return PreparePopup<T>(popupArea);
        }

        /// <summary>
        /// You can pass a Popup prefab reference
        /// </summary>
        /// <param name="popupPrefab"> the basePrefab Popup </param>
        /// <param name="popupArea"> parent of the popup </param>
        public T Show<T>(T popupPrefab, RectTransform popupArea) where T : Popup
        {
            return CreatePopup<T>(popupPrefab, popupArea);
        }

        /// <summary>
        /// Check if the popup of type T is a instance
        /// </summary>
        public bool IsOpened<T>() where T : Popup
        {
            return instantiatedPopups.ContainsKey(typeof(T));
        }

        /// <summary>
        /// Get all the popup instances of type T
        /// </summary>
        public List<T> GetOpenedPopups<T>() where T : Popup
        {
            var type = typeof(T);
            return instantiatedPopups.ContainsKey(type) ? instantiatedPopups[type].Select(popup => (T)popup).ToList() : new List<T>();
        }        

        #endregion

        #region Private Methods

        private T PreparePopup<T>(RectTransform popupArea) where T : Popup
        {
            var type = typeof(T);
            Debug.Assert(this.prefabs.ContainsKey(type), string.Format("The pop-up {0} wasn't found inside the PopupConfig", typeof(T)));

            return CreatePopup<T>(this.prefabs[type], popupArea);
        }

        private T CreatePopup<T>(Popup popupPrefab, RectTransform popupArea) where T : Popup
        {
            T popup = Instantiate((T)popupPrefab, popupArea, false);

            AddPopupCounter<T>(popup);
            popup.OnBeforeClose += () => RemovePopupCounter<T>(popup);
            return popup;
        }

        private void AddPopupCounter<T>(T popup) where T : Popup
        {
            var type = typeof(T);
            if (!instantiatedPopups.ContainsKey(type)) instantiatedPopups.Add(typeof(T), new List<Popup>());
            instantiatedPopups[type].Add(popup);
        }

        private void RemovePopupCounter<T>(T popup) where T : Popup
        {
            var type = typeof(T);
            if (!instantiatedPopups.ContainsKey(type)) return;

            instantiatedPopups[type].Remove(popup);
            if (instantiatedPopups[type].Count <= 0) instantiatedPopups.Remove(type);
        }

        #endregion
    }
}