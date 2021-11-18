using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
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
            var key = BuildKey(radicalKey);

            return PlayerPrefs.HasKey(key);
        }

        public bool DeleteSave(string radicalKey)
        {
            var key = BuildKey(radicalKey);

            if(!Contains(key)) return false;

            PlayerPrefs.DeleteKey(key);

            return true;
        }

        public T GetOrDefault<T>(string radicalKey, T defaultValue = default(T))
        {
            var key = BuildKey(radicalKey);

            if (Contains(key))
                return Get<T>(key);
            else
                return defaultValue;
        }      

        public T Get<T>(string radicalKey)
        {
            var key = BuildKey(radicalKey);
            
            return GetUnit<T>(key);
        }

        public void Set<T>(string radicalKey, T value)
        {
            var key = BuildKey(radicalKey);
            SetUnit<T>(key, value);
        }

        #endregion

        #region Private Methods

        private string BuildKey(string radical)
        {
            return string.Format("{0}_{1}", config.Prefix, radical);
        }

        private T GetUnit<T>(string key)
        {
            var type = typeof(T);

            if (type == typeof(int))
            {
                return (T) Convert.ChangeType(PlayerPrefs.GetInt(key), type);  

            }else if (type == typeof(float))
            {
                return (T) Convert.ChangeType(PlayerPrefs.GetFloat(key), type);                 
            }

            var stringValue = PlayerPrefs.GetString(key);

            Debugs.Log(stringValue, type, type == typeof(object));

            if (type == typeof(object))
            {
                return JsonUtility.FromJson<T>(stringValue);               
            }else
            {
                if(type == typeof(Vector3))
                {
                    var auxValue = JsonUtility.FromJson<Vector3Value>(stringValue);
                    return (T)Convert.ChangeType(auxValue.value, type);
                }
                else
                {
                    return (T)Convert.ChangeType(stringValue, type);
                }
            }
        }

        private void SetUnit<T>(string key, T tValue)
        {
            var type = typeof(T);
            Debugs.Log(tValue, type);

            if (type == typeof(int))
            {
                PlayerPrefs.SetInt(key, ((int) Convert.ChangeType(tValue, type)));

                return;

            }else if (type == typeof(float))
            {
                PlayerPrefs.SetFloat(key, ((float) Convert.ChangeType(tValue, type)));

                return;
            }

            var value = "";

            if (type == typeof(object))
            {
                value = JsonUtility.ToJson(tValue);
            }else
            {
                if(type == typeof(Vector3))
                {
                    Vector3 v = ((Vector3) Convert.ChangeType(tValue, type));
                    value = JsonUtility.ToJson(new Vector3Value(){value = v});
                }else
                {
                    value = tValue.ToString();                    
                }
            }
            
            PlayerPrefs.SetString(key, value);
        }

        #endregion
        
    }


    [Serializable]
    internal class Vector3Value
    {
        public Vector3 value;
    }
}