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

        private RectTransform GetPopupArea(PopupInfo  info)
        {
            if (string.IsNullOrEmpty(info.overridePopupTag))
            {
                return this.popupArea;
            }
            
            return UtilWrapper.FindRectTransformWithTag(info.overridePopupTag);            
        }

        public T ShowPopup<T>() where T : BasePopup
        {
            var info = PopupsInfos.Find(info => info.prefab is T);

            var area = GetPopupArea(info);
            
            T popup = Instantiate((T)info.prefab);

            ((RectTransform)popup.transform).SetParent(area, false);

            return popup;
        }

    }
}