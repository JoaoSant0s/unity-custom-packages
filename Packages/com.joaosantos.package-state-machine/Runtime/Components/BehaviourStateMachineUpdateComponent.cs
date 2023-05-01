/*
Copyright (c) 2023, JoaoSant0s
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public class BehaviourStateMachineUpdateComponent : BehaviourStateMachineComponent<BehaviourStateMachineUpdateComponent>
    {
        public override BehaviourComponentTypes BehaviourComponentType => BehaviourComponentTypes.Update;

        //private void Update() => currentState?.OnUpdate();
    }
}