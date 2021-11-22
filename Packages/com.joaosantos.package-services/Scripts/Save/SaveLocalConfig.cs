using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Save
{
[CreateAssetMenu(fileName = "SaveLocalConfig", menuName = "JoaoSant0s/ServicePackage/Save/SaveLocalConfig")]

    public class SaveLocalConfig : ServiceConfig
    {
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
