using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.General
{
    public class Services : SingletonBehaviour<Services>
    {
        private static Transform staticTransform;
        private static List<Service> services;

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            staticTransform = transform;
        }

        #endregion

        public static T Get<T>() where T : Service
        {
            if (services == null)
            {
                services = new List<Service>();
            }
            var service = services.Find(s => s is T);

            if (service != null) return (T)service;

            return CreateService<T>();
        }

        private static T CreateService<T>() where T : Service
        {
            var newGameObject = new GameObject();

            var newService = newGameObject.AddComponent<T>();

            newGameObject.transform.SetParent(staticTransform);
            newGameObject.name = newService.GetType().Name;

            services.Add(newService);

            return newService;
        }
    }
}
