using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Conversor = System.Text.Encoding;

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

            var stringValue = PlayerPrefs.GetString(key);

            if (type == typeof(object))
            {
                return JsonUtility.FromJson<T>(stringValue);               
            }else
            {
                return GetSimpleUnit<T>(type, stringValue);
            }
        }

        private void SetUnit<T>(string key, T tValue)
        {
            var type = typeof(T);

            var value = "";

            if (type == typeof(object))
            {
                value = JsonUtility.ToJson(tValue);
            }else
            {
                Byte[] bytes = GetBytes<T>(tValue, type);

                value = BitConverter.ToString(bytes);
            }
            
            PlayerPrefs.SetString(key, value);
        }

        private Byte[] GetBytes<T>(T tValue, Type type)
        {
            if (tValue is int)
            {
                return BitConverter.GetBytes((int) Convert.ChangeType(tValue, type));

            }else if (tValue is float)
            {
                return BitConverter.GetBytes((float) Convert.ChangeType(tValue, type));

            }else if (tValue is string)
            {
                var stringValue = (string) Convert.ChangeType(tValue, type);

                return Conversor.UTF8.GetBytes(stringValue);

            }

            Debug.LogError(string.Format("Create the type to convert the value {0} to Array of Bytes", tValue));

            return new Byte [0];
        }

        private T GetSimpleUnit<T>(Type  type, string stringValue)
        {
            if (type == typeof(int) )
            {                
                var bytes = UtilWrapper.GetBytesFromStringTransformation(stringValue);
                var vale = BitConverter.ToInt32(bytes, 0);

                return (T)Convert.ChangeType(vale, type);

            }else if (type == typeof(float) )
            {                
                var bytes = UtilWrapper.GetBytesFromStringTransformation(stringValue);
                var vale = BitConverter.ToSingle(bytes, 0);

                return (T)Convert.ChangeType(vale, type);

            }else if (type == typeof(string) )
            {                
                var bytes = UtilWrapper.GetBytesFromStringTransformation(stringValue);                
                var vale = Conversor.UTF8.GetString(bytes);

                return (T)Convert.ChangeType(vale, type);

            }
            
            return (T)Convert.ChangeType(stringValue, type);
        }

        #endregion
        
    }


    [Serializable]
    internal class Vector3Value
    {
        public Vector3 value;
    }
}