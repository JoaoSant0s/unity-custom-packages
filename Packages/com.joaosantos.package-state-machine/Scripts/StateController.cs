using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.StateMachine
{
    public class StateController
    {
        protected StateMachineController machineController;
        public StateController(StateMachineController controller)
        {
            this.machineController = controller;
        }
        protected void ChangeState(IState nextState)
        {
            this.machineController.ChangeState(nextState);
        }

    }
}
