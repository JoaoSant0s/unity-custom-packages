using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Pool
{
    public class PoolService : Service
    {
        private PoolConfig config;

        private Dictionary<PoolBase, List<PoolBase>> poolDictionary;

        protected override void Init()
        {
            config = Resources.Load<PoolConfig>("Configs/PoolConfig");
            Setup();
        }

        #region Public Methods        

        public T Instatiate<T>(Transform parent, Vector3 position, Quaternion quaternion) where T : PoolBase
        {
            var instance = GetValidElement<T>();
            instance.transform.SetParent(parent);
            instance.transform.position = position;
            instance.transform.rotation = quaternion;
            instance.Show();
            instance.gameObject.SetActive(true);

            return instance;
        }

        public T Instatiate<T>(Transform parent, Vector3 position) where T : PoolBase
        {
            var instance = GetValidElement<T>();
            instance.transform.SetParent(parent);
            instance.transform.position = position;
            instance.Show();
            instance.gameObject.SetActive(true);

            return instance;
        }

        #endregion

        #region Private Methods

        private void Setup()
        {
            poolDictionary = new Dictionary<PoolBase, List<PoolBase>>();

            foreach (var item in config.PoolConfigDictionary)
            {
                CreatePoolDictionary(item.Value);
            }
        }

        private void CreatePoolDictionary(PoolInfo info)
        {
            var key = info.prefab;
            
            poolDictionary[key] = new List<PoolBase>();

            for (int i = 0; i < info.startPoolAmount; i++)
            {
                CreatePoolElement(key);
            }
        }

        private T GetValidElement<T>() where T : PoolBase
        {
            var tuple = poolDictionary.FirstOrDefault(element => element.Key is T);
            
            Debug.Assert(tuple.Key != null, "The Type selected was not initialized by the PoolConfig");

            T instance = GetElementFromList<T>(tuple.Value);
            
            if (instance == null)
            {
                instance = CreatePoolElement((T) tuple.Key, false);
            }

            return instance;
        }

        private T GetElementFromList<T>(List<PoolBase> pool) where T : PoolBase
        {
            T instance = null;

            if (pool.Count != 0)
            {
                instance = (T)pool[0];
                pool.RemoveAt(0);
            }

            return instance;
        }

        private T CreatePoolElement<T>(T key, bool restore = true) where T : PoolBase
        {
            var poolElement = Instantiate(key, transform);
            ResetPoolElement(key, poolElement);
            poolElement.HidePoolElement += ReturnToPool;

            if (!IsPoolFull(key) && restore) poolDictionary[key].Add(poolElement);

            return poolElement;
        }

        private bool IsPoolFull<T>(T key) where T : PoolBase
        {
            var amount = poolDictionary[key].Count;

            var maxAmount = config.PoolConfigDictionary[key].maxPoolAmount;

            return amount >= maxAmount;
        }

        private void ReturnToPool(PoolBase pool)
        {
            var tuple = poolDictionary.FirstOrDefault(element => element.Key.GetType() == pool.GetType());
            
            var key = tuple.Key;

            if (IsPoolFull(key))
            {
                Destroy(pool.gameObject);
                return;
            }

            tuple.Value.Add(pool);
            ResetPoolElement(tuple.Key, pool);
        }

        private void ResetPoolElement(PoolBase key, PoolBase pool)
        {
            pool.gameObject.SetActive(false);
            pool.transform.SetParent(transform);
            pool.transform.position = config.PoolConfigDictionary[key].outsidePosition;            
        }

        #endregion
    }
}
