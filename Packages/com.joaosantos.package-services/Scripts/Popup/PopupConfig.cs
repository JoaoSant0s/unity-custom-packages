using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NaughtyAttributes;
using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Popup
{
    [CreateAssetMenu(fileName = "PopupConfig", menuName = "JoaoSant0s/ServicePackage/Popup/PopupConfig")]
    public class PopupConfig : ServiceConfig
    {
        [Tag]
        public string popupTag;
        public BasePopup[] popupPrefabs;
    }
}
