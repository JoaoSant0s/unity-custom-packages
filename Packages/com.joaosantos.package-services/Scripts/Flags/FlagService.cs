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
            if (flagDictionary[asset].State == FlagState.Raise) return;

            flagDictionary[asset].State = FlagState.Raise;
        }

        public void Lower(FlagAsset asset)
        {
            if (!flagDictionary.ContainsKey(asset)) return;
            if (flagDictionary[asset].State == FlagState.Lower) return;

            flagDictionary[asset].State = FlagState.Lower;
        }

        public void AddListening(FlagAsset asset, UnityEvent raiseEvent, UnityEvent lowerEvent)
        {
            var flagObject = new FlagEventObject(FlagState.None, raiseEvent, lowerEvent);
            flagDictionary.Add(asset, flagObject);
        }

         public void AddListening(FlagAsset asset, UnityAction raiseEvent, UnityAction lowerEvent)
        {
            var flagObject = new FlagActionObject(FlagState.None, raiseEvent, lowerEvent);
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
        protected FlagState state; 

        public FlagState State
        {
            get
            {
                return state;
            }
            set{
                state = value;

                if(state == FlagState.Raise)
                {
                    Raise();
                } else if (state == FlagState.Lower)
                {
                    Lower();
                }
            }
        }

        public FlagObject(FlagState state)
        {
            this.state = state;            
        }   

        protected virtual void Raise() { }

        protected virtual void Lower() { }
    }

    [Serializable]
    public class FlagEventObject : FlagObject
    {
        public UnityEvent raiseEvent;
        public UnityEvent lowerEvent;

        public FlagEventObject(FlagState state, UnityEvent raiseEvent, UnityEvent lowerEvent) : base(state)
        {
            this.raiseEvent = raiseEvent;
            this.lowerEvent = lowerEvent;
        }        

        protected override void Raise()
        {
            this.raiseEvent?.Invoke();
        }

        protected override void Lower()
        {
            this.lowerEvent?.Invoke();
        }
    }

     [Serializable]
    public class FlagActionObject : FlagObject
    {
        public UnityAction raiseAction;
        public UnityAction lowerAction;

        public FlagActionObject(FlagState state, UnityAction raiseAction, UnityAction lowerAction) : base(state)
        {            
            this.raiseAction = raiseAction;
            this.lowerAction = lowerAction;
        } 

        protected override void Raise()
        {
            this.raiseAction?.Invoke();
        }

        protected override void Lower()
        {
            this.lowerAction?.Invoke();
        }
    }
}