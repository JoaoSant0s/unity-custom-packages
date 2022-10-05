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

namespace JoaoSant0s.ServicePackage.Popups
{
    public class PopupService : Service
    {
        private RectTransform popupArea;
        private PopupConfig config;
        private Dictionary<Type, int> popupsCounter;
        private Dictionary<Type, Popup> prefabs;

        #region Override Methods

        public override void OnInit()
        {
            config = PopupConfig.Get();
            this.popupsCounter = new Dictionary<Type, int>();
            this.prefabs = config.popupsInfos.ToDictionary(info => info.prefab.GetType(), info => info.prefab);
            this.popupArea = TransformWrapper.FindRectTransformWithTag(config.mainPopupTag);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Instantiate a popup of a specific Type
        /// </summary>        
        public T Show<T>() where T : Popup
        {
            return PreparePopup<T>(this.popupArea);
        }

        /// <summary>
        /// You can pass a Popup prefab reference
        /// </summary>
        /// <param name="popupPrefab"> the basePrefab Popup </param>
        public T Show<T>(T popupPrefab) where T : Popup
        {
            return CreatePopup<T>(popupPrefab, this.popupArea);
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
            return popupsCounter.ContainsKey(typeof(T));
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

            AddPopupCounter<T>();
            popup.OnBeforeClose += () => RemovePopupCounter<T>();
            return popup;
        }

        private void AddPopupCounter<T>() where T : Popup
        {
            var type = typeof(T);
            if (!popupsCounter.ContainsKey(type)) popupsCounter.Add(typeof(T), 0);
            popupsCounter[type] += 1;
        }

        private void RemovePopupCounter<T>() where T : Popup
        {
            var type = typeof(T);
            if (!popupsCounter.ContainsKey(type)) return;

            popupsCounter[type] -= 1;
            if (popupsCounter[type] <= 0) popupsCounter.Remove(type);
        }

        #endregion
    }
}