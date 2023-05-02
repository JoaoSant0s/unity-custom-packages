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

        protected BehaviourState(T controller) => this.stateMachine = controller;

        public abstract void OnBeging();
        public virtual void OnUpdate() { }
        public abstract void OnFinish();

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
