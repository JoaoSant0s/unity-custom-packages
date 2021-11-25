using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.CommonWrapper
{
    public class Debugs
    {
        /// <summary>
        /// Log a array of elements or a sequence finity of elements
        /// Eg: Debugs.Log("a", "c", 10);
        /// </summary>
        /// <param name="list"> the next state object</param>
        public static void Log(params object[] list)
        {
            var log = "";

            for (int i = 0; i < list.Length; i++)
            {
                log += list[i];
                if (i + 1 < list.Length) log += " --- ";
            }
            Debug.Log(log);
        }

        /// <summary>
        /// Log a List of elements of type T in sequence
        /// </summary>
        /// <param name="list"> the next state object</param>
        public static void Log<T>(List<T> main)
        {
            Debug.Log(LogList(main));
        }

        /// <summary>
        /// Log a List of elements of type T in sequence   
        /// </summary>
        public static void Log<T>(T[] main)
        {
            Debug.Log(LogList(main));
        }

        private static string LogList<T>(List<T> list)
        {
            var log = "";

            for (int i = 0; i < list.Count; i++)
            {
                log += list[i];
                if (i + 1 < list.Count) log += " --- ";
            }
            return log;
        }

        private static string LogList<T>(T[] list)
        {
            var log = "";

            for (int i = 0; i < list.Length; i++)
            {
                log += list[i];
                if (i + 1 < list.Length) log += " --- ";
            }
            return log;
        }
    }
}