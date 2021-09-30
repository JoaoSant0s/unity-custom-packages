using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.ServicePackage.Flag
{
    public enum FlagState
    {        
        Raise,
        Lower,
        None
    }
    [CreateAssetMenu(fileName = "FlagAsset", menuName = "Main/Service/Flag/FlagAsset")]
    public class FlagAsset : ScriptableObject
    {

    }
}
