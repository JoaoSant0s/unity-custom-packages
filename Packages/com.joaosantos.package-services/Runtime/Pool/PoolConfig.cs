/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Pool
{
    [CreateAssetMenu(fileName = "PoolConfig", menuName = "JoaoSant0s/ServicePackage/Pool/PoolConfig")]
    public class PoolConfig : CustomScriptableObject<PoolConfig>
    {
        [SerializeField]
        private PoolInfo[] poolBaseInfos;

        private Dictionary<PoolBase, PoolInfo> poolDictionary;

        public Dictionary<PoolBase, PoolInfo> PoolConfigDictionary
        {
            get
            {
                if (poolDictionary == null)
                {
                    poolDictionary = poolBaseInfos.ToDictionary(p => p.prefab, p => p);
                }

                return poolDictionary;
            }
        }
    }

    [Serializable]
    public struct PoolInfo
    {
        public PoolBase prefab;

        [Header("Settings")]
        public int startPoolAmount;
        public int maxPoolAmount;
        public Vector3 outsidePosition;

        [Header("Extra Get Parameter")]
        [Min(0)]
        public int indexOrdering;
    }
}