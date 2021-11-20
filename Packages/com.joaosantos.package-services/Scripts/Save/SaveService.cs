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

        public bool DeleteKey(string radicalKey)
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
           
            return ConvertToObjectFormat<T>(type, stringValue);    
        }

        private void SetUnit<T>(string key, T tValue)
        {
            var type = typeof(T);

            var value = ConvertToStringFormat(tValue, type);

            Debug.Assert(value != null, string.Format("Convertion of {0} to type {0} can be made! Implement on the service", tValue, type));
            
            PlayerPrefs.SetString(key, value);
        }

        private string ConvertToStringFormat<T>(T tValue, Type type)
        {
            object obj = null;

            if(type == typeof(object))
            {
                obj = JsonUtility.ToJson(tValue);
            } else if (type == typeof(int))
            {
                obj = new IntValue((int) Convert.ChangeType(tValue, type));
            }else if (type == typeof(float))
            {
                obj = new FloatValue((float) Convert.ChangeType(tValue, type));
            }else if (type == typeof(string))
            {
                return (string) Convert.ChangeType(tValue, type);
            }else if (type == typeof(bool))
            {
                obj = new BoolValue((bool) Convert.ChangeType(tValue, type));
            }else if (type == typeof(double))
            {
                obj = new DoubleValue((double) Convert.ChangeType(tValue, type));
            }

            return (obj != null) ? JsonUtility.ToJson(obj) : null;
        }

        private T ConvertToObjectFormat<T>(Type  type, string stringValue)
        {
            if (type == typeof(object))
            {
                return JsonUtility.FromJson<T>(stringValue);    
            }else if (type == typeof(int))
            {                
                var obj = JsonUtility.FromJson<IntValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(float))
            {                
                var obj = JsonUtility.FromJson<FloatValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(bool))
            {                
                var obj = JsonUtility.FromJson<BoolValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(double))
            {                
                var obj = JsonUtility.FromJson<DoubleValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }
            
            return (T)Convert.ChangeType(stringValue, type);
        }

        #endregion
        
    }

    [Serializable]
    internal class IntValue
    {
        public int value;

        public IntValue(int newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class FloatValue
    {
        public float value;

        public FloatValue(float newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class BoolValue
    {
        public bool value;

        public BoolValue(bool newValue)
        {
            value = newValue;
        }
    }

    [Serializable]
    internal class DoubleValue
    {
        public double value;

        public DoubleValue(double newValue)
        {
            value = newValue;
        }
    }
}