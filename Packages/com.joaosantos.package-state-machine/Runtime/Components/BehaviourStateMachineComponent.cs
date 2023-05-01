/*
Copyright (c) 2023, JoaoSant0s

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public abstract class BehaviourStateMachineComponent<T> : MonoBehaviour where T : BehaviourStateMachineComponent<T>
    {
        public abstract BehaviourComponentTypes BehaviourComponentType { get; }
        //protected BehaviourState<T> currentState;

        //public void SetCurrentState(BehaviourState<T> state) => currentState = state;

        //private void OnValidate() => Debug.Assert(GetComponent<T>(), "This BehaviourStateMachine component must exist to Add this component");
    }
}