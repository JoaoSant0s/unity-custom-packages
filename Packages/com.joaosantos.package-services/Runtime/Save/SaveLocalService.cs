/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Linq;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Save
{
    public class SaveLocalService : Service
    {
        private SaveLocalConfig config;

        #region Override Methods

        public override void OnInit()
        {
            config = SaveLocalConfig.Get();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Contains a Key        
        /// <param name="key"> basic key parameter</param>
        public bool Contains(string radicalKey)
        {
            var key = BuildKey(radicalKey);

            return PlayerPrefs.HasKey(key);
        }

        /// <summary>
        /// Delete Key        
        /// <param name="key">basic key parameter</param>
        public bool DeleteKey(string radicalKey)
        {
            var key = BuildKey(radicalKey);

            if (!Contains(key)) return false;

            PlayerPrefs.DeleteKey(key);

            return true;
        }

        /// <summary>
        /// Get a saved value locally or use a Default value.
        /// Can Get values with type:
        /// Int, Long, Double, Bool, String, Vector2, Vector3, Serializable Objects, Quaternion, DateTime, Rect.	
        /// Int[], Long[], Double[], Bool[], String[], Vector2[], Vector3[], Quaternion[], DateTime[], Rect[].
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
        /// Int[], Long[], Double[], bool[], string[], Vector2[], Vector3[], Quaternion[], DateTime[], Rect[].
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

        private T ConvertToObjectFormat<T>(Type type, string stringValue)
        {
            object obj = (type.IsArray) ? CollectionObjectFromJson<T>(type, stringValue) : UnitObjectFromJson<T>(type, stringValue);

            return (T)Convert.ChangeType(obj, type);
        }

        private object CollectionObjectFromJson<T>(Type type, string stringValue)
        {
            if (type == typeof(int[]))
            {
                return JsonUtility.FromJson<IntArrayValue>(stringValue).value;
            }
            else if (type == typeof(float[]))
            {
                return JsonUtility.FromJson<FloatArrayValue>(stringValue).value;
            }
            else if (type == typeof(long[]))
            {
                return JsonUtility.FromJson<LongArrayValue>(stringValue).value;
            }
            else if (type == typeof(bool[]))
            {
                return JsonUtility.FromJson<BoolArrayValue>(stringValue).value;
            }
            else if (type == typeof(double[]))
            {
                return JsonUtility.FromJson<DoubleArrayValue>(stringValue).value;
            }
            else if (type == typeof(string[]))
            {
                return JsonUtility.FromJson<StringArrayValue>(stringValue).value;
            }
            else if (type == typeof(Vector2[]))
            {
                return JsonUtility.FromJson<Vector2ArrayValue>(stringValue).value;
            }
            else if (type == typeof(Vector3[]))
            {
                return JsonUtility.FromJson<Vector3ArrayValue>(stringValue).value;
            }
            else if (type == typeof(Quaternion[]))
            {
                return JsonUtility.FromJson<QuaternionArrayValue>(stringValue).value;
            }
            else if (type == typeof(Rect[]))
            {
                return JsonUtility.FromJson<RectArrayValue>(stringValue).value;
            }
            else if (type == typeof(DateTime[]))
            {
                var tickArray = JsonUtility.FromJson<LongArrayValue>(stringValue);
                return tickArray.value.Select(t => new DateTime(t)).ToArray();
            }

            return null;
        }

        private object UnitObjectFromJson<T>(Type type, string stringValue)
        {
            if (type == typeof(int))
            {
                return JsonUtility.FromJson<IntValue>(stringValue).value;
            }
            else if (type == typeof(float))
            {
                return JsonUtility.FromJson<FloatValue>(stringValue).value;
            }
            else if (type == typeof(long))
            {
                return JsonUtility.FromJson<LongValue>(stringValue).value;
            }
            else if (type == typeof(bool))
            {
                return JsonUtility.FromJson<BoolValue>(stringValue).value;
            }
            else if (type == typeof(double))
            {
                return JsonUtility.FromJson<DoubleValue>(stringValue).value;
            }
            else if (type == typeof(string))
            {
                return JsonUtility.FromJson<StringValue>(stringValue).value;
            }
            else if (type == typeof(Vector2))
            {
                return JsonUtility.FromJson<Vector2Value>(stringValue).value;
            }
            else if (type == typeof(Vector3))
            {
                return JsonUtility.FromJson<Vector3Value>(stringValue).value;
            }
            else if (type == typeof(Quaternion))
            {
                return JsonUtility.FromJson<QuaternionValue>(stringValue).value;
            }
            else if (type == typeof(Rect))
            {
                return JsonUtility.FromJson<RectValue>(stringValue).value;
            }
            else if (type == typeof(DateTime))
            {
                var longObj = JsonUtility.FromJson<LongValue>(stringValue);
                return new DateTime(longObj.value);
            }
            else
            {
                return JsonUtility.FromJson<T>(stringValue);
            }
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
            object obj = (type.IsArray) ? CollectionObjectFromObjectType<T>(type, tValue) : UnitObjectFromObjectType<T>(type, tValue);

            return JsonUtility.ToJson(obj);
        }

        private object CollectionObjectFromObjectType<T>(Type type, T tValue)
        {
            if (type == typeof(int[]))
            {
                return new IntArrayValue((int[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(float[]))
            {
                return new FloatArrayValue((float[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(long[]))
            {
                return new LongArrayValue((long[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(bool[]))
            {
                return new BoolArrayValue((bool[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(double[]))
            {
                return new DoubleArrayValue((double[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(string[]))
            {
                return new StringArrayValue((string[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Vector2[]))
            {
                return new Vector2ArrayValue((Vector2[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Vector3[]))
            {
                return new Vector3ArrayValue((Vector3[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Quaternion[]))
            {
                return new QuaternionArrayValue((Quaternion[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Rect[]))
            {
                return new RectArrayValue((Rect[])Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(DateTime[]))
            {
                var dates = (DateTime[])Convert.ChangeType(tValue, type);

                return new LongArrayValue(dates.Select(d => d.Ticks).ToArray());
            }
            else
            {
                var objects = (object[])Convert.ChangeType(tValue, type);
                var stringArray = objects.Select(o => JsonUtility.ToJson(o)).ToArray();
                return new StringArrayValue(stringArray);
            }
        }

        private object UnitObjectFromObjectType<T>(Type type, T tValue)
        {
            if (type == typeof(int))
            {
                return new IntValue((int)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(float))
            {
                return new FloatValue((float)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(long))
            {
                return new LongValue((long)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(bool))
            {
                return new BoolValue((bool)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(double))
            {
                return new DoubleValue((double)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(string))
            {
                return new StringValue((string)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Vector2))
            {
                return new Vector2Value((Vector2)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Vector3))
            {
                return new Vector3Value((Vector3)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Quaternion))
            {
                return new QuaternionValue((Quaternion)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(Rect))
            {
                return new RectValue((Rect)Convert.ChangeType(tValue, type));
            }
            else if (type == typeof(DateTime))
            {
                var date = (DateTime)Convert.ChangeType(tValue, type);
                return new LongValue(date.Ticks);
            }
            else
            {
                return tValue;
            }
        }

        #endregion
    }
}