using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public class StateController
    {
        protected StateMachineController machineController;

        public StateController(StateMachineController controller)
        {
            this.machineController = controller;
        }

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="nextState"> the next state object</param>
        protected void ChangeState(IState nextState)
        {
            this.machineController.ChangeState(nextState);
        }

    }
}
