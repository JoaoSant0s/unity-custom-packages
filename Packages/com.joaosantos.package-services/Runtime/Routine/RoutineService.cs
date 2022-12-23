/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Routine
{
    public enum WaitRoutineOptions
    {
        None,
        SkipFrame,
        EndOfFrame,
        FixedUpdate
    }

    public class RoutineService : Service
    {

        #region Override Methods

        public override void OnInit() { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create a coroutine after a specific time to execute a action
        /// </summary>
        /// <param name="delayTime"> delay to execute the action </param>
        /// <param name="action"> the action to execute after the time </param>
        /// <param name="beginOption"> the optional extra delay before the routine start </param>
        public Coroutine WaitTimeThenDo(float delayTime, UnityAction action, WaitRoutineOptions beginOption = WaitRoutineOptions.None)
        {
            return StartCoroutine(WaitTimeThenDoRoutine(delayTime, action, beginOption));
        }

        /// <summary>
        /// Create a coroutine that execute a action after a condition be true
        /// </summary>
        /// <param name="checkCondition"> the condition to be checked </param>
        /// <param name="action"> the action to execute after the time </param>
        /// <param name="beginOption"> the optional extra delay before the routine start </param>
        public Coroutine WaitUntilThenDo(Func<bool> checkCondition, UnityAction action, WaitRoutineOptions beginOption = WaitRoutineOptions.None)
        {
            return StartCoroutine(WaitUntilThenDoRoutine(checkCondition, action, beginOption));
        }

        /// <summary>
        /// Create a coroutine that executes an action and stops when achieving a condition. The next execution will be after an interval of time
        /// </summary>
        /// <param name="action"> the action to execute </param>
        /// <param name="checkCondition"> the condition to be checked </param>
        /// <param name="intervalTime"> interval to execute the next action </param>
        /// <param name="beginOption"> the optional extra delay before the routine start </param>
        public Coroutine RepeatActionUntilDuringIntervalTime(UnityAction action, Func<bool> checkCondition, float intervalTime, WaitRoutineOptions beginOption = WaitRoutineOptions.None)
        {
            return StartCoroutine(RepeatActionUntilDuringIntervalTimeRoutine(action, checkCondition, intervalTime, beginOption));
        }

        /// <summary>
        /// Stop a Coroutine genereted
        /// </summary>
        /// <param name="coroutine"> the coroutine generated by this service </param>
        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }


        /// <summary>
        /// Stop All Coroutines genereted
        /// </summary>
        public void StopAll()
        {
            StopAllCoroutines();
        }

        #endregion

        #region Private Methods
        private IEnumerator WaitTimeThenDoRoutine(float delayTime, UnityAction action, WaitRoutineOptions beginOption)
        {
            yield return SelectOptionRoutine(beginOption);
            yield return new WaitForSeconds(delayTime);
            action?.Invoke();
        }

        private IEnumerator WaitUntilThenDoRoutine(Func<bool> checkCondition, UnityAction action, WaitRoutineOptions beginOption)
        {
            yield return SelectOptionRoutine(beginOption);
            yield return new WaitUntil(checkCondition);
            action?.Invoke();
        }

        private IEnumerator RepeatActionUntilDuringIntervalTimeRoutine(UnityAction action, Func<bool> checkCondition, float intervalTime, WaitRoutineOptions beginOption)
        {
            yield return SelectOptionRoutine(beginOption);
            while (true)
            {
                action?.Invoke();
                if (checkCondition()) yield break;
                yield return new WaitForSeconds(intervalTime);
            }
        }

        private IEnumerator SelectOptionRoutine(WaitRoutineOptions option)
        {
            switch (option)
            {
                case WaitRoutineOptions.EndOfFrame:
                    yield return new WaitForEndOfFrame();
                    break;
                case WaitRoutineOptions.FixedUpdate:
                    yield return new WaitForFixedUpdate();
                    break;
                case WaitRoutineOptions.SkipFrame:
                    yield return null;
                    break;
            }
        }

        #endregion
    }
}