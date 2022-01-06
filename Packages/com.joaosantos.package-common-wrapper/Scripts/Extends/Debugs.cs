using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.Extensions.Colors;

namespace JoaoSant0s.CommonWrapper
{
    public class Debugs : Debug
    {
        #region Public Methods
        /// <summary>
        /// Log a array of elements or a sequence finity of elements
        /// Eg: Debugs.Log("a", "c", 10);
        /// </summary>
        /// <param name="list"> a sequence list of objects</param>
        public static void Log(params object[] list)
        {
            LogMessage(BuildLog(list));
        }

        /// <summary>
        /// Log a List of elements of type T in sequence
        /// </summary>
        /// <param name="list"> a lista of objects</param>
        public static void Log<T>(List<T> list)
        {
            LogMessage(BuildLog(list));
        }

        /// <summary>
        /// Log a List of elements of type T in sequence   
        /// </summary>
        /// <param name="array"> a array of objects</param>
        public static void Log<T>(T[] array)
        {
            LogMessage(BuildLog(array));
        }

        public static void LogColor(object value, Color color)
        {
            LogMessage(string.Format("<color={0}> {1} </color>", color.ToHex(), value));
        }

        #endregion

        #region Private Methods

        private static string BuildLog<T>(List<T> list)
        {
            var log = "";

            for (int i = 0; i < list.Count; i++)
            {
                log += list[i];
                if (i + 1 < list.Count) log += " --- ";
            }
            return log;
        }

        private static string BuildLog<T>(T[] list)
        {
            var log = "";

            for (int i = 0; i < list.Length; i++)
            {
                log += list[i];
                if (i + 1 < list.Length) log += " --- ";
            }
            return log;
        }

        private static void LogMessage(object message)
        {
            Debug.Log(message);
        }

        #endregion
    }
}