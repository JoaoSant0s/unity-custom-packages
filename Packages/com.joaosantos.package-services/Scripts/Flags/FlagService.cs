using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Flag
{
    public class FlagService : Service
    {
        private Dictionary<FlagAsset, FlagObject> flagDictionary = new Dictionary<FlagAsset, FlagObject>();

        public void Raise(FlagAsset asset)
        {
            if (!flagDictionary.ContainsKey(asset)) return;
            if (flagDictionary[asset].state == FlagState.Raise) return;

            flagDictionary[asset].state = FlagState.Raise;

            flagDictionary[asset].raiseEvent?.Invoke();
        }

        public void Lower(FlagAsset asset)
        {
            if (!flagDictionary.ContainsKey(asset)) return;
            if (flagDictionary[asset].state == FlagState.Lower) return;

            flagDictionary[asset].state = FlagState.Lower;

            flagDictionary[asset].lowerEvent?.Invoke();
        }

        public void AddListening(FlagAsset asset, UnityEvent raiseEvent, UnityEvent lowerEvent)
        {
            var flagObject = new FlagObject(FlagState.None, raiseEvent, lowerEvent);
            flagDictionary.Add(asset, flagObject);
        }

        public void RemoveListening(FlagAsset asset)
        {
            if (!flagDictionary.ContainsKey(asset)) return;
            flagDictionary.Remove(asset);
        }
    }

    [Serializable]
    public class FlagObject
    {
        public FlagState state;
        public UnityEvent raiseEvent;
        public UnityEvent lowerEvent;

        public FlagObject(FlagState state, UnityEvent raiseEvent, UnityEvent lowerEvent)
        {
            this.state = state;
            this.raiseEvent = raiseEvent;
            this.lowerEvent = lowerEvent;
        }
    }
}