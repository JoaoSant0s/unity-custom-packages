/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.StateMachine
{
    [Flags]
    public enum BehaviourComponentTypes
    {
        None = 0,
        FixedUpdate = 1 << 0,
        Update = 1 << 1,
        LateUpdate = 1 << 2
    }

    public abstract class BehaviourStateMachine<T> : MonoBehaviour where T : BehaviourStateMachine<T>
    {
        [Header("State Machine")]
        [SerializeField]
        protected bool showDebug = true;

        [SerializeField]
        protected BehaviourComponentTypes supportedTypes = BehaviourComponentTypes.Update;

        public string CurrentStateName => currentState?.GetType().Name;

        protected BehaviourState<T> currentState;
        //private Dictionary<BehaviourComponentTypes, BehaviourStateMachineComponent> components = new();

        /// <summary>
        /// Make the current state machine go to the next state
        /// </summary>
        /// <param name="state"> the next state object</param>
        /// <param name="finishPreviousState"> Call "OnFinish()" execution of the previous state</param>
        public void ChangeState(BehaviourState<T> state, bool finishPreviousState = true)
        {
            if (state == null || currentState?.GetType() == state.GetType()) return;

            if (currentState != null && finishPreviousState) currentState.OnFinish();

            if (showDebug) Debug.Log($"Change --- {currentState} --- {state}");

            currentState = state;

            currentState.OnBeging();

            //foreach (var (_, component) in components)
            // {
            //    component.enabled = currentState.SupportedTypes.HasFlag(component.BehaviourComponentType);
            //    component.SetCurrentState(currentState);
            // }
        }

        protected virtual void Awake()
        {
            //components = GetComponents<BehaviourStateMachineComponent<T>>().ToDictionary(value => value.BehaviourComponentType, value => value);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Application.isPlaying) return;

            var updateComponent = gameObject.GetComponent<BehaviourStateMachineUpdateComponent>();
            var hasFlag = supportedTypes.HasFlag(BehaviourComponentTypes.Update);

            if (hasFlag && !updateComponent)
            {
                updateComponent = gameObject.AddComponent<BehaviourStateMachineUpdateComponent>();
                //components[BehaviourComponentTypes.Update] = updateComponent;
            }
            else if (!hasFlag && updateComponent)
            {
                UnityEditor.EditorApplication.delayCall += () => DestroyImmediate(updateComponent);
            }
        }
#endif        

        protected void Update()
        {
            currentState.OnUpdate();
        }
        protected void LateUpdate()
        {
            currentState.OnLateUpdate();
        }

        protected void FixedUpdate()
        {
            currentState.OnFixedUpdate();
        }
    }
}
