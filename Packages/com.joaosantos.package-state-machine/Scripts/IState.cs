using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.StateMachine
{
    public interface IState
    {                
        void OnBeging();

        void OnUpdate();        

        void OnFinish();
    }
}
