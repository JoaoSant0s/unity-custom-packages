using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Save
{
    public class SaveService : Service
    {
      private SaveConfig config;
        
        #region Override Methods

        public override void Init()
        {
            config = Resources.Load<SaveConfig>("Configs/SaveConfig");
        }

        #endregion

        
        #region Public Methods
        public bool Contains(string radicalKey)
        {
            return PlayerPrefs.HasKey(BuildKey(radicalKey));
        }

        public void Save<T>(string radicalKey, T value) where T : UnityEngine.Object
        {

        }

        public T Get<T> (string radicalKey) where T : UnityEngine.Object
        {
            return null;
        }

        #endregion

        #region Private Methods

        private string BuildKey(string radical)
        {
            return string.Format("{0}_{1}", config.Prefix, radical);
        }

        #endregion
        
    }
}