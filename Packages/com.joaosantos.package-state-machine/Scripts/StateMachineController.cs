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

        protected virtual void Update()
        {
            currentState.OnUpdate();
        }
    }
}
