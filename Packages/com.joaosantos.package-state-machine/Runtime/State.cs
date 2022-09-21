/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

namespace JoaoSant0s.StateMachine
{
    public abstract partial class State<T> where T: StateMachineController<T>
    {
        protected T machineController;

        public State(T controller)
        {
            this.machineController = controller;
        }

        public abstract void OnBeging();

        public abstract void OnUpdate();

        public abstract void OnLateUpdate();

        public abstract void OnFixedUpdate();

        public abstract void OnFinish();

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="nextState"> the next state object</param>
        protected void ChangeState(State<T> nextState)
        {
            this.machineController.ChangeState(nextState);
        }
    }
}
