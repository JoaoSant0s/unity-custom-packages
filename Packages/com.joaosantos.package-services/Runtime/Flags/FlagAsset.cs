using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.ServicePackage.Flag
{
    public enum FlagState
    {
        Raise,
        Lower,
        None
    }
    [CreateAssetMenu(fileName = "FlagAsset", menuName = "JoaoSant0s/ServicePackage/Flag/FlagAsset")]
    public class FlagAsset : ScriptableObject
    {

    }
}
