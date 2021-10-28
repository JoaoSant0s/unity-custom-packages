using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Popup
{
    [CreateAssetMenu(fileName = "PopupConfig", menuName = "JoaoSant0s/ServicePackage/Popup/PopupConfig")]
    public class PopupConfig : ServiceConfig
    {
        public string mainPopupTag;
        public PopupInfo[] popupsInfo;
    }

    [Serializable]
    public struct PopupInfo
    {
        public BasePopup prefab;
        public string overridePopupTag;
    }
}
