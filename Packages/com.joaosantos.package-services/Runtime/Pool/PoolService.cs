/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Pool
{
    public class PoolService : Service
    {
        private PoolConfig config;

        private Dictionary<PoolInfo, List<PoolBehaviour>> poolDictionary;

        #region Override Methods

        public override void OnInit()
        {
            config = PoolConfig.Get();
            Setup();
        }

        #endregion

        #region Public Methods       

        /// <summary>
        /// Get a valid Pool element of type T
        /// </summary>        
        /// <param name="position"> position to spawn the element </param>        
        /// <param name="indexOrdering"> selection of an extra prefab of a specific Type. Default value: 0</param>
        /// <param name="parent"> parent to spawn the element. Default value: null</param>
        public T Get<T>(Vector3 position, Transform parent, int indexOrdering = 0) where T : PoolBehaviour
        {
            Debug.Assert(parent != null, "You must define a transform parent to move the object of the DontDestroyOnLoadScene");
            var instance = GetValidElement<T>(indexOrdering);
            instance.transform.SetParent(parent);
            instance.transform.position = position;
            instance.gameObject.SetActive(true);
            instance.Show();

            return instance;
        }

        /// <summary>
        /// Get a valid Pool element of type T
        /// </summary>
        /// <param name="position"> position to spawn the element </param>
        /// <param name="quaternion"> quaternion to spawn the element </param>
        /// <param name="indexOrdering"> selection of an extra prefab of a specific Type. Default value: 0 </param>
        /// <param name="parent"> parent to spawn the element. Default value: null</param>
        public T Get<T>(Vector3 position, Quaternion quaternion, Transform parent, int indexOrdering = 0) where T : PoolBehaviour
        {
            Debug.Assert(parent != null, "You must define a transform parent to move the object of the DontDestroyOnLoadScene");
            var instance = GetValidElement<T>(indexOrdering);
            instance.transform.SetParent(parent);
            instance.transform.position = position;
            instance.transform.rotation = quaternion;
            instance.gameObject.SetActive(true);
            instance.Show();

            return instance;
        }

        #endregion

        #region Private Methods

        private void Setup()
        {
            poolDictionary = new Dictionary<PoolInfo, List<PoolBehaviour>>();

            foreach (var item in config.PoolConfigDictionary)
            {
                CreatePoolDictionary(item.Value);
            }
        }

        private void CreatePoolDictionary(PoolInfo info)
        {
            poolDictionary[info] = new List<PoolBehaviour>();

            for (int i = 0; i < info.startPoolAmount; i++)
            {
                CreatePoolElement(info);
            }
        }

        private T GetValidElement<T>(int indexOrdering) where T : PoolBehaviour
        {
            var tuple = poolDictionary.FirstOrDefault(element =>
            {
                var key = element.Key;
                return key.prefab is T && key.indexOrdering == indexOrdering;
            });

            var errorString = string.Format("The Type or selected index {0} was not initialized by the PoolConfig", indexOrdering);

            Debug.Assert(tuple.Key.prefab != null, errorString);

            T instance = GetElementFromList<T>(tuple.Value);

            if (instance == null)
            {
                instance = (T)CreatePoolElement(tuple.Key, false);
            }

            return instance;
        }

        private T GetElementFromList<T>(List<PoolBehaviour> pool) where T : PoolBehaviour
        {
            T instance = null;

            if (pool.Count != 0)
            {
                instance = (T)pool[0];
                pool.RemoveAt(0);
            }

            return instance;
        }

        private PoolBehaviour CreatePoolElement(PoolInfo info, bool restore = true)
        {
            var poolElement = Instantiate(info.prefab, transform);
            ResetPoolElement(info, poolElement);
            poolElement.DisposePoolBehaviour += ReturnToPool;

            if (!IsPoolFull(info) && restore)
            {
                poolElement.IndexOrdering = info.indexOrdering;
                poolDictionary[info].Add(poolElement);
            }

            return poolElement;
        }

        private bool IsPoolFull(PoolInfo info)
        {
            var amount = poolDictionary[info].Count;

            var maxAmount = info.maxPoolAmount;

            return amount >= maxAmount;
        }

        private void ReturnToPool(PoolBehaviour pool)
        {
            var tuple = poolDictionary.FirstOrDefault(element =>
            {
                var checkType = element.Key.prefab.GetType() == pool.GetType();
                var checkOrdering = pool.IndexOrdering == element.Key.indexOrdering;

                return checkType && checkOrdering;
            });

            var key = tuple.Key;

            if (IsPoolFull(key))
            {
                Destroy(pool.gameObject);
                return;
            }

            tuple.Value.Add(pool);
            ResetPoolElement(tuple.Key, pool);
        }

        private void ResetPoolElement(PoolInfo info, PoolBehaviour pool)
        {
            pool.gameObject.SetActive(false);
            pool.transform.SetParent(transform);
            pool.transform.position = info.outsidePosition;
            pool.IndexOrdering = info.indexOrdering;
        }

        #endregion
    }
}

