using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Main.ServicePackage.General;
namespace Main.ServicePackage.Popup
{
    public class PopupService : Service
    {
        private RectTransform popupArea;

        private BasePopup[] popupPrefabs;

        protected override void Init()
        {
            var config = Resources.Load<PopupConfig>("Configs/PopupConfig");

            this.popupPrefabs = config.popupPrefabs;
            this.popupArea = (RectTransform)GameObject.FindGameObjectWithTag(config.popupTag).transform;
        }

        public T ShowPopup<T>() where T : BasePopup
        {
            var prefab = (T)popupPrefabs.Find(p => p is T);

            T popup = Instantiate(prefab);

            ((RectTransform)popup.transform).SetParent(this.popupArea, false);

            return popup;
        }

    }
}