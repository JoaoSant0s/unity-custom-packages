using System;
using System.Collections;
using System.Collections.Generic;
using JoaoSant0s.StateMachine;
using UnityEngine;

public class State1 : BehaviourState<TesteStateMachine>
{
    public State1(TesteStateMachine controller) : base(controller) { }

    #region Public Implemented Methods

    public override void OnBeging()
    {
        Debug.Log("OnBeging State1");
        this.stateMachine.StartCoroutine(ChangeState());
    }

    public override void OnUpdate()
    {
        Debug.Log("OnUpdate State1");
    }

    public override void OnFinish()
    {
        Debug.Log("OnFinish State1");
    }

    #endregion

    #region Private methods

    private IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(3f);
        ChangeState(new State2(this.stateMachine));
    }

    #endregion

}

