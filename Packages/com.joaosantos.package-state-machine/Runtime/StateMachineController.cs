using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public abstract partial class StateMachineController<T> : MonoBehaviour where T : StateMachineController<T>
    {
        [Header("State Machine Controller")]
        [SerializeField]
        private bool showDebug = true;
        public string CurrentStateName => currentState?.GetType().Name;

        private State<T> currentState;

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="state"> the next state object</param>
        /// <param name="jumpLastState"> Jump "OnFinish()" execution of the last state</param>
        public void ChangeState(State<T> state, bool jumpLastState = false)
        {
            if (state == null || currentState?.GetType() == state.GetType()) return;

            if (currentState != null && !jumpLastState)
            {
                currentState.OnFinish();
            }

            if (showDebug)
            {
                Debug.Log(string.Format("Change --- {0} --- {1}", currentState, state));
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
