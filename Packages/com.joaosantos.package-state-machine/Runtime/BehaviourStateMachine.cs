/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public abstract class BehaviourStateMachine<T> : MonoBehaviour where T : BehaviourStateMachine<T>
    {
        [Header("State Machine")]
        [SerializeField]
        protected bool showDebug = true;

        public string CurrentStateName => currentState?.GetType().Name;

        protected BehaviourState<T> currentState;

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="state"> the next state object</param>
        /// <param name="finishPreviousState"> Call "OnFinish()" execution of the previous state</param>
        public void ChangeState(BehaviourState<T> state, bool finishPreviousState = true)
        {
            if (state == null || currentState?.GetType() == state.GetType()) return;

            if (currentState != null && finishPreviousState) currentState.OnFinish();
            if (showDebug) Debug.Log($"Change --- {currentState} --- {state}");

            currentState = state;

            currentState.OnBeging();
        }

        private void Update()
        {
            currentState?.OnUpdate();
        }
    }
}
