using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.General;

using JoaoSant0s.Extensions.Collections;
namespace JoaoSant0s.ServicePackage.Popup
{
    public class PopupService : Service
    {
        private RectTransform popupArea;

        private PopupConfig config;

        public PopupInfo[] PopupsInfos => config.popupsInfos;        

        protected override void Init()
        {
            config = Resources.Load<PopupConfig>("Configs/PopupConfig");
            this.popupArea = UtilWrapper.FindRectTransformWithTag(config.mainPopupTag);            
        }

        public T Show<T>() where T : BasePopup
        {
            var info = PopupsInfos.Find(info => info.prefab is T);
            
            T popup = Instantiate((T)info.prefab);

            ((RectTransform)popup.transform).SetParent(this.popupArea, false);

            return popup;
        }

        public T Show<T>(RectTransform popupArea) where T : BasePopup
        {
            var info = PopupsInfos.Find(info => info.prefab is T);            
            
            T popup = Instantiate((T)info.prefab);

            ((RectTransform)popup.transform).SetParent(popupArea, false);

            return popup;
        }

    }
}