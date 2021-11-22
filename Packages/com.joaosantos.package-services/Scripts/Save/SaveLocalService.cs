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
    public class SaveLocalService : Service
    {
      private SaveLocalConfig config;
        
        #region Override Methods

        public override void Init()
        {
            config = Resources.Load<SaveLocalConfig>("Configs/SaveLocalConfig");
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

        /// <summary>
        /// Get a saved value locally or use a Default value.
        /// Can Get values with type:
        /// Int, Long, Double, Bool, String, Vector2, Vector3, Serializable Objects, Quaternion, DateTime, Rect.	
        /// Int[], Long[], Double[], Bool[], String[], Vector2[], Vector3[], Serializable Objects[], Quaternion[], DateTime[], Rect[].
        /// </summary>
        /// <param name="key">basic key parameter</param>
        public T Get<T>(string key)
        {
            var internalKey = BuildKey(key);

            return GetData<T>(internalKey);
        }

        /// <summary>
        /// Set the value locally.
        /// Can set this values Types:
        /// Int, Long, Double, Bool, String, Vector2, Vector3, Serializable Objects, Quaternion, DateTime, Rect.	
        /// Int[], Long[], Double[], bool[], string[], Vector2[], Vector3[], Serializable Objects[], Quaternion[], DateTime[], Rect[].
        /// </summary>
        /// <param name="key">basic key parameter</param>
        /// <param name="value"> the saved ba</param>
        public void Set<T>(string key, T value)
        {
            var internalKey = BuildKey(key);

            SetData<T>(internalKey, value);
        }
        
        #endregion

        #region Private Methods

        private string BuildKey(string radical)
        {
            return string.Format("{0}_{1}", config.Prefix, radical);
        }

        private T GetData<T>(string key)
        {
            var type = typeof(T);

            var stringValue = PlayerPrefs.GetString(key);
           
            return ConvertToObjectFormat<T>(type, stringValue);    
        }

        private T ConvertToObjectFormat<T>(Type  type, string stringValue)
        {
            object obj = (type.IsArray) ? CollectionObjectFromJson<T>( type, stringValue) : UnitObjectFromJson<T>( type, stringValue);

            return (T) Convert.ChangeType(obj, type);
        }

        private object CollectionObjectFromJson<T>(Type type, string stringValue)
        {
            object obj = null;

            if (type == typeof(int[]))
            {
                obj = JsonUtility.FromJson<IntArrayValue>(stringValue).value;
            }
            else if (type == typeof(float[]))
            {
                obj = JsonUtility.FromJson<FloatArrayValue>(stringValue).value;
            }else if (type == typeof(long[]))
            {
                obj = JsonUtility.FromJson<LongArrayValue>(stringValue).value;

            }else if (type == typeof(bool[]))
            {
                obj = JsonUtility.FromJson<BoolArrayValue>(stringValue).value;

            }else if (type == typeof(double[]))
            {
                obj = JsonUtility.FromJson<DoubleArrayValue>(stringValue).value;
            }else if (type == typeof(string[]))
            {
                obj = JsonUtility.FromJson<StringArrayValue>(stringValue).value;
            }

            return obj;
        }

        private object UnitObjectFromJson<T>(Type type, string stringValue)
        {
            object obj = null;

            if (type == typeof(int))
            {
                obj = JsonUtility.FromJson<IntValue>(stringValue).value;
            }
            else if (type == typeof(float))
            {
                obj = JsonUtility.FromJson<FloatValue>(stringValue).value;
            }else if (type == typeof(long))
            {
                obj = JsonUtility.FromJson<LongValue>(stringValue).value;
            }else if (type == typeof(bool))
            {
                obj = JsonUtility.FromJson<BoolValue>(stringValue).value;
            }else if (type == typeof(double))
            {
                obj = JsonUtility.FromJson<DoubleValue>(stringValue).value;
            }else if (type == typeof(string))
            {
                obj = JsonUtility.FromJson<StringValue>(stringValue).value;
            }else if (type == typeof(Vector2))
            {
                obj = JsonUtility.FromJson<Vector2Value>(stringValue).value;
            }else if (type == typeof(Vector3))
            {
                obj = JsonUtility.FromJson<Vector3Value>(stringValue).value;
            }else if (type == typeof(Quaternion))
            {
                obj = JsonUtility.FromJson<QuaternionValue>(stringValue).value;
            }else if (type == typeof(Rect))
            {
                obj = JsonUtility.FromJson<RectValue>(stringValue).value;
            }else if (type == typeof(DateTime))
            {
                var longObj = JsonUtility.FromJson<LongValue>(stringValue);
                obj = new DateTime(longObj.value);
            }else
            {
                obj = JsonUtility.FromJson<T>(stringValue);                     
            }

            return obj;
        }

        private void SetData<T>(string key, T tValue)
        {
            var type = typeof(T);

            var value = ConvertToStringFormat(type, tValue);

            Debug.Assert(value != null, string.Format("Convertion of {0} to type {0} can be made!", tValue, type));
            Debug.Assert(value != null, "Implement on the service or make the Object Serializable!");
            
            PlayerPrefs.SetString(key, value);
        }

        private string ConvertToStringFormat<T>(Type type, T tValue)
        {
            object obj = (type.IsArray) ? CollectionObjectFromObjectType<T>( type, tValue) : UnitObjectFromObjectType<T>(type, tValue);

            return JsonUtility.ToJson(obj);
        }

        private object UnitObjectFromObjectType<T>(Type type, T tValue)
        {
            object obj = null;

            if (type == typeof(int))
            {
                obj = new IntValue((int) Convert.ChangeType(tValue, type));
            }else if (type == typeof(float))
            {
                obj = new FloatValue((float) Convert.ChangeType(tValue, type));
            }else if (type == typeof(long))
            {
                obj = new LongValue((long) Convert.ChangeType(tValue, type));
            }else if (type == typeof(bool))
            {
                obj = new BoolValue((bool) Convert.ChangeType(tValue, type));
            }else if (type == typeof(double))
            {
                obj = new DoubleValue((double) Convert.ChangeType(tValue, type));
            }else if (type == typeof(string))
            {
                obj = new StringValue((string) Convert.ChangeType(tValue, type));                
            }else if (type == typeof(Vector2))
            {
                obj = new Vector2Value((Vector2) Convert.ChangeType(tValue, type));
            }else if (type == typeof(Vector3))
            {
                obj = new Vector3Value((Vector3) Convert.ChangeType(tValue, type));
            }else if (type == typeof(Quaternion))
            {
                obj = new QuaternionValue((Quaternion) Convert.ChangeType(tValue, type));
            }else if (type == typeof(Rect))
            {
                obj = new RectValue((Rect) Convert.ChangeType(tValue, type));
            }else if (type == typeof(DateTime))
            {
                var date = (DateTime) Convert.ChangeType(tValue, type);
                obj = new LongValue(date.Ticks);
            }else{
                obj = tValue;
            }

            return obj;
        }

        private object CollectionObjectFromObjectType<T>(Type type, T tValue)
        {
            object obj = null;

            if (type == typeof(int[]))
            {
                obj = new IntArrayValue((int[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(float[]))
            {
                obj = new FloatArrayValue((float[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(long[]))
            {
                obj = new LongArrayValue((long[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(bool[]))
            {
                obj = new BoolArrayValue((bool[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(double[]))
            {
                obj = new DoubleArrayValue((double[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(string[]))
            {
                obj = new StringArrayValue((string[]) Convert.ChangeType(tValue, type));
            }

            return obj;
        }

        #endregion        
    }   
}