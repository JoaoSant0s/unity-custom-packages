using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
using System;

namespace JoaoSant0s.ServicePackage.Console
{
    public class ConsoleManager : SingletonBehaviour<ConsoleManager>
    {
        public event Action<LogObject> OnLogAdded;
        public event Action OnLogCleared;
        public event Action<bool> OnLogManuallyActivated;

        protected override bool IsDontDestroyOnLoad => true;

        public List<LogObject> LogObjects { get; protected set; }

        private bool isConsoleActive;

        private ConsoleManagerConfig configs;

        #region Protected Methods

        protected override void Init()
        {
            configs = ConsoleManagerConfig.Get();
            LogObjects = new List<LogObject>();
            isConsoleActive = true;

            if (configs.IsThreaded)
            {
                Application.logMessageReceivedThreaded += Log;
            }
            else
            {
                Application.logMessageReceived += Log;
            }
        }

        #endregion

        #region Unity Methods

        void OnDisable()
        {
            if (configs.IsThreaded)
            {
                Application.logMessageReceivedThreaded -= Log;
            }
            else
            {
                Application.logMessageReceived -= Log;
            }
            LogObjects.Clear();
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            LogObjects.Clear();
            OnLogCleared?.Invoke();
        }

        public void StopProcessing()
        {
            isConsoleActive = false;
            OnLogManuallyActivated?.Invoke(isConsoleActive);
        }

        public void ResumeProcessing()
        {
            isConsoleActive = true;
            OnLogManuallyActivated?.Invoke(isConsoleActive);
        }

        #endregion

        #region Private Methods

        private void Log(string logString, string stackTrace, LogType type)
        {
            if (!isConsoleActive) return;
            var log = new LogObject() { logString = logString, stackTrace = stackTrace, type = type };
            LogObjects.Add(log);
            OnLogAdded?.Invoke(log);
        }

        #endregion
    }

    public struct LogObject
    {
        public string logString;
        public string stackTrace;
        public LogType type;
    }
}
