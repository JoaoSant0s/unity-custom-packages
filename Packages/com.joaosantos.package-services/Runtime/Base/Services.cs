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

        protected override bool IsDontDestroyOnLoad => true;

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            staticTransform = transform;
            gameObject.name = this.GetType().Name;
        }

        #endregion

        public static T Get<T>() where T : Service
        {
            CreateServicesSet();
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
            newService.OnInit();

            services.Add(newService);

            return newService;
        }

        private static void CreateServicesSet()
        {
            if (staticTransform != null) return;

            var newGameObject = new GameObject();

            var newServices = newGameObject.AddComponent<Services>();
            services = new List<Service>();
            newGameObject.name = newServices.GetType().Name;
        }
    }
}
