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
        protected readonly Dictionary<FlagAsset, FlagObject> flagDictionary = new();

        #region Override Methods

        public override void OnInit() { }

        #endregion

        /// <summary>
        /// Return the State of the flag asset. If was not used yet, will return the state Nono
        /// </summary>
        /// <param name="asset"> flag to be verifyed</param>
        public FlagState GetState(FlagAsset asset)
        {
            InitFlagObject(asset);
            return flagDictionary[asset].State;
        }

        /// <summary>
        /// Raise a flag asset
        /// </summary>
        /// <param name="asset"> flag to be raised </param>
        public void Raise(FlagAsset asset)
        {
            InitFlagObject(asset);
            if (flagDictionary[asset].State == FlagState.Raise) return;

            flagDictionary[asset].SetState(FlagState.Raise);
        }

        /// <summary>
        /// Lower a flag asset
        /// </summary>
        /// <param name="asset"> flag to be lowered </param>
        public void Lower(FlagAsset asset)
        {
            InitFlagObject(asset);
            if (flagDictionary[asset].State == FlagState.Lower) return;

            flagDictionary[asset].SetState(FlagState.Lower);
        }

        /// <summary>
        /// Create an action listener to specific flag
        /// </summary>
        /// <param name="asset"> flag reference asset </param>
        /// <param name="raiseEvent"> raise action after flag raised </param>
        /// <param name="lowerEvent"> lower action after flag lowered </param>
        public void AddListening(FlagAsset asset, FlagAction action)
        {
            InitFlagObject(asset);

            flagDictionary[asset].AddAction(action);
        }

        /// <summary>
        /// Remove all listenings from the asset
        /// </summary>
        /// <param name="asset"> flag asset to remove all listenings </param>
        public void RemoveListening(FlagAsset asset, FlagAction action)
        {
            if (!flagDictionary.ContainsKey(asset)) return;

            flagDictionary[asset].RemoveAction(action);
        }

        private void InitFlagObject(FlagAsset asset)
        {
            if (flagDictionary.ContainsKey(asset)) return;
            flagDictionary.Add(asset, new FlagObject(FlagState.None));
        }
    }

    [Serializable]
    public class FlagObject
    {
        protected List<FlagAction> flagActions;

        public FlagState State { get; protected set; }

        public FlagObject(FlagState state)
        {
            flagActions = new();
            SetState(state);
        }

        internal void AddAction(FlagAction action)
        {
            flagActions.Add(action);
        }

        internal void RemoveAction(FlagAction action)
        {
            flagActions.Remove(action);
        }

        internal void SetState(FlagState state)
        {
            State = state;
            if (State == FlagState.Raise)
            {
                Raise();
            }
            else if (State == FlagState.Lower)
            {
                Lower();
            }
        }

        protected void Raise()
        {
            for (int i = flagActions.Count - 1; i >= 0; i--)
            {
                flagActions[i].Raise();
            }
        }

        protected void Lower()
        {
            for (int i = flagActions.Count - 1; i >= 0; i--)
            {
                flagActions[i].Lower();
            }
        }
    }

    public interface FlagAction
    {
        public void Raise();

        public void Lower();
    }

    [Serializable]
    public class FlagEventObject : FlagAction
    {
        public UnityEvent raiseEvent;
        public UnityEvent lowerEvent;

        public FlagEventObject(UnityEvent raiseEvent, UnityEvent lowerEvent)
        {
            this.raiseEvent = raiseEvent;
            this.lowerEvent = lowerEvent;
        }

        public void Raise()
        {
            this.raiseEvent?.Invoke();
        }

        public void Lower()
        {
            this.lowerEvent?.Invoke();
        }
    }

    [Serializable]
    public class FlagActionObject : FlagAction
    {
        public UnityAction raiseAction;
        public UnityAction lowerAction;

        public FlagActionObject(UnityAction raiseAction, UnityAction lowerAction)
        {
            this.raiseAction = raiseAction;
            this.lowerAction = lowerAction;
        }

        public void Raise()
        {
            this.raiseAction?.Invoke();
        }

        public void Lower()
        {
            this.lowerAction?.Invoke();
        }
    }
}