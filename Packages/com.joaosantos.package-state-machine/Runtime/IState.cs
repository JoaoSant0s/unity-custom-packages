using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    public interface IState
    {
        void OnBeging();

        void OnUpdate();

        void LateUpdate();

        void FixedUpdate();

        void OnFinish();
    }
}
