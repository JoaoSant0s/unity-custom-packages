/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Collections.Generic;

using UnityEngine.Events;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Flag
{
    public class FlagService : Service
    {
        private readonly Dictionary<FlagAsset, FlagObject> flagDictionary = new();

        #region Override Methods

        public override void OnInit() { }

        #endregion

        /// <summary>
        /// Raise a flag asset
        /// </summary>
        /// <param name="asset"> flag to be raised </param>
        public void Raise(FlagAsset asset)
        {
            if (!flagDictionary.ContainsKey(asset)) return;
            if (flagDictionary[asset].State == FlagState.Raise) return;

            flagDictionary[asset].State = FlagState.Raise;
        }

        /// <summary>
        /// Lower a flag asset
        /// </summary>
        /// <param name="asset"> flag to be lowered </param>
        public void Lower(FlagAsset asset)
        {
            if (!flagDictionary.ContainsKey(asset)) return;
            if (flagDictionary[asset].State == FlagState.Lower) return;

            flagDictionary[asset].State = FlagState.Lower;
        }

        /// <summary>
        /// Create an event listener to specific flag
        /// </summary>
        /// <param name="asset"> flag reference asset </param>
        /// <param name="raiseEvent"> raise event after flag raised </param>
        /// <param name="lowerEvent"> lower event after flag lowered </param>
        public void AddListening(FlagAsset asset, UnityEvent raiseEvent, UnityEvent lowerEvent)
        {
            var flagObject = new FlagEventObject(FlagState.None, raiseEvent, lowerEvent);
            flagDictionary.Add(asset, flagObject);
        }

        /// <summary>
        /// Create an action listener to specific flag
        /// </summary>
        /// <param name="asset"> flag reference asset </param>
        /// <param name="raiseEvent"> raise action after flag raised </param>
        /// <param name="lowerEvent"> lower action after flag lowered </param>
        public void AddListening(FlagAsset asset, UnityAction raiseEvent, UnityAction lowerEvent)
        {
            var flagObject = new FlagActionObject(FlagState.None, raiseEvent, lowerEvent);
            flagDictionary.Add(asset, flagObject);
        }

        /// <summary>
        /// Remove all listenings from the asset
        /// </summary>
        /// <param name="asset"> flag asset to remove all listenings </param>
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
            set
            {
                state = value;

                if (state == FlagState.Raise)
                {
                    Raise();
                }
                else if (state == FlagState.Lower)
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