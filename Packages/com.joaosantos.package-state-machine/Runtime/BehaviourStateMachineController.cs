/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public abstract class BehaviourStateMachineController<T> : MonoBehaviour where T : BehaviourStateMachineController<T>
    {
        [Header("State Machine Controller")]
        [SerializeField]
        protected bool showDebug = true;
        public string CurrentStateName => currentState?.GetType().Name;

        protected BehaviourState<T> currentState;

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="state"> the next state object</param>
        /// <param name="jumpLastState"> Jump "OnFinish()" execution of the last state</param>
        public void ChangeState(BehaviourState<T> state, bool jumpLastState = false)
        {
            if (state == null || currentState?.GetType() == state.GetType()) return;

            if (currentState != null && !jumpLastState)
            {
                currentState.OnFinish();
            }

            if (showDebug)
            {
                Debug.Log($"Change --- {currentState} --- {state}");
            }

            currentState = state;

            currentState.OnBeging();
        }

        protected void Update()
        {
            currentState.OnUpdate();
        }
        protected void LateUpdate()
        {
            currentState.OnLateUpdate();
        }

        protected void FixedUpdate()
        {
            currentState.OnFixedUpdate();
        }
    }
}
