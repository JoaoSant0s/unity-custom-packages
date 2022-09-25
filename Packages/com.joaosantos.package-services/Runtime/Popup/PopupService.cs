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

namespace JoaoSant0s.ServicePackage.Popup
{
    public class PopupService : Service
    {
        private RectTransform popupArea;

        private PopupConfig config;

        public PopupInfo[] PopupsInfos => config.popupsInfos;

        #region Override Methods

        public override void OnInit()
        {
            config = PopupConfig.Get();
            this.popupArea = TransformWrapper.FindRectTransformWithTag(config.mainPopupTag);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Instantiate a popup of a specific Type
        /// </summary>        
        public T Show<T>() where T : BasePopup
        {
            return PreparePopup<T>(this.popupArea);
        }

        /// <summary>
        /// Instantiate a popup of a specific Type
        /// </summary>
        /// <param name="popupArea"> parent of the popup </param>
        public T Show<T>(RectTransform popupArea) where T : BasePopup
        {
            return PreparePopup<T>(popupArea);
        }

        /// <summary>
        /// Check if the popup of type T is a instance
        /// </summary>
        public bool IsPopupOpen<T>() where T : BasePopup
        {
            var instantiatedPopup = GameObject.FindObjectOfType<T>();

            return instantiatedPopup != null;
        }

        #endregion

        #region Private Methods

        private T PreparePopup<T>(RectTransform popupArea) where T : BasePopup
        {
            var info = PopupsInfos.FirstOrDefault(info => info.prefab is T);
            Debug.Assert(info.prefab != null, string.Format("The pop-up {0} wasn't found inside the PopupConfig", typeof(T)));

            T popup = Instantiate((T)info.prefab);

            ((RectTransform)popup.transform).SetParent(popupArea, false);

            return popup;
        }

        #endregion
    }
}