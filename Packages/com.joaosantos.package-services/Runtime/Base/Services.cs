/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.General
{
    public class Services : SingletonBehaviour<Services>
    {
        private Transform staticTransform;
        private List<Service> services;

        protected override bool IsDontDestroyOnLoad => true;

        #region Protected Methods

        protected override void Init()
        {
            services = new List<Service>();
            staticTransform = transform;
        }

        #endregion

        #region Public Methods

        public static T Get<T>() where T : Service
        {
            return Instance.GetOrCreate<T>();
        }

        public T GetOrCreate<T>() where T : Service
        {
            var service = services.Find(s => s is T);

            if (service != null) return (T)service;

            return CreateService<T>();
        }

        #endregion

        private T CreateService<T>() where T : Service
        {
            var newGameObject = new GameObject();

            var newService = newGameObject.AddComponent<T>();
            newGameObject.transform.SetParent(staticTransform);
            newGameObject.name = newService.GetType().Name;
            newService.OnInit();

            services.Add(newService);

            return newService;
        }
    }
}
