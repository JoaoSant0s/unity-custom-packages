/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

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
    public class FlagAsset : ScriptableObject { }
}
