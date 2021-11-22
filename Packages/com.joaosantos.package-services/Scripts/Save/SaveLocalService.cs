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

            Debugs.Log(key, type);

            var stringValue = PlayerPrefs.GetString(key);
           
            return ConvertToObjectFormat<T>(type, stringValue);    
        }

        private T ConvertToObjectFormat<T>(Type  type, string stringValue)
        {
            if (type == typeof(int))
            {                
                var obj = JsonUtility.FromJson<IntValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(int[]))
            {                
                var obj = JsonUtility.FromJson<IntArrayValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }
            else if (type == typeof(float))
            {                
                var obj = JsonUtility.FromJson<FloatValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(float[]))
            {                
                var obj = JsonUtility.FromJson<FloatArrayValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(long))
            {                
                var obj = JsonUtility.FromJson<LongValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(long[]))
            {                
                var obj = JsonUtility.FromJson<LongArrayValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(bool))
            {                
                var obj = JsonUtility.FromJson<BoolValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(bool[]))
            {                
                var obj = JsonUtility.FromJson<BoolArrayValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(double))
            {                
                var obj = JsonUtility.FromJson<DoubleValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(double[]))
            {                
                var obj = JsonUtility.FromJson<DoubleArrayValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(string))
            {
                return (T)Convert.ChangeType(stringValue, type);
            }else if (type == typeof(string[]))
            {                
                var obj = JsonUtility.FromJson<StringArrayValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);
            }else if (type == typeof(Vector2))
            {                
                var obj = JsonUtility.FromJson<Vector2Value>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(Vector3))
            {                
                var obj = JsonUtility.FromJson<Vector3Value>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(Quaternion))
            {                
                var obj = JsonUtility.FromJson<QuaternionValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(Rect))
            {                
                var obj = JsonUtility.FromJson<RectValue>(stringValue);

                return (T)Convert.ChangeType(obj.value, type);                
            }else if (type == typeof(DateTime))
            {                
                var obj = JsonUtility.FromJson<LongValue>(stringValue);
                var date = new DateTime(obj.value);

                return (T)Convert.ChangeType(date, type);                
            }else{
                var obj = JsonUtility.FromJson<T>(stringValue);

                return (T)Convert.ChangeType(obj, type);     
            }
        }

        private void SetData<T>(string key, T tValue)
        {
            var type = typeof(T);

            Debugs.Log(key, type, tValue);

            var value = ConvertToStringFormat(tValue, type);

            Debug.Assert(value != null, string.Format("Convertion of {0} to type {0} can be made!", tValue, type));
            Debug.Assert(value != null, "Implement on the service or make the Object Serializable!");
            
            PlayerPrefs.SetString(key, value);
        }

        private string ConvertToStringFormat<T>(T tValue, Type type)
        {
            object obj = null;

            if (type == typeof(int))
            {
                obj = new IntValue((int) Convert.ChangeType(tValue, type));
            }else if (type == typeof(int[]))
            {
                obj = new IntArrayValue((int[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(float))
            {
                obj = new FloatValue((float) Convert.ChangeType(tValue, type));
            }else if (type == typeof(float[]))
            {
                obj = new FloatArrayValue((float[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(long))
            {
                obj = new LongValue((long) Convert.ChangeType(tValue, type));
            }else if (type == typeof(long[]))
            {
                obj = new LongArrayValue((long[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(bool))
            {
                obj = new BoolValue((bool) Convert.ChangeType(tValue, type));
            }else if (type == typeof(bool[]))
            {
                obj = new BoolArrayValue((bool[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(double))
            {
                obj = new DoubleValue((double) Convert.ChangeType(tValue, type));
            }else if (type == typeof(double[]))
            {
                obj = new DoubleArrayValue((double[]) Convert.ChangeType(tValue, type));
            }else if (type == typeof(string))
            {
                return (string) Convert.ChangeType(tValue, type);
            }else if (type == typeof(string[]))
            {
                obj = new StringArrayValue((string[]) Convert.ChangeType(tValue, type));
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

            return JsonUtility.ToJson(obj);
        }

        #endregion        
    }   
}