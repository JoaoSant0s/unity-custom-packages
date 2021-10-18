using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public class StateMachineController : MonoBehaviour
    {
        private IState currentState;
        public string CurrentStateName => currentState?.GetType().Name;

        public void ChangeState(IState state, bool jumpLastState = false)
        {
            if (state == null || currentState?.GetType() == state.GetType()) return;

            if (currentState != null && !jumpLastState)
            {
                currentState.OnFinish();
            }

            Debugs.Log("Change", currentState, state);

            currentState = state;

            currentState.OnBeging();
        }

        private void Update()
        {
            currentState.OnUpdate();
        }
    }
}
