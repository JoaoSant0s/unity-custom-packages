using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.StateMachine;

public class TesteStateMachine : BehaviourStateMachine<TesteStateMachine>
{
    private void Start()
    {
        ChangeState(new State1(this));
    }
}

