using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.StateMachine;

public class State2 : BehaviourState<TesteStateMachine>
{
    public override BehaviourComponentTypes SupportedTypes => BehaviourComponentTypes.Update;

    public State2(TesteStateMachine controller) : base(controller) { }

    #region Public Implemented Methods

    public override void OnBeging()
    {
        Debug.Log("OnBeging State2");
        this.stateMachine.StartCoroutine(ChangeState());
    }

    public override void OnFixedUpdate() { }
    public override void OnLateUpdate() { }
    public override void OnUpdate() { }

    public override void OnFinish()
    {
        Debug.Log("OnFinish State2");
    }

    #endregion

    #region Private methods

    private IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(3f);
        ChangeState(new State1(this.stateMachine));
    }

    #endregion
}

