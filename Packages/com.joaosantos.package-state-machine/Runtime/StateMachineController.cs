using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public class StateMachineController : MonoBehaviour
    {
        [SerializeField]
        private bool showDebug = true;
        public string CurrentStateName => currentState?.GetType().Name;

        private IState currentState;

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="state"> the next state object</param>
        /// <param name="jumpLastState"> Jump "OnFinish()" execution of the last state</param>
        public void ChangeState(IState state, bool jumpLastState = false)
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

        /// <summary>
        /// Running the Update method of the current state using the MonoBehaviour Update method
        /// </summary>
        protected virtual void Update()
        {
            currentState.OnUpdate();
        }

        /// <summary>
        /// Running the LateUpdate method of the current state using the MonoBehaviour LateUpdate method
        /// </summary>
        protected virtual void LateUpdate()
        {
            currentState.LateUpdate();
        }

        /// <summary>
        /// Running the FixedUpdate method of the current state using the MonoBehaviour FixedUpdate method
        /// </summary>
        protected virtual void FixedUpdate()
        {
            currentState.FixedUpdate();
        }
    }
}
