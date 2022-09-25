/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Popup
{
    [CreateAssetMenu(fileName = "PopupConfig", menuName = "JoaoSant0s/ServicePackage/Popup/PopupConfig")]
    public class PopupConfig : CustomScriptableObject<PopupConfig>
    {
        [Header("Popup Config")]
        public string mainPopupTag;
        public PopupInfo[] popupsInfos;
    }

    [Serializable]
    public struct PopupInfo
    {
        public BasePopup prefab;
    }
}
