using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.Extensions.Colors;
using JoaoSant0s.Extensions.Strings;

namespace JoaoSant0s.CommonWrapper
{
    public enum DrawAxisType
    {
        XY,
        XZ
    }
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
            if (value == null)
            {
                LogMessage(value);
                return;
            }
            
            LogMessage(value.ToString().ToModifiedColor(color));
        }

        public static void DrawRectangle(Vector2 startLocalAxis, float width, float height, Color color, float duration = 0f, bool depthTest = true, DrawAxisType axisType = DrawAxisType.XY)
        {
            DrawRectangle(startLocalAxis, (startLocalAxis + new Vector2(width, height)), color, duration, depthTest, axisType);
        }

        public static void DrawRectangle(Vector2 startLocalAxis, float width, float height, float duration = 0f, bool depthTest = true, DrawAxisType axisType = DrawAxisType.XY)
        {
            DrawRectangle(startLocalAxis, (startLocalAxis + new Vector2(width, height)), Color.white, duration, depthTest, axisType);
        }

        public static void DrawRectangle(Vector2 startLocalAxis, Vector2 endLocalAxis, Color color, float duration = 0f, bool depthTest = true, DrawAxisType axisType = DrawAxisType.XY)
        {
            DrawRectangleLog(startLocalAxis, endLocalAxis, color, duration, depthTest, axisType);
        }

        public static void DrawRectangle(Vector2 startLocalAxis, Vector2 endLocalAxis, float duration = 0f, bool depthTest = true, DrawAxisType axisType = DrawAxisType.XY)
        {
            DrawRectangleLog(startLocalAxis, endLocalAxis, Color.white, duration, depthTest, axisType);
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

        private static void DrawRectangleLog(Vector2 start, Vector2 end, Color color, float duration, bool depthTest, DrawAxisType axisType)
        {
            Vector3 startAxis = start;
            Vector3 endAxis = end;
            var firstProjection = new Vector3(start.x, end.y, 0);
            var secondProjection = new Vector3(end.x, start.y, 0);

            if (axisType == DrawAxisType.XZ)
            {
                startAxis = new Vector3(start.x, 0, start.y);
                endAxis = new Vector3(end.x, 0, end.y);

                firstProjection = new Vector3(startAxis.x, 0, endAxis.z);
                secondProjection = new Vector3(endAxis.x, 0, startAxis.z);
            }

            DrawRectangleLog(startAxis, endAxis, firstProjection, secondProjection, color, duration, depthTest);
        }

        private static void DrawRectangleLog(Vector3 start, Vector3 end, Vector3 firstProjection, Vector3 secondProjection, Color color, float duration, bool depthTest)
        {
            Debug.DrawLine(start, firstProjection, color, duration, depthTest);
            Debug.DrawLine(start, secondProjection, color, duration, depthTest);

            Debug.DrawLine(end, firstProjection, color, duration, depthTest);
            Debug.DrawLine(end, secondProjection, color, duration, depthTest);
        }

        #endregion
    }
}
