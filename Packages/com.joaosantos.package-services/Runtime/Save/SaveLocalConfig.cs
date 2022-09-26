/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Save
{
    [CreateAssetMenu(fileName = "SaveLocalConfig", menuName = "JoaoSant0s/ServicePackage/Save/SaveLocalConfig")]

    public class SaveLocalConfig : CustomScriptableObject<SaveLocalConfig>
    {
        [Header("Save Local Config")]

        [SerializeField]
        [Tooltip("Used as Player Prefs prefix indicator")]
        private string savePrefix;

        [SerializeField]
        [Min(0)]
        [Tooltip("Increase this to indicate the system has a new version")]
        private int versionIndex;

        public string Prefix => savePrefix;
        public int VersionIndex => versionIndex;
    }
}
