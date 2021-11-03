using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Pool
{
    [CreateAssetMenu(fileName = "PoolConfig", menuName = "JoaoSant0s/ServicePackage/Pool/PoolConfig")]
    public class PoolConfig : ServiceConfig
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
    }
}