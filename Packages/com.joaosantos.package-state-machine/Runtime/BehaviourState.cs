/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;

namespace JoaoSant0s.StateMachine
{
    public abstract class BehaviourState<T> where T : BehaviourStateMachine<T>
    {
        protected T stateMachine;

        public abstract BehaviourComponentTypes SupportedTypes { get; }

        public BehaviourState(T controller)
        {
            this.stateMachine = controller;
        }

        public virtual void OnBeging() { }

        #region Update Functions

        public virtual void OnUpdate() { }

        public virtual void OnLateUpdate() { }

        public virtual void OnFixedUpdate() { }

        #endregion

        public virtual void OnFinish() { }

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="nextState"> the next state object</param>
        protected void ChangeState(BehaviourState<T> nextState)
        {
            this.stateMachine.ChangeState(nextState);
        }
    }
}
